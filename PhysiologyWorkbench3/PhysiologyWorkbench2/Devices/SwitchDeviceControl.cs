using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class SwitchDeviceControl : UserControl
    {
        private DeviceManager _DeviceManager;
        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set
            {
                if (DeviceManager == value) return;
                _DeviceManager = value;
                OnDeviceManagerChanged(EventArgs.Empty);
            }
        }
        protected virtual void OnDeviceManagerChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnDeviceManagerChanged), e);
                return;
            }
            deviceChooserControl1.DeviceManager = DeviceManager;
        }

        public SwitchDeviceControl()
        {
            InitializeComponent();
        }

        private void OnButton_Click(object sender, EventArgs e)
        {
            if (deviceChooserControl1.SelectedDevice == null) return;

            SwitchDevice device = deviceChooserControl1.SelectedDevice as SwitchDevice;
            device.SwitchOn();
        }

        private void OffButton_Click(object sender, EventArgs e)
        {
            if (deviceChooserControl1.SelectedDevice == null) return;

            SwitchDevice device = deviceChooserControl1.SelectedDevice as SwitchDevice;
            device.SwitchOff();
        }
    }
}
