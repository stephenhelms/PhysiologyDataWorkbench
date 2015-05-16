using System;
using System.ComponentModel;

namespace RRLab.PhysiologyWorkbench.Devices
{
	/// <summary>
	/// A generic class representing a device to be controlled by the Physiology Workbench software.
	/// Currently this class is not used for anything except recognizing that derived classes are Devices.
	/// </summary>
    [Serializable]
	public class Device
	{
        [field: NonSerialized]
        public event EventHandler DeviceSettingsChanged;

        private string _Name = "";
        [System.ComponentModel.Category("Information")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public override string ToString()
        {
            if ((Name == null) || (Name == "")) return "Unnamed Device";
            return Name;
        }

        protected void FireDeviceSettingsChanged(object sender, EventArgs e)
        {
            if (DeviceSettingsChanged != null) DeviceSettingsChanged(sender, e);
        }
	}
}
