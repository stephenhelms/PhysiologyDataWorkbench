using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataWorkshop.Experiments.CalciumImaging
{
    public partial class CalciumImagingPanelControl : UserControl
    {
        public event EventHandler ExperimentChanged;
        private CalciumImagingExperiment _Experiment;

        public CalciumImagingExperiment Experiment
        {
            get { return _Experiment; }
            set
            {
                if (Experiment != null)
                {
                    Experiment.SteadyStateCalciumDataSetChanged -= new EventHandler(OnSteadyStateCalciumDataSetChanged);
                    Experiment.RecordingDataLoaded -= new EventHandler(OnRecordingDataLoaded);
                }
                _Experiment = value;
                if (Experiment != null)
                {
                    Experiment.SteadyStateCalciumDataSetChanged += new EventHandler(OnSteadyStateCalciumDataSetChanged);
                    Experiment.RecordingDataLoaded += new EventHandler(OnRecordingDataLoaded);
                }
                OnExperimentChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnSteadyStateCalciumDataSetChanged(object sender, EventArgs e)
        {
            if (Experiment.SteadyStateCalciumDataSet != null)
                ExperimentDataSetBindingSource.DataSource = Experiment.SteadyStateCalciumDataSet;
            else ExperimentDataSetBindingSource.DataSource = typeof(SteadyStateCalciumDataSet);
        }

        protected virtual void OnRecordingDataLoaded(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Fires the experiment changed event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExperimentChanged(EventArgs e)
        {
            if (Experiment != null)
                ExperimentBindingSource.DataSource = Experiment;
            else ExperimentBindingSource.DataSource = typeof(CalciumImagingExperiment);

            if (ExperimentChanged != null)
                try
                {
                    ExperimentChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("CalciumImagingPanelControl: Error during ExperimentRowChanged event.");
                }
        }

        public CalciumImagingPanelControl(CalciumImagingExperiment experiment)
        {
            InitializeComponent();
            Experiment = experiment;
        }

        protected override void OnLoad(EventArgs e)
        {
            HistogramColumnComboBox.Items.AddRange(System.Collections.ArrayList.Adapter(ExperimentDataSetBindingSource.GetItemProperties(null)).ToArray());
            base.OnLoad(e);
        }

        private void OnLoadDataFromDatabaseClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(Experiment != null, "CalciumImagingPanelControl@OnLoadDataFromDatabaseClicked: ExperimentRow is null.");

            Experiment.LoadDataFromDatabase();
        }

        protected virtual void OnCurrentExperimentGridViewCellChanged(object sender, EventArgs e)
        {
            if (ExperimentsDataGridView.CurrentCell == null)
            {
                Experiment.CurrentSteadyStateCalciumExperiment = null;
                return;
            }

            DataGridViewRow row = ExperimentsDataGridView.CurrentCell.OwningRow;
            if (row != null)
                try
                {
                    Experiment.CurrentSteadyStateCalciumExperiment = Experiment.SteadyStateCalciumDataSet.SteadyStateCalciumExperiments.FindByCellID(
                        (int)row.Cells["cellIDDataGridViewTextBoxColumn"].Value);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.WriteLine("CalciumImagingPanelControl: Error while trying to set CurrentSteadyStateCalciumExperiment: " + x.Message);
                }
            else Experiment.CurrentSteadyStateCalciumExperiment = null;
        }

        private void OnExperimentsFilterTextChanged(object sender, EventArgs e)
        {
            try
            {
                ExperimentDataSetBindingSource.Filter = ExperimentsFilterTextBox.Text;
            }
            catch (Exception x)
            {
                ;
            }
        }

        private void OnViewCellRecordingDetailsClicked(object sender, EventArgs e)
        {
            if (Experiment.CurrentSteadyStateCalciumExperiment == null) return;

            Experiment.Program.CurrentCellID = Experiment.CurrentSteadyStateCalciumExperiment.CellID;
            Experiment.Program.CurrentRecordingID = Experiment.CurrentSteadyStateCalciumExperiment.SignalRecordingID;
        }

        private void OnLoadDataClicked(object sender, EventArgs e)
        {
            Experiment.LoadDataFromDatabase();
        }

        private void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            Experiment.UpdateDataToDatabase();
        }

        private void ReanalyzeExptButton_Click(object sender, EventArgs e)
        {
            AddNewCalciumExperimentDialog dialog = new AddNewCalciumExperimentDialog(Experiment, Experiment.CurrentSteadyStateCalciumExperiment);
            dialog.Show();
        }
    }
}
