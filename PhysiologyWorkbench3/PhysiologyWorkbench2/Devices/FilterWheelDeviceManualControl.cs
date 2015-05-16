using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class FilterWheelDeviceManualControl : UserControl
    {
        public event EventHandler DeviceManagerChanged;
        private DeviceManager _DeviceManager;

        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set {
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

            DeviceChooserControl.DeviceManager = DeviceManager;

            if(DeviceManagerChanged != null)
                try
                {
                    DeviceManagerChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during DeviceManagerChanged event: " + x.Message);
                }
        }
	

        public FilterWheelDeviceManualControl()
        {
            InitializeComponent();
        }

        protected virtual void DeviceChooserControl_SelectedDeviceChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(DeviceChooserControl_SelectedDeviceChanged), sender, e);
                return;
            }

            FilterWheelDevice filterWheel = (FilterWheelDevice)DeviceChooserControl.SelectedDevice;
            FilterWheelDeviceCompactControl.FilterWheel = filterWheel;
            if (filterWheel != null) FilterWheelDeviceCompactControl.Enabled = true;
        }
    }
}
