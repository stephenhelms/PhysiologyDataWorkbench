using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyDataConnectivity;
using RRLab.Utilities;
using RRLab.PhysiologyDataWorkshop.Experiments;

namespace RRLab.PhysiologyDataWorkshop
{
    public partial class RecordingViewerPanel : UserControl
    {
        public event EventHandler ProgramChanged;
        private PhysiologyDataWorkshopProgram _Program;
        [Bindable(true)]
        public PhysiologyDataWorkshopProgram Program
        {
            get { return _Program; }
            set {
                if (Program != null)
                {
                    Program.DataSetChanged -= new EventHandler(OnDataSetChanged);
                    Program.LoadingDataFromDatabase -= new EventHandler(OnLoadingDataFromDatabase);
                    Program.FinishedLoadingDataFromDatabase -= new EventHandler(OnFinishedLoadingDataFromDatabase);
                    Program.UpdatingDatabase -= new EventHandler(OnLoadingDataFromDatabase);
                    Program.UpdatedDatabase -= new EventHandler(OnFinishedLoadingDataFromDatabase);
                }
                _Program = value;
                if (Program != null)
                {
                    ProgramBindingSource.DataSource = Program;
                    Program.DataSetChanged += new EventHandler(OnDataSetChanged);
                    Program.LoadingDataFromDatabase += new EventHandler(OnLoadingDataFromDatabase);
                    Program.FinishedLoadingDataFromDatabase += new EventHandler(OnFinishedLoadingDataFromDatabase);
                    Program.UpdatingDatabase += new EventHandler(OnLoadingDataFromDatabase);
                    Program.UpdatedDatabase += new EventHandler(OnFinishedLoadingDataFromDatabase);
                }
                else ProgramBindingSource.DataSource = typeof(PhysiologyDataWorkshopProgram);
                OnDataSetChanged(this, EventArgs.Empty);
                if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CurrentCellIDChanged;
        private int _CurrentCellID;
        [Bindable(true)]
        public int CurrentCellID
        {
            get { return _CurrentCellID; }
            set {
                _CurrentCellID = value;
                OnCurrentCellIDChanged(EventArgs.Empty);
            }
        }

        public event EventHandler CurrentRecordingIDChanged;
        private long _CurrentRecordingID;
        [Bindable(true)]
        public long CurrentRecordingID
        {
            get { return _CurrentRecordingID; }
            set {
                _CurrentRecordingID = value;
                OnCurrentRecordingIDChanged(EventArgs.Empty);
            }
        }
	

        public RecordingViewerPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Place splitter at 75%
            MainSplitContainer.SplitterDistance = Convert.ToInt32(MainSplitContainer.Width * 0.75);
            base.OnLoad(e);
        }

        protected virtual void OnDataSetChanged(object sender, EventArgs e)
        {
            if (Program != null && Program.DataSet != null)
            {
                CellsBindingSource.DataSource = Program.DataSet;
            }
            else
            {
                CellsBindingSource.DataSource = typeof(PhysiologyDataSet);
            }

            CheckIfControlShouldBeEnabled();
        }

        protected virtual void OnCurrentCellIDChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnCurrentCellIDChanged), e);
                return;
            }

            recordingsDropDownButton.DropDownItems.Clear();

            if(Program == null || Program.DataSet == null)
                return;

            // Update data source
            if(Program.DatabaseConnector != null)
                try
                {
                    ((MySqlDataManagerDatabaseConnector)Program.DatabaseConnector).LoadRecordingsFromDatabase(Program.DataSet, CurrentCellID);
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error updating cell data: " + x.Message);
                }

            // Update recordings drop down list
            PhysiologyDataSet.RecordingsRow[] recordings = Program.DataSet.Cells.FindByCellID(CurrentCellID).GetRecordingsRows();
            foreach (PhysiologyDataSet.RecordingsRow row in recordings)
            {
                string text = String.Format("{0} ({1})", row.Title, row.Recorded.ToString("g"));
                ToolStripMenuItem menu = new ToolStripMenuItem(text);
                menu.Tag = row.RecordingID;
                menu.Click += new EventHandler(OnSelectRecordingMenuItemClicked);
                recordingsDropDownButton.DropDownItems.Add(menu);
            }

            // Change binding source position
            int bsPosition = CellsBindingSource.Find("CellID", CurrentCellID);
            try
            {
                CellsBindingSource.Position = bsPosition;
                CellsBindingSource.ResetCurrentItem();
            }
            catch (Exception x)
            {
                MessageBox.Show("Unable to select cell " + CurrentCellID.ToString() + ": " + x.Message);
            }

            UpdateRecordingIndexLabel();
            CheckIfControlShouldBeEnabled();

            if(CurrentCellIDChanged != null)
                try
                {
                    CurrentCellIDChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        protected virtual void OnCurrentRecordingIDChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnCurrentRecordingIDChanged), e);
                return;
            }
            if(Program == null || Program.DataSet == null) return;

            ClearRecordingData();

            // Update binding source position
            int bsPosition = RecordingsBindingSource.Find("RecordingID", CurrentRecordingID);
            try
            {
                RecordingsBindingSource.Position = bsPosition;
                RecordingsBindingSource.ResetBindings(true);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error selecting recording " + CurrentRecordingID.ToString() + ": " + x.Message);
            }

            // Download recording data
            PhysiologyDataSet.RecordingsRow recording = Program.DataSet.Recordings.FindByRecordingID(CurrentRecordingID);
            if(recording != null)
                Program.BeginLoadRecordingAndSubdataFromDatabase(recording);

            UpdateRecordingIndexLabel();
            CheckIfControlShouldBeEnabled();

            System.GC.Collect();

            if(CurrentRecordingIDChanged != null)
                try {
                    CurrentRecordingIDChanged(this, e);
                }
                catch(Exception x) { ; }
        }

        protected virtual void OnLoadingDataFromDatabase(object sender, EventArgs e)
        {
            recordingDataGraphControl1.SuspendUpdates(); // Stop graph updates to prevent updating as data loads
        }
        protected virtual void OnFinishedLoadingDataFromDatabase(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnFinishedLoadingDataFromDatabase), sender, e);
                return;
            }

            recordingDataGraphControl1.ResumeUpdates();
            RecordingsBindingSource.ResetCurrentItem();
            UpdateActionList();
        }

        protected virtual void UpdateActionList()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateActionList));
                return;
            }

            ActionsDropDownButton.DropDownItems.Clear();

            List<IExperiment> experiments = new List<IExperiment>(Program.GetExperiments());
            foreach (IExperiment experiment in experiments)
            {
                ToolStripMenuItem experimentItem = new ToolStripMenuItem(experiment.Name);
                experimentItem.Tag = experiment;

                ActionsDropDownButton.DropDownItems.Add(experimentItem);
                foreach(KeyValuePair<string, Action<PhysiologyDataSet.RecordingsRow>> kv in experiment.RecordingActions) {
                    ToolStripMenuItem actionItem = new ToolStripMenuItem(kv.Key);
                    actionItem.Tag = kv.Value;

                    actionItem.Click += new EventHandler(delegate(object sender, EventArgs e) {
                        ToolStripDropDownItem control = sender as ToolStripDropDownItem;
                        if(control != null) {
                            Action<PhysiologyDataSet.RecordingsRow> action = control.Tag as Action<PhysiologyDataSet.RecordingsRow>;
                            if(action != null)
                                try {
                                    action.Invoke(this.Program.DataSet.Recordings.FindByRecordingID(CurrentRecordingID));
                                } catch(Exception x) {
                                    MessageBox.Show(x.Message);
                                }
                        }
                    });
                    actionItem.Enabled = experiment.IsRecordingActionEnabled(kv.Key, Program.DataSet.Recordings.FindByRecordingID(CurrentRecordingID));
                    experimentItem.DropDownItems.Add(actionItem);
                }
                foreach (KeyValuePair<string, Action<PhysiologyDataSet.CellsRow>> kv in experiment.CellActions)
                {
                    ToolStripMenuItem actionItem = new ToolStripMenuItem(kv.Key);
                    actionItem.Tag = kv.Value;

                    actionItem.Click += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        ToolStripDropDownItem control = sender as ToolStripDropDownItem;
                        if (control != null)
                        {
                            Action<PhysiologyDataSet.CellsRow> action = control.Tag as Action<PhysiologyDataSet.CellsRow>;
                            if (action != null)
                                try
                                {
                                    action.Invoke(this.Program.DataSet.Cells.FindByCellID(CurrentCellID));
                                }
                                catch (Exception x)
                                {
                                    MessageBox.Show(x.Message);
                                }
                        }
                    });
                    actionItem.Enabled = experiment.IsCellActionEnabled(kv.Key, Program.DataSet.Cells.FindByCellID(CurrentCellID));
                    experimentItem.DropDownItems.Add(actionItem);
                }
            }
        }

        protected virtual void UpdateRecordingIndexLabel()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateRecordingIndexLabel));
                return;
            }

            RecordingIndexToolStripLabel.Text = String.Format("{0} of {1}", RecordingsBindingSource.Position, RecordingsBindingSource.Count);
            recordingIDLabel.Text = String.Format("{0}-{1}", Program.CurrentCellID, Program.CurrentRecordingID);
        }

        protected virtual void CheckIfControlShouldBeEnabled()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(CheckIfControlShouldBeEnabled));
                return;
            }

            if (Program == null || Program.DataSet == null ||
                (!(RecordingsBindingSource.Current is DataRowView) && !(CellsBindingSource.Current is DataRowView)))
                Enabled = false;
            else Enabled = true;
        }

        protected virtual void OnSelectRecordingMenuItemClicked(object sender, EventArgs e)
        {
            try
            {
                this.CurrentRecordingID = (long)((ToolStripMenuItem)sender).Tag;
            }
            catch (Exception x) { MessageBox.Show("Error selecting recording: " + x.Message); }
        }

        protected virtual void OnPreviousRecordingClicked(object sender, EventArgs e)
        {
            RecordingsBindingSource.MovePrevious();
            this.CurrentRecordingID = ((RecordingsBindingSource.Current as DataRowView).Row as PhysiologyDataSet.RecordingsRow).RecordingID;
        }

        protected virtual void OnNextRecordingClicked(object sender, EventArgs e)
        {
            RecordingsBindingSource.MoveNext();
            this.CurrentRecordingID = ((RecordingsBindingSource.Current as DataRowView).Row as PhysiologyDataSet.RecordingsRow).RecordingID;
        }

        protected virtual void ClearRecordingData()
        {
            if (Program == null || Program.DataSet == null) return;

            DataRow[] newRows = Program.DataSet.Recordings_Data.Select(null, null, DataViewRowState.Added);
            Program.DataSet.Recordings_Data.BeginLoadData();
            Program.DataSet.Recordings_Data.Clear();
            foreach (DataRow row in newRows)
            {
                Program.DataSet.Recordings_Data.ImportRow(row);
            }
            Program.DataSet.Recordings_Data.EndLoadData();
        }

        private void OnUpdateClicked(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Visible))
            {
                CellsBindingSource.EndEdit();
                RecordingsBindingSource.EndEdit();
                ProgressDialog progressDialog = new ProgressDialog();
                progressDialog.Show();
                ((MySqlDataManagerDatabaseConnector)Program.DatabaseConnector).BeginUpdateCellAndSubdataToDatabase(Program.DataSet, CurrentCellID, progressDialog);
            }
        }

        private void OnExportToMatlabClicked(object sender, EventArgs e)
        {
            Program.ExportRecordingToMatlab(Program.DataSet.Recordings.FindByRecordingID(CurrentRecordingID));
        }
    }
}
