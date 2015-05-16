using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench.Devices
{
    [Serializable]
    public class Photodiode : Device
    {
        private string _IntensityAI;

        public string IntensityAI
        {
            get { return _IntensityAI; }
            set {
                _IntensityAI = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }

        private double _Gain;
        public double Gain
        {
            get { return _Gain; }
            set {
                _Gain = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }

        private string _FilterInformation;

        public string FilterInformation
        {
            get { return _FilterInformation; }
            set {
                _FilterInformation = value;
                FireDeviceSettingsChanged(this, EventArgs.Empty);
            }
        }
	
	
	
        public Photodiode()
        {
            Name = "Photodiode";
        }
    }
}
