using System;
using System.Collections.Generic;
using System.Text;
using NationalInstruments.DAQmx;
using RRLab.PhysiologyData;

namespace RRLab.PhysiologyWorkbench.Devices
{
    /// <summary>
    /// Controls a device connected to a DAQ DO line which is on when the line is at +5V and off when it is at 0V
    /// </summary>
    [Serializable]
    public class SwitchDevice : Device
    {
        /// <summary>
		/// This event is fired when the switch is toggled.
		/// </summary>
        [field: NonSerialized]
		public event EventHandler SwitchToggled;

        public SwitchDevice()
        {
            Name = "Switch";
        }
		/// <summary>
		/// Creates a new SwitchDevice with the given properties.
		/// </summary>
		public SwitchDevice(string switchLine) : this(switchLine,null) 
		{}
		/// <summary>
		/// Creates a new SwitchDevice with the given properties.
		/// </summary>
		public SwitchDevice(string switchLine, string name)
		{
            this.Line = switchLine;
            this.Name = Name ?? "Switch";
		}

		#region Methods

        public override void InitializeDevice()
        {
            try
            {
                if (IsSwitchOffByDefault) SwitchOff();
                else SwitchOn();
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine("Could not initialize device: " + x.Message);
            }

            base.InitializeDevice();
        }
        public override void FinalizeDevice()
        {
            try
            {
                if (IsSwitchOffByDefault) SwitchOff();
                else SwitchOn();
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine("Could not initialize device: " + x.Message);
            }

            base.FinalizeDevice();
        }

        public void AnnotateEquipmentData(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.RecordingsRow recording)
        {
            recording.AddEquipmentSetting(String.Format("{0}-Line", Name), Line);
        }

		/// <summary>
		/// Turns on the device
		/// </summary>
		public void SwitchOn() 
		{
			WriteSampleToLine("SwitchOn", Line, "Line", true);
			IsSwitchOn = false;
		}
		/// <summary>
		/// Turns off the device
		/// </summary>
		public void SwitchOff() 
		{
			WriteSampleToLine("SwitchOff", Line, "Line", false);
			IsSwitchOn = true;
		}

        /// <summary>
        /// Generates DAQ output that will toggle on the switch after a delay for a given duration, then turn it back off
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="outputLength"></param>
        /// <param name="switchDelay"></param>
        /// <param name="switchDuration"></param>
        /// <returns></returns>
        public virtual byte[] GenerateSwitchDaqOutput(int sampleRate, double outputLength, double switchDelay, double switchDuration)
        {
            return GenerateSwitchDaqOutput(sampleRate, outputLength, switchDelay, switchDuration, false);
        }
        /// <summary>
        /// Generates DAQ output that will toggle the switch after a delay for a given duration, then turn it back to its initial state
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="outputLength"></param>
        /// <param name="switchDelay"></param>
        /// <param name="switchDuration"></param>
        /// <param name="initialSwitchState"></param>
        /// <returns></returns>
        public virtual byte[] GenerateSwitchDaqOutput(int sampleRate, double outputLength, double switchDelay, double switchDuration, bool initialSwitchState)
        {
            // Validate parameters
            if (switchDelay + switchDuration > outputLength) throw new ArgumentException("outputLength", "Output length is shorter than the switch delay and duration.");

            // Determine number of samples to output
            int nsamples = Convert.ToInt32(outputLength * ((double)sampleRate / 1000));
            if (Math.IEEERemainder(nsamples, 2) != 0) nsamples++;
            int preSwitchSamples = Convert.ToInt32(switchDelay * ((double)sampleRate / 1000));

            // Figure out which bits to write to
            int switchBit = ConvertAddressToBit(Line);

            // Prepare output bytes
            byte preSwitchByte;
            byte switchByte;
            byte postSwitchByte;

            System.Collections.BitArray bits = new System.Collections.BitArray(8);
            // Preflash
            bits.SetAll(false);
            bits[switchBit] = initialSwitchState;
            preSwitchByte = ConvertBitArrayToByte(bits);

            // Flash
            bits.SetAll(false);
            bits[switchBit] = !initialSwitchState;
            switchByte = ConvertBitArrayToByte(bits);

            // PostFlash
            bits.SetAll(false);
            bits[switchBit] = initialSwitchState;
            //bits[intTriggerBit] = true;
            postSwitchByte = ConvertBitArrayToByte(bits);

            // Make output array
            byte[] output = new byte[nsamples];
            for (int i = 0; i < preSwitchSamples; i++)
                output[i] = preSwitchByte;
            output[preSwitchSamples] = switchByte;
            for (int i = preSwitchSamples + 1; i < nsamples; i++)
                output[i] = postSwitchByte;

            return output;
        }


		/// <summary>
		/// Writes two samples to a digital line with software timing.
		/// </summary>
		protected void WriteSampleToLine(string taskName, string line, string lineName, bool sample) 
		{
			Task task = null;
			try 
			{
				// Create task
				task = new Task(taskName);

				// Add OpenLine to the channels
				task.DOChannels.CreateChannel(line,lineName,ChannelLineGrouping.OneChannelForEachLine);
				// Use software timing
				task.Control(TaskAction.Verify); // Verify task

				// Generate the writer and write { true, false } to the line to open the shutter
				DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(task.Stream);
				writer.WriteSingleSampleSingleLine(true,sample);
			} 
			catch(DaqException e) 
			{
				System.Windows.Forms.MessageBox.Show("Shutter Error: " + e.Message);
			}
			finally 
			{
				// Dispose of the task
				if(task!=null) task.Dispose();
			}
		}
		#endregion

		#region Properties
        public event EventHandler LineChanged;
		private string _Line;
		/// <summary>
		/// The DAQmx address of the line.
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public string Line
		{
			get { return _Line; }
			set {
                _Line = value;
                if (LineChanged != null) LineChanged(this, EventArgs.Empty);
            }
		}


        private bool _IsSwitchOffByDefault = true;

        public bool IsSwitchOffByDefault
        {
            get { return _IsSwitchOffByDefault; }
            set { _IsSwitchOffByDefault = value; }
        }
	

        public event EventHandler IsSwitchOnChanged;
        private bool _IsSwitchOn = false;
        public bool IsSwitchOn
        {
            get
            {
                return _IsSwitchOn;
            }
            protected set
            {
                _IsSwitchOn = value;
                if (IsSwitchOnChanged != null) IsSwitchOnChanged(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}
