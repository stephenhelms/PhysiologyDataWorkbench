using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class DeviceConfigurationReflectorPanel : UserControl
    {
        public event EventHandler DeviceChanged;

        protected Control CustomConfigurationControl = null;

        private Device _Device;
        public Device Device
        {
            get { return _Device; }
            set
            {
                _Device = value;
                UpdateDeviceInformation(Device);
                if (DeviceChanged != null) DeviceChanged(this, EventArgs.Empty);
            }
        }

        public DeviceConfigurationReflectorPanel()
        {
            InitializeComponent();
        }

        public virtual void UpdateDeviceInformation(Device device)
        {
            if (device == null)
            {
                if (CustomConfigurationControl != null)
                {
                    Controls.Remove(CustomConfigurationControl);
                    CustomConfigurationControl = null;
                    DeviceSettingsPropertySheet.Visible = true;
                }
                this.Enabled = false;
                DeviceNameLabel.Text = "No Device Selected";
                DeviceTypeLabel.Text = "";
                DeviceSettingsPropertySheet.SelectedObject = null;
                return;
            }
            else if (device is ICustomDeviceConfigurationControlProvider)
            {
                if (CustomConfigurationControl != null)
                {
                    Controls.Remove(CustomConfigurationControl);
                    CustomConfigurationControl = null;
                }
                this.Enabled = true;
                DeviceNameLabel.Text = device.Name;
                DeviceTypeLabel.Text = device.GetType().FullName;
                DeviceSettingsPropertySheet.SelectedObject = device;
                CustomConfigurationControl = ((ICustomDeviceConfigurationControlProvider)device).GetDeviceConfigurationControl();
                CustomConfigurationControl.Dock = DockStyle.Bottom;
                Controls.Add(CustomConfigurationControl);
            }
            else
            {
                if (CustomConfigurationControl != null)
                {
                    Controls.Remove(CustomConfigurationControl);
                    CustomConfigurationControl = null;
                }
                this.Enabled = true;
                DeviceNameLabel.Text = device.Name;
                DeviceTypeLabel.Text = device.GetType().FullName;
                DeviceSettingsPropertySheet.SelectedObject = device;
                return;
            }
        }
    }
}
