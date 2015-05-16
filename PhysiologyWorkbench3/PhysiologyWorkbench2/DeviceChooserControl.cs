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
    public partial class DeviceChooserControl : UserControl, IDeviceManagerUser
    {
        public event EventHandler SelectedDeviceChanged;

        private string _ChoiceLabel;

        public string ChoiceLabel
        {
            get { return _ChoiceLabel; }
            set {
                _ChoiceLabel = value;
                UpdateChoiceLabel();
            }
        }
	

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

        private Device _SelectedDevice;

        public Device SelectedDevice
        {
            get { return _SelectedDevice; }
            set {
                _SelectedDevice = value;
                UpdateDeviceComboBoxSelection();
                if (SelectedDeviceChanged != null) SelectedDeviceChanged(this, EventArgs.Empty);
            }
        }

        private Type _DeviceType;

        public Type DeviceType
        {
            get { return _DeviceType; }
            set {
                _DeviceType = value;
                OnAvailableDevicesChanged(this, EventArgs.Empty);
            }
        }
	
	

        public DeviceChooserControl()
        {
            InitializeComponent();
        }

        protected virtual void UpdateChoiceLabel()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateChoiceLabel));
                return;
            }
            NameLabel.Text = ChoiceLabel + ":";
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
                List<Device> devices = new List<Device>(DeviceManager.GetAvailableDevices(DeviceType));
                if (devices.Count == 0)
                {
                    this.Enabled = false;
                    return;
                }
                this.Enabled = true;

                DeviceComboBox.Items.Clear();
                foreach (Device d in devices)
                    DeviceComboBox.Items.Add(d);

                DeviceComboBox.SelectedIndex = 0;
            }
        }
        private void UpdateDeviceComboBoxSelection()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateDeviceComboBoxSelection));
                return;
            }
            if (SelectedDevice == null)
            {
                DeviceComboBox.SelectedItem = null;
                return;
            }
            else if (DeviceComboBox.Items.Contains(SelectedDevice)) DeviceComboBox.SelectedItem = SelectedDevice;
            else
            {
                DeviceComboBox.Items.Add(SelectedDevice);
                DeviceComboBox.SelectedItem = SelectedDevice;
            }
        }

        protected virtual void OnComboBoxSelectedLaserChanged(object sender, EventArgs e)
        {
            SelectedDevice = DeviceComboBox.SelectedItem as Device;
        }
    }
}
