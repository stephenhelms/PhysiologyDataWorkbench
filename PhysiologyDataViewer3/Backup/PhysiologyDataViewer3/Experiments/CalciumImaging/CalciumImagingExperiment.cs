using System;
using System.Collections.Generic;
using System.Text;
using CalciumImagingProcessor;
using RRLab.PhysiologyWorkbench.Data;
using System.ComponentModel;
using RRLab.PhysiologyDataConnectivity;
using MySql.Data.MySqlClient;
using MathWorks.MATLAB.NET.Arrays;
using RRLab.Utilities;

namespace RRLab.PhysiologyDataWorkshop.Experiments.CalciumImaging
{
    public class CalciumImagingExperiment : Experiment, IDisposable
    {
        #region Data
        public event EventHandler SteadyStateCalciumDataSetChanged;
        private SteadyStateCalciumDataSet _SteadyStateCalciumDataSet;

        public SteadyStateCalciumDataSet SteadyStateCalciumDataSet
        {
            get { return _SteadyStateCalciumDataSet; }
            set {
                _SteadyStateCalciumDataSet = value;
                OnSteadyStateCalciumDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnSteadyStateCalciumDataSetChanged(EventArgs e)
        {
            if(SteadyStateCalciumDataSetChanged != null)
                try
                {
                    SteadyStateCalciumDataSetChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("CalciumImagingExperiment: Error during SteadyStateCalciumDataSetChanged event.", x.Message);
                }
            NotifyPropertyChanged("SteadyStateCalciumDataSet");
        }
        #endregion

        #region State Management
        public event EventHandler CurrentSteadyStateCalciumExperimentChanged;
        private SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow _CurrentSteadyStateCalciumExperiment;
        [Bindable(true)]
        public SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow CurrentSteadyStateCalciumExperiment
        {
            get { return _CurrentSteadyStateCalciumExperiment; }
            set {
                _CurrentSteadyStateCalciumExperiment = value;
                OnCurrentSteadyStateCalciumExperimentChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnCurrentSteadyStateCalciumExperimentChanged(EventArgs e)
        {
            if(CurrentSteadyStateCalciumExperimentChanged != null)
                try
                {
                    CurrentSteadyStateCalciumExperimentChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("CalciumImagingExperiment: Error during CurrentSteadyStateCalciumExperimentChanged event.", x.Message);
                }
            NotifyPropertyChanged("CurrentSteadyStateCalciumExperimentChanged");
        }
        #endregion

        #region GUI State Management	

        private string _HistogramColumn;
        [Bindable(true)]
        public string HistogramColumn
        {
            get { return _HistogramColumn; }
            set
            {
                _HistogramColumn = value;
                NotifyPropertyChanged("HistogramColumn");
            }
        }

        private string _HistogramFilter;
        [Bindable(true)]
        public string HistogramFilter
        {
            get { return _HistogramFilter; }
            set
            {
                _HistogramFilter = value;
                NotifyPropertyChanged("HistogramFilter");
            }
        }

        private string _ScatterXColumn;
        [Bindable(true)]
        public string ScatterXColumn
        {
            get { return _ScatterXColumn; }
            set
            {
                _ScatterXColumn = value;
                NotifyPropertyChanged("ScatterXColumn");
            }
        }

        private string _ScatterYColumn;
        [Bindable(true)]
        public string ScatterYColumn
        {
            get { return _ScatterYColumn; }
            set
            {
                _ScatterYColumn = value;
                NotifyPropertyChanged("ScatterYColumn");
            }
        }

        private string _ScatterFilter;
        [Bindable(true)]
        public string ScatterFilter
        {
            get { return _ScatterFilter; }
            set
            {
                _ScatterFilter = value;
                NotifyPropertyChanged("ScatterFilter");
            }
        }
        #endregion

        #region Other Properties
        private CalciumImagingProcessor.CalciumImagingProcessor _CalciumImagingProcessor;

	    public CalciumImagingProcessor.CalciumImagingProcessor CalciumImagingProcessor
	    {
		    get { return _CalciumImagingProcessor;}
		    set { _CalciumImagingProcessor = value;}
        }
        #endregion

        #region Constructors
        public CalciumImagingExperiment() : base()
        {
        }
        #endregion

        #region Overridden ExperimentRow Properties and Methods
        public override string  Name
        {
	        get 
	        {
                return "Calcium Imaging";
	        }
        }

        protected CalciumImagingPanelControl _ExperimentPanel;
        public override System.Windows.Forms.Control GetExperimentPanelControl()
        {
            if (_ExperimentPanel == null) _ExperimentPanel = new CalciumImagingPanelControl(this);
            return _ExperimentPanel;
        }

        protected override void OnProgramChanged(EventArgs e)
        {
            base.OnProgramChanged(e);
            try
            {
                Program.UpdatedDatabase -= new EventHandler(OnPhysiologyDatabaseUpdated);
            }
            catch { ; }
            Program.UpdatedDatabase += new EventHandler(OnPhysiologyDatabaseUpdated);
        }
        #endregion

        #region Actions
        protected override void ConfigureCellActions()
        {
            CellActions.Add("Create new calcium imaging experiment using this cell", new Action<RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.CellsRow>(CreateNewCalciumImagingExperiment));
            CellActions.Add("Delete associated calcium imaging experiment", new Action<RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet.CellsRow>(DeleteCalciumImagingExperiment));
            base.ConfigureCellActions();
        }

        public override bool IsCellActionEnabled(string actionName, PhysiologyDataSet.CellsRow cell)
        {
            if (SteadyStateCalciumDataSet == null) return false;

            switch (actionName)
            {
                case "Create new calcium imaging experiment using this cell":
                    return SteadyStateCalciumDataSet.SteadyStateCalciumExperiments.FindByCellID(cell.CellID) == null;
                case "Delete associated calcium imaging experiment":
                    return SteadyStateCalciumDataSet.SteadyStateCalciumExperiments.FindByCellID(cell.CellID) != null;
                default:
                    return true;
            }
        }

        public virtual void CreateNewCalciumImagingExperiment(PhysiologyDataSet.CellsRow cell)
        {
            CurrentSteadyStateCalciumExperiment = SteadyStateCalciumDataSet.SteadyStateCalciumExperiments.NewSteadyStateCalciumExperimentsRow();
            CurrentSteadyStateCalciumExperiment.CellID = cell.CellID;

            AddNewCalciumExperimentDialog dialog = new AddNewCalciumExperimentDialog(this, CurrentSteadyStateCalciumExperiment);
            dialog.Show();
        }
        public virtual void DeleteCalciumImagingExperiment(PhysiologyDataSet.CellsRow cell)
        {
            SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow row = SteadyStateCalciumDataSet.SteadyStateCalciumExperiments.FindByCellID(cell.CellID);
            if (row != null)
            {
                row.Delete();
                if (CurrentSteadyStateCalciumExperiment == row) CurrentSteadyStateCalciumExperiment = null;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Cell {0} is not currently used in an experiment.", cell.CellID));
            }
        }

        protected override void ConfigureRecordingActions()
        {
            RecordingActions.Add("Set current recording as the calcium signal", new Action<PhysiologyDataSet.RecordingsRow>(SetCalciumSignalRecording));
            RecordingActions.Add("Set current recording as the high signal", new Action<PhysiologyDataSet.RecordingsRow>(SetHighSignalRecording));
            RecordingActions.Add("Set current recording as the low signal", new Action<PhysiologyDataSet.RecordingsRow>(SetLowSignalRecording));
            base.ConfigureRecordingActions();
        }

        public override bool IsRecordingActionEnabled(string actionName, PhysiologyDataSet.RecordingsRow recording)
        {
            if (SteadyStateCalciumDataSet == null) return false;

            if (CurrentSteadyStateCalciumExperiment == null) return false;
            else return true;
        }

        public virtual void SetCalciumSignalRecording(PhysiologyDataSet.RecordingsRow recording)
        {
            if (CurrentSteadyStateCalciumExperiment == null)
                CreateNewCalciumImagingExperiment(recording.CellsRow);

            CurrentSteadyStateCalciumExperiment.SignalRecordingID = recording.RecordingID;
        }
        public virtual void SetHighSignalRecording(PhysiologyDataSet.RecordingsRow recording)
        {
            if (CurrentSteadyStateCalciumExperiment == null)
                CreateNewCalciumImagingExperiment(recording.CellsRow);

            CurrentSteadyStateCalciumExperiment.HighRecordingID = recording.RecordingID;
        }
        public virtual void SetLowSignalRecording(PhysiologyDataSet.RecordingsRow recording)
        {
            if (CurrentSteadyStateCalciumExperiment == null)
                CreateNewCalciumImagingExperiment(recording.CellsRow);

            CurrentSteadyStateCalciumExperiment.LowRecordingID = recording.RecordingID;
        }
        #endregion

        #region IDisposable Members

        ~CalciumImagingExperiment()
        {
            Dispose();
        }
        public virtual void Dispose()
        {
            try
            {
                if (CalciumImagingProcessor != null)
                {
                    CalciumImagingProcessor.Dispose();
                }
                if (_ExperimentPanel != null)
                {
                    _ExperimentPanel.Dispose();
                }
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.Fail("CalciumImagingExperiment: Error while disposing.", x.Message);
            }
            finally
            {
                CalciumImagingProcessor = null;
                _ExperimentPanel = null;
            }
        }

        #endregion

        #region Database Operations
        private LogInDialog _LogInDialog = new LogInDialog();

        public LogInDialog LogInDialog
        {
            get { return _LogInDialog; }
            set { _LogInDialog = value; }
        }

        SortedList<SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow, PhysiologyDataSet.RecordingsRow> _ProcessedCalciumRowsToSync = new SortedList<SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow, PhysiologyDataSet.RecordingsRow>();
        public virtual void AddExperiment(SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow experiment)
        {
            try
            {
                if (!experiment.IsProcessedSignalRecordingIDNull())
                {
                    PhysiologyDataSet.RecordingsRow processedCalcium = PhysiologyDataSet.Recordings.FindByRecordingID(experiment.ProcessedSignalRecordingID);
                    _ProcessedCalciumRowsToSync.Add(experiment, processedCalcium);
                }

                if (experiment.RowState == System.Data.DataRowState.Detached)
                    SteadyStateCalciumDataSet.SteadyStateCalciumExperiments.AddSteadyStateCalciumExperimentsRow(experiment);
                Program.UpdateDatabase();
                // UpdateDataToDatabase() gets called when Program.UpdateDatabase() asynchronously completes. This ensures that the rows are in the right state.
            }
            catch (Exception x)
            {
                System.Windows.Forms.MessageBox.Show(x.Message, "Error adding experiment.");
            }
        }

        protected virtual void OnPhysiologyDatabaseUpdated(object sender, EventArgs e)
        {
            SyncProcessedCalciumRows();
            UpdateDataToDatabase();
        }

        protected virtual void SyncProcessedCalciumRows()
        {
            foreach (KeyValuePair<SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow, PhysiologyDataSet.RecordingsRow> kv in _ProcessedCalciumRowsToSync)
                kv.Key.ProcessedSignalRecordingID = kv.Value.RecordingID;

            _ProcessedCalciumRowsToSync.Clear();

        }

        protected string FillExperimentTableSelectCommandText =
            @"SELECT s.CellID, s.Analyzed, rs.Recorded, u.Name Experimenter, g.Genotype,
              s.CalciumConcentration, s.DarkAdapted, s.SignalRecordingID, s.HighRecordingID,
              s.LowRecordingID, s.ProcessedSignalRecordingID, s.SignalPeakFluorescence,
              s.SignalAverageFluorescence, s.SignalFluorescenceError, s.HighAverageFluorescence,
              s.HighFluorescenceError, s.LowAverageFluorescence, s.LowFluorescenceError, s.SteadyStateCalcium,
              s.SteadyStateCalciumError, s.InitialCalcium, s.InitialCalciumError, s.PeakCalcium,
              s.PeakCalciumError, s.TimeToPeak, s.TimeToSteadyState, s.Comments, c.PipetteResistance, c.SealResistance,
              c.CellCapacitance, c.MembraneResistance, c.SeriesResistance, c.MembranePotential, rs.HoldingPotential,
              rs.PipetteSolution, rs.BathSolution, rh.BathSolution AS HighBathSolution, rl.BathSolution AS LowBathSolution,
              c.RoughAppearanceRating, c.LengthAppearanceRating, c.ShapeAppearanceRating, c.BreakInTime,
              timediff(c.BreakInTime, rs.Recorded) AS TimeSinceBreakIn,
              timediff(rs.Recorded, rh.Recorded) AS HighMeasurementDelay,
              timediff(rl.Recorded, rh.Recorded) AS LowMeasurementDelay
              FROM expt_sscalcium s, cells c, recordings rs, recordings rh, recordings rl, users u, genotypes g
              WHERE c.CellID = s.CellID AND rs.RecordingID = s.SignalRecordingID AND
              rh.RecordingID = s.HighRecordingID AND rl.RecordingID = s.LowRecordingID AND
              u.UserID = c.UserID AND g.FlyStockID = c.FlyStockID";

        public virtual void LoadDataFromDatabase()
        {
            if (SteadyStateCalciumDataSet == null)
                SteadyStateCalciumDataSet = new SteadyStateCalciumDataSet();

            if (LogInDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (MySqlConnection connection = new MySqlConnection(LogInDialog.ConnectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(FillExperimentTableSelectCommandText, connection))
                    {
                        adapter.Fill(SteadyStateCalciumDataSet.SteadyStateCalciumExperiments);
                    }
                }
            }

            OnSteadyStateCalciumDataSetChanged(EventArgs.Empty);
        }

        public virtual void UpdateDataToDatabase()
        {
            if (SteadyStateCalciumDataSet == null)
                SteadyStateCalciumDataSet = new SteadyStateCalciumDataSet();

            if (LogInDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (MySqlConnection connection = new MySqlConnection(LogInDialog.ConnectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(FillExperimentTableSelectCommandText, connection))
                    {
                        using (MySqlCommand insertCommand = new MySqlCommand(
                            @"INSERT INTO expt_sscalcium (CellID, Analyzed, CalciumConcentration, DarkAdapted, SignalRecordingID," +
                              "HighRecordingID, LowRecordingID, ProcessedSignalRecordingID, SignalPeakFluorescence," +
                              "SignalAverageFluorescence, SignalFluorescenceError, HighAverageFluorescence," +
                              "HighFluorescenceError, LowAverageFluorescence, LowFluorescenceError, SteadyStateCalcium," +
                              "SteadyStateCalciumError, InitialCalcium, InitialCalciumError, PeakCalcium," +
                              "PeakCalciumError, TimeToPeak, TimeToSteadyState, Comments, SignalInitialFluorescence)" +
                              "VALUES (?p1,?p2,?p3,?p4,?p5,?p6,?p7,?p8,?p9,?p10,?p11,?p12,?p13,?p14,?p15,?p16,?p17,?p18,?p19,?p20,?p21,?p22,?p23,?p24,?p25);",
                            connection),
                            updateCommand = new MySqlCommand(
                            @"UPDATE expt_sscalcium SET CellID = ?p1, Analyzed = ?p2, CalciumConcentration = ?p3, DarkAdapted = ?p4,
                              SignalRecordingID = ?p5, HighRecordingID = ?p6, LowRecordingID = ?p7, ProcessedSignalRecordingID = ?p8,
                              SignalPeakFluorescence = ?p9, SignalAverageFluorescence = ?p10,
                              SignalFluorescenceError = ?p11, HighAverageFluorescence = ?p12, HighFluorescenceError = ?p13,
                              LowAverageFluorescence = ?p14, LowFluorescenceError = ?p15, SteadyStateCalcium = ?p16,
                              SteadyStateCalciumError = ?p17, InitialCalcium = ?p18, InitialCalciumError = ?p19, PeakCalcium = ?p20,
                              PeakCalciumError = ?p21, TimeToPeak = ?p22, TimeToSteadyState = ?p23, Comments = ?p24, SignalInitialFluorescence = ?p25
                              WHERE CellID = ?p26",
                            connection),
                            deleteCommand = new MySqlCommand(
                            @"DELETE FROM expt_sscalcium WHERE CellID = ?p1", connection))
                        {
                            insertCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                            insertCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "Analyzed");
                            insertCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "CalciumConcentration");
                            insertCommand.Parameters.Add("?p4", MySqlDbType.Bit, 0, "DarkAdapted");
                            insertCommand.Parameters.Add("?p5", MySqlDbType.Int64, 0, "SignalRecordingID");
                            insertCommand.Parameters.Add("?p6", MySqlDbType.Int64, 0, "HighRecordingID");
                            insertCommand.Parameters.Add("?p7", MySqlDbType.Int64, 0, "LowRecordingID");
                            insertCommand.Parameters.Add("?p8", MySqlDbType.Int64, 0, "ProcessedSignalRecordingID");
                            insertCommand.Parameters.Add("?p9", MySqlDbType.Double, 0, "SignalPeakFluorescence");
                            insertCommand.Parameters.Add("?p10", MySqlDbType.Double, 0, "SignalAverageFluorescence");
                            insertCommand.Parameters.Add("?p11", MySqlDbType.Double, 0, "SignalFluorescenceError");
                            insertCommand.Parameters.Add("?p12", MySqlDbType.Double, 0, "HighAverageFluorescence");
                            insertCommand.Parameters.Add("?p13", MySqlDbType.Double, 0, "HighFluorescenceError");
                            insertCommand.Parameters.Add("?p14", MySqlDbType.Double, 0, "LowAverageFluorescence");
                            insertCommand.Parameters.Add("?p15", MySqlDbType.Double, 0, "LowFluorescenceError");
                            insertCommand.Parameters.Add("?p16", MySqlDbType.Double, 0, "SteadyStateCalcium");
                            insertCommand.Parameters.Add("?p17", MySqlDbType.Double, 0, "SteadyStateCalciumError");
                            insertCommand.Parameters.Add("?p18", MySqlDbType.Double, 0, "InitialCalcium");
                            insertCommand.Parameters.Add("?p19", MySqlDbType.Double, 0, "InitialCalciumError");
                            insertCommand.Parameters.Add("?p20", MySqlDbType.Double, 0, "PeakCalcium");
                            insertCommand.Parameters.Add("?p21", MySqlDbType.Double, 0, "PeakCalciumError");
                            insertCommand.Parameters.Add("?p22", MySqlDbType.Float, 0, "TimeToPeak");
                            insertCommand.Parameters.Add("?p23", MySqlDbType.Float, 0, "TimeToSteadyState");
                            insertCommand.Parameters.Add("?p24", MySqlDbType.String, 0, "Comments");
                            insertCommand.Parameters.Add("?p25", MySqlDbType.Double, 0, "SignalInitialFluorescence");

                            updateCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");
                            updateCommand.Parameters.Add("?p2", MySqlDbType.Datetime, 0, "Analyzed");
                            updateCommand.Parameters.Add("?p3", MySqlDbType.Float, 0, "CalciumConcentration");
                            updateCommand.Parameters.Add("?p4", MySqlDbType.Bit, 0, "DarkAdapted");
                            updateCommand.Parameters.Add("?p5", MySqlDbType.Int64, 0, "SignalRecordingID");
                            updateCommand.Parameters.Add("?p6", MySqlDbType.Int64, 0, "HighRecordingID");
                            updateCommand.Parameters.Add("?p7", MySqlDbType.Int64, 0, "LowRecordingID");
                            updateCommand.Parameters.Add("?p8", MySqlDbType.Int64, 0, "ProcessedSignalRecordingID");
                            updateCommand.Parameters.Add("?p9", MySqlDbType.Double, 0, "SignalPeakFluorescence");
                            updateCommand.Parameters.Add("?p10", MySqlDbType.Double, 0, "SignalAverageFluorescence");
                            updateCommand.Parameters.Add("?p11", MySqlDbType.Double, 0, "SignalFluorescenceError");
                            updateCommand.Parameters.Add("?p12", MySqlDbType.Double, 0, "HighAverageFluorescence");
                            updateCommand.Parameters.Add("?p13", MySqlDbType.Double, 0, "HighFluorescenceError");
                            updateCommand.Parameters.Add("?p14", MySqlDbType.Double, 0, "LowAverageFluorescence");
                            updateCommand.Parameters.Add("?p15", MySqlDbType.Double, 0, "LowFluorescenceError");
                            updateCommand.Parameters.Add("?p16", MySqlDbType.Double, 0, "SteadyStateCalcium");
                            updateCommand.Parameters.Add("?p17", MySqlDbType.Double, 0, "SteadyStateCalciumError");
                            updateCommand.Parameters.Add("?p18", MySqlDbType.Double, 0, "InitialCalcium");
                            updateCommand.Parameters.Add("?p19", MySqlDbType.Double, 0, "InitialCalciumError");
                            updateCommand.Parameters.Add("?p20", MySqlDbType.Double, 0, "PeakCalcium");
                            updateCommand.Parameters.Add("?p21", MySqlDbType.Double, 0, "PeakCalciumError");
                            updateCommand.Parameters.Add("?p22", MySqlDbType.Float, 0, "TimeToPeak");
                            updateCommand.Parameters.Add("?p23", MySqlDbType.Float, 0, "TimeToSteadyState");
                            updateCommand.Parameters.Add("?p24", MySqlDbType.String, 0, "Comments");
                            updateCommand.Parameters.Add("?p25", MySqlDbType.Double, 0, "SignalInitialFluorescence");
                            updateCommand.Parameters.Add("?p26", MySqlDbType.Int32, 0, "CellID");
                            updateCommand.Parameters["?p26"].SourceVersion = System.Data.DataRowVersion.Original;

                            deleteCommand.Parameters.Add("?p1", MySqlDbType.Int32, 0, "CellID");

                            adapter.DeleteCommand = deleteCommand;
                            adapter.InsertCommand = insertCommand;
                            adapter.UpdateCommand = updateCommand;

                            adapter.Update(SteadyStateCalciumDataSet.SteadyStateCalciumExperiments);
                            adapter.Fill(SteadyStateCalciumDataSet.SteadyStateCalciumExperiments);
                        }
                    }
                }
            }
        }

        
        #endregion

        #region Data Processing

        private string _FluorescenceDataName = "Photodiode 1";

        public string FluorescenceDataName
        {
            get { return _FluorescenceDataName; }
            set { _FluorescenceDataName = value; }
        }

        public virtual void AnalyzeExperiment(SteadyStateCalciumDataSet.SteadyStateCalciumExperimentsRow experiment, float steadyStateTime, int nPeaks)
        {
            if (CalciumImagingProcessor == null) CalciumImagingProcessor = new CalciumImagingProcessor.CalciumImagingProcessor();

            try {
                PhysiologyDataSet.RecordingsRow signalRecording = PhysiologyDataSet.Recordings.FindByRecordingID(experiment.SignalRecordingID);
                Program.LoadRecordingAndSubdataFromDatabase(signalRecording);
                PhysiologyDataSet.RecordingsRow highRecording = PhysiologyDataSet.Recordings.FindByRecordingID(experiment.HighRecordingID);
                Program.LoadRecordingAndSubdataFromDatabase(highRecording);
                PhysiologyDataSet.RecordingsRow lowRecording = PhysiologyDataSet.Recordings.FindByRecordingID(experiment.LowRecordingID);
                Program.LoadRecordingAndSubdataFromDatabase(lowRecording);

                TimeResolvedData signal, high, low;
                signal = signalRecording.GetData(FluorescenceDataName);
                high = highRecording.GetData(FluorescenceDataName);
                low = lowRecording.GetData(FluorescenceDataName);

                string equipmentSettingsName = FluorescenceDataName + "-Gain";
                if (signalRecording.DoesEquipmentSettingExist(equipmentSettingsName) && highRecording.DoesEquipmentSettingExist(equipmentSettingsName) && lowRecording.DoesEquipmentSettingExist(equipmentSettingsName))
                {
                    try
                    {
                        double signalGain = Double.Parse(signalRecording.GetEquipmentSetting(equipmentSettingsName));
                        double highGain = Double.Parse(highRecording.GetEquipmentSetting(equipmentSettingsName));
                        double lowGain = Double.Parse(lowRecording.GetEquipmentSetting(equipmentSettingsName));

                        if (signalGain != highGain || signalGain != lowGain)
                        {
                            for(int i=0; i < high.DataPoints.Length; i++)
                                high[i] = new TimeResolvedDataPoint(high[i].Time, high[i].Data * signalGain / highGain);
                            for(int i=0; i < low.DataPoints.Length; i++)
                                low[i] = new TimeResolvedDataPoint(low[i].Time, low[i].Data * signalGain / lowGain);
                        }
                    }
                    catch (Exception x)
                    {
                        System.Windows.Forms.MessageBox.Show("Error while analyzing calcium data. Could not adjust fluorescence values for differences in gain.");
                    }
                }

                experiment.Analyzed = DateTime.Now;

                MWStructArray output = (MWStructArray)CalciumImagingProcessor.ProcessCalciumData((MWNumericArray)signal.Time, (MWNumericArray)signal.Values, (MWNumericArray)high.Time, (MWNumericArray)high.Values, (MWNumericArray)low.Time, (MWNumericArray)low.Values, (MWNumericArray)steadyStateTime, nPeaks);
                experiment.SignalInitialFluorescence = ((MWNumericArray)output.GetField("Vinit")).ToScalarDouble();
                experiment.SignalAverageFluorescence = ((MWNumericArray)output.GetField("ssV")).ToScalarDouble();
                experiment.SignalFluorescenceError = ((MWNumericArray)output.GetField("ssV_std")).ToScalarDouble();
                experiment.SignalPeakFluorescence = ((MWNumericArray)output.GetField("peakV")).ToScalarDouble();
                experiment.HighAverageFluorescence = ((MWNumericArray)output.GetField("Vmax")).ToScalarDouble();
                experiment.HighFluorescenceError = ((MWNumericArray)output.GetField("Vmax_std")).ToScalarDouble();
                experiment.LowAverageFluorescence = ((MWNumericArray)output.GetField("Vmin")).ToScalarDouble();
                experiment.LowFluorescenceError = ((MWNumericArray)output.GetField("Vmin_std")).ToScalarDouble();
                
                MWNumericArray ssCa = ((MWNumericArray)output.GetField("ssCa"));
                if(!ssCa.IsComplex)
                    experiment.SteadyStateCalcium = ssCa.ToScalarDouble();
                MWNumericArray ssCaError = ((MWNumericArray)output.GetField("ssCa_err"));
                if(!ssCaError.IsComplex)
                    experiment.SteadyStateCalciumError = ssCaError.ToScalarDouble();
                MWNumericArray iCa = ((MWNumericArray)output.GetField("iCa"));
                if(!iCa.IsComplex)
                    experiment.InitialCalcium = iCa.ToScalarDouble();
                MWNumericArray iCaError = ((MWNumericArray)output.GetField("iCa_err"));
                if(!iCaError.IsComplex)
                    experiment.InitialCalciumError = iCaError.ToScalarDouble();
                MWNumericArray peakCa = ((MWNumericArray)output.GetField("peakCa"));
                if(!peakCa.IsComplex)
                    experiment.PeakCalcium = peakCa.ToScalarDouble();
                MWNumericArray peakCaError = ((MWNumericArray)output.GetField("peakCa_err"));
                if(!peakCaError.IsComplex)
                    experiment.PeakCalciumError = peakCaError.ToScalarDouble();
                experiment.TimeToPeak = Convert.ToSingle(((MWNumericArray)output.GetField("TimeToPeak")).ToScalarDouble());
                experiment.TimeToSteadyState = Convert.ToSingle(((MWNumericArray)output.GetField("TimeToSteadyState")).ToScalarDouble());

                // Create processed recording
                MWStructArray caSignal = (MWStructArray) output["CalculatedCa"];
                MWNumericArray caTime = (MWNumericArray) caSignal["t"];
                MWNumericArray caValues = (MWNumericArray)caSignal["y"];
                MWNumericArray caLowError = (MWNumericArray)caSignal["y_lowerr"];
                MWNumericArray caHighError = (MWNumericArray)caSignal["y_higherr"];

                List<float> time = new List<float>(caTime.NumberOfElements);
                List<double> values = new List<double>(caTime.NumberOfElements);
                List<double> lowErr = new List<double>(caTime.NumberOfElements);
                List<double> highErr = new List<double>(caTime.NumberOfElements);

                for (int i = 1; i <= caTime.NumberOfElements; i++)
                {
                    try
                    {
                        float time_i = Convert.ToSingle(caTime[i].ToScalarDouble());
                        double value_i = caValues[i].ToScalarDouble();
                        double lowErr_i = caLowError[i].ToScalarDouble();
                        double highErr_i = caHighError[i].ToScalarDouble();

                        time.Add(time_i);
                        values.Add(value_i);
                        lowErr.Add(lowErr_i);
                        highErr.Add(highErr_i);
                    }
                    catch
                    {
                        continue; // Ignore errors
                    }
                }

                PhysiologyDataSet.RecordingsRow processedSignalRecording;
                if (experiment.IsProcessedSignalRecordingIDNull())
                    processedSignalRecording = PhysiologyDataSet.Recordings.NewRecordingsRow();
                else
                {
                    processedSignalRecording = PhysiologyDataSet.Recordings.FindByRecordingID(experiment.ProcessedSignalRecordingID);

                    ProgressDialog callback = new ProgressDialog("Loading Processed Calcium Recording...");
                    Program.DatabaseConnector.LoadRecordingSubdataFromDatabase(PhysiologyDataSet, processedSignalRecording.RecordingID, callback);

                    ICollection<string> dataNames = processedSignalRecording.GetDataNames();
                    if (dataNames.Contains("Calculated Calcium"))
                        processedSignalRecording.ClearData("Calculated Calcium");
                    if (dataNames.Contains("Low Estimated Calcium Error"))
                        processedSignalRecording.ClearData("Low Estimated Calcium Error");
                    if (dataNames.Contains("High Estimated Calcium Error"))
                        processedSignalRecording.ClearData("High Estimated Calcium Error");
                }
                processedSignalRecording.CellID = experiment.CellID;
                processedSignalRecording.BathSolution = signalRecording.BathSolution;
                if(!signalRecording.IsPipetteSolutionNull()) processedSignalRecording.PipetteSolution = signalRecording.PipetteSolution;
                processedSignalRecording.Recorded = DateTime.Now;
                processedSignalRecording.Description = String.Format(
                    "Processed calcium data based on signal recording {0}, high recording {1}, and low recording {2}. Generated at {3}.",
                    experiment.SignalRecordingID, experiment.HighRecordingID, experiment.LowRecordingID, processedSignalRecording.Recorded);
                if(!signalRecording.IsHoldingPotentialNull()) processedSignalRecording.HoldingPotential = signalRecording.HoldingPotential;
                processedSignalRecording.Title = "Processed Calcium Signal";
                
                processedSignalRecording.EndEdit();

                if(processedSignalRecording.RowState == System.Data.DataRowState.Detached)
                    PhysiologyDataSet.Recordings.AddRecordingsRow(processedSignalRecording);

                processedSignalRecording.AddData("Calculated Calcium", "uM", time.ToArray(), values.ToArray());
                processedSignalRecording.AddData("Low Estimated Calcium Error", "uM", time.ToArray(), lowErr.ToArray());
                processedSignalRecording.AddData("High Estimated Calcium Error", "uM", time.ToArray(), highErr.ToArray());
                processedSignalRecording.SetMetaData("SignalRecordingID", experiment.SignalRecordingID.ToString());
                processedSignalRecording.SetMetaData("HighRecordingID", experiment.HighRecordingID.ToString());
                processedSignalRecording.SetMetaData("LowRecordingID", experiment.LowRecordingID.ToString());
                
                PhysiologyDataSet.Recordings_Data.EndLoadData();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Fail("Error analyzing experiment.", e.Message);
            }
        }

        #endregion
    }
}
