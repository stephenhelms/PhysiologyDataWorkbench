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
    public partial class LaserFluorescenceRecordingProtocolConfigPanel : UserControl
    {
        public event EventHandler ProgramChanged;

        private PhysiologyWorkbenchProgram _Program;

        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set
            {
                _Program = value;
                OnProgramChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnProgramChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnProgramChanged), e);
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

        private LaserFluorescenceRecordingProtocol _Protocol;

        public LaserFluorescenceRecordingProtocol Protocol
        {
            get { return _Protocol; }
            set
            {
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
                ProtocolBindingSource.DataSource = typeof(LaserFluorescenceRecordingProtocol);
                Enabled = false;
            }
            else
            {
                ProtocolBindingSource.DataSource = Protocol;
                if (Program != null)
                {
                    Protocol.Amplifier = Program.DeviceManager.DefaultAmplifier;
                    Protocol.Laser = Program.DeviceManager.DefaultLaser;
                    
                    List<Device> fdus = new List<Device>(Program.DeviceManager.GetAvailableDevices(typeof(Photodiode)));
                    if(fdus.Count == 0) {
                        Protocol.Photodiode1 = null;
                        Protocol.Photodiode2 = null;
                    }
                    else if(fdus.Count == 1) {
                        Protocol.Photodiode1 = fdus[0] as Photodiode;
                        Protocol.Photodiode2 = null;
                    } else if(fdus.Count >= 2) {
                        Protocol.Photodiode1 = fdus[0] as Photodiode;
                        Protocol.Photodiode2 = fdus[1] as Photodiode;
                    }

                    Enabled = true;
                }
            }

            if (ProtocolChanged != null) ProtocolChanged(this, e);
        }


        public LaserFluorescenceRecordingProtocolConfigPanel()
        {
            InitializeComponent();
        }
        public LaserFluorescenceRecordingProtocolConfigPanel(LaserFluorescenceRecordingProtocol protocol)
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
    }
}
