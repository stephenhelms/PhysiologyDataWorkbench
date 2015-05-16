using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyWorkbench.Devices;
using NationalInstruments.DAQmx;
using System.ComponentModel;
using RRLab.Utilities;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class PulsedLaserLightRecordingProtocol : DaqProtocol
    {
        private Task _DOTask;
        protected Task DOTask
        {
            get { return _DOTask; }
            set { _DOTask = value; }
        }
        private Task _AITask;
        protected Task AITask
        {
            get { return _AITask; }
            set { _AITask = value; }
        }
        private string _AISampleClock = "/dev1/100kHzTimebase";
        public string AISampleClock
        {
            get { return _AISampleClock; }
            set {
                _AISampleClock = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }
        private string _DOSampleClock = "/dev1/100kHzTimebase";

        public string DOSampleClock
        {
            get { return _DOSampleClock; }
            set {
                _DOSampleClock = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private int _ProcessedSampleRate = 2500;
        [Bindable(true)]
        [DefaultValue(2500)]
        public int ProcessedSampleRate
        {
            get { return _ProcessedSampleRate; }
            set {
                if (ProcessedSampleRate == value) return;
                _ProcessedSampleRate = value;
                NotifyPropertyChanged("ProcessedSampleRate");
            }
        }
	
	
        private int _SampleRate = 100000;
        [Bindable(true)]
        [DefaultValue(100000)]
        public int SampleRate
        {
            get { return _SampleRate; }
            set {
                if (SampleRate == value) return;
                _SampleRate = value;
                NotifyPropertyChanged("SampleRate");
            }
        }

        private SampleClockActiveEdge _ClockEdge = SampleClockActiveEdge.Rising;
        public SampleClockActiveEdge ClockEdge
        {
            get { return _ClockEdge; }
            set { _ClockEdge = value; }
        }

        private int _AcquisitionLength = 10000;
        [Bindable(true)]
        [DefaultValue(5000)]
        public int AcquisitionLength
        {
            get { return _AcquisitionLength; }
            set {
                if (AcquisitionLength == value) return;
                _AcquisitionLength = value;
                NotifyPropertyChanged("AcquisitionLength");
            }
        }
        private List<string> _ChannelNames = new List<string>();
        public ICollection<string> ChannelNames
        {
            get { return _ChannelNames.AsReadOnly(); }
            protected set
            {
                _ChannelNames.Clear();
                _ChannelNames.AddRange(value);
                NotifyPropertyChanged("ChannelNames");
            }
        }

        private Amplifier _Amplifier;
        [Bindable(true)]
        public Amplifier Amplifier
        {
            get { return _Amplifier; }
            set
            {
                if (Amplifier == value) return;
                _Amplifier = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                NotifyPropertyChanged("Amplifier");
            }
        }
        private SpectraPhysicsNitrogenLaser _Laser;
        [Bindable(true)]
        public SpectraPhysicsNitrogenLaser Laser
        {
            get { return _Laser; }
            set
            {
                if (Laser == value) return;
                _Laser = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                NotifyPropertyChanged("Laser");
            }
        }

        private FilterWheelDevice _FilterWheel;
        [Bindable(true)]
        public FilterWheelDevice FilterWheel
        {
            get { return _FilterWheel; }
            set
            {
                if (FilterWheel == value) return;
                _FilterWheel = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                NotifyPropertyChanged("FilterWheel");
            }
        }

        private int _LaserPulseFrequency = 20;
        [Bindable(true)]
        [DefaultValue(20)]
        public int LaserPulseFrequency
        {
            get { return _LaserPulseFrequency; }
            set {
                if (LaserPulseFrequency == value) return;
                _LaserPulseFrequency = value;
                NotifyPropertyChanged("LaserPulseFrequency");
            }
        }

        private float _PreFlashAcquisitionTime = 0.5F;
        [Bindable(true)]

        private string _DOStartTrigger = "/dev1/ai/StartTrigger";

        public string DOStartTrigger
        {
            get { return _DOStartTrigger; }
            set {
                _DOStartTrigger = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private DigitalEdgeStartTriggerEdge _DOStartTriggerEdge = DigitalEdgeStartTriggerEdge.Rising;

        public DigitalEdgeStartTriggerEdge DOStartTriggerEdge
        {
            get { return _DOStartTriggerEdge; }
            set {
                _DOStartTriggerEdge = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }
	
        protected AnalogMultiChannelReader AIReader = null;


        public PulsedLaserLightRecordingProtocol()
        {
        }
        ~PulsedLaserLightRecordingProtocol()
        {
            Dispose();
        }

        protected double CurrentScalingFactor = 0;

        protected virtual void ReadCurrentGain()
        {
            if (AITask != null) FinalizeProtocol();

            using (AITask = new Task("AI"))
            {
                AITask.AIChannels.CreateVoltageChannel(Amplifier.GainAI, "Gain", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);

                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(AITask.Stream);
                double[] gainReadings = new double[10];
                for(int i=0; i<10; i++)
                    gainReadings[i] = reader.ReadSingleSample();
                CurrentScalingFactor = Amplifier.CalculateVtoIFactorFromTTL(MathHelper.CalculateMean(gainReadings));
            }

            AITask = null;
        }

        protected override void Initialize()
        {
            Data = null;
            CurrentScalingFactor = 0;
            _ChannelNames.Clear();
            if ((DOTask != null) || (AITask != null)) FinalizeProtocol();

            if (Amplifier != null) ReadCurrentGain();

            try
            {
                DOTask = new Task("DO");
                AITask = new Task("AI");

                ConfigureChannels(); // Configure channels
                if (ChannelNames.Count == 0)
                {
                    for (int i = 0; i < AITask.AIChannels.Count; i++)
                        _ChannelNames.Add(AITask.AIChannels[i].VirtualName);
                }

                int nsamples = AcquisitionLength * SampleRate / 1000;
                
                // Configure timing
                AITask.Timing.ConfigureSampleClock(AISampleClock, SampleRate, ClockEdge, SampleQuantityMode.FiniteSamples, nsamples);
                DOTask.Timing.ConfigureSampleClock(DOSampleClock, SampleRate, ClockEdge, SampleQuantityMode.FiniteSamples, nsamples);

                // Configure triggers
                DOTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(DOStartTrigger, DOStartTriggerEdge);

                AITask.Control(TaskAction.Verify);
                DOTask.Control(TaskAction.Verify);

                FireStartingEvent(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error during initialization: " + e.Message);
                FinalizeProtocol();
            }
        }

        protected virtual void ConfigureChannelReaders()
        {
            AIReader = new AnalogMultiChannelReader(AITask.Stream);
        }

        public override void StartContinuousExecute()
        {
            throw new ApplicationException("Continuous execution is not supported.");
        }

        protected override void Execute()
        {
            try
            {
                WriteToDOChannels();
                ConfigureChannelReaders();

                DOTask.Start();
                AITask.Start();

                BeginAsyncRecordFromAIChannels();
                
                AITask.WaitUntilDone();
                DOTask.WaitUntilDone();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error during execution: " + e.Message);
                FinalizeProtocol();
            }
        }

        protected virtual void ContinuousExecute()
        {
            throw new NotSupportedException("Method not supported.");
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
            }
        }
        protected virtual void AsyncRecordFromAIChannels()
        {
            // Read all the samples
            int nsamples = Convert.ToInt32(AcquisitionLength * SampleRate / 1000);
            AIReader.BeginReadMultiSample(nsamples, new AsyncCallback(OnAIReadCompleted), null);
        }
        protected virtual void BeginAsyncRecordFromAIChannels()
        {
            System.Threading.ThreadStart asyncRecord = new System.Threading.ThreadStart(AsyncRecordFromAIChannels);
            asyncRecord.Invoke();
        }

        protected override void FinalizeProtocol()
        {
            try
            {
                if (DOTask != null)
                {
                    DOTask.Dispose();
                    DOTask = null;
                }
                if (AITask != null)
                {
                    AITask.Dispose();
                    AITask = null;
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
            if (DOTask != null) DOTask.Dispose();
            if (AITask != null) AITask.Dispose();
            base.Dispose(disposing);
        }

        protected virtual void OnAIReadCompleted(IAsyncResult ar)
        {
            if (Disposing) return;

            double[,] data = AIReader.EndReadMultiSample(ar);

            string[] channelNames = new string[ChannelNames.Count];
            ChannelNames.CopyTo(channelNames, 0);

            StoreCollectedData(channelNames, data);
        }

        protected virtual void StoreCollectedData(string[] channelNames, double[,] data)
        {
            List<string> units = new List<string>();
            foreach (string name in channelNames)
                if (name == "Current") units.Add("pA");
                else units.Add("V");

            int nDataSamples = data.Length / channelNames.Length;

            float[] time;

            Data = CreateNewRecording();

            int nFilteredSamples = Convert.ToInt32(nDataSamples * ((double)ProcessedSampleRate) / ((double)SampleRate));
            time = new float[nFilteredSamples];
            double[,] filteredData = new double[channelNames.Length, nFilteredSamples];
            int i_stored = 0;
            for (int i = 0; i < nDataSamples; i++)
            {
                float t = 1000F * ((float)i) / ((float)SampleRate);

                float prev_t = i_stored >= 1 ? time[i_stored - 1] : 0;
                float dt = (t - prev_t);
                float cutoff = 1000F / ((float)ProcessedSampleRate);

                if (dt >= cutoff || i == 0)
                {
                    time[i_stored] = t;
                    for (int j = 0; j < channelNames.Length; j++)
                        filteredData[j, i_stored] = data[j, i];
                    i_stored++;
                }
                else continue;
            }
            Data.AddData(channelNames, time, filteredData, units.ToArray());

            ProcessData();
        }

        protected virtual void ConfigureChannels()
        {
            if (Amplifier != null)
                AITask.AIChannels.CreateVoltageChannel(Amplifier.CurrentAI, "Current", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);
            
            AITask.AIChannels.CreateVoltageChannel(Laser.PowerAI, "LaserPower", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);

            DOTask.DOChannels.CreateChannel("/dev2/port0", "DO", NationalInstruments.DAQmx.ChannelLineGrouping.OneChannelForAllLines);
            DOTask.Stream.WriteRegenerationMode = WriteRegenerationMode.AllowRegeneration;  
        }

        protected virtual void WriteToDOChannels()
        {
            DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(DOTask.Stream);
            byte[] output = Laser.GenerateLaserFlashDaqOutput(SampleRate, 1000/((double)LaserPulseFrequency), Laser.MinimumChargingTime); // Add laser method
            writer.WriteMultiSamplePort(false, output);          
        }

        public override string ProtocolName
        {
            get { return "Pulsed Laser Light Recording Protocol"; }
        }

        public override string ProtocolDescription
        {
            get { return "Records the current while illuminating continuously with a pulsed laser."; }
        }

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            return new PulsedLaserLightRecordingProtocolConfigPanel(this);
        }

        protected override void ProcessData()
        {
            lock (DataSet)
            {
                if (CurrentScalingFactor != 0)
                {
                    // Convert current using amplifier gain information
                    Data.SetEquipmentSetting("AmplifierGain", CurrentScalingFactor.ToString());

                    Data.ModifyData("Current", new Transform<double>(delegate(double value)
                    {
                        return 1000 * value / CurrentScalingFactor; // *1000 b/c we want pA/V
                    }), "pA");

                    Data.SetEquipmentSetting("DynamicRange-Min:Current", Convert.ToString(-10 * CurrentScalingFactor));
                    Data.SetEquipmentSetting("DynamicRange-Max:Current", Convert.ToString(10 * CurrentScalingFactor));
                }
            }

            base.ProcessData();
        }

        protected override void AnnotateData()
        {
            lock (DataSet)
            {
                Amplifier.AnnotateEquipmentData(Data);
                if (Laser != null) Laser.AnnotateEquipmentData(Data);
                if (FilterWheel != null) FilterWheel.AnnotateEquipmentData(Data);
                Data.SetMetaData("DataToShow", "Current");

                if (FilterWheel != null && Laser != null)
                    Data.Title = String.Format("PulsedLaserLightProtocol: {0} Hz {1} {2} nm Flashes", LaserPulseFrequency , FilterWheel.CurrentFilter, Laser.Wavelength);
            }

            base.AnnotateData();
        }
    }
}
