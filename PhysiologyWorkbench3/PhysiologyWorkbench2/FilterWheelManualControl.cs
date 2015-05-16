using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class FilterWheelManualControl : UserControl, IDeviceManagerUser
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
	

        public FilterWheelManualControl()
        {
            InitializeComponent();
        }

        protected virtual void SetDeviceManagerOnMembers()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetDeviceManagerOnMembers));
                return;
            }

            DeviceChooserControl.DeviceManager = DeviceManager;
        }

        private void OnSelectedDeviceChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedDeviceChanged), sender, e);
                return;
            }

            FilterWheelPositionControl.FilterWheel = DeviceChooserControl.SelectedDevice as FilterWheel;
        }
    }
}
