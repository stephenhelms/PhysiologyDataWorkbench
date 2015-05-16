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
        // TODO: Fix!!! Needs to update the display	

        public event EventHandler RecordingChanged;

        private PhysiologyDataSet.RecordingsRow _Recording;
        [Bindable(true)]
        public PhysiologyDataSet.RecordingsRow Recording
        {
            get { return _Recording; }
            set {
                _Recording = value;
                if (RecordingChanged != null) RecordingChanged(this, EventArgs.Empty);
                RefreshData();
            }
        }
	

        public AmplifierAnalysisControl()
        {
            InitializeComponent();
        }

        public virtual void RefreshData()
        {
            string baseline = "";
            string peak = "";
            string noise = "";

            // Get the data
            if (Recording != null)
            {
                lock (Recording.PhysiologyDataSet)
                {
                    if (Recording.DoesMetaDataExist("BaselineCurrent"))
                        baseline = Recording.GetMetaData("BaselineCurrent");
                    else BaselineCurrentTextBox.Text = "";

                    if (Recording.DoesMetaDataExist("PeakCurrent"))
                        peak = Recording.GetMetaData("PeakCurrent");
                    else PeakCurrentTextBox.Text = "";

                    if (Recording.DoesMetaDataExist("CurrentNoise"))
                        noise = Recording.GetMetaData("CurrentNoise");
                    else StDevTextBox.Text = "";
                }
            }

            SetDataDisplayed(baseline, peak, noise); // Update the display
        }

        private delegate void ThreeArgs<T>(T arg1, T arg2, T arg3);
        protected virtual void SetDataDisplayed(string baseline, string peak, string noise)
        {
            if (InvokeRequired)
            {
                Invoke(new ThreeArgs<string>(SetDataDisplayed), baseline, peak, noise);
                return;
            }

            BaselineCurrentTextBox.Text = baseline;
            PeakCurrentTextBox.Text = peak;
            StDevTextBox.Text = noise;
        }
    }
}
