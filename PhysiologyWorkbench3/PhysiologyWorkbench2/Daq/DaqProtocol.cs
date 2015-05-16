using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NationalInstruments.DAQmx;
using RRLab.PhysiologyWorkbench.Data;
using System.ComponentModel;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public abstract class DaqProtocol : System.ComponentModel.Component, INotifyPropertyChanged, IDisposable
    {
        public event EventHandler Starting, Finished, DataChanged, DataUpdated, SettingsChanged, Processed, Annotated;

        protected AutoResetEvent ContinuousExecutionSyncEvent = new AutoResetEvent(true);

        /// <summary>
        /// The name of the protocol. The default is the type name.
        /// </summary>
        public virtual string ProtocolName {
            get { return this.GetType().ToString(); }
        }

        /// <summary>
        /// A description of the protocol.
        /// </summary>
        public abstract string ProtocolDescription { get; }

        private bool _Disposing;
        /// <summary>
        /// True if the protocol is being disposed.
        /// </summary>
        public bool Disposing
        {
            get { return _Disposing; }
            set { _Disposing = value; }
        }
	
        /// <summary>
        /// True if continuous recording is supported.
        /// </summary>
        public virtual bool IsContinuousRecordingSupported
        {
            get
            {
                return false;
            }
        }
        private bool _IsProtocolRunning;
        /// <summary>
        /// True if the protocol is currently running.
        /// </summary>
        [Bindable(true)]
        public bool IsProtocolRunning
        {
            get { return _IsProtocolRunning; }
            protected set {
                _IsProtocolRunning = value;
                NotifyPropertyChanged("IsProtocolRunning");
            }
        }
	
        private Thread _ContinuouslyExecutingThread;
        /// <summary>
        /// The thread on which the protocol is continuously executing.
        /// </summary>
        protected Thread ContinuouslyExecutingThread
        {
            get { return _ContinuouslyExecutingThread; }
            set { _ContinuouslyExecutingThread = value; }
        }

        /// <summary>
        /// If true, continuous execution will stop.
        /// </summary>
        protected bool StopContinuousExecutionTrigger = true;
        /// <summary>
        /// If false, the protocol will wait before executing again.
        /// </summary>
        protected bool IsOkToStartNextExecution = true;

        private PhysiologyDataSet.RecordingsRow _Data;
        /// <summary>
        /// The collected data.
        /// </summary>
        public virtual PhysiologyDataSet.RecordingsRow Data
        {
            get { return _Data; }
            protected set {
                _Data = value;
            }
        }

        public event EventHandler DataSetChanged;
        /// <summary>
        /// The DataSet associated with Data.
        /// </summary>
        public PhysiologyDataSet DataSet
        {
            get
            {
                if (Data == null) return null;
                return Data.PhysiologyDataSet;
            }
        }

        public event EventHandler CellChanged;
        /// <summary>
        /// The Cell associated with the data.
        /// </summary>
        public PhysiologyDataSet.CellsRow Cell
        {
            get
            {
                return Data != null ? Data.CellsRow : null;
            }
        }

        public event EventHandler RecordingIDChanged;
        /// <summary>
        /// The RecordingID of the collected data.
        /// </summary>
        public long RecordingID
        {
            get
            {
                if (Data == null) return 0;
                else return Data.RecordingID;
            }
        }

        public event EventHandler ProgramChanged;

        private PhysiologyWorkbenchProgram _Program;
        
        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                _Program = value;
                OnProgramChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnProgramChanged(EventArgs e)
        {
            if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
            NotifyPropertyChanged("Program");
        }

        /// <summary>
        /// Creates a new recording object and disables notifications on the dataset.
        /// </summary>
        /// <returns>A new recording.</returns>
        protected virtual PhysiologyDataSet.RecordingsRow CreateNewRecording()
        {
            System.Diagnostics.Debug.Assert(Program != null, "DaqProtocol: Program null at CreateNewRecording.");
            if (Program != null)
            {
                PhysiologyDataSet.RecordingsRow recording = Program.DataManager.CreateNewRecording();

                // Suppress databinding
                recording.BeginEdit();
                recording.PhysiologyDataSet.Cells.BeginLoadData();
                recording.PhysiologyDataSet.Cells_Annotations.BeginLoadData();
                recording.PhysiologyDataSet.Recordings_Annotations.BeginLoadData();
                recording.PhysiologyDataSet.Recordings_Data.BeginLoadData();
                recording.PhysiologyDataSet.Recordings_EquipmentSettings.BeginLoadData();
                recording.PhysiologyDataSet.Recordings_MetaData.BeginLoadData();
                recording.PhysiologyDataSet.Recordings_ProtocolSettings.BeginLoadData();

                if (DataSetChanged != null && !Disposing)
                    if(Data == null || (Data != null && Data.PhysiologyDataSet != recording.PhysiologyDataSet) )
                        try
                        {
                            DataSetChanged(this, EventArgs.Empty);
                            NotifyPropertyChanged("DataSet");
                        }
                        catch (Exception x)
                        {
                            System.Diagnostics.Debug.Fail("DaqProtocol: Error during DataSetChanged event.", x.Message);
                        }
                if (CellChanged != null && !Disposing)
                    if(Data == null || (Data != null && Data.CellsRow != recording.CellsRow) )
                        try
                        {
                            CellChanged(this, EventArgs.Empty);
                            NotifyPropertyChanged("Cell");
                        }
                        catch (Exception x)
                        {
                            System.Diagnostics.Debug.Fail("DaqProtocol: Error during CellChanged event.", x.Message);
                        }
                if (DataChanged != null && !Disposing)
                    try
                    {
                        DataChanged(this, EventArgs.Empty);
                        NotifyPropertyChanged("Data");
                    }
                    catch (Exception x)
                    {
                        System.Diagnostics.Debug.Fail("DaqProtocol: Error during DataChanged event.", x.Message);
                    }
                if (RecordingIDChanged != null && !Disposing)
                    try
                    {
                        RecordingIDChanged(this, EventArgs.Empty);
                        NotifyPropertyChanged("RecordingID");
                    }
                    catch (Exception x)
                    {
                        System.Diagnostics.Debug.Fail("DaqProtocol: Error during RecordingIDChanged event.");
                    }
                
                return recording;
            }
            else throw new Exception("No dataset.");
        }

        /// <summary>
        /// Obtains a control which can be used to configure the protocol.
        /// </summary>
        /// <returns></returns>
        public virtual System.Windows.Forms.Control GetConfigurationControl()
        {
            System.Windows.Forms.PropertyGrid grid = new System.Windows.Forms.PropertyGrid();
            grid.SelectedObject = this;
            return grid;
        }

        /// <summary>
        /// Runs the protocol.
        /// </summary>
        public virtual void Run()
        {
            IsProtocolRunning = true;
            Initialize();
            Execute();
            FinalizeProtocol();
            IsProtocolRunning = false;
        }

        /// <summary>
        /// Prepares the protocol for execution.
        /// </summary>
        protected abstract void Initialize();
        /// <summary>
        /// Starts continuous execution of the protocol.
        /// </summary>
        public abstract void StartContinuousExecute();
        /// <summary>
        /// Executes the protocol.
        /// </summary>
        protected abstract void Execute();
        /// <summary>
        /// Stops continuous execution of the protocol.
        /// </summary>
        public abstract void StopContinuousExecute();
        /// <summary>
        /// Finalizes the protocol.
        /// </summary>
        protected abstract void FinalizeProtocol();

        /// <summary>
        /// Processes the collected data.
        /// </summary>
        protected virtual void ProcessData()
        {
            System.Diagnostics.Debug.Assert(Data != null, "DaqProtocol: Data null at processing data.");
            if (Data == null) return;

            System.Diagnostics.Debug.WriteLine("DaqProtocol: Processing data.");
            DateTime start = DateTime.Now;

            AnnotateData();
            Data.EndEdit();

            System.Diagnostics.Debug.WriteLine(String.Format("DaqProtocol: Processing and annotating data took {0}.", DateTime.Now - start));

            IsOkToStartNextExecution = true;
            FireDataUpdatedEvent(this, EventArgs.Empty);
            ContinuousExecutionSyncEvent.Set();
        }
        /// <summary>
        /// Annotates the collected data.
        /// </summary>
        protected virtual void AnnotateData()
        {
            System.Diagnostics.Debug.Assert(Data != null, "DaqProtocol: Data null at annotating data.");
            if (Data == null) return;

            System.Diagnostics.Debug.WriteLine("DaqProtocol: Annotating data.");

            lock (Data)
            {
                Data.SetProtocolSetting("Name", ProtocolName);
                Data.SetProtocolSetting("Description", ProtocolDescription);

                Data.Title = ProtocolName;
                Data.Description = ProtocolDescription;
            }

            OnAnnotated(EventArgs.Empty);
        }

        protected void FireSettingsChangedEvent(object sender, EventArgs e)
        {
            if (SettingsChanged != null && !Disposing) SettingsChanged(sender, e);
        }
        protected void FireStartingEvent(object sender, EventArgs e)
        {
            if (Starting != null && !Disposing) Starting(sender, e);
        }
        protected void FireFinishedEvent(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DaqProtocol: Firing finished event.");
            if (Finished != null && !Disposing) Finished(sender, e);
        }
        protected void FireDataUpdatedEvent(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DaqProtocol: Starting data update events.");
            DateTime start = DateTime.Now;

            if (Data != null)
            {
                Data.EndEdit();
                Data.PhysiologyDataSet.Cells.EndLoadData();
                Data.PhysiologyDataSet.Cells_Annotations.EndLoadData();
                Data.PhysiologyDataSet.Recordings_Annotations.EndLoadData();
                Data.PhysiologyDataSet.Recordings_Data.EndLoadData();
                Data.PhysiologyDataSet.Recordings_EquipmentSettings.EndLoadData();
                Data.PhysiologyDataSet.Recordings_MetaData.EndLoadData();
                Data.PhysiologyDataSet.Recordings_ProtocolSettings.EndLoadData();
            }
            if (DataUpdated != null)
                try
                {
                    DataUpdated(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DaqProtocol: Error during DataUpdated event.", x.Message);
                }
            NotifyPropertyChanged("Data");

            TimeSpan span = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("DaqProtocol: Data update events took " + span.ToString());
        }
        protected virtual void OnAnnotated(EventArgs e)
        {
            if(Annotated != null)
                try
                {
                    Annotated(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DaqProtocol: Error during Annotated event.", x.Message);
                }
        }

        public override string ToString()
        {
            return ProtocolName;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                try {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                } catch(Exception x)
                {
                    System.Diagnostics.Debug.Fail("DaqProtocol: Error during PropertyChanged event.", x.Message);
                }
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            Dispose(Disposing);
        }

        protected override void Dispose(bool disposing)
        {
            Disposing = true;
            try
            {
                FinalizeProtocol();
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine("DaqProtocol: Error finalizing protocol while disposing: " + x.Message);
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
