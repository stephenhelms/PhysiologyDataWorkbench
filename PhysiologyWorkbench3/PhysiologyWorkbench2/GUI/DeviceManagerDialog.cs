using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class DeviceManagerDialog : Form
    {
        private DeviceManager _DeviceManager;
        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set
            {
                DeregisterDeviceManagerEventListeners(_DeviceManager);
                _DeviceManager = value;
                RegisterDeviceManagerEventListeners(value);

                if (_DeviceManager == null) DialogEnabled = false;
                else DialogEnabled = true;

                UpdateDeviceManagerInformation();
            }
        }

        private bool _DialogEnabled = true;
        public bool DialogEnabled
        {
            get
            {
                return _DialogEnabled;
            }
            protected set
            {
                _DialogEnabled = value;
                // TODO: Implement this property
            }
        }

        public DeviceManagerDialog()
        {
            InitializeComponent();
        }
        public DeviceManagerDialog(DeviceManager manager)
        {
            InitializeComponent();
            DeviceManager = manager;
        }

        protected virtual void DeregisterDeviceManagerEventListeners(DeviceManager manager)
        {
            if (manager == null) return;
            manager.AvailableDevicesChanged -= new EventHandler(OnAvailableDevicesChanged);
        }
        protected virtual void RegisterDeviceManagerEventListeners(DeviceManager manager)
        {
            if (manager == null) return;
            manager.AvailableDevicesChanged += new EventHandler(OnAvailableDevicesChanged);
        }

        protected virtual void OnAvailableDevicesChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnAvailableDevicesChanged), sender, e);
                return;
            }
            UpdateDeviceManagerInformation();
        }

        protected virtual void UpdateDeviceManagerInformation()
        {
            UpdateAvailableDevicesList();
        }

        protected virtual void UpdateAvailableDevicesList()
        {
            // Get the available Devices from the DeviceManager
            List<Device> devices = new List<Device>(DeviceManager.GetAvailableDevices());
            
            // Add the available Devices to the listbox
            DeviceListBox.Items.Clear();
            foreach (Device device in devices) DeviceListBox.Items.Add(device);
        }

        protected virtual void OnDeviceListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDeviceListSelectedIndexChanged), sender, e);
                return;
            }

            if ((DeviceListBox.SelectedItem != null) && (DeviceListBox.SelectedItem is Device))
                DeviceConfigurationReflectorPanel.Device = DeviceListBox.SelectedItem as Device;
            else DeviceConfigurationReflectorPanel.Device = null;
        }

        protected virtual void OnAddDeviceClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnAddDeviceClicked), sender, e);
                return;
            }

            InstallNewDeviceDialog dialog = new InstallNewDeviceDialog(DeviceManager);
            dialog.ShowDialog(this);
        }

        protected virtual void OnRemoveDeviceClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRemoveDeviceClicked), sender, e);
                return;
            }

            if ((DeviceListBox.SelectedItem == null) || (!(DeviceListBox.SelectedItem is Device))) return;

            Device deviceToRemove = DeviceListBox.SelectedItem as Device;

            // Ask user to confirm removal
            if (MessageBox.Show("Are you sure you want to remove " + deviceToRemove.Name + "?", "Confirm Device Removal", MessageBoxButtons.YesNo)
                != DialogResult.Yes) return;

            try
            {
                DeviceManager.RemoveDevice(deviceToRemove);
            }
            catch (ArgumentException x)
            {
                MessageBox.Show("Error removing device:" + x.Message);
            }
        }

        protected virtual void OnSaveClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSaveClicked), sender, e);
                return;
            }

            DeviceManager.SaveDeviceSettings();
            this.Close();
        }

        protected virtual void OnCancelClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCancelClicked), sender, e);
                return;
            }

            DeviceManager.RestoreSavedDeviceSettings();
            this.Close();
        }
    }
}