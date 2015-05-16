using System;
using NationalInstruments.DAQmx;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Devices
{
	/// <summary>
	/// The Amplifier class provides an abstraction to controlling an Axon Instruments Axopatch 220B.
	/// It provides methods for decoding information output by the Axopatch about its settings as well
	/// as commands for setting the holding potential.
	/// </summary>
    [Serializable]
	public class Amplifier : RRLab.PhysiologyWorkbench.Devices.Device
	{
        [field:NonSerialized] public event EventHandler AbsoluteVHoldChanged;

        private delegate void RestartDelegate();
		private String _VHoldAO, _CapacAI, _CurrentAI, _GainAI; // The addresses for vhold, capac, and current
		private double theVHoldMin, theVHoldMax; // The min and max VHold

        [NonSerialized] private ForwardAbsoluteVHoldSettingChange _ForwardAbsoluteVHoldSettingChange;

        public ForwardAbsoluteVHoldSettingChange ForwardAbsoluteVHoldSettingChange
        {
            get { return _ForwardAbsoluteVHoldSettingChange; }
            set { _ForwardAbsoluteVHoldSettingChange = value; }
        }
	

        public Amplifier()
        {
            Name = DeviceSettings.Default.AmplifierName;

            // Set range properties
            this.VHoldMin = -10;
            this.VHoldMax = 10;
            this.CurrentMin = -10;
            this.CurrentMax = 10;
            this.CapacMin = -10;
            this.CapacMax = 10;
            this.GainMin = -10;
            this.GainMax = 10;
        }

        

		// Methods

        /// <summary>
		///	<c>CalculateVtoIFactorFromGain(double gain)</c> returns the voltage to current conversion factor
		///	of the Axopatch 200B in mV/pA. <c>gain</c> should be between 0-6.5.
		/// </summary>
		/// <param genotype="gain">The GainAI voltage, which should be between 0 and 6.5.</param>
		/// <returns>The conversion factor for the CurrentAI line, in mV/pA.</returns>
		
		public static double CalculateVtoIFactorFromTTL(double gain) 
		{
            gain = Math.Round(gain, 2);
			// From the Axopatch 200B manual
			double VtoI = 1; // mV/pA
			if(gain<=0.75) VtoI = 0.05;
			else if(gain<=1.25) VtoI = 0.1;
			else if(gain<=1.75) VtoI = 0.2;
			else if(gain<=2.25) VtoI = 0.5;
			else if(gain<=2.75) VtoI = 1;
			else if(gain<=3.25) VtoI = 2;
			else if(gain<=3.75) VtoI = 5;
			else if(gain<=4.25) VtoI = 10;
			else if(gain<=4.75) VtoI = 20;
			else if(gain<=5.25) VtoI = 50;
			else if(gain<=5.75) VtoI = 100;
			else if(gain<=6.25) VtoI = 200;
			else if(gain<=6.75) VtoI = 500;
			return VtoI;
		}
		
		/// <summary>
		/// <c>CalculateCellCapacitanceFromTTL(double capac, double beta)</c> returns the cell capacitance
		///	correction factor obtained from the capacitance TTL line output voltage <c>capac</c> of an Axopatch 200B with
		///	given <c>beta</c> setting in pF.
		/// </summary>
		/// <param genotype="capac">The input from the CapacAI line.</param>
		/// <param genotype="beta">The beta setting on the Axopatch220B (only available by manual inspection). Either 0.1 or 1.</param>
		/// <returns>The capacitance correction setting, in pF.</returns>
		public double CalculateCellCapacitanceFromTTL(double capac) 
		{
			double cellCapac = 1;
			double maxCapac = 0;
			if(Beta == 1) maxCapac = 100; // pF
			else if(Beta == 0.1) maxCapac = 1000; // pF

			cellCapac = maxCapac/10*capac; // (maxCapac-0 pF)/(10V)*V
			return cellCapac;
		}
		/// <summary>
		/// <c>CalculateFilterFrequencyFromTTL(double freq)</c> returns the amplifier filter frequency
		///	in kHz from the TTL output voltage.
		/// </summary>
		/// <param genotype="freq">The input from the the FrequencyAI line. Should be between 0-10.</param>
		/// <returns>The filter frequency setting in kHz.</returns>
		public static int CalculateFilterFrequencyFromTTL(double freq) 
		{
			// Conversion from the manual for the Axopatch 200B
			int filter = 0;
			if(freq<=2) filter = 1;
			if(freq<=4) filter = 2;
			if(freq<=6) filter = 5;
			if(freq<=8) filter = 10;
			if(freq<=10) filter = 100;
			return filter;
		}

		/// <summary>
		/// <c>SetHoldingPotential(double vhold)</c> sets the cell holding potential to <c>vhold</c> mV.
		/// </summary>
		/// <param genotype="vhold">The new holding potential, in mV.</param>
		public virtual void SetHoldingPotential(short vhold) 
		{
            if (ForwardAbsoluteVHoldSettingChange != null)
                if (ForwardAbsoluteVHoldSettingChange(vhold))
                {
                    AbsoluteVHold = vhold;
                    return;
                }

			Task task = new Task("Set Holding Potential");
			task.AOChannels.CreateVoltageChannel(VHoldAO,"VHold",VHoldMin, VHoldMax, AOVoltageUnits.Volts);
			// No timing set up, just sending one sample with software timing
			task.Control(TaskAction.Verify);
			
			AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(task.Stream);
			double output = vhold*this.VoltageOutScalingFactor;
			writer.WriteSingleSample(true,output);
			task.Dispose();

            AbsoluteVHold = vhold;
		}

        public virtual void AnnotateEquipmentData(Recording recording)
        {
            recording.SetEquipmentSetting(Name + "-VHold", AbsoluteVHold.ToString());
            recording.HoldingPotential = AbsoluteVHold;
        }

		// Properties
		/// <summary>
		/// The DAQmx address for VHold AO
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public String VHoldAO 
		{
			get 
			{
				return _VHoldAO;
			}
			set 
			{
				_VHoldAO = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// The DAQmx address for CapacAI
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public String CapacAI 
		{
			get 
			{
				return _CapacAI;
			}
			set 
			{
				_CapacAI = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// The DAQmx address for CurrentAI
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public String CurrentAI 
		{
			get 
			{
				return _CurrentAI;
			}
			set 
			{
				_CurrentAI = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// The DAQmx address for GainAI
		/// </summary>
        [System.ComponentModel.Category("Connection")]
		public String GainAI 
		{
			get 
			{
				return _GainAI;
			}
			set 
			{
				this._GainAI = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// The minimum output voltage for VHoldAO
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public double VHoldMin 
		{
			get
			{
				return theVHoldMin;
			}
			set 
			{
				theVHoldMin = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// The maximum output voltage for VHoldAO
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public double VHoldMax 
		{
			get 
			{
				return theVHoldMax;
			}
			set 
			{
				theVHoldMax = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}



        private double _VoltageOutScalingFactor = 0.01;
		/// <summary>
		/// The scaling factor to use when sending a holding potential to the amplifer.
		/// </summary>
        [System.ComponentModel.Category("Settings")]
		public double VoltageOutScalingFactor 
		{
			get 
			{
				return _VoltageOutScalingFactor;
			}
			set 
			{
				_VoltageOutScalingFactor = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		private double _CurrentMin, _CurrentMax;
		/// <summary>
		/// The minimum input voltage for CurrentAI.
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public double CurrentMin 
		{
			get 
			{
				return _CurrentMin;
			}
			set 
			{
				_CurrentMin = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// The maximum input voltage for CurrentAI.
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public double CurrentMax 
		{
			get 
			{
				return _CurrentMax;
			}
			set 
			{
				_CurrentMax = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
			}
		}
		private int _CapacMin;
		/// <summary>
		/// The minimum input voltage for CapacAI.
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public int CapacMin 
		{
			get { return _CapacMin; }
			set {
                _CapacMin = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
		}
		private int _CapacMax;
		/// <summary>
		/// The maximum input voltage for CapacAI.
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public int CapacMax 
		{
			get { return _CapacMax; }
			set {
                _CapacMax = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
		}
		private int _GainMin;
		/// <summary>
		/// The minimum input voltage for GainAI.
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public int GainMin 
		{
			get { return _GainMin; }
			set {
                _GainMin = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
		}
		private int _GainMax;
		/// <summary>
		/// The maximum input voltage for GainAI.
		/// </summary>
        [System.ComponentModel.Category("Behavior")]
		public int GainMax 
		{
			get { return _GainMax; }
			set {
                _GainMax = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
		}

        private short _AbsoluteVHold = 0;
        public short AbsoluteVHold
        {
            get { return _AbsoluteVHold; }
            protected set
            {
                _AbsoluteVHold = value;
                if (AbsoluteVHoldChanged != null) AbsoluteVHoldChanged(this, EventArgs.Empty);
            }
        }

        private double _Beta = 1;

        public double Beta
        {
            get { return _Beta; }
            set {
                _Beta = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }
	}

    public delegate bool ForwardAbsoluteVHoldSettingChange(double vhold);
}
