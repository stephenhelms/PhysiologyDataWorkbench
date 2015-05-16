using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench
{
    public partial class StopwatchControl : UserControl
    {
        public event EventHandler Started, Stopped, Reset;

        public event EventHandler StartTimeChanged;

        private DateTime _StartTime = DateTime.MinValue;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set {
                _StartTime = value;
                if (StartTimeChanged != null) StartTimeChanged(this, EventArgs.Empty);
            }
        }

        public bool IsStopwatchActive
        {
            get { return StartTime != DateTime.MinValue; }
        }

        public bool IsStopwatchReset
        {
            get { return StopwatchButton.Text == PreStartMessage; }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                if (StartTime == DateTime.MinValue) return TimeSpan.MinValue;
                else return DateTime.Now - StartTime;
            }
        }

        public event EventHandler PreStartMessageChanged;
        private string _PreStartMessage = "Click to Start Timer";
        [DefaultValue("Click to Start Timer")]
	    public string PreStartMessage
	    {
		    get { return _PreStartMessage;}
		    set {
                _PreStartMessage = value;
                if (PreStartMessageChanged != null) PreStartMessageChanged(this, EventArgs.Empty);
            }
	    }

        public event EventHandler ActiveColorChanged;
        private Color _ActiveColor = Color.Gold;
        public Color ActiveColor
        {
            get { return _ActiveColor; }
            set {
                _ActiveColor = value;
                if (ActiveColorChanged != null) ActiveColorChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler InactiveColorChanged;
        private Color _InactiveColor = System.Drawing.SystemColors.Control;
        public Color InactiveColor
        {
            get { return _InactiveColor; }
            set {
                _InactiveColor = value;
                if (InactiveColorChanged != null) InactiveColorChanged(this, EventArgs.Empty);
            }
        }
	
	
	

        public StopwatchControl()
        {
            InitializeComponent();
        }

        public virtual void Start()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(Start));
                return;
            }

            StartTime = DateTime.Now;
            StopwatchButton.BackColor = ActiveColor;
            UpdateTimer.Start();

            try
            {
                if (Started != null) Started(this, EventArgs.Empty);
            }
            catch (Exception e) { MessageBox.Show("Error while handling Started event: " + e.Message); }
        }
        public virtual void ResetStopwatch()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResetStopwatch));
                return;
            }

            StartTime = DateTime.MinValue;
            StopwatchButton.Text = PreStartMessage;
            StopwatchButton.BackColor = InactiveColor;

            try
            {
                if (Reset != null) Reset(this, EventArgs.Empty);
            }
            catch (Exception e) { MessageBox.Show("Error while handling Reset event: " + e.Message); }
        }
        public virtual void Stop()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(Stop));
                return;
            }

            UpdateTimer.Stop();
            StartTime = DateTime.MinValue;
            StopwatchButton.BackColor = InactiveColor;

            try
            {
                if (Stopped != null) Stopped(this, EventArgs.Empty);
            }
            catch (Exception e) { MessageBox.Show("Error while handling Stopped event: " + e.Message); }
        }

        protected virtual void OnTimerTick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnTimerTick), sender, e);
                return;
            }

            if (ElapsedTime == TimeSpan.MinValue)
            {
                UpdateTimer.Stop();
                return;
            }
            else
            {
                StopwatchButton.Text = ElapsedTime.Minutes.ToString() + ":" + ElapsedTime.Seconds.ToString();
            }
        }

        protected virtual void OnStopwatchButtonClick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnStopwatchButtonClick), sender, e);
                return;
            }

            if (IsStopwatchActive)
                Stop();
            else if (!IsStopwatchReset)
                ResetStopwatch();
            else Start();
        }
    }
}
