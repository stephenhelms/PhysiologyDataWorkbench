using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataWorkshop.Experiments.CalciumImaging
{
    public partial class AddNewCalciumExperimentDialog : Form
    {
        public event EventHandler ExperimentChanged;
        private CalciumImagingExperiment _Experiment;

        public CalciumImagingExperiment Experiment
        {
            get { return _Experiment; }
            set {
                _Experiment = value;
                OnExperimentChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnExperimentChanged(EventArgs e)
        {
            if (Experiment != null && Experiment.SteadyStateCalciumDataSet != null)
                ExperimentBindingSource.DataSource = Experiment.SteadyStateCalciumDataSet;
            else ExperimentBindingSource.DataSource = typeof(SteadyStateCalciumDataSet);

            if (ExperimentChanged != null)
                try
                {
                    ExperimentChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during ExperimentChanged event.", x.Message);
                }
        }

        public event EventHandler ExperimentRowChanged;
        private SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow _ExperimentRow;

        public SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow ExperimentRow
        {
            get { return _ExperimentRow; }
            set {
                _ExperimentRow = value;
                OnExperimentRowChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnExperimentRowChanged(EventArgs e)
        {
            int position = ExperimentBindingSource.Find("CellID", ExperimentRow.CellID);
            //System.Diagnostics.Debug.Assert(position >= 0, "AddNewCalciumExperimentDialog: Couldn't find experiment row.");
            ExperimentBindingSource.Position = position;
            ExperimentBindingSource.ResetBindings(false);

            if(ExperimentRowChanged != null)
                try
                {
                    ExperimentRowChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during ExperimentRowChanged event.", x.Message);
                }
        }

        

        public AddNewCalciumExperimentDialog(CalciumImagingExperiment experiment, SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow experimentRow)
        {
            InitializeComponent();
            Experiment = experiment;
            ExperimentRow = experimentRow;
        }

        protected virtual void OnAutoAnalyzeClicked(object sender, EventArgs e)
        {
            try
            {
                float steadyStateTime = Single.Parse(SteadyStateTimeTextBox.Text);
                int nPeaks = Int32.Parse(NumberOfPeaksTextBox.Text);

                Experiment.AnalyzeExperiment(ExperimentRow, steadyStateTime, nPeaks);
                MessageBox.Show("Data successfully analyzed.");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error analyzing data.");
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            float calcium = Single.Parse(textBox4.Text);
            ExperimentRow.CalciumConcentration = calcium;
            ExperimentRow.Comments = textBox5.Text;
            ExperimentRow.IsDarkAdapted = checkBox1.Checked;
            Experiment.AddExperiment(ExperimentRow);
            this.Close();
        }
    }
}