using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Daq;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class ProtocolSidebarControl : UserControl
    {
        public event EventHandler ProgramChanged;

        private PhysiologyWorkbenchProgram _Program;

        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                if (Program != null) Program.CurrentProtocolChanged -= new EventHandler(OnCurrentProtocolChanged);
                _Program = value;
                OnProgramChanged(EventArgs.Empty);
            }
        }

        private void OnProgramChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnProgramChanged), e);
                return;
            }

            if (Program != null)
            {
                ProgramBindingSource.DataSource = Program;
                Program.CurrentProtocolChanged += new EventHandler(OnCurrentProtocolChanged);

                ProtocolComboBox.DataSource = Program.Protocols;
                ProtocolComboBox.DisplayMember = "ProtocolName";

                Enabled = true;
            }
            else
            {
                ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
                Enabled = false;
            }

            if (ProgramChanged != null) ProgramChanged(this, e);
        }
	

        public ProtocolSidebarControl()
        {
            InitializeComponent();
        }

        protected virtual void OnCurrentProtocolChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCurrentProtocolChanged), sender, e);
                return;
            }

            SettingsTab.Controls.Clear();
            if (Program != null && Program.CurrentProtocol != null)
            {
                Control configControl = Program.CurrentProtocol.GetConfigurationControl();
                if (configControl is IDeviceManagerUser)
                    (configControl as IDeviceManagerUser).DeviceManager = Program.DeviceManager;
                configControl.Dock = DockStyle.Fill;
                SettingsTab.Controls.Add(configControl);

                ProtocolAdvancedSettingsPropertyGrid.SelectedObject = Program.CurrentProtocol;
            }
            else ProtocolComboBox.SelectedItem = null;
        }

        private void OnSelectedProtocolCommitted(object sender, EventArgs e)
        {
            Validate();
        }
    }
}
