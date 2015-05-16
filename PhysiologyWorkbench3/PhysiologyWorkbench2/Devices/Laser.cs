using System;
using NationalInstruments.DAQmx;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Devices
{
	/// <summary>
	/// This class provides methods for interacting with a SpectraPhysics nitrogen laser.
	/// </summary>
    [Serializable]
	public class SpectraPhysicsNitrogenLaser : RRLab.PhysiologyWorkbench.Devices.Device
	{
		
		// Fields
		private String triggerDO, burstDO, optosyncPFI; // The device address for the trigger output, burst output, and optosync input wires on the DAQ.
		[NonSerialized] private DOChannel triggerChannel, burstChannel; // DO channels for the trigger and burst lines

        private float _MinimumChargingTime = 15;

        public float MinimumChargingTime
        {
            get { return _MinimumChargingTime; }
            set {
                _MinimumChargingTime = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }
	

        private string _InternalTriggerPFI;

        public string InternalTriggerPFI
        {
            get { return _InternalTriggerPFI; }
            set {
                _InternalTriggerPFI = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }
	

        private string _InternalTriggerDO;

        public string InternalTriggerDO
        {
            get { return _InternalTriggerDO; }
            set {
                _InternalTriggerDO = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }
	


        public SpectraPhysicsNitrogenLaser()
        {
            Name = "SpectraPhysics Nitrogen Laser";
            Wavelength = 0;
        }

		// Constructors
		/// <summary>
		/// Generates a SpectraPhysicsNitrogenLaser with the given information.
		/// </summary>
		/// <param genotype="TriggerDO">The DAQmx address for the TriggerDO line.</param>
		/// <param genotype="BurstDO">The DAQmx address for the BurstDO line.</param>
		/// <param genotype="OptosyncPFI">The DAQmx address for the OptosyncPFI trigger.</param>
		/// <param genotype="PowerAI">The DAQmx address for the Laser Power AI.</param>
		/// <param genotype="PowerMin">The minimum input voltage for PowerAI.</param>
		/// <param genotype="PowerMax">The maximum input voltage for PowerAI.</param>
		/// <param genotype="Wavelength">The wavelength (in nm) of this laser.</param>
		public SpectraPhysicsNitrogenLaser(string TriggerDO, string BurstDO, string OptosyncPFI, string PowerAI, int PowerMin, int PowerMax, int Wavelength)
		{
			// Store parameters
			this.triggerDO = TriggerDO;
			this.burstDO = BurstDO;
			this.optosyncPFI = OptosyncPFI;
			this.Wavelength = Wavelength;
			this.PowerAI = PowerAI;
			this.PowerMin = PowerMin;
			this.PowerMax = PowerMax;

            Name = "SpectraPhysics Nitrogen Laser (" + Wavelength.ToString() + " nm)";
		}

		// Methods

        public virtual void AnnotateEquipmentData(PhysiologyDataSet.RecordingsRow recording)
        {
            recording.SetEquipmentSetting(Name + "-Wavelength", Wavelength.ToString());
        }


		/// <summary>
		/// Fires the laser with a given frequency for a particular length of time.
		/// </summary>
		/// <param genotype="hz">The frequency to fire the laser (in Hz).</param>
		/// <param genotype="t">The length of time to fire the laser (in ms).</param>
		/// <param genotype="sampleRate">The sampling rate to use (in Hz).</param>
		/// <param genotype="clock">The DAQmx address of the sample clock to use.</param>
		/// <param genotype="clockEdge">The clock edge to use.</param>
		public void FireLaserContinuously(int hz, int t, int sampleRate, String clock, SampleClockActiveEdge clockEdge) 
		{
			int nSamplesToWrite = (int) (((double) sampleRate) * ((double) t)/1000); // samples/s * ms*(1s/1000ms)

			// Create Task object
			Task task = new Task("FireLaserContinuously");
			try 
			{
				// Create channels
				DOChannel burstChannel = task.DOChannels.CreateChannel(this.BurstDO, "Burst", ChannelLineGrouping.OneChannelForEachLine);
				DOChannel triggerChannel = task.DOChannels.CreateChannel(this.TriggerDO, "Trigger", ChannelLineGrouping.OneChannelForEachLine);
				// Configure sample clock
				task.Timing.ConfigureSampleClock(clock,sampleRate,clockEdge,SampleQuantityMode.FiniteSamples,nSamplesToWrite);
				task.Stream.WriteRegenerationMode = WriteRegenerationMode.AllowRegeneration;
			
				// Verify task settings
				task.Control(TaskAction.Verify);

				// Generate buffers
				int nSamplesWaveform = sampleRate/hz; // samples/s * 1/Hz s
				bool[] trigger = new bool[nSamplesWaveform];
				bool[] burst = new bool[nSamplesWaveform];
				int burstPretriggerDelaySamples = 15/1000*sampleRate; // 15 ms * 1s/1000ms * samples/s
				// Check to make sure there's not an error
				if(burstPretriggerDelaySamples>nSamplesWaveform) throw new ArgumentException("Frequency too fast. Interval must be at least 15 ms.","hz");
				for(int i=0; i<burstPretriggerDelaySamples; i++) // While recharging the power cell
				{
					trigger[i] = false; // trigger off
					burst[i] = false; // burst low
				}
				trigger[burstPretriggerDelaySamples] = true; // trigger on
				burst[burstPretriggerDelaySamples] = false; // burst low
				for(int i=burstPretriggerDelaySamples+1; i<nSamplesWaveform; i++) 
				{
					trigger[i] = false; // trigger off
					burst[i] = true; // burst high
				}

				// Write the buffers to the channels
				DigitalMultiChannelWriter doWriter = new DigitalMultiChannelWriter(task.Stream);
				for(int i=0; i<nSamplesWaveform; i++) 
				{
					doWriter.WriteSingleSampleSingleLine(false,new bool[] {burst[i],trigger[i]});
				}

				task.Start();

				// Dispose task
				task.Dispose();
				task = null;
			} 
			catch(DaqException e) {
				System.Windows.Forms.MessageBox.Show(e.Message);
				if(task != null) task.Dispose();
			}
		}

        public virtual byte[] GenerateLaserFlashDaqOutput(int SampleRate, double OutputLength, double FlashDelay)
        {
            // Determine number of samples to output
            int nsamples = Convert.ToInt32(OutputLength * ((double) SampleRate / 1000));
            if (Math.IEEERemainder(nsamples, 2) != 0) nsamples++;
            int preFlashSamples = Convert.ToInt32(FlashDelay * ((double) SampleRate / 1000));

            // Check for minimum charging time
            int burstChargeSamples = Convert.ToInt32(MinimumChargingTime * SampleRate / 1000); // Minimum 15ms charging time
            if (preFlashSamples < burstChargeSamples) throw new ApplicationException("The laser must charge for at least " + MinimumChargingTime.ToString() + " ms between flashes.");

            // Figure out which bits to write to
            int triggerBit = ConvertAddressToBit(TriggerDO);
            int burstBit = ConvertAddressToBit(BurstDO);
            int intTriggerBit = ConvertAddressToBit(InternalTriggerDO);

            // Prepare output bytes
            byte preFlashByte;
            byte flashByte;
            byte postFlashByte;

            System.Collections.BitArray bits = new System.Collections.BitArray(8);
            // Preflash
            bits.SetAll(false);
            preFlashByte = ConvertBitArrayToByte(bits);

            // Flash
            bits.SetAll(false);
            bits[triggerBit] = true;
            bits[intTriggerBit] = true;
            flashByte = ConvertBitArrayToByte(bits);

            // PostFlash
            bits.SetAll(false);
            bits[burstBit] = true;
            //bits[intTriggerBit] = true;
            postFlashByte = ConvertBitArrayToByte(bits);

            // Make output array
            byte[] output = new byte[nsamples];
            for (int i = 0; i < preFlashSamples; i++)
                output[i] = preFlashByte;
            output[preFlashSamples] = flashByte;
            for (int i = preFlashSamples + 1; i < nsamples; i++)
                output[i] = postFlashByte;

            return output;
        }

        

        public void FireLaserOnce()
        {
            FireLaserOnce(DeviceSettings.Default.DefaultSamplingRate, DeviceSettings.Default.DefaultSampleClock, DeviceSettings.Default.DefaultSampleClockActiveEdge);
        }

		/// <summary>
		/// Fires the laser once.
		/// </summary>
		/// <param genotype="sampleRate">The sampling rate to use (in Hz).</param>
		/// <param genotype="clock">The DAQmx address of the sample clock to use.</param>
		/// <param genotype="clockEdge">The clock edge to use.</param>
		public void FireLaserOnce(int sampleRate, String clock, SampleClockActiveEdge clockEdge) 
		{
            Task t = null;
            try
            {
                t = new Task("LaserFlash");
                t.DOChannels.CreateChannel("/dev2/port0", "Lasers", ChannelLineGrouping.OneChannelForAllLines);

                byte[] output = GenerateLaserFlashDaqOutput(10000, 250, MinimumChargingTime);

                t.Timing.ConfigureSampleClock("", 10000, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, output.Length * 10);

                t.Control(TaskAction.Verify);

                DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(t.Stream);
                //writer.WriteSingleSampleSingleLine(true, true);


                t.Stream.WriteRegenerationMode = WriteRegenerationMode.AllowRegeneration;
                writer.WriteMultiSamplePort(false, output);

                t.Start();
                t.WaitUntilDone();

                
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error firing laser: " + e.Message);
            }
            finally
            {
                t.Dispose();
            }
		}

		/// <summary>
		/// <c>CreateChannels(Task task)</c> generates the laser channels within the
		///	given Task <c>task</c>.
		/// </summary>
		/// <param genotype="task">The task to generate the channels within.</param>
		protected void CreateChannels(Task task) 
		{
			this.TriggerChannel = task.DOChannels.CreateChannel(this.TriggerDO,"Trigger",ChannelLineGrouping.OneChannelForEachLine);
			this.BurstChannel = task.DOChannels.CreateChannel(this.BurstDO,"Burst",ChannelLineGrouping.OneChannelForEachLine);

			// TODO: Add code for configuring the channels, if necessary
		}
		
		/// <summary>
		/// <c>DisposeOfChannels()</c> frees up the dataName variables created in
		///	<c>CreateChannels(Task task)</c>. This method should be called when the
		///	channels are no longer in use, or if a different Task needs channels to be made.
		/// </summary>
		protected void DisposeOfChannels() 
		{
			triggerChannel = null;
			burstChannel = null;
		}

		/// <summary>
		/// Returns [Name] ([Wavelength] nm).
		/// </summary>
		/// <returns>[Name] ([Wavelength] nm)</returns>
		public override string ToString()
		{
			return this.Name + "(" + this.Wavelength + "nm)";
		}


		// Properties
		/// <summary>
		/// The dataName for TriggerDO.
		/// </summary>
		protected DOChannel TriggerChannel 
		{
			get 
			{
				return triggerChannel;
			}
			set 
			{
				triggerChannel = value;
			}
		}
		/// <summary>
		/// The dataName for BurstDO.
		/// </summary>
		protected DOChannel BurstChannel 
		{
			get 
			{
				return burstChannel;
			}
			set 
			{
				burstChannel = value;
			}
		}
		/// <summary>
		/// The DAQmx address of the TriggerDO line.
		/// </summary>
		public String TriggerDO
		{
			get
			{
				return triggerDO;
			}
			set
			{
				triggerDO = value;
			}
		}
		/// <summary>
		/// The DAQmx address of the BurstDO line.
		/// </summary>
		public String BurstDO
		{
			get
			{
				return burstDO;
			}
			set
			{
				burstDO = value;
			}
		}
		private String _OptosyncPFI;
		/// <summary>
		/// The DAQmx address of the OptosyncPFI trigger.
		/// </summary>
		public String OptosyncPFI 
		{
			get 
			{
				return _OptosyncPFI;
			}
			set 
			{
				_OptosyncPFI = value;
			}
		}
		private int _Wavelength;
		/// <summary>
		/// The wavelength of the laser, in nm.
		/// </summary>
		public int Wavelength 
		{
			get { return _Wavelength; }
			set { _Wavelength = value; }
		}
		private string _PowerAI;
		/// <summary>
		/// The DAQmx address of the PowerAI.
		/// </summary>
		public string PowerAI 
		{
			get { return _PowerAI; }
			set { _PowerAI = value; }
		}
		private int _PowerMin;
		/// <summary>
		/// The minimum input voltage for PowerAI.
		/// </summary>
		public int PowerMin 
		{
			get { return _PowerMin; }
			set { _PowerMin = value; }
		}
		private int _PowerMax;
		/// <summary>
		/// The maximum input voltage for PowerAI.
		/// </summary>
		public int PowerMax 
		{
			get { return _PowerMax; }
			set { _PowerMax = value; }
		}
	}
}
