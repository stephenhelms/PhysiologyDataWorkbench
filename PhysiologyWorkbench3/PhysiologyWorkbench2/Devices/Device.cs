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
        [field: NonSerialized]
        public event EventHandler DeviceInitialized;
        [field: NonSerialized]
        public event EventHandler DeviceFinalized;

        private string _Name = "";
        [System.ComponentModel.Category("Information")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public virtual void InitializeDevice()
        {
            if (DeviceInitialized != null)
                try
                {
                    DeviceInitialized(this, EventArgs.Empty);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Fail("Error during device initialization event.", e.Message);
                }
        }

        public virtual void FinalizeDevice()
        {
            if (DeviceFinalized != null)
                try
                {
                    DeviceFinalized(this, EventArgs.Empty);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Fail("Error during device finalization event.", e.Message);
                }
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


        protected int ConvertAddressToBit(string daqAddress)
        {
            string[] parts = daqAddress.Split('/');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].ToLowerInvariant().Contains("line"))
                {
                    return Int32.Parse(parts[i].Substring(4));
                }
            }
            return -1;
        }
        protected byte ConvertBitArrayToByte(System.Collections.BitArray bits)
        {
            byte value = 0x00;

            for (byte x = 0; x < bits.Count; x++)
            {
                value |= (byte)((bits[x] == true) ? (0x01 << x) : 0x00);
            }
            return value;
        }
	}
}
