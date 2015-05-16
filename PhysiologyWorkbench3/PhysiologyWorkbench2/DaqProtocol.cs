using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NationalInstruments.DAQmx;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public abstract class DaqProtocol : System.ComponentModel.Component
    {
        public event EventHandler Starting, Finished, DataChanged, SettingsChanged;

        public virtual string ProtocolName {
            get { return this.GetType().ToString(); }
        }
        public abstract string ProtocolDescription { get; }

        private bool _Disposing;

        public bool Disposing
        {
            get { return _Disposing; }
            set { _Disposing = value; }
        }
	
        
        public virtual bool IsContinuousRecordingSupported
        {
            get
            {
                return false;
            }
        }
        private bool _IsProtocolRunning;

        public bool IsProtocolRunning
        {
            get { return _IsProtocolRunning; }
            set { _IsProtocolRunning = value; }
        }
	
        private Thread _ContinuouslyExecutingThread;
        protected Thread ContinuouslyExecutingThread
        {
            get { return _ContinuouslyExecutingThread; }
            set { _ContinuouslyExecutingThread = value; }
        }
        protected bool StopContinuousExecutionTrigger = true;

        private Recording _Data;
        public virtual Recording Data
        {
            get { return _Data; }
            protected set {
                _Data = value;
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
        }

        protected virtual Recording CreateNewRecording()
        {
            if (Program != null)
                return Program.DataManager.CreateNewRecording();
            else return new Recording();
        }

        public virtual System.Windows.Forms.Control GetConfigurationControl()
        {
            System.Windows.Forms.PropertyGrid grid = new System.Windows.Forms.PropertyGrid();
            grid.SelectedObject = this;
            return grid;
        }

        public virtual void Run()
        {
            IsProtocolRunning = true;
            Initialize();
            Execute();
            FinalizeProtocol();
            IsProtocolRunning = false;
        }
        protected abstract void Initialize();
        public abstract void StartContinuousExecute();
        protected abstract void Execute();
        public abstract void StopContinuousExecute();
        protected abstract void FinalizeProtocol();

        protected virtual void ProcessData()
        {
            if (Data == null) return;

            AnnotateData();
            if (DataChanged != null && !Disposing) DataChanged(this, EventArgs.Empty);
        }
        protected virtual void AnnotateData()
        {
            if (Data == null) return;

            Data.SetProtocolSetting("Name", ProtocolName);
            Data.SetProtocolSetting("Description", ProtocolDescription);

            Data.Title = ProtocolName;
            Data.Description = ProtocolDescription;
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
            if (Finished != null && !Disposing) Finished(sender, e);
        }
        protected void FireDataUpdatedEvent(object sender, EventArgs e)
        {
            if (DataChanged != null && !Disposing) DataChanged(sender, e);
        }
        public override string ToString()
        {
            return ProtocolName;
        }

        protected override void Dispose(bool disposing)
        {
            Disposing = true;
            base.Dispose(disposing);
        }
    }
}
