using System;
using System.Collections.Generic;
using System.Text;
using NationalInstruments.DAQmx;
using RRLab.Utilities;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class TestPulseProtocol : DaqProtocol
    {
        protected double[] _CellCapacitance;
        protected double[] _Gain;
        protected double[] _Current;

        public override string ProtocolName
        {
            get { return "Test Pulse"; }
        }
        public override string ProtocolDescription
        {
            get { return "Outputs a short voltage shift while recording the current."; }
        }

        [field: NonSerialized]
        public event EventHandler ResistanceChanged;
        private float _Resistance = 0;
        public float Resistance
        {
            get { return _Resistance; }
            protected set
            {
                _Resistance = value;
                if (ResistanceChanged != null) ResistanceChanged(this, EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler AmplifierChanged;
        private Amplifier _Amplifier;
        public Amplifier Amplifier
        {
            get { return _Amplifier; }
            set {
                if (Amplifier == value) return;
                _Amplifier = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                if (AmplifierChanged != null) AmplifierChanged(this, EventArgs.Empty);
            }
        }

        public virtual int AcquisitionLength
        {
            get
            {
                return (2*RestingLength+PulseLength);
            }
        }

        [field:NonSerialized]
        public event EventHandler RestingPotentialChanged;
        private int _RestingPotential = 0;
        public int RestingPotential
        {
            get { return _RestingPotential; }
            set
            {
                if (RestingPotential == value) return;
                _RestingPotential = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                if (RestingPotentialChanged != null) RestingPotentialChanged(this, EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler RestingLengthChanged;
        private int _RestingLength = 50;
        public int RestingLength
        {
            get { return _RestingLength; }
            set
            {
                if (RestingLength == value) return;
                _RestingLength = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                if (RestingLengthChanged != null) RestingLengthChanged(this, EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler PulsePotentialChanged;
        private int _PulsePotential = 10;
        public int PulsePotential
        {
            get { return _PulsePotential; }
            set
            {
                if (PulsePotential == value) return;
                _PulsePotential = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                if (PulsePotentialChanged != null) PulsePotentialChanged(this, EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler PulseLengthChanged;
        private int _PulseLength = 100;
        public int PulseLength
        {
            get { return _PulseLength; }
            set
            {
                if (PulseLength == value) return;
                _PulseLength = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                if (PulseLengthChanged != null) PulseLengthChanged(this, EventArgs.Empty);
            }
        }

        public override bool IsContinuousRecordingSupported
        {
            get
            {
                return true;
            }
        }

        private bool _TriggerRegenerationOfOutputWaveform;

        protected bool TriggerRegenerationOfOutputWaveform
        {
            get { return _TriggerRegenerationOfOutputWaveform; }
            set { _TriggerRegenerationOfOutputWaveform = value; }
        }

        private bool _TriggerNewData;
        public bool TriggerNewData
        {
            get { return _TriggerNewData; }
            set { _TriggerNewData = value; }
        }

        protected bool IsNewDataSet = true;	

        public TestPulseProtocol()
        {
        }

        private Task _AITask;
        protected Task AITask
        {
            get { return _AITask; }
            set { _AITask = value; }
        }
        private Task _AOTask;
        public Task AOTask
        {
            get { return _AOTask; }
            set { _AOTask = value; }
        }

        public event EventHandler SampleClockChanged;
        private string _SampleClock = "";
        public string SampleClock
        {
            get { return _SampleClock; }
            set {
                if (SampleClock == value) return;
                _SampleClock = value;
                if (SampleClockChanged != null) SampleClockChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler SampleRateChanged;
        private int _SampleRate = 2500;
        public int SampleRate
        {
            get { return _SampleRate; }
            set {
                if (SampleRate == value) return;
                _SampleRate = value;
                if (SampleRateChanged != null) SampleRateChanged(this, EventArgs.Empty);
            }
        }


        private SampleClockActiveEdge _ClockEdge = SampleClockActiveEdge.Rising;
        public SampleClockActiveEdge ClockEdge
        {
            get { return _ClockEdge; }
            set { _ClockEdge = value; }
        }
        private string _TriggerLine = "/Dev1/ai/StartTrigger";
        public string TriggerLine
        {
            get { return _TriggerLine; }
            set { _TriggerLine = value; }
        }
        private DigitalEdgeStartTriggerEdge _TriggerEdge = DigitalEdgeStartTriggerEdge.Rising;
        public DigitalEdgeStartTriggerEdge TriggerEdge
        {
            get { return _TriggerEdge; }
            set { _TriggerEdge = value; }
        }
        private List<string> _ChannelNames = new List<string>();
        protected List<string> ChannelNames
        {
            get { return _ChannelNames; }
            set
            {
                _ChannelNames = value;
            }
        }

        private SortedList<string,string> _ChannelUnits = new SortedList<string,string>();
        protected SortedList<string,string> ChannelUnits
        {
            get { return _ChannelUnits; }
        }

        protected AnalogMultiChannelReader AIReader = null;
        protected float[] CachedTime;

        protected override void Initialize()
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Initializing");

            Data = null;
            CachedTime = null;
            _ChannelNames.Clear();
            _ChannelUnits.Clear();

            if ((AOTask != null) || (AITask != null)) FinalizeProtocol();

            if (Amplifier == null) return;

            try
            {
                Amplifier.ForwardAbsoluteVHoldSettingChange += new ForwardAbsoluteVHoldSettingChange(ReceiveForwardedVHoldChange);

                AOTask = new Task("AO");
                AITask = new Task("AI");

                ConfigureChannels(); // Configure channels

                // Configure timing
                AOTask.Timing.ConfigureSampleClock(SampleClock, SampleRate, ClockEdge, SampleQuantityMode.FiniteSamples, AcquisitionLength * SampleRate / 1000);
                AITask.Timing.ConfigureSampleClock(SampleClock, SampleRate, ClockEdge, SampleQuantityMode.FiniteSamples, AcquisitionLength * SampleRate / 1000);

                // Configure triggers
                AOTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(TriggerLine, TriggerEdge);

                AOTask.Control(TaskAction.Verify);
                AITask.Control(TaskAction.Verify);

                FireStartingEvent(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error during initialization: " + e.Message);
                FinalizeProtocol();
            }
        }

        protected override void Execute()
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Execute.");
            try
            {
                WriteToAOChannels();
                ConfigureChannelReaders();

                AOTask.Start();

                AITask.Start();
                AsyncRecordFromAIChannels();
                AITask.WaitUntilDone();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error during execution: " + e.Message);
                FinalizeProtocol();
            }
        }
        public override void StartContinuousExecute()
        {
            if (!IsContinuousRecordingSupported) throw new ApplicationException("Continuous execution is not supported.");

            StopContinuousExecutionTrigger = false;
            IsProtocolRunning = true;

            Initialize();

            System.Threading.ThreadStart exec = new System.Threading.ThreadStart(ContinuousExecute);
            ContinuouslyExecutingThread = new System.Threading.Thread(exec);
            ContinuouslyExecutingThread.Start();
        }
        protected virtual void ContinuousExecute()
        {
            WriteToAOChannels();
            ConfigureChannelReaders();

            while (!StopContinuousExecutionTrigger)
            {
                DateTime start = DateTime.Now;
                try
                {
                    IsOkToStartNextExecution = false;
                    if (TriggerRegenerationOfOutputWaveform)
                    {
                        GenerateTestPulseWaveform();
                        WriteToAOChannels();
                        TriggerRegenerationOfOutputWaveform = false;
                    }

                    AOTask.Start();

                    AITask.Start();
                    AsyncRecordFromAIChannels();

                    // Have to check for null because sometimes the protocol gets finalized before this is finished
                    if(AITask != null) AITask.WaitUntilDone();

                    if(AITask != null) AITask.Stop();

                    if(AOTask != null) AOTask.Stop();
                }
                catch (Exception e)
                {
                    StopContinuousExecutionTrigger = true;
                    System.Windows.Forms.MessageBox.Show("Error during execution: " + e.Message);
                    FinalizeProtocol();
                }
                TimeSpan time = DateTime.Now - start;
                System.Diagnostics.Debug.WriteLine("Test pulse took " + time.ToString());
            }
        }
        public override void StopContinuousExecute()
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Stopping continuous execution.");
            StopContinuousExecutionTrigger = true;
            try
            {
                ContinuouslyExecutingThread.Join(AcquisitionLength * 2);
            }
            finally
            {
                ContinuouslyExecutingThread = null;
                FinalizeProtocol();
                IsProtocolRunning = false;
            }
        }

        protected virtual void ConfigureChannelReaders()
        {
            System.Diagnostics.Debug.Assert(AITask != null, "TestPulseProtocol: No AITask at ConfigureChannelReaders.");
            AIReader = new AnalogMultiChannelReader(AITask.Stream);
        }
        protected virtual void AsyncRecordFromAIChannels()
        {
            System.Diagnostics.Debug.Assert(AcquisitionLength * SampleRate / 1000 > 0);

            IAsyncResult asyncRead = AIReader.BeginReadMultiSample(AcquisitionLength * SampleRate / 1000, new AsyncCallback(OnAIReadCompleted), null);
            asyncRead.AsyncWaitHandle.WaitOne();
        }

        protected override void FinalizeProtocol()
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Finalizing protocol.");
            try
            {
                if (AOTask != null)
                {
                    AOTask.Dispose();
                    AOTask = null;
                }
                if (AITask != null)
                {
                    AITask.Dispose();
                    AITask = null;
                }
                if (Amplifier != null && !Disposing)
                {
                    Amplifier.ForwardAbsoluteVHoldSettingChange -= new ForwardAbsoluteVHoldSettingChange(ReceiveForwardedVHoldChange);

                    // Make sure the amplifier really got set to the holding potential
                    Amplifier.SetHoldingPotential(Amplifier.AbsoluteVHold);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error during finalization: " + e.Message);
            }
            FireFinishedEvent(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (AITask != null) AITask.Dispose();
                if (AOTask != null) AOTask.Dispose();
            }
            base.Dispose(disposing);
        }

        protected virtual void OnAIReadCompleted(IAsyncResult ar)
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: AI Read completed.");

            if (AITask == null || Disposing) return; // Stop if the protocol was finalized before the read happened

            double[,] data = AIReader.EndReadMultiSample(ar);

            if (CachedTime == null)
            {
                CachedTime = new float[((int)AcquisitionLength) * SampleRate / 1000];
                for (int i = 0; i < (SampleRate * AcquisitionLength / 1000); i++)
                {
                    CachedTime[i] = ((float)i) * 1000 / ((float)SampleRate);
                }
            }

            string[] channelNames = new string[ChannelNames.Count];
            ChannelNames.CopyTo(channelNames, 0);

            string[] units = new string[ChannelUnits.Count];
            for (int i = 0; i < channelNames.Length; i++)
                if (ChannelUnits.ContainsKey(channelNames[i]))
                    units[i] = ChannelUnits[channelNames[i]];
                else units[i] = "Unknown";

            DateTime start = DateTime.Now;
            ContinuousExecutionSyncEvent.WaitOne();
            TimeSpan span = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("Sync event wait took " + span.ToString());

            StoreCollectedData(CachedTime, channelNames, data, units);
        }

        protected virtual void StoreCollectedData(float[] time, string[] channelNames, double[,] data, string[] units)
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Storing data.");
            IsNewDataSet = false;
            if (TriggerNewData && Data != null)
            {
                lock (DataSet)
                {
                    Data = CreateNewRecording();
                }
                TriggerNewData = false;
                IsNewDataSet = true;
            }
            else if (Data == null)
            {
                Data = CreateNewRecording();
                TriggerNewData = false;
                IsNewDataSet = true;
            }

            if (!IsNewDataSet)
            {
                Data.ClearData("Current");
                Data.ClearEquipmentSettings();
                Data.ClearMetaData();
                Data.ClearProtocolSettings();
            }

            lock (DataSet)
            {
                int singleLength = data.Length / channelNames.Length;
                for (int i = 0; i < channelNames.Length; i++)
                {
                    double[] singleData = new double[singleLength];
                    for (int j = 0; j < singleLength; j++)
                        singleData[j] = data[i, j];

                    if (channelNames[i] == "Gain")
                        _Gain = singleData;
                    else if (channelNames[i] == "CellCapacitance")
                        _CellCapacitance = singleData;
                    else if (channelNames[i] == "Current")
                        _Current = singleData;
                    else if (IsNewDataSet)
                        Data.AddData(channelNames[i], units[i], time, singleData);
                    else Data.ReplaceData(channelNames[i], singleData);
                }
            }

            ProcessData();
        }

        protected virtual void ConfigureChannels()
        {
            AOTask.AOChannels.CreateVoltageChannel(Amplifier.VHoldAO, "VHold", Amplifier.VHoldMin, Amplifier.VHoldMax, AOVoltageUnits.Volts);
            AOTask.Stream.WriteRegenerationMode = WriteRegenerationMode.AllowRegeneration;

            AITask.AIChannels.CreateVoltageChannel(Amplifier.CurrentAI, "Current", AITerminalConfiguration.Rse, Amplifier.CurrentMin, Amplifier.CurrentMax, AIVoltageUnits.Volts);
            ChannelNames.Add("Current");
            ChannelUnits.Add("Current", "pA");

            AITask.AIChannels.CreateVoltageChannel(Amplifier.GainAI, "Gain", AITerminalConfiguration.Rse, Amplifier.GainMin, Amplifier.GainMax, AIVoltageUnits.Volts);
            ChannelNames.Add("Gain");
            ChannelUnits.Add("Gain", "V");

            AITask.AIChannels.CreateVoltageChannel(Amplifier.CapacAI, "CellCapacitance", AITerminalConfiguration.Rse, Amplifier.CapacMin, Amplifier.CapacMax, AIVoltageUnits.Volts);
            ChannelNames.Add("CellCapacitance");
            ChannelUnits.Add("CellCapacitance", "V");
        }
        protected virtual void WriteToAOChannels()
        {
            try
            {
                AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(AOTask.Stream);
                double[] output = GenerateTestPulseWaveform();
                writer.WriteMultiSample(false, output);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
                FinalizeProtocol();
            }
        }
        protected virtual double[] GenerateTestPulseWaveform()
        {
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Generating waveform.");

            double[] output = new double[AcquisitionLength * SampleRate / 1000];
            int nRestingSamples = RestingLength * SampleRate / 1000;
            int nPulseSamples = PulseLength * SampleRate / 1000;
            double restingVoltage =
                (RestingPotential + Amplifier.AbsoluteVHold) * Amplifier.VoltageOutScalingFactor;
            double pulseVoltage =
                (PulsePotential + Amplifier.AbsoluteVHold) * Amplifier.VoltageOutScalingFactor;

            for (int i = 0; i < nRestingSamples; i++)
                output[i] = restingVoltage;
            for (int i = nRestingSamples; i < (nRestingSamples + nPulseSamples); i++)
                output[i] = pulseVoltage;
            for (int i = (nRestingSamples + nPulseSamples); i < output.Length; i++)
                output[i] = restingVoltage;

            return output;
        }
        protected virtual bool ReceiveForwardedVHoldChange(double vhold)
        {
            TriggerRegenerationOfOutputWaveform = true;
            return true;
        }
        protected override void ProcessData()
        {
            DateTime start = DateTime.Now;

            lock (DataSet)
            {
                DateTime start2 = DateTime.Now;
                // Get mean gain from Gain dataName
                double gain = MathHelper.CalculateMean(_Gain);

                // Convert current using amplifier gain information
                double currentScalingFactor = Amplifier.CalculateVtoIFactorFromTTL(gain);
                Data.AddEquipmentSetting("AmplifierGain", currentScalingFactor.ToString());
                System.Diagnostics.Debug.WriteLine(String.Format("TestPulseProtocol: Calculating gain took {0}.", DateTime.Now - start2));

                start2 = DateTime.Now;
                for(int i=0; i < _Current.Length; i++)
                    _Current[i] *= 1000 / currentScalingFactor; // *1000 b/c we want pA/V
                Data.AddData("Current", "pA", CachedTime, _Current);

                System.Diagnostics.Debug.WriteLine(String.Format("TestPulseProtocol: Scaling current took {0}.", DateTime.Now - start2));

                start2 = DateTime.Now;
                // Determine capacitance correction value
                // TODO: *** Make the beta switch part of the amplifier settings
                double capac = MathHelper.CalculateMean(_CellCapacitance);
                Data.AddEquipmentSetting("AmplifierCapacitanceCorrection", Amplifier.CalculateCellCapacitanceFromTTL(capac).ToString());
                System.Diagnostics.Debug.WriteLine(String.Format("TestPulseProtocol: Calculating cell capacitance took {0}.", DateTime.Now - start2));
            }

            DateTime start3 = DateTime.Now;
            CalculateResistance();
            System.Diagnostics.Debug.WriteLine(String.Format("TestPulseProtocol: Calculating resistance took {0}.", DateTime.Now - start3));

            System.Diagnostics.Debug.WriteLine(String.Format("TestPulseProtocol: Processing data took {0}.", DateTime.Now - start));

            base.ProcessData(); // Will call AnnotateData()
        }
        protected virtual void CalculateResistance()
        {
            double dV = PulsePotential - RestingPotential;

            TimeResolvedData currentData = Data.GetData("Current");
            float[] time = currentData.Time;
            double[] current = currentData.Values;

            double restI = MathHelper.CalculateMeanOverTimeRange(time, current, ((float)RestingLength) / 4, 3 * ((float)RestingLength) / 4); // pA
            double pulseI = MathHelper.CalculateMeanOverTimeRange(time, current, ((float) RestingLength) + ((float)PulseLength) / 4, ((float)RestingLength) + 3 * ((float)PulseLength) / 4); // pA
            double noise = MathHelper.CalculateStDevOverTimeRange(time, current, ((float)RestingLength) / 4, 3 * ((float)RestingLength) / 4); // pA

            
            lock (DataSet)
            {
                Data.AddMetaData("BaselineCurrent", restI.ToString("f0"));
                Data.AddMetaData("PeakCurrent", pulseI.ToString("f0"));
                Data.AddMetaData("CurrentNoise", noise.ToString("f2"));
            }

            // Calculate resistance from Ohm's law (Rseal=dV/I)
            // If the current is equal to the noise, return infinity
            if (dV > 0 && (pulseI - restI) < 0) Resistance = Single.PositiveInfinity;
            // Otherwise calculate proper resistance
            else
            {
                double Rseal = dV * 1E-3 / (Math.Abs(pulseI - restI) * 1E-12);
                Resistance = Convert.ToSingle(Rseal / 1E9); // Convert to Gigaohms
            }

            
            if (ResistanceChanged != null && !Disposing) ResistanceChanged(this, new EventArgs());
        }


        protected override void AnnotateData()
        {
            base.AnnotateData();

            System.Diagnostics.Debug.Assert(Data != null, "TestPulseProtocol: Data null at annotating data.");
            if (Data == null) return;

            
            System.Diagnostics.Debug.WriteLine("TestPulseProtocol: Annotating data.");

            DateTime start = DateTime.Now;

            lock (DataSet)
            {
                Data.Title = "Test Pulse";

                Data.AddProtocolSetting("RestingPotential", RestingPotential.ToString());
                Data.AddProtocolSetting("RestingLength", RestingLength.ToString());
                Data.AddProtocolSetting("PulsePotential", PulsePotential.ToString());
                Data.AddProtocolSetting("PulseLength", PulseLength.ToString());

                Data.AddEquipmentSetting("SampleRate", SampleRate.ToString());

                Data.AddMetaData("Resistance", Resistance.ToString());
            }

            Amplifier.AnnotateEquipmentData(Data);

            System.Diagnostics.Debug.WriteLine(String.Format("TestPulseProtocol: Annotating data took {0}.", DateTime.Now - start));
        }

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            RRLab.PhysiologyWorkbench.TestPulseSettingsBox control = new TestPulseSettingsBox();
            control.TestPulseProtocol = this;
            return control;
        }
    }
}
