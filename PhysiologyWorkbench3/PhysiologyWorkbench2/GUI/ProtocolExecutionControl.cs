using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class ProtocolExecutionControl : UserControl
    {
        public event EventHandler DataManagerChanged;
        private DataManager _DataManager;
        [Bindable(true)]
        public DataManager DataManager
        {
            get { return _DataManager; }
            set
            {
                _DataManager = value;
                if (DataManagerChanged != null) DataManagerChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler ProtocolChanged;

        private DaqProtocol _Protocol;
        [Bindable(true)]
        public DaqProtocol Protocol
        {
            get { return _Protocol; }
            set
            {
                if (Protocol != null)
                {
                    Protocol.Starting -= new EventHandler(OnProtocolStarted);
                    Protocol.Finished -= new EventHandler(OnProtocolFinished);
                    Protocol.DataChanged -= new EventHandler(OnProtocolDataUpdated);
                }
                _Protocol = value;
                if (Protocol != null)
                {
                    CheckProtocolSupport();
                    Protocol.Starting += new EventHandler(OnProtocolStarted);
                    Protocol.Finished += new EventHandler(OnProtocolFinished);
                    Protocol.DataChanged += new EventHandler(OnProtocolDataUpdated);
                }
                if (ProtocolChanged != null) ProtocolChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler StoppedColorChanged;

        private Color _StoppedColor = Color.LawnGreen;

        public Color StoppedColor
        {
            get { return _StoppedColor; }
            set {
                _StoppedColor = value;
                if (StoppedColorChanged != null) StoppedColorChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler RunningColorChanged;

        private Color _RunningColor;

        public Color RunningColor
        {
            get { return _RunningColor; }
            set {
                _RunningColor = value;
                if (RunningColorChanged != null) RunningColorChanged(this, EventArgs.Empty);
            }
        }

        protected bool IsProtocolRunning = false;

        public ProtocolExecutionControl()
        {
            InitializeComponent();
            CheckProtocolSupport();
            StartContButton.BackColor = StoppedColor;
            RunButton.BackColor = StoppedColor;
            Disposed += new EventHandler(OnDisposing);
        }

        protected virtual void CheckProtocolSupport()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(CheckProtocolSupport));
                return;
            }
            if (Protocol == null)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
                RunButton.Enabled = true;
                if (Protocol.IsContinuousRecordingSupported)
                    StartContButton.Enabled = true;
                else
                    StartContButton.Enabled = false;
            }
        }
        protected virtual void OnProtocolStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnProtocolStarted), sender, e);
                return;
            }
            IsProtocolRunning = true;
            RunButton.Enabled = false;
            StartContButton.Text = "Stop";
            StartContButton.BackColor = RunningColor;
            TrashButton.Enabled = false;
        }
        protected virtual void OnProtocolFinished(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnProtocolFinished), sender, e);
                return;
            }
            IsProtocolRunning = false;
            RunButton.Enabled = true;
            StartContButton.Text = "Start";
            StartContButton.BackColor = StoppedColor;
            TrashButton.Enabled = true;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadStart run = new System.Threading.ThreadStart(Protocol.Run);
            System.Threading.Thread runThread = new System.Threading.Thread(run);
            GC.Collect();
            runThread.Start();
        }

        private void StartContButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsProtocolRunning)
                    Protocol.StopContinuousExecute();
                else
                {
                    GC.Collect();
                    Protocol.StartContinuousExecute();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error while executing protocol:" + x.Message);
            }
        }

        private void TrashButton_Click(object sender, EventArgs e)
        {
            if (DataManager == null) return;

            if (InvokeRequired)
            {
                Invoke(new EventHandler(TrashButton_Click), sender, e);
                return;
            }

            try
            {
                Protocol.Data.Delete();
                Protocol.Data.AcceptChanges();
                TrashButton.Enabled = false;
            }
            catch (Exception x)
            {
                MessageBox.Show("Error trashing data: " + x.Message);
            }
        }

        protected virtual void OnProtocolDataUpdated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnProtocolDataUpdated), sender, e);
                return;
            }

            if (DataManager == null || (Protocol == null) || (Protocol.Data == null))
                return;

            try
            {
                TrashButton.Enabled = true;
            }
            catch (Exception x)
            {
                MessageBox.Show("Error storing data: " + x.Message);
            }
        }

        protected virtual void OnDisposing(object sender, EventArgs e)
        {
            if (Protocol != null) Protocol.Dispose();
        }
    }
}
