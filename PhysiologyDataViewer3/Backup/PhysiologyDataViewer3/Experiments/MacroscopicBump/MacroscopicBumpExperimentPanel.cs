using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    public partial class MacroscopicBumpExperimentPanel : UserControl
    {
        public event EventHandler ExperimentChanged;
        private MacroscopicBumpExperiment _Experiment;

        public MacroscopicBumpExperiment Experiment
        {
            get { return _Experiment; }
            set
            {
                if (Experiment != null)
                {
                    Experiment.MacroscopicBumpsDataSetChanged -= new EventHandler(OnMacroscopicBumpsDataSetChanged);
                    Experiment.RecordingDataLoaded -= new EventHandler(OnRecordingDataLoaded);
                }
                _Experiment = value;
                if (Experiment != null)
                {
                    Experiment.MacroscopicBumpsDataSetChanged += new EventHandler(OnMacroscopicBumpsDataSetChanged);
                    Experiment.RecordingDataLoaded += new EventHandler(OnRecordingDataLoaded);
                }
                OnExperimentChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnMacroscopicBumpsDataSetChanged(object sender, EventArgs e)
        {
            if(Experiment.MacroscopicBumpsDataSet != null)
                MacroscopicBumpBindingSource.DataSource = Experiment.MacroscopicBumpsDataSet;
            else MacroscopicBumpBindingSource.DataSource = typeof(MacroscopicRecordingsDataSet);
        }

        protected virtual void OnRecordingDataLoaded(object sender, EventArgs e)
        {
            MacroscopicBumpViewerControl.RefreshGraph();
        }

        /// <summary>
        /// Fires the experiment changed event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExperimentChanged(EventArgs e)
        {
            if (Experiment != null)
                ExperimentBindingSource.DataSource = Experiment;
            else ExperimentBindingSource.DataSource = typeof(MacroscopicBumpExperiment);

            if (ExperimentChanged != null)
                try
                {
                    ExperimentChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("MacroscopicBumpExperimentPanel: Error during ExperimentRowChanged event.");
                }
        }


        public MacroscopicBumpExperimentPanel()
        {
            InitializeComponent();
        }
        public MacroscopicBumpExperimentPanel(MacroscopicBumpExperiment experiment)
        {
            InitializeComponent();
            Experiment = experiment;
        }

        protected override void OnLoad(EventArgs e)
        {
            HistogramColumnComboBox.Items.AddRange(System.Collections.ArrayList.Adapter(MacroscopicBumpBindingSource.GetItemProperties(null)).ToArray());
            base.OnLoad(e);
        }

        private void OnLoadDataFromDatabaseClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(Experiment != null, "MacroscopicBumpExperimentPanel@OnLoadDataFromDatabaseClicked: ExperimentRow is null.");

            Experiment.LoadDataFromDatabase();
        }

        protected virtual void OnCurrentMacroscopicBumpRecordingGridViewCellChanged(object sender, EventArgs e)
        {
            if (MacroscopicBumpsDataGridView.CurrentCell == null)
            {
                Experiment.CurrentMacroscopicBump = null;
                return;
            }

            DataGridViewRow row = MacroscopicBumpsDataGridView.CurrentCell.OwningRow;
            if (row != null)
                try
                {
                    Experiment.CurrentMacroscopicBump = Experiment.MacroscopicBumpsDataSet.MacroscopicRecordings.FindByRecordingID(
                        (long)row.Cells["recordingIDDataGridViewTextBoxColumn"].Value);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.WriteLine("MacroscopicBumpExperimentPanel: Error while trying to set CurrentMacroscopicBump: " + x.Message);
                }
            else Experiment.CurrentMacroscopicBump = null;
        }

        private void OnViewCellRecordingDetailsClicked(object sender, EventArgs e)
        {
            if (Experiment.CurrentMacroscopicBump == null) return;

            Experiment.Program.CurrentCellID = Experiment.CurrentMacroscopicBump.CellID;
            Experiment.Program.CurrentRecordingID = Experiment.CurrentMacroscopicBump.RecordingID;
        }

        private void calcAvgResponseButton_Click(object sender, EventArgs e)
        {
            CalculateAverageResponseDialog dialog = new CalculateAverageResponseDialog(Experiment);
            dialog.Show();
        }
    }
}
