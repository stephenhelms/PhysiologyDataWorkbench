using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class AbsoluteVHoldController : UserControl, IHotkeyManagerUser, IDataManagerUser
    {
        private DataManager _DataManager;

        public DataManager DataManager
        {
            get { return _DataManager; }
            set {
                if (DataManager != null) DataManager.CurrentCellChanged -= new EventHandler(OnCellChanged);
                _DataManager = value;
                if (DataManager != null) DataManager.CurrentCellChanged += new EventHandler(OnCellChanged);

            }
        }
	

        private HotkeyManager _HotkeyManager;

        public HotkeyManager HotkeyManager
        {
            get { return _HotkeyManager; }
            set {
                _HotkeyManager = value;
                if (_HotkeyManager != null)
                {
                    if (!_HotkeyManager.Actions.ContainsKey("Increase VHold"))
                        _HotkeyManager.RegisterAction("Increase VHold", new System.Threading.ThreadStart(IncreaseVHold));
                    if (!_HotkeyManager.Actions.ContainsKey("Decrease VHold"))
                        _HotkeyManager.RegisterAction("Decrease VHold", new System.Threading.ThreadStart(DecreaseVHold));
                    if (!_HotkeyManager.Actions.ContainsKey("Set Zero VHold"))
                        _HotkeyManager.RegisterAction("Set Zero VHold", new System.Threading.ThreadStart(SetZeroVHold));
                    if (!_HotkeyManager.Actions.ContainsKey("Set Break-In VHold"))
                        _HotkeyManager.RegisterAction("Set Break-In VHold", new System.Threading.ThreadStart(SetBreakInVHold));
                }
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
                UpdateAmplifierList();
            }
        }

        private Amplifier _Amplifier = null;
        public Amplifier Amplifier
        {
            get { return _Amplifier; }
            set {
                if (Amplifier != null) Amplifier.AbsoluteVHoldChanged -= new EventHandler(OnAbsoluteVHoldChanged);
                _Amplifier = value;
                if (Amplifier != null) Amplifier.AbsoluteVHoldChanged += new EventHandler(OnAbsoluteVHoldChanged);
                UpdateAmplifierList();
            }
        }

        public AbsoluteVHoldController() : this(null)
        {
        }
        public AbsoluteVHoldController(Amplifier amp)
        {
            InitializeComponent();
            Amplifier = amp;
        }

        public virtual void IncreaseVHold()
        {
            if (Amplifier == null) return;
            SetAbsoluteVHold((short)(Amplifier.AbsoluteVHold + 5));
        }
        public virtual void DecreaseVHold()
        {
            if (Amplifier == null) return;
            SetAbsoluteVHold((short)(Amplifier.AbsoluteVHold - 5));
        }

        protected virtual void OnAbsoluteVHoldChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnAbsoluteVHoldChanged), sender, e);
                return;
            }
            if (!Disposing)
            {
                if(!VHoldSlider.Disposing) VHoldSlider.Value = Amplifier.AbsoluteVHold;
                if(!VHoldSlider.Disposing) VHoldLabel.Text = Amplifier.AbsoluteVHold.ToString();
            }
        }

        private void VHoldSlider_ValueChanged(object sender, System.EventArgs e)
        {
            if(Amplifier != null && Amplifier.AbsoluteVHold != VHoldSlider.Value)
                SetAbsoluteVHold(Convert.ToInt16(VHoldSlider.Value));
        }

        protected virtual void UpdateAmplifierList()
        {
            if (DeviceManager == null) return;

            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateAmplifierList));
                return;
            }

            List<Device> amps = new List<Device>(DeviceManager.GetAvailableDevices(typeof(Amplifier)));
            foreach (Device device in amps)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(device.Name, null, new EventHandler(OnSelectedAmplifierChanged));
                if (Amplifier == device) menuItem.Checked = true;
                else menuItem.Checked = false;
                menuItem.Tag = device;
                amplifierToolStripMenuItem.DropDownItems.Clear();
                amplifierToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            if ((Amplifier == null)&&(amplifierToolStripMenuItem.DropDownItems.Count!=0))
                amplifierToolStripMenuItem.DropDownItems[0].PerformClick();
        }

        protected virtual void OnSelectedAmplifierChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedAmplifierChanged), sender, e);
                return;
            }

            if (!(sender is ToolStripDropDownItem)) return;

            ToolStripDropDownItem menu = (ToolStripDropDownItem)sender;

            if ((menu.Tag == null) || !(menu.Tag is Amplifier)) return;
            Amplifier = (Amplifier) menu.Tag;
            UpdateAmplifierList();
        }

        protected virtual void OnAvailableDevicesChanged(object sender, EventArgs e)
        {
            UpdateAmplifierList();
        }

        public virtual void SetAbsoluteVHold(short value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<short>(SetAbsoluteVHold), value);
                return;
            }

            if (Amplifier == null)
            {
                // TODO: Figure out a way to check if the control is loaded yet
                //MessageBox.Show("No amplifier available.");
                return;
            }

            if (value == Amplifier.AbsoluteVHold) return;

            try
            {
                Amplifier.SetHoldingPotential(value);
                this.VHoldSlider.Value = value;
            }
            catch (Exception e) {
                VHoldSlider.Value = Amplifier.AbsoluteVHold;
            }
        }

        private void OnSetZeroVHoldClicked(object sender, EventArgs e)
        {
            SetZeroVHold();
        }

        private void OnSetBreakInVHoldClicked(object sender, EventArgs e)
        {
            SetBreakInVHold();
        }

        public virtual void SetZeroVHold()
        {
            SetAbsoluteVHold(0);
        }
        public virtual void SetBreakInVHold()
        {
            SetAbsoluteVHold(-40); // This should be made a variable
        }

        protected virtual void OnCellChanged(object sender, EventArgs e)
        {
            if(Visible) SetZeroVHold();
        }
    }
}
