using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.Utilities
{
    public partial class ProgressDialog : Form, IProgressCallback
    {
        /// A delegate for methods which take a range
        public delegate void RangeInvoker(int minimum, int maximum);

        public event EventHandler TaskStarted;
        public event EventHandler TaskStopped;
        public event EventHandler<ExceptionEventArgs> TaskError;

        public event EventHandler IsUserAllowedToCancelChanged;
        private bool _IsUserAllowedToCancel = true;
        /// <summary>
        /// Determines whether the user can cancel the executing task
        /// </summary>
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(true)]
        public bool IsUserAllowedToCancel
        {
            get { return _IsUserAllowedToCancel; }
            set {
                _IsUserAllowedToCancel = value;
                if (IsUserAllowedToCancelChanged != null) IsUserAllowedToCancelChanged(this, EventArgs.Empty);
            }
        }
	

        public ProgressDialog()
        {
            InitializeComponent();
        }
        public ProgressDialog(string title)
        {
            InitializeComponent();
            Text = title ?? Text;
        }

        #region IProgressCallback Members

        public void Begin()
        {
            Begin(0, 100);
        }
        public void Begin(int minimum, int maximum)
        {
            if (InvokeRequired)
            {
                Invoke(new RangeInvoker(Begin), minimum, maximum);
                return;
            }

            OnTaskStarted(EventArgs.Empty);
            Visible = true;
            SetRange(minimum, maximum);
            CancelTaskButton.Enabled = IsUserAllowedToCancel;
        }

        public void SetRange(int minimum, int maximum)
        {
            if (InvokeRequired)
            {
                Invoke(new RangeInvoker(SetRange), minimum, maximum);
                return;
            }

            TaskProgressBar.Minimum = minimum;
            TaskProgressBar.Maximum = maximum;
        }

        public void SetTaskInfo(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetTaskInfo), text);
            }

            TaskInfoLabel.Text = text;
        }

        public void StepTo(int val)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(StepTo), val);
                return;
            }
            TaskProgressBar.Value = val;
        }

        public void Increment(int val)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(Increment), val);
                return;
            }

            TaskProgressBar.Increment(val);
        }

        private bool _IsAborting = false;
        public bool IsAborting
        {
            get { return _IsAborting; }
            protected set
            {
                _IsAborting = value;
            }
        }

        private bool _StartTrigger = true;
        public bool StartTrigger
        {
            get
            {
                return _StartTrigger;
            }
            protected set
            {
                _StartTrigger = value;
            }
        }

        public void NotifyFinished()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(NotifyFinished));
                return;
            }

            SetTaskInfo("Finished.");
            StepTo(TaskProgressBar.Maximum);
        }

        public void End()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(End));
                return;
            }

            this.Close();
            OnTaskStopped(EventArgs.Empty);
        }

        public void NotifyError(ExceptionEventArgs e)
        {
            OnTaskError(e);
        }

        public void SetTitle(string title)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetTitle), title);
                return;
            }

            Text = title;
        }

        #endregion

        private void OnCancelClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCancelClicked), sender, e);
                return;
            }

            IsAborting = true;
        }

        protected virtual void OnTaskError(ExceptionEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ExceptionEventArgs>(OnTaskError), e);
                return;
            }
            this.Visible = false;
            MessageBox.Show(e.Message);
        }

        public event EventHandler IsShowOnTaskExecutionEnabledChanged;
        private bool _IsShowOnTaskExecutionEnabled = true;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(true)]
        public bool IsShowOnTaskExecutionEnabled
        {
            get { return _IsShowOnTaskExecutionEnabled; }
            set {
                _IsShowOnTaskExecutionEnabled = value;
                if (IsShowOnTaskExecutionEnabledChanged != null) IsShowOnTaskExecutionEnabledChanged(this, EventArgs.Empty);
            }
        }
	

        protected virtual void OnTaskStarted(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnTaskStarted), e);
                return;
            }

            if (IsShowOnTaskExecutionEnabled) Visible = true;
            if (TaskStarted != null)
                try
                {
                    TaskStarted(this, e);
                }
                catch (Exception x) { ; }
        }
        protected virtual void OnTaskStopped(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnTaskStopped), e);
                return;
            }

            if (IsShowOnTaskExecutionEnabled) Visible = false;
            if (TaskStopped != null)
                try
                {
                    TaskStopped(this, e);
                }
                catch (Exception x) { ; }
        }
    }
}