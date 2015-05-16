using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public partial class MultiLaserFlashConfigurationControl : UserControl
    {
        public event EventHandler ProgramChanged;

        private PhysiologyWorkbenchProgram _Program;

        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                _Program = value;
                OnProgramChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnProgramChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnProgramChanged),e);
                return;
            }

            if (Program != null)
            {
                ProgramBindingSource.DataSource = Program;
                if (Protocol != null)
                {
                    Enabled = true;
                    Protocol.Amplifier = Program.DeviceManager.DefaultAmplifier;
                }
                else Enabled = false;
            }
            else
            {
                ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
                Enabled = false;
            }

            if (ProgramChanged != null) ProgramChanged(this, e);
        }
	

        public event EventHandler ProtocolChanged;

        private MultiFlashProtocol _Protocol;

        public MultiFlashProtocol Protocol
        {
            get { return _Protocol; }
            set {
                _Protocol = value;
                OnProtocolChanged(EventArgs.Empty);
            }
        }

        private void OnProtocolChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnProtocolChanged), e);
                return;
            }

            if (Protocol == null)
            {
                ProtocolBindingSource.DataSource = typeof(LaserFlashProtocol);
                Enabled = false;
            }
            else
            {
                ProtocolBindingSource.DataSource = Protocol;
                if (Program != null)
                {
                    Protocol.Amplifier = Program.DeviceManager.DefaultAmplifier;
                    Enabled = true;
                }
            }

            if (ProtocolChanged != null) ProtocolChanged(this, e);
        }
	

        public MultiLaserFlashConfigurationControl()
        {
            InitializeComponent();
        }
        public MultiLaserFlashConfigurationControl(MultiFlashProtocol protocol)
        {
            InitializeComponent();
            Protocol = protocol;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (ParentForm is IPhysiologyWorkbenchProgramProvider)
                Program = ((IPhysiologyWorkbenchProgramProvider)ParentForm).Program;
            base.OnLocationChanged(e);
        }

        protected virtual void OnSelectedLaserChanged(object sender, EventArgs e)
        {
            //if (Protocol != null) Protocol.Laser = LaserChooser.SelectedDevice as Laser;
        }
    }
}
