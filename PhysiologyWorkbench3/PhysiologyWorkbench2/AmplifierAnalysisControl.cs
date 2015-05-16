using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class AmplifierAnalysisControl : UserControl
    {
        public event EventHandler RecordingChanged;
        
        private Recording _Recording;
        [Bindable(true)]
        public Recording Recording
        {
            get { return _Recording; }
            set {
                if (Recording != null) Recording.MetaDataChanged -= new EventHandler(OnRecordingMetaDataUpdated);
                _Recording = value;
                if (Recording != null) Recording.MetaDataChanged += new EventHandler(OnRecordingMetaDataUpdated);
                if (RecordingChanged != null) RecordingChanged(this, EventArgs.Empty);
            }
        }
	
	

        public AmplifierAnalysisControl()
        {
            InitializeComponent();
        }

        protected virtual void OnRecordingMetaDataUpdated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRecordingMetaDataUpdated), sender, e);
                return;
            }

            if (Recording == null)
            {
                BaselineCurrentTextBox.Text = "";
                PeakCurrentTextBox.Text = "";
                StDevTextBox.Text = "";
            }
            else
            {
                if (Recording.MetaData.ContainsKey("BaselineCurrent"))
                    BaselineCurrentTextBox.Text = Recording.MetaData["BaselineCurrent"];
                else BaselineCurrentTextBox.Text = "";

                if (Recording.MetaData.ContainsKey("PeakCurrent"))
                    PeakCurrentTextBox.Text = Recording.MetaData["PeakCurrent"];
                else PeakCurrentTextBox.Text = "";

                if (Recording.MetaData.ContainsKey("CurrentNoise"))
                    StDevTextBox.Text = Recording.MetaData["CurrentNoise"];
                else StDevTextBox.Text = "";
            }
        }
    }
}
