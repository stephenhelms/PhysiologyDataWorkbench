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
    public partial class ShutterControl : UserControl, IDeviceManagerUser
    {
        private DeviceManager _DeviceManager;
        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set {
                if (DeviceManager != null) DeviceManager.AvailableDevicesChanged -= new EventHandler(OnAvailableDevicesChanged);
                _DeviceManager = value;
                if (DeviceManager != null) DeviceManager.AvailableDevicesChanged += new EventHandler(OnAvailableDevicesChanged);
                OnAvailableDevicesChanged(this, EventArgs.Empty);
            }
        }

        private Shutter _Shutter;

        public Shutter Shutter
        {
            get { return _Shutter; }
            set {
                if (Shutter != null) Shutter.ShutterToggled -= new EventHandler(OnShutterToggled);
                _Shutter = value;
                if (Shutter != null) Shutter.ShutterToggled += new EventHandler(OnShutterToggled);
                OnShutterToggled(this, EventArgs.Empty);
                UpdateShutterComboBoxSelection();
            }
        }	

        public ShutterControl()
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
                List<Device> shutters = new List<Device>(DeviceManager.GetAvailableDevices(typeof(Shutter)));
                if (shutters.Count == 0)
                {
                    this.Enabled = false;
                    return;
                }
                this.Enabled = true;

                ShutterComboBox.Items.Clear();
                foreach (Device d in shutters)
                    ShutterComboBox.Items.Add(d as Shutter);
                
                ShutterComboBox.SelectedIndex = 0;
            }
        }

        protected virtual void OnOpenClicked(object sender, EventArgs e)
        {
            if (Shutter == null) return;
            try
            {
                Shutter.OpenShutter();
            }
            catch (Exception x) { MessageBox.Show("Error opening shutter: " + x.Message); }
        }

        protected virtual void OnCloseClicked(object sender, EventArgs e)
        {
            if (Shutter == null) return;
            try
            {
                Shutter.CloseShutter();
            }
            catch (Exception x) { MessageBox.Show("Error closing shutter: " + x.Message); }
        }

        protected virtual void OnShutterToggled(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnShutterToggled), sender, e);
                return;
            }
            if (Shutter == null)
            {
                OpenShutterButton.Enabled = false;
                CloseShutterButton.Enabled = false;
                return;
            }
            if (Shutter.IsShutterClosed)
            {
                OpenShutterButton.Enabled = true;
                CloseShutterButton.Enabled = false;
            }
            else
            {
                OpenShutterButton.Enabled = false;
                CloseShutterButton.Enabled = true;
            }
        }

        private void UpdateShutterComboBoxSelection()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateShutterComboBoxSelection));
                return;
            }
            if (Shutter == null) ShutterComboBox.SelectedItem = null;
            else if (ShutterComboBox.Items.Contains(Shutter)) ShutterComboBox.SelectedItem = Shutter;
            else
            {
                ShutterComboBox.Items.Add(Shutter);
                ShutterComboBox.SelectedItem = Shutter;
            }
        }

        protected virtual void OnComboBoxSelectedShutterChanged(object sender, EventArgs e)
        {
            Shutter = ShutterComboBox.SelectedItem as Shutter;
        }
    }
}
