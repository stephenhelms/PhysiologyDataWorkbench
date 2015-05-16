using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyDataWorkshop.Experiments;
using MacroscopicResponseFitter;
using System.ComponentModel;
using RRLab.PhysiologyDataConnectivity;
using MySql.Data.MySqlClient;
using MathWorks.MATLAB.NET.Arrays;
using RRLab.Utilities;
using System.Windows.Forms;

namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    public class MacroscopicBumpExperiment : Experiment, IDisposable
    {
        #region MacroscopicBumpExperiment Properties
        /// <summary>
        /// Occurs when the MacroscopicBumpsDataSet changes.
        /// </summary>
        public event EventHandler MacroscopicBumpsDataSetChanged;
        private MacroscopicRecordingsDataSet _MacroscopicBumpsDataSet;
        [Bindable(true)]
        public MacroscopicRecordingsDataSet MacroscopicBumpsDataSet
        {
            get { return _MacroscopicBumpsDataSet; }
            set {
                _MacroscopicBumpsDataSet = value;
                OnMacroscopicBumpsDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnMacroscopicBumpsDataSetChanged(EventArgs e)
        {
            if(MacroscopicBumpsDataSetChanged != null)
                try
                {
                    MacroscopicBumpsDataSetChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("MacroscopicBumpExperiment: Error during MacroscopicBumpsDataSetChanged event.", x.Message);
                }
        }

        private MacroscopicResponseFitter.MacroscopicResponseFitter _BumpFitter;

        public MacroscopicResponseFitter.MacroscopicResponseFitter BumpFitter
        {
            get { return _BumpFitter; }
            set { _BumpFitter = value; }
        }

        public event EventHandler CurrentMacroscopicBumpChanged;
        private MacroscopicRecordingsDataSet.MacroscopicRecordingsRow _CurrentMacroscopicBump;
        
        public MacroscopicRecordingsDataSet.MacroscopicRecordingsRow CurrentMacroscopicBump
        {
            get { return _CurrentMacroscopicBump; }
            set {
                if (CurrentMacroscopicBump == value) return;

                _CurrentMacroscopicBump = value;
                OnCurrentMacroscopicBumpChanged(EventArgs.Empty);
                NotifyPropertyChanged("CurrentMacroscopicBump");
            }
        }

        protected virtual void OnCurrentMacroscopicBumpChanged(EventArgs e)
        {
            PhysiologyDataSet.Recordings_Data.Clear();

            if(CurrentMacroscopicBump != null)
                LoadRecordingFromDatabase(CurrentMacroscopicBump.RecordingID);

            if(CurrentMacroscopicBumpChanged != null)
                try
                {
                    CurrentMacroscopicBumpChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Macroscopic Bump ExperimentRow: Error during CurrentMacroscopicBumpChanged event.", x.Message);
                }
        }
	
        #endregion

        #region GUI-related properties

        private string _HistogramColumn;
        [Bindable(true)]
        public string HistogramColumn
        {
            get { return _HistogramColumn; }
            set {
                _HistogramColumn = value;
                NotifyPropertyChanged("HistogramColumn");
            }
        }

        private string _HistogramFilter;
        [Bindable(true)]
        public string HistogramFilter
        {
            get { return _HistogramFilter; }
            set {
                _HistogramFilter = value;
                NotifyPropertyChanged("HistogramFilter");
            }
        }

        private string _ScatterXColumn;
        [Bindable(true)]
        public string ScatterXColumn
        {
            get { return _ScatterXColumn; }
            set {
                _ScatterXColumn = value;
                NotifyPropertyChanged("ScatterXColumn");
            }
        }

        private string _ScatterYColumn;
        [Bindable(true)]
        public string ScatterYColumn
        {
            get { return _ScatterYColumn; }
            set {
                _ScatterYColumn = value;
                NotifyPropertyChanged("ScatterYColumn");
            }
        }

        private string _ScatterFilter;
        [Bindable(true)]
        public string ScatterFilter
        {
            get { return _ScatterFilter; }
            set {
                _ScatterFilter = value;
                NotifyPropertyChanged("ScatterFilter");
            }
        }
	
	
	
		

        #endregion

        #region Constructors and Destructor
        public MacroscopicBumpExperiment() : base()
        {
            
        }
        ~MacroscopicBumpExperiment()
        {
            Dispose();
        }
        #endregion

        #region Intialization
        protected override void Initialize()
        {
            try
            {
                BumpFitter = new MacroscopicResponseFitter.MacroscopicResponseFitter();
            }
            catch (Exception x)
            {
                ;
            }
            base.Initialize();
        }
        #endregion

        #region Overriden ExperimentRow methods

        public override string Name
        {
            get
            {
                return "Macroscopic Bump";
            }
        }

        private MacroscopicBumpExperimentPanel _ExperimentPanelControl = null;
        public override System.Windows.Forms.Control GetExperimentPanelControl()
        {
            if (_ExperimentPanelControl == null)
                _ExperimentPanelControl = new MacroscopicBumpExperimentPanel(this);
            
            return _ExperimentPanelControl;
        }

        protected override void ConfigureRecordingActions()
        {
            RecordingActions.Add("Add Macroscopic Bump Recording",
                new Action<PhysiologyDataSet.RecordingsRow>(AddMacroscopicBumpRecording));
            RecordingActions.Add("Remove Macroscopic Bump Recording",
                new Action<PhysiologyDataSet.RecordingsRow>(RemoveMacroscopicBumpRecording));
            
            base.ConfigureRecordingActions();
        }

        public override bool IsRecordingActionEnabled(string action, PhysiologyDataSet.RecordingsRow recording)
        {
            if (MacroscopicBumpsDataSet == null) MacroscopicBumpsDataSet = new MacroscopicRecordingsDataSet();
            switch (action)
            {
                case "Add Macroscopic Bump Recording":
                    return true;
                case "Remove Macroscopic Bump Recording":
                    return MacroscopicBumpsDataSet.MacroscopicRecordings.Select(
                        String.Format("RecordingID = {0}", recording["RecordingID", System.Data.DataRowVersion.Original])).Length > 0;
                default:
                    return true;
            }
        }
        #endregion

        #region Database

        private LogInDialog _LogInDialog = new LogInDialog();

        public LogInDialog LogInDialog
        {
            get { return _LogInDialog; }
            set { _LogInDialog = value; }
        }

        public virtual void LoadDataFromDatabase()
        {
            if (MacroscopicBumpsDataSet == null)
                MacroscopicBumpsDataSet = new MacroscopicRecordingsDataSet();

            if (LogInDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (MacroscopicRecordingsDataSetTableAdapters.MacroscopicRecordingsTableAdapter adapter = new RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump.MacroscopicRecordingsDataSetTableAdapters.MacroscopicRecordingsTableAdapter())
                {
                    using (MySqlConnection connection = new MySqlConnection(LogInDialog.ConnectionString))
                    {
                        adapter.Connection = connection;
                        adapter.Fill(MacroscopicBumpsDataSet.MacroscopicRecordings);
                    }
                }
            }
        }

        #endregion

        #region Recording Action Implementations
        /// <summary>
        /// Adds a recording to the list of macroscopic recordings. This will also trigger the display of
        /// a form asking for additional information.
        /// </summary>
        /// <param name="recording">The recording to add</param>
        public virtual void AddMacroscopicBumpRecording(PhysiologyDataSet.RecordingsRow recording)
        {
            AddNewRecordingDialog dialog = new AddNewRecordingDialog(this, recording);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Sync database
                if (LogInDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (MySqlConnection connection = new MySqlConnection(LogInDialog.ConnectionString))
                    {
                        try
                        {
                            MacroscopicBumpsDataSet.MacroscopicRecordings.Update(connection);
                        }
                        catch (Exception x)
                        {
                            System.Diagnostics.Debug.Fail("MacroscopicBumpExperiment: Error updating database.", x.Message);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Removes a recording from the list of macroscopic recordings
        /// </summary>
        /// <param name="recording">The recording to remove</param>
        public virtual void RemoveMacroscopicBumpRecording(PhysiologyDataSet.RecordingsRow recording)
        {
            MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[] rows = MacroscopicBumpsDataSet.MacroscopicRecordings.Select(
                String.Format("RecordingID = {0}", recording.RecordingID)) as MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[];
            if (rows != null && rows.Length > 0)
                foreach (MacroscopicRecordingsDataSet.MacroscopicRecordingsRow row in rows)
                    row.Delete();
            else throw new ApplicationException("Recording not found in list of macroscopic recordings.");
        }
        #endregion

        #region Other Actions

        private double _BumpDetectionThreshold = 2;

        public double BumpDetectionThreshold
        {
            get { return _BumpDetectionThreshold; }
            set { _BumpDetectionThreshold = value; }
        }

        public virtual void CalculateMacroscopicBumpFitInMatlab(MacroscopicRecordingsDataSet.MacroscopicRecordingsRow bump)
        {
            try
            {
                PhysiologyDataSet.RecordingsRow recording = PhysiologyDataSet.Recordings.FindByRecordingID(bump.RecordingID);

                TimeResolvedData data = recording.GetData("Current");
                MWNumericArray time = (MWNumericArray)data.Time;
                MWNumericArray currentData = (MWNumericArray)data.Values;

                // [J, t_peak, t_lat, t_act1, t_act2, t_inact1, t_inact2, J_int, fitsCriteria]
                MWArray[] output = BumpFitter.GetMacroBumpStats(8, time, currentData, (MWArray)BumpDetectionThreshold);
                
                bump.BeginEdit();
                bump.Amplitude = ((MWNumericArray)output[0]).ToScalarDouble();
                bump.TimeOfPeak = ((MWNumericArray)output[1]).ToScalarFloat();
                bump.LatencyTime = ((MWNumericArray)output[2]).ToScalarFloat();
                bump.SlowActivationTime = ((MWNumericArray)output[3]).ToScalarFloat();
                bump.FastActivationTime = ((MWNumericArray)output[4]).ToScalarFloat();
                bump.FastInactivationTime = ((MWNumericArray)output[5]).ToScalarFloat();
                bump.SlowInactivationTime = ((MWNumericArray)output[6]).ToScalarFloat();
                bump.ChargeIntegral = ((MWNumericArray)output[7]).ToScalarFloat();
                bump.EndEdit();
            }
            catch (Exception x)
            {
                throw new Exception("Error calculating macroscopic bump fit.", x);
            }
        }

        public virtual TimeResolvedData GetAverageMacroscopicResponse(string filter)
        {
            return GetAverageMacroscopicResponse(filter, true, false);
        }
        public virtual TimeResolvedData GetAverageMacroscopicResponse(string filter, bool adjustBaseline, bool normalizeAmplitude)
        {
            ProgressDialog dialog = new ProgressDialog("Getting average macroscopic response...");
            IProgressCallback callback = dialog;

            MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[] rows = MacroscopicBumpsDataSet.MacroscopicRecordings.Select(filter) as MacroscopicRecordingsDataSet.MacroscopicRecordingsRow[];
            List<TimeResolvedData> interpolatedData = new List<TimeResolvedData>();

            callback.Begin(0, rows.Length);
            callback.SetTaskInfo("Processing macroscopic responses...");

            try
            {
                MLApp.MLApp matlab = new MLApp.MLAppClass();

                foreach (MacroscopicRecordingsDataSet.MacroscopicRecordingsRow row in rows)
                {
                    callback.Increment(1);
                    PhysiologyDataSet.RecordingsRow recording = Program.DataSet.Recordings.FindByRecordingID(row.RecordingID);
                    if (recording == null) continue; // If the recording doesn't exist, skip it

                    Program.LoadRecordingAndSubdataFromDatabase(recording);
                    TimeResolvedData current = recording.GetData("Current");

                    if (current.DataPoints.Length == 0) continue; // If there's no data, skip it

                    double baseline = MathHelper.CalculateMeanOverTimeRange(current.Time, current.Values, current[0].Time, 0);

                    try
                    {
                        matlab.PutWorkspaceData("time", "base", current.Time);
                        matlab.PutWorkspaceData("current", "base", current.Values);
                        
                        if(adjustBaseline)
                            matlab.Execute(String.Format("current = current - {0};", baseline));
                        if(normalizeAmplitude)
                            matlab.Execute("current = current ./ max(abs(current));");

                        matlab.Execute("time_int = [-50:1:time(end)];current_int = interp1(time,current,time_int);");
                        float[,] current_int_m = (float[,]) matlab.GetVariable("current_int", "base");
                        float[,] time_int_m = (float[,]) matlab.GetVariable("time_int", "base");
                        
                        // Convert arrays to appropriate format
                        float[] time_int = new float[time_int_m.Length];
                        for (int i = 0; i < time_int_m.Length; i++)
                            time_int[i] = time_int_m[0,i];
                        double[] current_int = new double[current_int_m.Length];
                        for (int i = 0; i < current_int_m.Length; i++)
                            current_int[i] = Convert.ToDouble(current_int_m[0,i]);
                        
                        interpolatedData.Add(new TimeResolvedData(time_int, current_int));
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.Fail("Error while using MATLAB.", e.Message);
                    }

                    Program.DataSet.Recordings_Data.Clear();
                }
                matlab.Quit();
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.Fail("Error while processing macroscopic responses.", x.Message);
                callback.NotifyError(new ExceptionEventArgs(x));
            }

            
            int shortestTime = Int32.MaxValue;
            foreach (TimeResolvedData data in interpolatedData)
                if (data.DataPoints.Length < shortestTime) shortestTime = data.DataPoints.Length;

            TimeResolvedDataPoint[] points = new TimeResolvedDataPoint[shortestTime];
            for (int i = 0; i < shortestTime; i++)
            {
                double[] values = new double[interpolatedData.Count];
                for (int j = 0; j < interpolatedData.Count; j++)
                    values[j] = interpolatedData[j].DataPoints[i].Data;
                points[i] = new TimeResolvedDataPoint(interpolatedData[0].DataPoints[i].Time, MathHelper.CalculateMean(values));
            }

            callback.NotifyFinished();
            dialog.Close();
            dialog.Dispose();

            return new TimeResolvedData(points);
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            if (BumpFitter != null)
                try
                {
                    BumpFitter.Dispose();
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("MacroscopicBumpExperiment: Error while disposing.", x.Message);
                }
        }

        #endregion
    }
}
