using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Daq;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class ProtocolPanel : UserControl
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
                Invoke(new Action<EventArgs>(OnProgramChanged), e);
                return;
            }

            if (Program != null)
            {
                ProgramBindingSource.DataSource = Program;
                Program.CurrentProtocolChanged += new EventHandler(OnCurrentProtocolChanged);
                OnCurrentProtocolChanged(this, EventArgs.Empty);
                Enabled = true;
            }
            else
            {
                ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
                OnCurrentProtocolChanged(this, EventArgs.Empty);
                Enabled = false;
            }

            if (ProgramChanged != null) ProgramChanged(this, e);
        }

        protected virtual void OnCurrentProtocolChanged(object sender, EventArgs e)
        {
            if (Program == null)
            {
                ProtocolBindingSource.DataSource = typeof(DaqProtocol);
                return;
            }

            if (Program.CurrentProtocol != null)
                ProtocolBindingSource.DataSource = Program.CurrentProtocol;
            else ProtocolBindingSource.DataSource = typeof(DaqProtocol);
        }
	
	

        public ProtocolPanel()
        {
            InitializeComponent();
            ControlBindingSource.DataSource = this;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (ParentForm is IPhysiologyWorkbenchProgramProvider)
                Program = ((IPhysiologyWorkbenchProgramProvider)ParentForm).Program;
            base.OnLocationChanged(e);
        }
    }
}
