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
                ProtocolSidebarControl.Program = Program;
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

                if (Program.DataManager != null)
                {
                    try
                    {
                        Program.DataManager.StartingDatabaseUpdate -= new EventHandler(OnDatabaseUpdateStarted);
                        Program.DataManager.FinishedDatabaseUpdate -= new EventHandler(OnDatabaseUpdateFinished);
                    }
                    catch { ; }

                    Program.DataManager.StartingDatabaseUpdate += new EventHandler(OnDatabaseUpdateStarted);
                    Program.DataManager.FinishedDatabaseUpdate += new EventHandler(OnDatabaseUpdateFinished);
                }

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

        protected virtual void OnDatabaseUpdateStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDatabaseUpdateStarted), sender, e);
                return;
            }

            RecordingGraphControl.SuspendBinding();
        }
        protected virtual void OnDatabaseUpdateFinished(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDatabaseUpdateFinished), sender, e);
                return;
            }

            RecordingGraphControl.ResumeBinding();
        }

        protected virtual void OnCurrentProtocolChanged(object sender, EventArgs e)
        {
            if (Program != null && Program.CurrentProtocol != null)
            {
                try
                {
                    Program.CurrentProtocol.DataUpdated -= new EventHandler(OnProtocolDataUpdated);
                }
                catch { ; }
                Program.CurrentProtocol.DataUpdated += new EventHandler(OnProtocolDataUpdated);
            }
        }

        protected virtual void OnProtocolDataUpdated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnProtocolDataUpdated), sender, e);
                return;
            }

            if (Program != null && Program.CurrentProtocol != null)
            {
                RecordingGraphControl.DataSet = Program.CurrentProtocol.DataSet;
                RecordingGraphControl.Recording = Program.CurrentProtocol.Data;
            }
        }
	

        public ProtocolPanel()
        {
            InitializeComponent();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (ParentForm is IPhysiologyWorkbenchProgramProvider)
                Program = ((IPhysiologyWorkbenchProgramProvider)ParentForm).Program;
            base.OnLocationChanged(e);
        }
    }
}
