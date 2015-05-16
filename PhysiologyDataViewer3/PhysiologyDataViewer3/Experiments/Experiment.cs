using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.Utilities;
using RRLab.PhysiologyDataConnectivity;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataWorkshop.Experiments
{
    /// <summary>
    /// An abstract implementation of IExperiment providing property management
    /// features.
    /// </summary>
    public abstract class Experiment : IExperiment, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Call Initialize.
        /// </summary>
        public Experiment()
        {
            Initialize();
        }

        #region IExperiment Members

        public event EventHandler NameChanged;

        /// <summary>
        /// Gets the type name by default.
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Fires the NameChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNameChanged(EventArgs e)
        {
            if(NameChanged != null)
                try
                {
                    NameChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("ExperimentRow: Error during NameChanged event.", x.Message);
                }
        }

        public event EventHandler ProgramChanged;

        private PhysiologyDataWorkshopProgram _Program;
        
        public PhysiologyDataWorkshopProgram Program
        {
            get
            {
                return _Program;
            }
            set
            {
                _Program = value;
                OnProgramChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the ProgramChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnProgramChanged(EventArgs e)
        {
            if (ProgramChanged != null)
                try
                {
                    ProgramChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("ExperimentRow: Error during ProgramChanged event.", x.Message);
                }
        }

        
        public event EventHandler PhysiologyDataSetChanged;

        private PhysiologyDataSet _PhysiologyDataSet;

        public PhysiologyDataSet PhysiologyDataSet
        {
            get
            {
                return _PhysiologyDataSet;
            }
            set
            {
                _PhysiologyDataSet = value;
                OnPhysiologyDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnPhysiologyDataSetChanged(EventArgs e)
        {
            if(PhysiologyDataSetChanged != null)
                try
                {
                    PhysiologyDataSetChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during PhysiologyDataSetChanged event.", x.Message);
                }
        }

        public event EventHandler CellActionsChanged;

        private SortedList<string, Action<RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.CellsRow>> _CellActions = new SortedList<string, Action<PhysiologyDataSet.CellsRow>>();

        public virtual IDictionary<string, Action<RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.CellsRow>> CellActions
        {
            get { return _CellActions; }
        }

        /// <summary>
        /// Fires the CellActionsChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCellActionsChanged(EventArgs e)
        {
            if(CellActionsChanged != null)
                try
                {
                    CellActionsChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("ExperimentRow: Error during CellActionsChanged event.", x.Message);
                }
        }

        public event EventHandler RecordingActionsChanged;

        private SortedList<string, Action<RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.RecordingsRow>> _RecordingActions = new SortedList<string, Action<PhysiologyDataSet.RecordingsRow>>();

        public virtual IDictionary<string, Action<RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.RecordingsRow>> RecordingActions
        {
            get { return _RecordingActions; }
        }

        /// <summary>
        /// Fires the RecordingActionsChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRecordingActionsChanged(EventArgs e)
        {
            if (RecordingActionsChanged != null)
                try
                {
                    RecordingActionsChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("ExperimentRow: Error during the RecordingActionsChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Returns true by default.
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        public virtual bool IsCellActionEnabled(string actionName, RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.CellsRow cell)
        {
            return true;
        }

        /// <summary>
        /// Returns true by default.
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="recording"></param>
        /// <returns></returns>
        public virtual bool IsRecordingActionEnabled(string actionName, RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.RecordingsRow recording)
        {
            return true;
        }

        /// <summary>
        /// Returns an empty panel by default.
        /// </summary>
        /// <returns></returns>
        public virtual System.Windows.Forms.Control GetExperimentPanelControl()
        {
            return new System.Windows.Forms.Panel();
        }

        #endregion

        /// <summary>
        /// Initializes the experiment object by configuring cell and recording actions.
        /// </summary>
        protected virtual void Initialize()
        {
            ConfigureCellActions();
            ConfigureRecordingActions();
        }

        protected virtual void ConfigureCellActions()
        {
            OnCellActionsChanged(EventArgs.Empty);
        }

        protected virtual void ConfigureRecordingActions()
        {
            OnRecordingActionsChanged(EventArgs.Empty);
        }

        #region INotifyPropertyChanged Members

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                try
                {
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("ExperimentRow: Error during PropertyChanged event.", x.Message);
                }
        }

        #endregion

        #region Database

        public event EventHandler RecordingDataLoaded;

        public virtual void LoadRecordingFromDatabase(long recordingID)
        {
            // Download recording data
            if (Program != null && Program.DatabaseConnector != null)
            {
                try
                {
                    ProgressDialog dialog = new ProgressDialog();
                    dialog.TaskStopped += new EventHandler(delegate(object sender, EventArgs x)
                    {
                        OnRecordingDataLoaded(EventArgs.Empty);
                    });
                    dialog.Show();
                    ((MySqlDataManagerDatabaseConnector)Program.DatabaseConnector).BeginLoadRecordingSubdataFromDatabase(PhysiologyDataSet, recordingID, dialog);
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error updating recording data: " + x.Message);
                }
            }
        }

        protected virtual void OnRecordingDataLoaded(EventArgs e)
        {
            if (RecordingDataLoaded != null)
                try
                {
                    RecordingDataLoaded(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("ExperimentRow: Error during RecordingDataLoaded event.", x.Message);
                }
        }

        #endregion
    }
}
