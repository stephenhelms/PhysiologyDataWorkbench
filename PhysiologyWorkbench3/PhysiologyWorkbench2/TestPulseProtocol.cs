using System;
using System.Collections.Generic;
using System.Text;
using NationalInstruments.DAQmx;
using RRLab.PhysiologyWorkbench.Utilities;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class TestPulseProtocol : DaqProtocol
    {
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
        private double _Resistance = 0;
        public double Resistance
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
                try
                {
                    if (TriggerRegenerationOfOutputWaveform)
                    {
                        GenerateTestPulseWaveform();
                        WriteToAOChannels();
                        TriggerRegenerationOfOutputWaveform = false;
                    }

                    AOTask.Start();

                    AITask.Start();
                    AsyncRecordFromAIChannels();
                    AITask.WaitUntilDone();

                    AITask.Stop();

                    AOTask.Stop();
                }
                catch (Exception e)
                {
                    StopContinuousExecutionTrigger = true;
                    System.Windows.Forms.MessageBox.Show("Error during execution: " + e.Message);
                    FinalizeProtocol();
                }
            }
        }
        public override void StopContinuousExecute()
        {
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
            AIReader = new AnalogMultiChannelReader(AITask.Stream);

        }
        protected virtual void AsyncRecordFromAIChannels()
        {
            IAsyncResult asyncRead = AIReader.BeginReadMultiSample(AcquisitionLength * SampleRate / 1000, new AsyncCallback(OnAIReadCompleted), null);
            asyncRead.AsyncWaitHandle.WaitOne();
        }

        protected override void FinalizeProtocol()
        {
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
                Amplifier.ForwardAbsoluteVHoldSettingChange -= new ForwardAbsoluteVHoldSettingChange(ReceiveForwardedVHoldChange);

                // Make sure the amplifier really got set to the holding potential
                Amplifier.SetHoldingPotential(Amplifier.AbsoluteVHold);
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

            StoreCollectedData(CachedTime, channelNames, data, units);
        }

        protected virtual void StoreCollectedData(float[] time, string[] channelNames, double[,] data, string[] units)
        {
            if (TriggerNewData || Data == null)
            {
                Data = CreateNewRecording();
                TriggerNewData = false;
            } 
            else Data.RemoveAllData();

            Data.AddData(channelNames, time, data, units);

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
            // Get mean gain from Gain dataName
            double gain = MathHelper.CalculateMean(Data.Data["Gain"].Values);
            Data.RemoveData("Gain");

            // Convert current using amplifier gain information
            double currentScalingFactor = Amplifier.CalculateVtoIFactorFromTTL(gain);
            Data.SetEquipmentSetting("AmplifierGain", currentScalingFactor.ToString());
            double[] currentData = Data.Data["Current"].Values;
            for (int i = 0; i < currentData.Length; i++)
                currentData[i] *= 1000 / currentScalingFactor; // *1000 b/c we want pA/V
            Data.SetChannelData("Current", currentData);

            // Determine capacitance correction value
            // TODO: *** Make the beta switch part of the amplifier settings
            double capac = MathHelper.CalculateMean(Data.Data["CellCapacitance"].Values);
            Data.RemoveData("CellCapacitance");
            Data.SetEquipmentSetting("AmplifierCapacitanceCorrection", Amplifier.CalculateCellCapacitanceFromTTL(capac).ToString());

            CalculateResistance();

            base.ProcessData(); // Will call AnnotateData()
        }
        protected virtual void CalculateResistance()
        {
            double dV = PulsePotential - RestingPotential;

            TimeResolvedData currentData = Data.Data["Current"];
            float[] time = currentData.Time;
            double[] current = currentData.Values;

            double restI = MathHelper.CalculateMeanOverTimeRange(time, current, ((float)RestingLength) / 4, 3 * ((float)RestingLength) / 4); // pA
            double pulseI = MathHelper.CalculateMeanOverTimeRange(time, current, ((float) RestingLength) + ((float)PulseLength) / 4, ((float)RestingLength) + 3 * ((float)PulseLength) / 4); // pA
            double noise = MathHelper.CalculateStDevOverTimeRange(time, current, ((float)RestingLength) / 4, 3 * ((float)RestingLength) / 4); // pA
            Data.SetMetaData("BaselineCurrent", restI.ToString("f0"));
            Data.SetMetaData("PeakCurrent", pulseI.ToString("f0"));
            Data.SetMetaData("CurrentNoise", noise.ToString("f2"));

            // Calculate resistance from Ohm's law (Rseal=dV/I)
            double Rseal = dV*1E-3 / ((pulseI - restI)*1E-12);

            Resistance = Rseal / 1E9; // Convert to Gigaohms

            if (ResistanceChanged != null && !Disposing) ResistanceChanged(this, new EventArgs());
        }
        protected override void AnnotateData()
        {
            base.AnnotateData();

            if (Data == null) return;

            Data.Title = "Test Pulse";

            Data.SetProtocolSetting("RestingPotential", RestingPotential.ToString());
            Data.SetProtocolSetting("RestingLength", RestingLength.ToString());
            Data.SetProtocolSetting("PulsePotential", PulsePotential.ToString());
            Data.SetProtocolSetting("PulseLength", PulseLength.ToString());

            Amplifier.AnnotateEquipmentData(Data);
            Data.SetEquipmentSetting("SampleRate", SampleRate.ToString());
            Data.SetEquipmentSetting("AISampleClock", SampleClock);
            Data.SetEquipmentSetting("SampleClockEdge", ClockEdge.ToString());
            Data.SetEquipmentSetting("AOTrigger", TriggerLine);
            Data.SetEquipmentSetting("AOTriggerEdge", TriggerEdge.ToString());
            
            Data.SetMetaData("Resistance", Resistance.ToString());
        }

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            RRLab.PhysiologyWorkbench.TestPulseSettingsBox control = new TestPulseSettingsBox();
            control.TestPulseProtocol = this;
            return control;
        }
    }
}
