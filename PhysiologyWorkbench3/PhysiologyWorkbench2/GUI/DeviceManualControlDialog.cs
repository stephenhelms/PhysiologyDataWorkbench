using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class DeviceManualControlDialog : Form, IDeviceManagerUser
    {
        private DeviceManager _DeviceManager;

        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set {
                _DeviceManager = value;
                SetDeviceManagerOnMembers();
            }
        }

        public DeviceManualControlDialog()
        {
            InitializeComponent();
        }
        public DeviceManualControlDialog(DeviceManager deviceManager)
        {
            InitializeComponent();
            DeviceManager = deviceManager;
        }

        protected virtual void SetDeviceManagerOnMembers()
        {
            if (DeviceManager == null) this.Enabled = false;
            else this.Enabled = true;

            LaserManualControl.DeviceManager = DeviceManager;
            ShutterControl.DeviceManager = DeviceManager;
            filterWheelDeviceManualControl1.DeviceManager = DeviceManager;
            switchDeviceControl1.DeviceManager = DeviceManager;
        }
    }
}