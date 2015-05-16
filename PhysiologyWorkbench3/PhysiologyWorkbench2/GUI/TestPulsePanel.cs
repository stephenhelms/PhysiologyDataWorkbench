using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class TestPulsePanel : UserControl
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
            if (Program != null)
            {
                RegisterHotkeys();
                ProgramBindingSource.DataSource = Program;
                Protocol = Program.TestPulseProtocol;

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
            }
            else ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
            
            if (ProgramChanged != null)
                try
                {
                    ProgramChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("TestPulsePanel: Error during ProgramChanged event.", x.Message);
                }
        }

        protected virtual void OnDatabaseUpdateStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDatabaseUpdateStarted), sender, e);
                return;
            }

            RecordingDataGraphControl.SuspendBinding();
        }
        protected virtual void OnDatabaseUpdateFinished(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDatabaseUpdateFinished), sender, e);
                return;
            }

            RecordingDataGraphControl.ResumeBinding();
        }

        public event EventHandler ProtocolChanged;
        private TestPulseProtocol _Protocol;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true)]
        public TestPulseProtocol Protocol
        {
            get { return _Protocol; }
            set
            {
                if (Protocol != null)
                {
                    Protocol.Starting -= new EventHandler(OnTestPulseStarted);
                    Protocol.DataUpdated -= new EventHandler(OnTestPulseDataUpdated);
                }
                _Protocol = value;
                if (Protocol != null)
                {
                    TestPulseBindingSource.DataSource = Protocol;
                    Protocol.Starting += new EventHandler(OnTestPulseStarted);
                    Protocol.DataUpdated += new EventHandler(OnTestPulseDataUpdated);
                }
                else TestPulseBindingSource.DataSource = typeof(TestPulseProtocol);

                OnTestPulseProtocolChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnTestPulseProtocolChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnTestPulseProtocolChanged), e);
                return;
            }

            RecordingDataGraphControl.DataSet =
                Protocol != null ? Protocol.DataSet : null;
            RecordingDataGraphControl.Recording =
                Protocol != null ? Protocol.Data : null;

            if (ProtocolChanged != null) ProtocolChanged(this, EventArgs.Empty);
        }

        public event EventHandler AutoStartTestPulseChanged;

        private bool _AutoStartTestPulse;
        [Bindable(true)]
        public bool AutoStartTestPulse
        {
            get { return _AutoStartTestPulse; }
            set {
                _AutoStartTestPulse = value;
                if (AutoStartTestPulseChanged != null) AutoStartTestPulseChanged(this, EventArgs.Empty);
            }
        }
	

        public TestPulsePanel()
        {
            InitializeComponent();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (ParentForm is IPhysiologyWorkbenchProgramProvider)
                Program = ((IPhysiologyWorkbenchProgramProvider)ParentForm).Program;
            base.OnLocationChanged(e);
        }

        protected virtual void RegisterHotkeys()
        {
            if (Program == null) return;

            Program.HotkeyManager.RegisterAction("Toggle Test Pulse", new System.Threading.ThreadStart(ToggleTestPulseRunning));
            Program.HotkeyManager.RegisterAction("Save Resistance Measurement", new System.Threading.ThreadStart(SaveResistanceMeasurement));
        }

        public virtual void ToggleTestPulseRunning()
        {
            if (Protocol == null)
            {
                MessageBox.Show("No test pulse protocol loaded.");
                return;
            }

            try
            {
                if (!Protocol.IsProtocolRunning) Protocol.StartContinuousExecute();
                else Protocol.StopContinuousExecute();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error starting or stopping test pulse: " + e.Message);
            }
        }

        public virtual void SaveResistanceMeasurement()
        {
            if (Protocol == null || Program == null || Program.DataManager.CurrentCell == null
                || Protocol.Data == null || Protocol.Resistance == 0)
            {
                MessageBox.Show("Unable to save resistance.");
                return;
            }

            // First save pipette R, then seal, then whole cell, finally just keep result
            PhysiologyDataSet.CellsRow cell = Program.DataManager.CurrentCell;
            if (cell.IsPipetteResistanceNull() || cell.PipetteResistance == 0)
                SaveInBathTestPulseDataButton.SaveData();
            else if (cell.IsSealResistanceNull() || cell.SealResistance == 0)
                SaveCellAttachedTestPulseData.SaveData();
            else if (cell.IsMembraneResistanceNull() || cell.MembraneResistance == 0)
                saveWholeCellTestPulseDataButton1.SaveData();
            else Program.TestPulseProtocol.TriggerNewData = true;
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnVisibleChanged), sender, e);
                return;
            }

            if (AutoStartTestPulse && Visible)
                try
                {
                    if (Protocol != null && (!Protocol.IsProtocolRunning))
                        Protocol.StartContinuousExecute();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error while starting test pulse: " + x.Message);
                }
        }

        public virtual void NotifyNotVisible()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(NotifyNotVisible));
                return;
            }

            if (Protocol != null && Protocol.IsProtocolRunning)
                try
                {
                    Protocol.StopContinuousExecute();
                }
                catch (Exception x) { MessageBox.Show("Error stopping test pulse: " + x.Message); }
        }

        protected virtual void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (Protocol != null)
            {
                Protocol.TriggerNewData = true;
            }
        }

        protected virtual void OnTestPulseStarted(object sender, EventArgs e)
        {
            //RecordingDataGraphControl.ResetGraph();
        }
        protected virtual void OnTestPulseDataUpdated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnTestPulseDataUpdated), sender, e);
                return;
            }

            if (Protocol == null) RecordingDataGraphControl.DataSet = null;
            else if(Protocol.DataSet != RecordingDataGraphControl.DataSet)
                RecordingDataGraphControl.DataSet = Protocol.DataSet;

            if (Protocol == null) RecordingDataGraphControl.Recording = null;
            else if (Protocol.Data != RecordingDataGraphControl.Recording)
                RecordingDataGraphControl.Recording = Protocol.Data;
            else RecordingDataGraphControl.RefreshGraphData();

            if (Protocol == null) RecordingDataGraphControl.ResetGraph();
        }

        private void OnAutoStartTestPulseChecked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnAutoStartTestPulseChecked), sender, e);
                return;
            }

            AutoStartTestPulse = AutoStartTestPulseCheckBox.Checked;
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (AutoStartTestPulseCheckBox.Checked != AutoStartTestPulse)
                AutoStartTestPulseCheckBox.Checked = AutoStartTestPulse;

            base.OnInvalidated(e);
        }
    }
}
