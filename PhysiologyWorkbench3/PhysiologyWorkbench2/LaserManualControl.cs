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
    public partial class LaserManualControl : UserControl, IDeviceManagerUser
    {
        private DeviceManager _DeviceManager;
        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set
            {
                if (DeviceManager != null) DeviceManager.AvailableDevicesChanged -= new EventHandler(OnAvailableDevicesChanged);
                _DeviceManager = value;
                if (DeviceManager != null) DeviceManager.AvailableDevicesChanged += new EventHandler(OnAvailableDevicesChanged);
                OnAvailableDevicesChanged(this, EventArgs.Empty);
            }
        }

        private SpectraPhysicsNitrogenLaser _Laser;

        public SpectraPhysicsNitrogenLaser Laser
        {
            get { return _Laser; }
            set {
                _Laser = value;
                UpdateLaserComboBoxSelection();
            }
        }
	

        public LaserManualControl()
        {
            InitializeComponent();
        }

        protected virtual void OnAvailableDevicesChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnAvailableDevicesChanged), sender, e);
                return;
            }
            if (DeviceManager == null) this.Enabled = false;
            else
            {
                List<Device> lasers = new List<Device>(DeviceManager.GetAvailableDevices(typeof(SpectraPhysicsNitrogenLaser)));
                if (lasers.Count == 0)
                {
                    this.Enabled = false;
                    return;
                }
                this.Enabled = true;

                LaserComboBox.Items.Clear();
                foreach (Device d in lasers)
                    LaserComboBox.Items.Add(d as SpectraPhysicsNitrogenLaser);

                LaserComboBox.SelectedIndex = 0;
            }
        }
        private void UpdateLaserComboBoxSelection()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateLaserComboBoxSelection));
                return;
            }
            if (Laser == null)
            {
                LaserComboBox.SelectedItem = null;
                FlashLaserButton.Enabled = false;
                return;
            }
            else if (LaserComboBox.Items.Contains(Laser)) LaserComboBox.SelectedItem = Laser;
            else
            {
                LaserComboBox.Items.Add(Laser);
                LaserComboBox.SelectedItem = Laser;
            }
            FlashLaserButton.Enabled = true;
        }

        protected virtual void OnComboBoxSelectedLaserChanged(object sender, EventArgs e)
        {
            Laser = LaserComboBox.SelectedItem as SpectraPhysicsNitrogenLaser;
        }

        private void OnFlashClicked(object sender, EventArgs e)
        {
            if (Laser == null) return;
            Laser.FireLaserOnce();
        }
    }
}
