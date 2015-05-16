using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;

namespace RRLab.PhysiologyWorkbench
{
    public partial class TestPulseSettingsBox : UserControl
    {
        public event EventHandler TestPulseProtocolChanged;
        private TestPulseProtocol _TestPulseProtocol;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true)]
        public TestPulseProtocol TestPulseProtocol
        {
            get { return _TestPulseProtocol; }
            set
            {
                _TestPulseProtocol = value;
                if (TestPulseProtocol != null) TestPulseBindingSource.DataSource = value;
                else TestPulseBindingSource.DataSource = typeof(TestPulseProtocol);
                OnTestPulseProtocolChanged(EventArgs.Empty);
            }
        }

        public event EventHandler ProgramChanged;
        private PhysiologyWorkbenchProgram _Program;

        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                _Program = value;
                if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
            }
        }
	

        protected virtual void OnTestPulseProtocolChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnTestPulseProtocolChanged), e);
                return;
            }

            if (TestPulseProtocol != null)
            {
                Enabled = true;
                if (TestPulseProtocol.Amplifier == null && Program != null && Program.DeviceManager != null)
                    TestPulseProtocol.Amplifier = Program.DeviceManager.DefaultAmplifier;
            }
            else Enabled = false;

            if (TestPulseProtocolChanged != null) TestPulseProtocolChanged(this, e);
        }

        public TestPulseSettingsBox()
        {
            InitializeComponent();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (ParentForm is IPhysiologyWorkbenchProgramProvider)
            {
                Program = ((IPhysiologyWorkbenchProgramProvider)ParentForm).Program;
                OnTestPulseProtocolChanged(EventArgs.Empty);
            }
        }
    }
}
