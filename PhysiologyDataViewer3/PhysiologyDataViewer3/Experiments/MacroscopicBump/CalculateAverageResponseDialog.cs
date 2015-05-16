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
    public partial class CalculateAverageResponseDialog : Form
    {
        private MacroscopicBumpExperiment _Experiment;

        public MacroscopicBumpExperiment Experiment
        {
            get { return _Experiment; }
            set { _Experiment = value; }
        }
	

        public CalculateAverageResponseDialog(MacroscopicBumpExperiment experiment)
        {
            InitializeComponent();
            Experiment = experiment;
        }

        

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                TimeResolvedData averaged = Experiment.GetAverageMacroscopicResponse(filterTextBox.Text, AdjustBaselineCheckBox.Checked, NormalizeAmplitudeCheckBox.Checked);
                MLApp.MLApp matlab = (MLApp.MLApp)Activator.CreateInstance(Type.GetTypeFromProgID("Matlab.Desktop.Application"));
                matlab.Visible = 1;
                matlab.PutWorkspaceData("averaged_response_time", "base", averaged.Time);
                matlab.PutWorkspaceData("averaged_response", "base", averaged.Values);
                matlab.PutCharArray("averaged_response_filter", "base", filterTextBox.Text);
                matlab.Execute("plot(averaged_response_time,averaged_response)");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception x)
            {
                DialogResult = DialogResult.Abort;
                Close();
                MessageBox.Show(x.Message);
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CalculateForEachGenotype_Click(object sender, EventArgs e)
        {
            MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[] rows = Experiment.MacroscopicBumpsDataSet.MacroscopicRecordings.Select(filterTextBox.Text) as MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[];
            List<string> genotypes = new List<string>();
            foreach (MacroscopicRecordingsDataSet.MacroscopicRecordingsRow row in rows)
                if (!genotypes.Contains(row.Genotype))
                    genotypes.Add(row.Genotype);

            MLApp.MLApp matlab = null;

            foreach (string genotype in genotypes)
            {
                try
                {
                    if (matlab == null)
                    {
                        matlab = (MLApp.MLApp)Activator.CreateInstance(Type.GetTypeFromProgID("Matlab.Desktop.Application"));
                        matlab.Execute("figure;hold on");
                    }

                    TimeResolvedData averaged = Experiment.GetAverageMacroscopicResponse(filterTextBox.Text + " AND Genotype = '" + genotype + "'", AdjustBaselineCheckBox.Checked, NormalizeAmplitudeCheckBox.Checked);

                    string safeGenotype = genotype.Replace(' ', '_').Replace(';', '_');
                    matlab.Visible = 1;
                    matlab.PutWorkspaceData("averaged_response_" + safeGenotype + "_time", "base", averaged.Time);
                    matlab.PutWorkspaceData("averaged_response_" + safeGenotype, "base", averaged.Values);
                    matlab.PutCharArray("averaged_response_filter", "base", filterTextBox.Text);
                    matlab.Execute(String.Format("plot(averaged_response_{0}_time,averaged_response_{0})",safeGenotype));
                }
                catch (Exception x)
                {
                    DialogResult = DialogResult.Abort;
                    Close();
                    MessageBox.Show(x.Message);
                }
            }

            if (matlab != null) matlab.Execute("hold off");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[] rows = Experiment.MacroscopicBumpsDataSet.MacroscopicRecordings.Select(filterTextBox.Text) as MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[];
            List<int> cellIDs = new List<int>();
            foreach (MacroscopicRecordingsDataSet.MacroscopicRecordingsRow row in rows)
                if (!cellIDs.Contains(row.CellID))
                    cellIDs.Add(row.CellID);

            MLApp.MLApp matlab = null;

            foreach (int cellID in cellIDs)
            {
                try
                {
                    if (matlab == null)
                    {
                        matlab = (MLApp.MLApp)Activator.CreateInstance(Type.GetTypeFromProgID("Matlab.Desktop.Application"));
                        matlab.Execute("figure;hold on");
                    }

                    TimeResolvedData averaged = Experiment.GetAverageMacroscopicResponse(filterTextBox.Text + " AND CellID = " + cellID, AdjustBaselineCheckBox.Checked, NormalizeAmplitudeCheckBox.Checked);

                    matlab.Visible = 1;
                    matlab.PutWorkspaceData("averaged_response_" + cellID.ToString() + "_time", "base", averaged.Time);
                    matlab.PutWorkspaceData("averaged_response_" + cellID.ToString(), "base", averaged.Values);
                    matlab.PutCharArray("averaged_response_filter", "base", filterTextBox.Text);
                    matlab.Execute(String.Format("plot(averaged_response_{0}_time,averaged_response_{0})", cellID));
                }
                catch (Exception x)
                {
                    DialogResult = DialogResult.Abort;
                    Close();
                    MessageBox.Show(x.Message);
                }
            }

            if (matlab != null) matlab.Execute("hold off");

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}