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
        public event EventHandler NormalColorChanged;
        private Color _NormalColor = System.Drawing.SystemColors.Window;
        [SettingsBindable(true)]
        public Color NormalColor
        {
            get { return _NormalColor; }
            set
            {
                _NormalColor = value;
                if (NormalColorChanged != null) NormalColorChanged(this, EventArgs.Empty);
            }
        }


        public event EventHandler WarningColorChanged;
        private Color _WarningColor = Color.Gold;
        [SettingsBindable(true)]
        public Color WarningColor
        {
            get { return _WarningColor; }
            set
            {
                _WarningColor = value;
                if (WarningColorChanged != null) WarningColorChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;
        [Bindable(true)]
        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                _DataSet = value;

                OnDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnDataSetChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnDataSetChanged), e);
                return;
            }

            if (DataSet != null)
            {
                RecordingBindingSource.DataSource = DataSet;
            }
            else
            {
                RecordingBindingSource.DataSource = typeof(PhysiologyDataSet);
            }

            if (DataSetChanged != null) DataSetChanged(this, e);
        }

        public event EventHandler RecordingChanged;
        private PhysiologyDataSet.RecordingsRow _Recording;
        [Bindable(true)]
        public PhysiologyDataSet.RecordingsRow Recording
        {
            get { return _Recording; }
            set {
                _Recording = value;
                OnRecordingChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnRecordingChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnRecordingChanged), e);
                return;
            }

            
            if (Recording == null)
            {
                Enabled = false;
                RecordingBindingSource.EndEdit();
                RecordingBindingSource.Position = -1;
                System.Diagnostics.Debug.WriteLine("RecordingInfoControl: Recording set to null.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("RecordingInfoControl: Recording switched to " + Recording.RecordingID);
                Enabled = true;
                RecordingBindingSource.EndEdit();
                int position = RecordingBindingSource.Find("RecordingID", Recording.RecordingID);
                System.Diagnostics.Debug.Assert(position >= 0, "Could not find recording.");
                RecordingBindingSource.Position = position;
            }

            if(RecordingChanged != null)
                try
                {
                    RecordingChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during RecordingInfoControl OnRecordingChanged.", x.Message);
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

        public virtual void EndEdit()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(EndEdit));
                return;
            }

            System.Diagnostics.Debug.WriteLine("RecordingInfoControl: Manual databinding update.");
            RecordingBindingSource.EndEdit();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (BathSolutionComboBox.Text == null || BathSolutionComboBox.Text == "")
            {
                BathSolutionComboBox.BackColor = WarningColor;
                e.Cancel = true;
            }
            else BathSolutionComboBox.BackColor = NormalColor;

            if (PipetteSolutionComboBox.Text == null || PipetteSolutionComboBox.Text == "")
                PipetteSolutionComboBox.BackColor = WarningColor;
            else PipetteSolutionComboBox.BackColor = NormalColor;

            base.OnValidating(e);
        }
        protected override void OnValidated(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("RecordingInfoControl: Validated, ending edit.");
            RecordingBindingSource.EndEdit();

            base.OnValidated(e);
        }

        private void OnDataBindingError(object sender, BindingManagerDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Fail("Error during databinding to RecordingInfoControl", e.Exception.Message);
        }

        private void OnRecordingPositionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("RecordingInfoControl: Current position changed.", "DataBinding");
        }

        private void OnDataBinding(object sender, BindingCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new BindingCompleteEventHandler(OnDataBinding), sender, e);
                return;
            }

            if (e == null || e.Binding == null || e.Binding.Control == null) return;
            System.Diagnostics.Debug.WriteLine(String.Format(
                "RecordingInfoControl: Databinding {0}.{1}. {2}", e.Binding.Control.Name, e.Binding.PropertyName, e.BindingCompleteContext), "DataBinding");
            System.Diagnostics.Debug.WriteLine("TitleTextbox.Text is currently " + TitleTextbox.Text);
        }

        private void OnRecordingUpdated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRecordingUpdated), sender, e);
                return;
            }

            //RecordingBindingSource.CancelEdit();
        }


        public virtual void SuspendDataBinding()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SuspendDataBinding));
                return;
            }

            RecordingBindingSource.SuspendBinding();
        }
        public virtual void ResumeDataBinding()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResumeDataBinding));
                return;
            }

            RecordingBindingSource.ResumeBinding();

            OnRecordingChanged(EventArgs.Empty);

            RecordingBindingSource.ResetCurrentItem();
        }
    }
}
