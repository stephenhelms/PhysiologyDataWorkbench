using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    public partial class AddNewRecordingDialog : Form
    {
        private MacroscopicBumpExperiment _Experiment;

        public MacroscopicBumpExperiment Experiment
        {
            get { return _Experiment; }
            set { _Experiment = value; }
        }

        private PhysiologyDataSet.RecordingsRow _Recording;

        public PhysiologyDataSet.RecordingsRow Recording
        {
            get { return _Recording; }
            set { _Recording = value; }
        }

        private MacroscopicRecordingsDataSet.MacroscopicRecordingsRow _MacroscopicBump;

        public MacroscopicRecordingsDataSet.MacroscopicRecordingsRow MacroscopicBump
        {
            get { return _MacroscopicBump; }
            set { _MacroscopicBump = value; }
        }

        public AddNewRecordingDialog(MacroscopicBumpExperiment experiment, PhysiologyDataSet.RecordingsRow recording)
        {
            InitializeComponent();
            Experiment = experiment;
            Recording = recording;
        }

        protected override void OnLoad(EventArgs e)
        {
            MacroscopicBump =
                Experiment.MacroscopicBumpsDataSet.MacroscopicRecordings.NewMacroscopicRecordingsRow();
            MacroscopicBump.RecordingID = Recording.RecordingID;

            base.OnLoad(e);
        }

        private void OnAutoFitInMATLABClicked(object sender, EventArgs e)
        {
            Experiment.CalculateMacroscopicBumpFitInMatlab(MacroscopicBump);
        }

        protected virtual void OnCancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected virtual void OnAcceptClicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    MacroscopicBump.AnalysisDate = DateTime.Now;
                    MacroscopicBump.CalciumConcentration = Single.Parse(CalciumConcentrationTextBox.Text);
                    MacroscopicBump.RelativeLogIntensity = Single.Parse(RelativeLogIntensityTextBox.Text);
                    MacroscopicBump.Comments = CommentsTextBox.Text;

                    if (!KeepFitCheckBox.Checked)
                    {
                        MacroscopicBump.SetAmplitudeNull();
                        MacroscopicBump.SetChargeIntegralNull();
                        MacroscopicBump.SetFastActivationTimeNull();
                        MacroscopicBump.SetFastInactivationTimeNull();
                        MacroscopicBump.SetLatencyTimeNull();
                        MacroscopicBump.SetSlowActivationTimeNull();
                        MacroscopicBump.SetSlowInactivationTimeNull();
                        MacroscopicBump.SetTimeOfPeakNull();
                    }

                    Experiment.MacroscopicBumpsDataSet.MacroscopicRecordings.AddMacroscopicRecordingsRow(MacroscopicBump);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error entering recording");
                }
            }
        }
    }
}