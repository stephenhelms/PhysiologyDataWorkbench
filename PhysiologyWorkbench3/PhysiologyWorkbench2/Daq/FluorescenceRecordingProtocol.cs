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
    public class LaserFluorescenceRecordingProtocol : DaqProtocol
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

        private int _ProcessedSampleRate = 10000;
        [Bindable(true)]
        [DefaultValue(10000)]
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

        private int _AcquisitionLength = 5000;
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

        private Photodiode _Photodiode1;
        [Bindable(true)]
        public Photodiode Photodiode1
        {
            get { return _Photodiode1; }
            set
            {
                if (Photodiode1 == value) return;
                _Photodiode1 = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                NotifyPropertyChanged("Photodiode1");
            }
        }

        private Photodiode _Photodiode2;
        [Bindable(true)]
        public Photodiode Photodiode2
        {
            get { return _Photodiode2; }
            set
            {
                if (Photodiode2 == value) return;
                _Photodiode2 = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                NotifyPropertyChanged("Photodiode2");
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
        [DefaultValue(0.5F)]
        public float PreFlashAcquisitionTime
        {
            get { return _PreFlashAcquisitionTime; }
            set {
                if (PreFlashAcquisitionTime == value) return;
                _PreFlashAcquisitionTime = value;
                NotifyPropertyChanged("PreFlashAcquisitionTime");
            }
        }
        private float _PostFlashAcquisitionTime = 1.5F;
        [Bindable(true)]
        [DefaultValue(1.5F)]
        public float PostFlashAcquisitionTime
        {
            get { return _PostFlashAcquisitionTime; }
            set {
                if (PostFlashAcquisitionTime == value) return;
                _PostFlashAcquisitionTime = value;
                NotifyPropertyChanged("PostFlashAcquisitionTime");
            }
        }

        private bool _DiscardDataBetweenFlashes = true;
        [Bindable(true)]
        [DefaultValue(true)]
        public bool DiscardDataBetweenFlashes
        {
            get { return _DiscardDataBetweenFlashes; }
            set {
                if (DiscardDataBetweenFlashes == value) return;
                _DiscardDataBetweenFlashes = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
                NotifyPropertyChanged("DiscardDataBetweenFlashes");
            }
        }

        private bool _RecordCurrent = true;
        [Bindable(true)]
        [DefaultValue(true)]
        public bool RecordCurrent
        {
            get { return _RecordCurrent; }
            set {
                if (RecordCurrent == value) return;
                _RecordCurrent = value;
                NotifyPropertyChanged("RecordCurrent");
            }
        }
	

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


        public LaserFluorescenceRecordingProtocol()
        {
        }
        ~LaserFluorescenceRecordingProtocol()
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

            if (RecordCurrent && Amplifier != null) ReadCurrentGain();

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
                int nReducedSamples = Convert.ToInt32((PreFlashAcquisitionTime + PostFlashAcquisitionTime) * SampleRate / 1000);
                if (!DiscardDataBetweenFlashes) nReducedSamples = nsamples;
                
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
            if (!IsContinuousRecordingSupported) throw new ApplicationException("Continuous execution is not supported.");

            StopContinuousExecutionTrigger = false;

            Initialize();

            System.Threading.ThreadStart exec = new System.Threading.ThreadStart(ContinuousExecute);
            ContinuouslyExecutingThread = new System.Threading.Thread(exec);
            ContinuouslyExecutingThread.Start();
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
            WriteToDOChannels();
            ConfigureChannelReaders();

            while (!StopContinuousExecutionTrigger)
            {
                try
                {
                    DOTask.Start();

                    AITask.Start();
                    AsyncRecordFromAIChannels();
                    AITask.WaitUntilDone();

                    AITask.Stop();

                    DOTask.Stop();
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

            if (!DiscardDataBetweenFlashes)
            {
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
            }
            else
            { 
                int nPreFlashDiscardSamples = Convert.ToInt32((Laser.MinimumChargingTime - PreFlashAcquisitionTime) * SampleRate / 1000);
                int nPostFlashDiscardSamples = Convert.ToInt32((Laser.MinimumChargingTime + PostFlashAcquisitionTime) * SampleRate / 1000);
                int nLaserOutputSamples = Convert.ToInt32(((double)SampleRate) / ((double)LaserPulseFrequency));
                int nSamplesToKeepPerFlash = nLaserOutputSamples - nPreFlashDiscardSamples - (nLaserOutputSamples - nPostFlashDiscardSamples);

                // nSamplesToKeep = # samples/flash * # flashes * downsampling factor
                int nSamplesToKeep = Convert.ToInt32(nSamplesToKeepPerFlash * ((AcquisitionLength / 1000) * LaserPulseFrequency) * ProcessedSampleRate / SampleRate);
                    //Convert.ToInt32((PreFlashAcquisitionTime + PostFlashAcquisitionTime) * ((AcquisitionLength / 1000) * LaserPulseFrequency - 1) * ProcessedSampleRate / 1000);
                int nFilteredSamplesToKeepPerFlash = nSamplesToKeepPerFlash * ProcessedSampleRate / SampleRate;

                time = new float[nSamplesToKeep];
                double[,] reducedData = new double[channelNames.Length, nSamplesToKeep];

                int i_stored = 0; // Index for the next data point stored
                int iSampleOfFlash = 0;
                for (int i = 0; i < nDataSamples; i++)
                {
                    int i_rel = i - Convert.ToInt32(Math.Floor(((double)i) / ((double)nLaserOutputSamples)) * nLaserOutputSamples);

                    if (i_rel == 0) iSampleOfFlash = 0;

                    float t = 1000 * ((float)i) / ((float)SampleRate);

                    float prev_t = i_stored >= 1 ? time[i_stored - 1] : 0;
                    float dt = (t - prev_t);
                    float cutoff = 1000F / ((float)ProcessedSampleRate);

                    if ( (i_rel > nPreFlashDiscardSamples && i_rel < nPostFlashDiscardSamples && dt > cutoff)
                        || (i_rel >= nPostFlashDiscardSamples && iSampleOfFlash != nFilteredSamplesToKeepPerFlash) )
                    {
                        time[i_stored] = t;
                        for (int j = 0; j < channelNames.Length; j++)
                            reducedData[j, i_stored] = data[j, i];
                        i_stored++;
                        iSampleOfFlash++;
                    }
                    else continue; // Otherwise discard
                }

                Data.AddData(channelNames, time, reducedData, units.ToArray());
            }

            // Replace current data with the whole, filtered data
            int currentIndex = Array.IndexOf(channelNames, "Current");
            if (currentIndex >= 0)
            {
                int nCurrentFilteredSamples = Convert.ToInt32(((double)nDataSamples) * ((double)CurrentSampleRate) / ((double)SampleRate));

                List<float> currentTime = new List<float>(nCurrentFilteredSamples);
                List<double> current = new List<double>(nCurrentFilteredSamples);

                int i_currentStored = 0;
                for (int i = 0; i < nDataSamples; i++)
                {
                    float t_current = 1000 * ((float)i) / ((float)SampleRate);

                    float prev_t_current = i_currentStored >= 1 ? currentTime[i_currentStored - 1] : 0;
                    float dt_current = (t_current - prev_t_current);
                    float cutoff_current = 1000F / ((float)CurrentSampleRate);

                    if (dt_current >= cutoff_current || i_currentStored == 0)
                    {
                        currentTime.Add(t_current);
                        current.Add(data[currentIndex, i]);
                        i_currentStored++;
                    }
                }

                Data.ClearData("Current");

                currentTime.TrimExcess();
                current.TrimExcess();

                Data.AddData("Current", units[currentIndex], currentTime.ToArray(), current.ToArray()); 
            }

            ProcessData();
        }

        private int _CurrentSampleRate = 2500;
        [Bindable(true)]
        [DefaultValue(2500)]
        public int CurrentSampleRate
        {
            get { return _CurrentSampleRate; }
            set {
                if (CurrentSampleRate == value) return;
                _CurrentSampleRate = value;
                NotifyPropertyChanged("CurrentSampleRate");
            }
        }
	

        protected virtual void ConfigureChannels()
        {
            if ((Photodiode1 == null) && (Photodiode2 == null)) throw new ApplicationException("At least one photodiode must be set.");
            if (Amplifier != null && RecordCurrent)
                AITask.AIChannels.CreateVoltageChannel(Amplifier.CurrentAI, "Current", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);
            if (Photodiode1 != null)
                AITask.AIChannels.CreateVoltageChannel(Photodiode1.IntensityAI, Photodiode1.Name, NationalInstruments.DAQmx.AITerminalConfiguration.Rse, -10, 10, NationalInstruments.DAQmx.AIVoltageUnits.Volts);
            if (Photodiode2 != null && Photodiode2 != Photodiode1)
                AITask.AIChannels.CreateVoltageChannel(Photodiode2.IntensityAI, Photodiode2.Name, NationalInstruments.DAQmx.AITerminalConfiguration.Rse, -10, 10, NationalInstruments.DAQmx.AIVoltageUnits.Volts);
            
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
            get { return "Laser-Illuminated Fluorescence Recording Protocol"; }
        }

        public override string ProtocolDescription
        {
            get { return "Records from a photodiode while illuminating continuously with a pulsed laser."; }
        }

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            return new LaserFluorescenceRecordingProtocolConfigPanel(this);
        }

        protected override void ProcessData()
        {
            lock (DataSet)
            {
                if (RecordCurrent && CurrentScalingFactor != 0)
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
                if (Photodiode1 != null) Photodiode1.AnnotateEquipmentData(Data);
                if (Photodiode2 != null) Photodiode2.AnnotateEquipmentData(Data);
                if (Laser != null) Laser.AnnotateEquipmentData(Data);
                if (FilterWheel != null) FilterWheel.AnnotateEquipmentData(Data);
                Data.SetMetaData("DataToShow", "Current,Photodiode 1,Photodiode 2");

                if (FilterWheel != null && Laser != null)
                    Data.Title = String.Format("FluorescenceRecordingProtocol: {0} Hz {1} {2} nm Flashes", LaserPulseFrequency , FilterWheel.CurrentFilter, Laser.Wavelength);
            }

            base.AnnotateData();
        }
    }
}
