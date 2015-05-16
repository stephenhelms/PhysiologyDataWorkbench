using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench
{
    public partial class RecordingInfoControl : UserControl
    {
        public event EventHandler PhysiologyDataChanged;
        private PhysiologyData _PhysiologyData;
        [Bindable(true)]
        public PhysiologyData PhysiologyData
        {
            get { return _PhysiologyData; }
            set {
                _PhysiologyData = value;

                if (PhysiologyData != null) UsersBindingSource.DataSource = _PhysiologyData;
                else UsersBindingSource.DataSource = typeof(PhysiologyData);

                if (PhysiologyDataChanged != null) PhysiologyDataChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler RecordingChanged;
        private Recording _Recording = null;
        [DefaultValue(null)]
        [Bindable(true)]
        public Recording Recording
        {
            get { return _Recording; }
            set {
                _Recording = value;

                if (Recording != null)
                {
                    RecordingBindingSource.DataSource = value;
                    Invoke(new Action<Control>(delegate(Control control) {
                        control.Enabled = true; }),this);
                }
                else
                {
                    RecordingBindingSource.DataSource = typeof(Recording);
                    Invoke(new Action<Control>(delegate(Control control) {
                        control.Enabled = false; }),this);
                }
            }
        }

        public event EventHandler ReadOnlyChanged;

        private bool _ReadOnly = false;
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set {
                _ReadOnly = value;
                OnReadOnlyChanged(EventArgs.Empty);
            }
        }	

        public RecordingInfoControl()
        {
            InitializeComponent();
        }

        protected virtual void OnReadOnlyChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnReadOnlyChanged),e);
                return;
            }

            TitleTextbox.ReadOnly = ReadOnly;
            CreatedTimePicker.Enabled = !ReadOnly;
            BathSolutionComboBox.Enabled = !ReadOnly;
            PipetteSolutionComboBox.Enabled = !ReadOnly;
            DescriptionTextbox.ReadOnly = ReadOnly;

            if (ReadOnlyChanged != null) ReadOnlyChanged(this, EventArgs.Empty);
        }
    }
}
