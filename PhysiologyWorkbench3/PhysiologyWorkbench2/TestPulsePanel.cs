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
                if (Program != null)
                {
                    RegisterHotkeys();
                    ProgramBindingSource.DataSource = value;
                }
                else ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
                if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
            }
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
                _Protocol = value;
                if (Protocol != null) TestPulseBindingSource.DataSource = Protocol;
                else TestPulseBindingSource.DataSource = typeof(TestPulseProtocol);
                if (ProtocolChanged != null) ProtocolChanged(this, EventArgs.Empty);
            }
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
            ControlBindingSource.DataSource = this;
            Protocol = new TestPulseProtocol();
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
            if (Program.DataManager.CurrentCell.PipetteResistance == 0)
                SavePipetteResistanceButton.SaveResistance();
            else if (Program.DataManager.CurrentCell.SealResistance == 0)
                SaveSealResistanceMeasurementButton.SaveResistance();
            else if (Program.DataManager.CurrentCell.MembraneResistance == 0)
                SaveSeriesResistanceButton.Save();
            else Program.DataManager.StoreRecording(Program.DataManager.CurrentRecording);
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
                Program.DataManager.StoreRecording(Protocol.Data);
                Protocol.TriggerNewData = true;
            }
        }
    }
}
