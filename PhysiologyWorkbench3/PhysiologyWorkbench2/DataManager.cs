using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RRLab.PhysiologyDataConnectivity;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.Utilities;
using System.IO;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench
{
    /// <summary>
    /// Handles data management tasks.
    /// </summary>
    public partial class DataManager : Component
    {
        public enum DataTemplateMode { Manual, UsePreviousItem };

        public event EventHandler CellUpdated;
        public event EventHandler CellRemoved;
        public event EventHandler CellStored;

        public event EventHandler RecordingUpdated;
        public event EventHandler RecordingRemoved;
        public event EventHandler RecordingStored;
        
        public event EventHandler DataUpdated;
        public event EventHandler DataStored;
        public event EventHandler<ExceptionEventArgs> DataStorageError;

        public DataManager()
        {
            InitializeComponent();

            
        }

        public DataManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Properties
        /// <summary>
        /// The dataset has been changed.
        /// </summary>
        public event EventHandler DataChanged;

        private PhysiologyDataSet _Data = new PhysiologyDataSet();
        /// <summary>
        /// A dataset containing all the collected data.
        /// </summary>
        public PhysiologyDataSet Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
                OnDataChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DataChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataChanged(EventArgs e)
        {
            if (DataChanged != null)
                try
                {
                    DataChanged(this, e);
                }
                catch(Exception x) {
                    Console.WriteLine("Error during DataChanged event: " + x.Message);
                }
        }

        #endregion

        #region State Management
        
        /// <summary>
        /// Initializes the DataManager by loading recovery data and retrieving initial data from the database
        /// </summary>
        public virtual void Initialize()
        {
            // Generate initial dataset
            if (DatabaseConnector != null) NewDataSetFromDatabase();
            else NewDataSet();
            
            // Restore recovery file data
            RestoreRecoveryFile();

            // Register application exit listener
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            OnApplicationExit(e);
        }

        /// <summary>
        /// Finalizes the DataManager by saving data
        /// </summary>
        protected virtual void OnApplicationExit(EventArgs e)
        {
            IsExiting = true;

            if (DatabaseConnector != null)
            {
                UpdateAllToDatabase();
            }
            else SaveRecoveryFile();
        }
        
        #endregion

        #region Current Cell/Recording Management

        /// <summary>
        /// Occurs when the cell template mode is changed.
        /// </summary>
        public event EventHandler CellTemplateModeChanged;
        private DataManager.DataTemplateMode _CellTemplateMode = DataTemplateMode.UsePreviousItem;
        /// <summary>
        /// Determines how the source template for new cells is chosen.
        /// </summary>
        [DefaultValue(DataManager.DataTemplateMode.UsePreviousItem)]
        [SettingsBindable(true)]
        public DataManager.DataTemplateMode CellTemplateMode
        {
            get { return _CellTemplateMode; }
            set
            {
                _CellTemplateMode = value;
                OnCellTemplateModeChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the CellTemplateModeChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCellTemplateModeChanged(EventArgs e)
        {
            if (CellTemplateModeChanged != null)
                try
                {
                    CellTemplateModeChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during CellTemplateModeChanged event: " + x.Message);
                }
        }

        public event EventHandler RecordingTemplateModeChanged;
        private DataManager.DataTemplateMode _RecordingTemplateMode = DataTemplateMode.UsePreviousItem;
        /// <summary>
        /// Determines how the source template for new recordings is chosen.
        /// </summary>
        [DefaultValue(DataManager.DataTemplateMode.UsePreviousItem)]
        [SettingsBindable(true)]
        public DataManager.DataTemplateMode RecordingTemplateMode
        {
            get { return _RecordingTemplateMode; }
            set
            {
                _RecordingTemplateMode = value;
                OnRecordingTemplateModeChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the RecordingTemplateModeChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRecordingTemplateModeChanged(EventArgs e)
        {
            if (RecordingTemplateChanged != null)
                try
                {
                    RecordingTemplateChanged(this, EventArgs.Empty);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during TemplateRecordingChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the current Recording is changed.
        /// </summary>
        public event EventHandler CurrentRecordingChanged;
        private PhysiologyDataSet.RecordingsRow _CurrentRecording = null;
        /// <summary>
        /// Gets or sets the current Recording by its row in the dataset.
        /// If the row's dataset is not the same as the current dataset,
        /// DataManager.Data will be changed accordingly. Acts by setting
        /// the CurrentRecording property.
        /// </summary>
        [Bindable(true)]
        public PhysiologyDataSet.RecordingsRow CurrentRecording
        {
            get { return _CurrentRecording; }
            set
            {
                if (RecordingTemplateMode == DataTemplateMode.UsePreviousItem && CurrentRecording != null)
                    RecordingTemplate = CurrentRecording;

                _CurrentRecording = value;
                OnCurrentRecordingChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the CurrentRecordingChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCurrentRecordingChanged(EventArgs e)
        {
            if (CurrentRecordingChanged != null)
                try
                {
                    CurrentRecordingChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.WriteLine("Error during CurrentRecordingChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the current cell is changed.
        /// </summary>
        public event EventHandler CurrentCellChanged;
        private PhysiologyDataSet.CellsRow _CurrentCell = null;
        /// <summary>
        /// Gets or sets the current cell by its row in the dataset.
        /// If the dataset of the row is not the same as the current dataset,
        /// DataManager.Data is updated accordingly. Acts by setting
        /// CellID.
        /// </summary>
        public PhysiologyDataSet.CellsRow CurrentCell
        {
            get
            {
                return _CurrentCell;
            }
            set
            {
                if (CellTemplateMode == DataTemplateMode.UsePreviousItem && CurrentCell != null)
                    CellTemplate = CurrentCell;
                _CurrentCell = value;
                OnCurrentCellChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the CellChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCurrentCellChanged(EventArgs e)
        {
            if (CurrentCellChanged != null)
                try
                {
                    CurrentCellChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.WriteLine("Error during CellChanged event: " + x.Message);
                }
        }

        #endregion

        #region Data Creation Methods

        /// <summary>
        /// Occurs when the default genotype is changed.
        /// </summary>
        public event EventHandler DefaultFlyStockIDChanged;
        private int _DefaultFlyStockID = 0;
        /// <summary>
        /// The default genotype to use in the absence of a template cell.
        /// </summary>
        [SettingsBindable(true)]
        [DefaultValue(0)]
        public int DefaultFlyStockID
        {
            get { return _DefaultFlyStockID; }
            set
            {
                _DefaultFlyStockID = value;
                OnDefaultFlyStockIDChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DefaultFlyStockIDChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDefaultFlyStockIDChanged(EventArgs e)
        {
            if (DefaultFlyStockIDChanged != null)
                try
                {
                    DefaultFlyStockIDChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DefaultFlyStockIDChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the default user is changed.
        /// </summary>
        public event EventHandler DefaultUserIDChanged;
        private short _DefaultUserID = 0;
        /// <summary>
        /// The default user to use in the absence of a template cell.
        /// </summary>
        [SettingsBindable(true)]
        [DefaultValue(0)]
        public short DefaultUserID
        {
            get { return _DefaultUserID; }
            set
            {
                _DefaultUserID = value;
                OnDefaultUserIDChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DefaultUserIDChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDefaultUserIDChanged(EventArgs e)
        {
            if (DefaultUserIDChanged != null)
                try
                {
                    DefaultUserIDChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DefaultUserIDChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the default bath solution is changed.
        /// </summary>
        public event EventHandler DefaultBathSolutionChanged;
        private string _DefaultBathSolution = "";
        /// <summary>
        /// The default bath solution to use in the absence of a template recording.
        /// </summary>
        [SettingsBindable(true)]
        public string DefaultBathSolution
        {
            get { return _DefaultBathSolution; }
            set
            {
                _DefaultBathSolution = value;
                OnDefaultBathSolutionChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DefaultBathSolutionChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDefaultBathSolutionChanged(EventArgs e)
        {
            if (DefaultBathSolutionChanged != null)
                try
                {
                    DefaultBathSolutionChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DefaultBathSolutionChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the default recording title is changed.
        /// </summary>
        public event EventHandler DefaultRecordingTitleChanged;
        private string _DefaultRecordingTitle = "Untitled Recording";
        /// <summary>
        /// The default recording title.
        /// </summary>
        [SettingsBindable(true)]
        [DefaultValue("Untitled Recording")]
        public string DefaultRecordingTitle
        {
            get { return _DefaultRecordingTitle; }
            set
            {
                _DefaultRecordingTitle = value;
                OnDefaultRecordingTitleChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DefaultRecordingTitleChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDefaultRecordingTitleChanged(EventArgs e)
        {
            if (DefaultRecordingTitleChanged != null)
                try
                {
                    DefaultRecordingTitleChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DefaultRecordingTitleChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the template cell is changed.
        /// </summary>
        public event EventHandler CellTemplateChanged;
        private PhysiologyDataSet.CellsRow _CellTemplate;
        /// <summary>
        /// The cell row that will be used as a template for new cells.
        /// </summary>
        [Bindable(true)]
        public PhysiologyDataSet.CellsRow CellTemplate
        {
            get { return _CellTemplate; }
            set
            {
                _CellTemplate = value;
                OnCellTemplateChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the CellTemplateChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCellTemplateChanged(EventArgs e)
        {
            if (CellTemplateChanged != null)
                try
                {
                    CellTemplateChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during CellTemplateChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the recording template is changed.
        /// </summary>
        public event EventHandler RecordingTemplateChanged;
        private PhysiologyDataSet.RecordingsRow _RecordingTemplate;
        /// <summary>
        /// The Recordings row that will be used as a template for new rows.
        /// </summary>
        [Bindable(true)]
        public PhysiologyDataSet.RecordingsRow RecordingTemplate
        {
            get { return _RecordingTemplate; }
            set
            {
                _RecordingTemplate = value;
                OnRecordingTemplateChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnRecordingTemplateChanged(EventArgs e)
        {
            if (RecordingTemplateChanged != null)
                try
                {
                    RecordingTemplateChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during RecordingTemplateChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// If there is no current dataset, creates a new empty one.
        /// </summary>
        public virtual void NewDataSet()
        {
            if (Data == null) Data = new PhysiologyDataSet();
        }

        /// <summary>
        /// Generates a new cells row, setting Created and filling in
        /// the FlyStockID and UserID based on the CellTemplate or 
        /// DefaultFlyStockID and DefaultUserID.
        /// </summary>
        /// <returns>The new cells row.</returns>
        public virtual PhysiologyDataSet.CellsRow CreateNewCell()
        {
            if (Data == null) NewDataSetFromDatabase();

            UpdateAllToDatabase();

            PhysiologyDataSet.CellsRow cell = Data.Cells.NewCellsRow();

            // Apply general settings
            cell.Created = DateTime.Now;

            // Apply template
            if (CellTemplate != null)
            {
                cell.FlyStockID = CellTemplate.FlyStockID;
                cell.UserID = CellTemplate.UserID;
            }
            else // Ensure no fields that are NotNull are left null
            {
                cell.FlyStockID = DefaultFlyStockID;
                cell.UserID = DefaultUserID;
            }

            Data.Cells.AddCellsRow(cell);

            CurrentCell = cell;

            return cell;
        }

        public virtual PhysiologyDataSet.RecordingsRow GetNewRecording()
        {
            if (Data == null) NewDataSetFromDatabase();
            PhysiologyDataSet.RecordingsRow recording = Data.Recordings.NewRecordingsRow();

            if (CurrentCell == null) CreateNewCell();

            // Apply general settings
            recording.Recorded = DateTime.Now;
            recording.CellID = CurrentCell.CellID; // Add it to the current cell
            recording.Title = DefaultRecordingTitle;

            // Apply template
            if (RecordingTemplate != null)
            {
                recording.BathSolution = RecordingTemplate.BathSolution;
                if (!RecordingTemplate.IsPipetteSolutionNull()) recording.PipetteSolution = RecordingTemplate.PipetteSolution;
            }
            else // Ensure that no NotNull fields are left null
            {
                recording.BathSolution = DefaultBathSolution;
            }

            Data.Recordings.AddRecordingsRow(recording);

            return recording;
        }

        /// <summary>
        /// Creates a new recording, attaches it to the the current cell, and
        /// sets Recorded to the current time, Title to DefaultRecordingTitle,
        /// and fills in BathSolution and PipetteSolution using RecordingTemplate
        /// or DefaultBathSolution.
        /// </summary>
        /// <returns>The new recording.</returns>
        public virtual PhysiologyDataSet.RecordingsRow CreateNewRecording()
        {
            CurrentRecording = GetNewRecording();
            return CurrentRecording;
        }

        #endregion

        #region Database Storage

        /// <summary>
        /// The database connector has been changed.
        /// </summary>
        public event EventHandler DatabaseConnectorChanged;

        private IPhysiologyDataDatabaseConnector _DatabaseConnector = new MySqlDataManagerDatabaseConnector();
        /// <summary>
        /// The database connector that will be called when the data needs to be updated to a database.
        /// </summary>
        public IPhysiologyDataDatabaseConnector DatabaseConnector
        {
            get { return _DatabaseConnector; }
            set
            {
                _DatabaseConnector = value;
                OnDatabaseConnectorChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DatabaseConnectorChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDatabaseConnectorChanged(EventArgs e)
        {
            if (DatabaseConnectorChanged != null)
                try
                {
                    DatabaseConnectorChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DatabaseConnectorChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Creates a new dataset and fills the users and genotypes table.
        /// If DatabaseConnector is null, only calls NewDataSet.
        /// </summary>
        public virtual void NewDataSetFromDatabase()
        {
            NewDataSet();
            if (DatabaseConnector != null)
            {
                try
                {
                    DatabaseConnector.LoadUsersFromDatabase(Data);
                    DatabaseConnector.LoadGenotypesFromDatabase(Data);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Error loading users and genotypes: " + e.Message);
                }
            }
        }

        public event EventHandler StartingDatabaseUpdate;

        protected virtual void OnStartingDatabaseUpdate(EventArgs e)
        {
            if(StartingDatabaseUpdate != null)
                try
                {
                    StartingDatabaseUpdate(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataManager: Error during StartingDatabaseUpdate event.", x.Message);
                }
        }

        public event EventHandler FinishedDatabaseUpdate;

        protected virtual void OnFinishedDatabaseUpdate(object sender, EventArgs e)
        {
            OnFinishedDatabaseUpdate(e);
        }
        protected virtual void OnFinishedDatabaseUpdate(EventArgs e)
        {
            ClearStoredRecordingData(); // To save memory
            System.GC.Collect();

            if (FinishedDatabaseUpdate != null)
                try
                {
                    FinishedDatabaseUpdate(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataManager: Error during FinishedDatabaseUpdate event.", x.Message);
                }
        }

        /// <summary>
        /// Updates all data to the database asynchronously, showing a ProgressDialog.
        /// If a TaskError occurs, fires DataStorageError.
        /// </summary>
        public virtual void UpdateAllToDatabase()
        {
            // TODO: Safe handling of this error
            if (DatabaseConnector == null) throw new Exception("Database connector is null.");

            OnStartingDatabaseUpdate(EventArgs.Empty);

            ProgressDialog dialog = new ProgressDialog();
            dialog.TaskError += new EventHandler<ExceptionEventArgs>(OnDataStorageError);
            dialog.TaskStopped += new EventHandler(OnFinishedDatabaseUpdate);
            DatabaseConnector.BeginUpdateDataSetToDatabase(Data, dialog);
        }

        /// <summary>
        /// Updates the current cell to the database asynchronously, showing a ProgressDialog.
        /// If a TaskError occurs, fires DataStorageError.
        /// </summary>
        public virtual void UpdateCurrentCellToDatabase()
        {
            if (CurrentCell == null) return;

            // TODO: Safe handling of this error
            if (DatabaseConnector == null) throw new Exception("Database connector is null.");

            OnStartingDatabaseUpdate(EventArgs.Empty);
            ProgressDialog dialog = new ProgressDialog();
            dialog.TaskError += new EventHandler<ExceptionEventArgs>(OnDataStorageError);
            dialog.TaskStopped += new EventHandler(OnFinishedDatabaseUpdate);

            DatabaseConnector.BeginUpdateCellAndSubdataToDatabase(Data, CurrentCell.CellID, dialog);
        }

        /// <summary>
        /// Updates the current recording to the database asynchronously, showing a ProgressDialog.
        /// If a TaskError occurs, fires DataStorageError.
        /// </summary>
        public virtual void UpdateCurrentRecordingToDatabase()
        {
            // TODO: Safe handling of this error
            if (DatabaseConnector == null) throw new Exception("Database connector is null.");

            OnStartingDatabaseUpdate(EventArgs.Empty);
            ProgressDialog dialog = new ProgressDialog();
            dialog.TaskError += new EventHandler<ExceptionEventArgs>(OnDataStorageError);
            dialog.TaskStopped += new EventHandler(OnFinishedDatabaseUpdate);

            DatabaseConnector.BeginUpdateRecordingAndSubdataToDatabase(Data, CurrentRecording.RecordingID, dialog);
        }


        /// <summary>
        /// Removes recording data that has already been stored
        /// (determined by the RowState being set to Original). Be sure to call
        /// EndCurrentEdit() on any BindingSources before this method.
        /// </summary>
        public virtual void ClearStoredRecordingData()
        {
            // Recording data
            DataRow[] rows = Data.Recordings_Data.Select(null, null, System.Data.DataViewRowState.Unchanged);
            foreach (DataRow row in rows)
            {
                row.EndEdit(); // Does this address the BindingSource edit problem?
                if (row.RowState == DataRowState.Unchanged)
                {
                    row.Delete();
                    row.AcceptChanges();
                }
            }
        }

        private bool _IsExiting = false;
        /// <summary>
        /// True if the application is exiting.
        /// </summary>
        protected bool IsExiting
        {
            get { return _IsExiting; }
            set { _IsExiting = value; }
        }


        private void OnDataStorageError(object sender, ExceptionEventArgs e)
        {
            OnDataStorageError(e);
        }

        /// <summary>
        /// Fires the DataStorageError event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataStorageError(ExceptionEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Error storing data: " + e.Message);

            if (IsExiting)
            {
                System.Windows.Forms.MessageBox.Show("Saving recovery file...");
                try
                {
                    SaveRecoveryFile();
                    System.Windows.Forms.MessageBox.Show("Recovery file successfully saved to " + DataFolder + RecoveryFileName);
                }
                catch (Exception x)
                {
                    System.Windows.Forms.MessageBox.Show("Error while saving recovery file: " + x.Message);
                }
            }

            if(DataStorageError != null)
                try
                {
                    DataStorageError(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DataStorageError event: " + x.Message);
                }
        }

        #endregion

        #region File Storage Methods

        /// <summary>
        /// Occurs when the data folder is changed.
        /// </summary>
        public event EventHandler DataFolderChanged;
        private string _DataFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar + "Physiology Workbench Data" + System.IO.Path.DirectorySeparatorChar;
        /// <summary>
        /// The default folder to store saved data and recovery information to.
        /// </summary>
        [Bindable(true)]
        [SettingsBindable(true)]
        public string DataFolder
        {
            get { return _DataFolder; }
            set
            {
                _DataFolder = value;
                OnDataFolderChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the DataFolderChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDataFolderChanged(EventArgs e)
        {
            if (DataFolderChanged != null)
                try
                {
                    DataFolderChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DataFolderChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Occurs when the recovery file name is changed.
        /// </summary>
        public event EventHandler RecoveryFileNameChanged;
        private string _RecoveryFileName = "Recovery Autosave.pdata";
        /// <summary>
        /// The recovery autosave file name. Should have the pdata extension.
        /// The file will be placed in the DataFolder.
        /// </summary>
        [DefaultValue("Recovery Autosave.pdata")]
        [Bindable(true)]
        [SettingsBindable(true)]
        public string RecoveryFileName
        {
            get { return _RecoveryFileName; }
            set
            {
                _RecoveryFileName = value;
                OnRecoveryFileNameChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the RecoveryFileNameChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRecoveryFileNameChanged(EventArgs e)
        {
            if (RecoveryFileNameChanged != null)
                try
                {
                    RecoveryFileNameChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during RecoveryFileNameChanged event: " + x.Message);
                }
        }

        /// <summary>
        /// Checks whether the recovery file exists.
        /// </summary>
        public bool DoesRecoveryFileExist
        {
            get
            {
                return File.Exists(DataFolder + RecoveryFileName);
            }
        }

        /// <summary>
        /// Shows the user a save file dialog box and saves the current data
        /// to the chosen file.
        /// </summary>
        /// <returns>True if the data was saved</returns>
        public virtual bool RequestUserToSaveDataToFile()
        {
            if (SaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try {
                    using (Stream fileStream = SaveFileDialog.OpenFile())
                    {
                        SaveDataToStream(fileStream);
                        return true;
                    }
                } catch(Exception e) {
                    OnDataStorageError(new ExceptionEventArgs(e));
                    return false;
                }
            }
            else return false;
        }

        /// <summary>
        /// Saves the current data to the recovery file.
        /// </summary>
        public virtual void SaveRecoveryFile()
        {
            SaveDataToFile(DataFolder + RecoveryFileName);
        }
        /// <summary>
        /// Saves the current data to the specified file
        /// </summary>
        /// <param name="path">The file name and path to save the data to</param>
        public virtual void SaveDataToFile(string path)
        {
            using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
            {
                SaveDataToStream(fileStream);
            }
        }
        /// <summary>
        /// Saves the current data to the provided stream
        /// </summary>
        /// <param name="stream">The stream to save the data to</param>
        public virtual void SaveDataToStream(Stream stream)
        {
            using (System.IO.Compression.GZipStream zipStream = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Compress))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(zipStream, Data);
                }
                catch (Exception e)
                {
                    OnDataStorageError(new ExceptionEventArgs("Error during data serialization",e));
                }
            }
        }

        /// <summary>
        /// Restores the recovery file if it exists
        /// </summary>
        public virtual void RestoreRecoveryFile()
        {
            if (DoesRecoveryFileExist)
            {
                OpenDataFromFile(DataFolder + RecoveryFileName);
            }
        }
        /// <summary>
        /// Merges the data in the provided file with the current data
        /// </summary>
        /// <param name="file">The file name to open</param>
        public virtual void OpenDataFromFile(string file)
        {
            using (FileStream fileStream = File.Open(file, FileMode.Open))
            {
                OpenDataFromStream(fileStream);
            }
        }
        /// <summary>
        /// Merges the data in the provided stream with the current data
        /// </summary>
        /// <param name="stream">The stream to read from</param>
        public virtual void OpenDataFromStream(Stream stream)
        {
            using (System.IO.Compression.GZipStream zipStream = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    PhysiologyDataSet openedData = binaryFormatter.Deserialize(zipStream) as PhysiologyDataSet;
                    if (openedData != null && Data != null)
                        Data.Merge(openedData);
                    else if (Data == null)
                        Data = openedData;
                }
                catch (Exception e)
                {
                    OnDataStorageError(new ExceptionEventArgs("Error during data deserialization", e));
                }
            }
        }

        #endregion
    }
}
