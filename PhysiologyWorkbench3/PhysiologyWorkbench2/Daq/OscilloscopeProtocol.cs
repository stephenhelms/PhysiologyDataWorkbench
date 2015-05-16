using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;
using NationalInstruments.DAQmx;
using System.ComponentModel;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class OscilloscopeProtocol : DaqProtocol
    {

        public override string ProtocolName
        {
            get { return "Oscilloscope"; }
        }

        public override string ProtocolDescription
        {
            get { return "Records from selected DAQ channels."; }
        }

        private Task _AITask;

        protected Task AITask
        {
            get { return _AITask; }
            set { _AITask = value; }
        }

        private float _UpdateTime = 200;

        public float UpdateTime
        {
            get { return _UpdateTime; }
            set {
                _UpdateTime = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private double _SampleRate = 10000;

        public double SampleRate
        {
            get { return _SampleRate; }
            set {
                _SampleRate = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        public override bool IsContinuousRecordingSupported
        {
            get
            {
                return true;
            }
        }

        public event EventHandler ChannelsToRecordChanged;
        private SortedList<string, string> _ChannelsToRecord = new SortedList<string, string>();
        public IDictionary<string, string> ChannelsToRecord
        {
            get { return _ChannelsToRecord; }
        }

        protected AnalogMultiChannelReader ChannelReader;
        private float[] _CachedTimeVector;

        public OscilloscopeProtocol()
        {
        }

        public void AddChannel(string name, string address)
        {
            _ChannelsToRecord.Add(name, address);
            FireSettingsChangedEvent(this, EventArgs.Empty);
            if (ChannelsToRecordChanged != null) ChannelsToRecordChanged(this, EventArgs.Empty);
        }
        public void RemoveChannel(string name)
        {
            _ChannelsToRecord.Remove(name);
            FireSettingsChangedEvent(this, EventArgs.Empty);
            if (ChannelsToRecordChanged != null) ChannelsToRecordChanged(this, EventArgs.Empty);
        }

        protected override void Initialize()
        {
            try
            {
                AITask = new Task("AI");
                ConfigureChannels();
                
                AITask.Timing.ConfigureSampleClock("", SampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, Convert.ToInt32(UpdateTime*SampleRate*5/1000));
                GenerateChannelReader();
                FireStartingEvent(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                FinalizeProtocol();
            }
        }
        protected virtual void ConfigureChannels()
        {
            foreach (KeyValuePair<string, string> kv in ChannelsToRecord)
                AITask.AIChannels.CreateVoltageChannel(kv.Value, kv.Key, AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);
        }
        protected virtual void GenerateChannelReader()
        {
            ChannelReader = new AnalogMultiChannelReader(AITask.Stream);
        }

        public override void StartContinuousExecute()
        {
            if (!IsContinuousRecordingSupported) throw new ApplicationException("Continuous execution is not supported.");

            StopContinuousExecutionTrigger = false;

            Initialize();

            try
            {
                AITask.Start();
                BeginAsyncRead();
            }
            catch (Exception e)
            {
                ContinuouslyExecutingThread = null;
                FinalizeProtocol();
            }
        }

        protected override void Execute()
        {
            try
            {
                AITask.Start();
                BeginAsyncRead();
                System.Threading.Thread.Sleep(Convert.ToInt32(UpdateTime));
                AITask.Stop();
            }
            catch (Exception e)
            {
                FinalizeProtocol();
            }
        }
        protected virtual void BeginAsyncRead()
        {
            System.Threading.ThreadStart asyncRead = new System.Threading.ThreadStart(AsyncRead);
            asyncRead.BeginInvoke(null, null);
        }
        protected virtual void AsyncRead()
        {
            if (!AITask.IsDone)
            {
                int nsamples = Convert.ToInt32(UpdateTime * SampleRate / 1000);
                IAsyncResult ar = ChannelReader.BeginReadMultiSample(nsamples, new AsyncCallback(OnAsyncReadFinished), null);
            }
        }

        public override void StopContinuousExecute()
        {
            StopContinuousExecutionTrigger = true;
            try
            {
                AITask.Stop();
            }
            finally
            {
                ContinuouslyExecutingThread = null;
                FinalizeProtocol();
            }
        }

        protected override void FinalizeProtocol()
        {
            if (AITask != null)
            {
                AITask.Dispose();
                AITask = null;
            }
            _CachedTimeVector = null;

            FireFinishedEvent(this, EventArgs.Empty);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (AITask != null) AITask.Dispose();
        }

        protected virtual void OnAsyncReadFinished(IAsyncResult ar)
        {
            if (Disposing) return;
            try
            {
                double[,] data = ChannelReader.EndReadMultiSample(ar);

                if (_CachedTimeVector == null)
                {
                    int nsamples = Convert.ToInt32(UpdateTime * SampleRate / 1000);
                    _CachedTimeVector = new float[nsamples];
                    for (int i = 0; i < nsamples; i++)
                    {
                        _CachedTimeVector[i] = ((float)i) * 1000 / ((float)SampleRate);
                    }
                }

                string[] channelNames = new string[ChannelsToRecord.Count];
                ChannelsToRecord.Keys.CopyTo(channelNames, 0);

                string[] units = new string[channelNames.Length];
                for (int i = 0; i < units.Length; i++)
                    units[i] = "V";

                StoreCollectedData(_CachedTimeVector, channelNames, data, units);

                if (!StopContinuousExecutionTrigger) BeginAsyncRead();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while reading data: " + e.Message);
            }
        }

        protected virtual void StoreCollectedData(float[] time, string[] channelNames, double[,] data, string[] units)
        {
            Data = CreateNewRecording();
            Data.AddData(channelNames, time, data, units);
            ProcessData();
        }

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            return new OscilloscopeConfigurationControl(this);
        }
    }
}
