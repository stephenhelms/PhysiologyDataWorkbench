using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using System.ComponentModel;
using RRLab.PhysiologyDataConnectivity;
using RRLab.PhysiologyDataWorkshop.Experiments;
using System.Reflection;
using System.IO;
using RRLab.Utilities;

namespace RRLab.PhysiologyDataWorkshop
{
    public class PhysiologyDataWorkshopProgram : System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow window = new MainWindow();
            window.Program = new PhysiologyDataWorkshopProgram();
            window.Program.Initialize();
            Application.Run(window);
        }

        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;

        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                _DataSet = value;
                if (DataSetChanged != null) DataSetChanged(this, EventArgs.Empty);
                OnPropertyChanged("DataSet");
            }
        }

        private IPhysiologyDataDatabaseConnector _DatabaseConnector = new MySqlDataManagerDatabaseConnector();
        public IPhysiologyDataDatabaseConnector DatabaseConnector
        {
            get { return _DatabaseConnector; }
            set {
                _DatabaseConnector = value;
                OnPropertyChanged("DatabaseConnector");
            }
        }

        public event EventHandler MyUserIDChanged;
        private short _MyUserID = 1;
        
        public short MyUserID
        {
            get { return _MyUserID; }
            set {
                _MyUserID = value;
                if(MyUserIDChanged != null)
                    try
                    {
                        MyUserIDChanged(this, EventArgs.Empty);
                    }
                    catch (Exception x) { ; }
                OnPropertyChanged("MyUserID");
            }
        }
	

        public event EventHandler CurrentCellIDChanged;
        private int _CurrentCellID;
        [System.ComponentModel.Bindable(true)]
        public int CurrentCellID
        {
            get { return _CurrentCellID; }
            set {
                _CurrentCellID = value;
                if (CurrentCellIDChanged != null) CurrentCellIDChanged(this, EventArgs.Empty);
                OnPropertyChanged("CurrentCellID");
            }
        }

        public event EventHandler CurrentRecordingIDChanged;
        private long _CurrentRecordingID;
        [System.ComponentModel.Bindable(true)]
        public long CurrentRecordingID
        {
            get { return _CurrentRecordingID; }
            set {
                _CurrentRecordingID = value;
                if (CurrentRecordingIDChanged != null) CurrentRecordingIDChanged(this, EventArgs.Empty);
                OnPropertyChanged("CurrentRecordingID");
            }
        }

        public event EventHandler HistogramTableChanged;
        private string _HistogramTable;
        [Bindable(true)]
        public string HistogramTable
        {
            get { return _HistogramTable; }
            set {
                _HistogramTable = value;
                if (HistogramTableChanged != null) HistogramTableChanged(this, EventArgs.Empty);
                OnPropertyChanged("HistogramTable");
            }
        }

        public event EventHandler HistogramColumnChanged;
        private string _HistogramColumn;
        [Bindable(true)]
        public string HistogramColumn
        {
            get { return _HistogramColumn; }
            set {
                _HistogramColumn = value;
                if (HistogramColumnChanged != null) HistogramColumnChanged(this, EventArgs.Empty);
                OnPropertyChanged("HistogramColumn");
            }
        }

        public event EventHandler HistogramFilterChanged;
        private string _HistogramFilter;
        [Bindable(true)]
        public string HistogramFilter
        {
            get { return _HistogramFilter; }
            set {
                _HistogramFilter = value;
                if (HistogramFilterChanged != null) HistogramFilterChanged(this, EventArgs.Empty);
                OnPropertyChanged("HistogramFilter");
            }
        }

        public event EventHandler ScatterPlotTableChanged;
        private string _ScatterPlotTable;
        [Bindable(true)]
        public string ScatterPlotTable
        {
            get { return _ScatterPlotTable; }
            set
            {
                _ScatterPlotTable = value;
                if (ScatterPlotTableChanged != null) ScatterPlotTableChanged(this, EventArgs.Empty);
                OnPropertyChanged("ScatterPlotTable");
            }
        }

        public event EventHandler ScatterPlotXColumnChanged;
        private string _ScatterPlotXColumn;
        [Bindable(true)]
        public string ScatterPlotXColumn
        {
            get { return _ScatterPlotXColumn; }
            set
            {
                _ScatterPlotXColumn = value;
                if (ScatterPlotXColumnChanged != null) ScatterPlotXColumnChanged(this, EventArgs.Empty);
                OnPropertyChanged("ScatterPlotXColumn");
            }
        }

        public event EventHandler ScatterPlotYColumnChanged;
        private string _ScatterPlotYColumn;
        [Bindable(true)]
        public string ScatterPlotYColumn
        {
            get { return _ScatterPlotYColumn; }
            set
            {
                _ScatterPlotYColumn = value;
                if (ScatterPlotYColumnChanged != null) ScatterPlotYColumnChanged(this, EventArgs.Empty);
                OnPropertyChanged("ScatterPlotYColumn");
            }
        }

        public event EventHandler ScatterPlotTagColumnChanged;
        private string _ScatterPlotTagColumn;
        [Bindable(true)]
        public string ScatterPlotTagColumn
        {
            get { return _ScatterPlotTagColumn; }
            set
            {
                _ScatterPlotTagColumn = value;
                if (ScatterPlotTagColumnChanged != null) ScatterPlotTagColumnChanged(this, EventArgs.Empty);
                OnPropertyChanged("ScatterPlotTagColumn");
            }
        }

        public event EventHandler ScatterPlotFilterChanged;
        private string _ScatterPlotFilter;
        [Bindable(true)]
        public string ScatterPlotFilter
        {
            get { return _ScatterPlotFilter; }
            set
            {
                _ScatterPlotFilter = value;
                if (ScatterPlotFilterChanged != null) ScatterPlotFilterChanged(this, EventArgs.Empty);
                OnPropertyChanged("ScatterPlotFilter");
            }
        }
	

        public PhysiologyDataWorkshopProgram()
        {
        }
        ~PhysiologyDataWorkshopProgram()
        {
            if (Matlab != null)
            {
                if (MessageBox.Show("Do you want to close Matlab?", "Matlab is Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Matlab.Quit();
                }
            }
        }

        public virtual void Initialize()
        {
            if(DataSet == null) DataSet = new PhysiologyDataSet();

            if (DatabaseConnector != null)
            {
                DatabaseConnector.RequestUserToConfigureConnection();

                try
                {
                    DatabaseConnector.LoadGenotypesFromDatabase(DataSet);
                    DatabaseConnector.LoadUsersFromDatabase(DataSet);
                    LoadCellsFromDatabase();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error loading genotypes and users: " + x.Message);
                }
            }
        }

        public event EventHandler LoadingDataFromDatabase;
        public event EventHandler FinishedLoadingDataFromDatabase;

        protected virtual void OnLoadingDataFromDatabase(EventArgs e)
        {
            if(LoadingDataFromDatabase != null)
                try
                {
                    LoadingDataFromDatabase(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Program: Error during LoadingDataFromDatabase event.", x.Message);
                }
        }
        protected virtual void OnFinishedLoadingDataFromDatabase(EventArgs e)
        {
            if (FinishedLoadingDataFromDatabase != null)
                try
                {
                    FinishedLoadingDataFromDatabase(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Program: Error during FinishedLoadingDataFromDatabase event.", x.Message);
                }
        }

        public virtual void LoadCellsFromDatabase()
        {
            if (DataSet == null) DataSet = new PhysiologyDataSet();

            if(DatabaseConnector != null)
                try
                {
                    OnLoadingDataFromDatabase(EventArgs.Empty);

                    DatabaseConnector.LoadCellsFromDatabase(DataSet, DatabaseSyncOptions.All);
                    ((MySqlDataManagerDatabaseConnector)DatabaseConnector).LoadRecordingsFromDatabase(DataSet);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error loading cells: " + e.Message);
                }
                finally
                {
                    OnFinishedLoadingDataFromDatabase(EventArgs.Empty);
                }
        }

        public virtual void LoadRecordingAndSubdataFromDatabase(PhysiologyDataSet.RecordingsRow row)
        {
            if (DatabaseConnector != null)
            {
                try
                {
                    OnLoadingDataFromDatabase(EventArgs.Empty);

                    ProgressDialog empty = new ProgressDialog();
                    empty.IsShowOnTaskExecutionEnabled = false;

                    DatabaseConnector.LoadRecordingSubdataFromDatabase(DataSet, row.RecordingID, empty);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error loading recording subdata.");
                }
                finally { OnFinishedLoadingDataFromDatabase(EventArgs.Empty); }
            }
            else throw new Exception("No database connector available.");
        }
        public virtual void BeginLoadRecordingAndSubdataFromDatabase(PhysiologyDataSet.RecordingsRow row)
        {
            BeginLoadRecordingAndSubdataFromDatabase(row, null);
        }
        public virtual void BeginLoadRecordingAndSubdataFromDatabase(PhysiologyDataSet.RecordingsRow row, Delegate callback, params object[] args)
        {
            // Download recording data
            if (DatabaseConnector != null)
            {
                try
                {
                    OnLoadingDataFromDatabase(EventArgs.Empty);

                    ProgressDialog dialog = new ProgressDialog();
                    dialog.TaskStopped += new EventHandler(delegate(object sender, EventArgs x)
                    {
                        OnFinishedLoadingDataFromDatabase(EventArgs.Empty);
                        try
                        {
                            if (callback != null) callback.DynamicInvoke(args);
                        }
                        catch (Exception x1)
                        {
                            System.Diagnostics.Debug.Fail("Error during loading data callback.", x1.Message);
                        }
                    });
                    dialog.Show();
                    ((MySqlDataManagerDatabaseConnector)DatabaseConnector).BeginLoadRecordingSubdataFromDatabase(DataSet, row.RecordingID, dialog);
                }
                catch (Exception x2)
                {
                    MessageBox.Show("Error updating recording data: " + x2.Message);
                }
            }
            else throw new Exception("No database connector available.");
        }

        public event EventHandler UpdatingDatabase;
        public event EventHandler UpdatedDatabase;

        public virtual void UpdateDatabase()
        {
            if (DatabaseConnector == null)
            {
                System.Diagnostics.Trace.Fail("No database connector available.");
                return;
            }

            ProgressDialog progressDialog = new ProgressDialog("Updating Database");
            progressDialog.TaskStarted += new EventHandler(delegate(object sender, EventArgs e)
            {
                OnUpdatingDatabase(e);
            });
            progressDialog.TaskStopped += new EventHandler(delegate(object sender, EventArgs e)
            {
                OnUpdatedToDatabase(e);
            });
            DatabaseConnector.BeginUpdateDataSetToDatabase(DataSet, progressDialog);
        }

        protected virtual void OnUpdatingDatabase(EventArgs e)
        {
            if(UpdatingDatabase != null)
                try
                {
                    UpdatingDatabase(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Program: Error during UpdatingToDatabase event.", x.Message);
                }
        }
        protected virtual void OnUpdatedToDatabase(EventArgs e)
        {
            if(UpdatedDatabase != null)
                try
                {
                    UpdatedDatabase(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Program: Error during UpdatedToDatabase event.", x.Message);
                }
        }

        public event EventHandler CurrentExperimentChanged;
        private IExperiment _CurrentExperiment;
        [Bindable(true)]
        public IExperiment CurrentExperiment
        {
            get { return _CurrentExperiment; }
            set {
                if (value == CurrentExperiment) return;

                _CurrentExperiment = value;
                OnCurrentExperimentChanged(EventArgs.Empty);
            }
        }
        protected virtual void OnCurrentExperimentChanged(EventArgs e)
        {
            if(CurrentExperimentChanged != null)
                try
                {
                    CurrentExperimentChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Program: Error during CurrentExperimentChanged event.", x.Message);
                }
        }
	

        private List<IExperiment> _Experiments = new List<IExperiment>();
        public virtual IList<IExperiment> GetExperiments()
        {
            if (_Experiments.Count == 0)
            {
                foreach (Assembly assembly in GetExperimentAssemblies())
                {
                    try
                    {
                        foreach (Type type in assembly.GetTypes())
                        {
                            if ((typeof(IExperiment).IsAssignableFrom(type)) && (!type.IsAbstract) && (!type.IsInterface) && (type.GetConstructor(new Type[] { }) != null))
                            {
                                try
                                {
                                    IExperiment experiment = Activator.CreateInstance(type) as IExperiment;
                                    experiment.PhysiologyDataSet = this.DataSet;
                                    experiment.Program = this;
                                    if (experiment != null)
                                        _Experiments.Add(experiment);
                                }
                                catch (Exception x) { ; }
                            }
                        }
                    }
                    catch (Exception x) { ; }
                }
            }

            return _Experiments;
        }

        protected virtual ICollection<Assembly> GetExperimentAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();

            // Search current directory
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo info = new DirectoryInfo(currentDirectory);
            FileInfo[] dllFiles = info.GetFiles("*.dll");
            foreach (FileInfo dllFile in dllFiles)
            {
                try
                {
                    assemblies.Add(Assembly.LoadFrom(dllFile.FullName));
                }
                catch (Exception e) { ; }
            }

            try
            {
                // Add currently loaded assemblies
                Assembly currentThread = Assembly.GetExecutingAssembly();
                if (!assemblies.Contains(currentThread)) assemblies.Add(currentThread);
            }
            catch (Exception e) { ; }

            return assemblies;
        }

        #region INotifyPropertyChanged Members

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(property));
        }

        #endregion

        #region MATLAB

        private MLApp.MLApp _Matlab;
        
        protected MLApp.MLApp Matlab
        {
            get { return _Matlab; }
            set { _Matlab = value; }
        }
	

        public virtual void ExportRecordingToMatlab(PhysiologyDataSet.RecordingsRow recording)
        {
            try
            {
                if (Matlab == null) //Matlab = new MLApp.MLAppClass();
                    Matlab = (MLApp.MLApp) Activator.CreateInstance(Type.GetTypeFromProgID("Matlab.Desktop.Application"));

                string varName = String.Format(
                    "recording{0}",
                    recording.RecordingID);

                ICollection<string> dataNames = recording.GetDataNames();
                foreach (string dataName in dataNames)
                {
                    TimeResolvedData data = recording.GetData(dataName);
                    string varNameSafe = dataName.Replace(' ', '_');
                    Matlab.PutWorkspaceData(varName + "_" + varNameSafe + "_time", "base", data.Time);
                    Matlab.PutWorkspaceData(varName + "_" + varNameSafe, "base", data.Values);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error exporting to MATLAB");
            }
        }

        #endregion
    }
}