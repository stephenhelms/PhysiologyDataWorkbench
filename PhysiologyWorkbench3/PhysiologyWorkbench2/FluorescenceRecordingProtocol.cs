using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyWorkbench.Devices;
using NationalInstruments.DAQmx;

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
        private string _AISampleClock = "/dev1/MasterTimebase";
        public string AISampleClock
        {
            get { return _AISampleClock; }
            set {
                _AISampleClock = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }
        private string _DOSampleClock = "/dev1/MasterTimebase";

        public string DOSampleClock
        {
            get { return _DOSampleClock; }
            set {
                _DOSampleClock = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }
	
        private int _SampleRate = 10000;
        public int SampleRate
        {
            get { return _SampleRate; }
            set { _SampleRate = value; }
        }
        private SampleClockActiveEdge _ClockEdge = SampleClockActiveEdge.Rising;
        public SampleClockActiveEdge ClockEdge
        {
            get { return _ClockEdge; }
            set { _ClockEdge = value; }
        }

        private int _AcquisitionLength = 5000;
        public int AcquisitionLength
        {
            get { return _AcquisitionLength; }
            set { _AcquisitionLength = value; }
        }
        private List<string> _ChannelNames = new List<string>();
        public ICollection<string> ChannelNames
        {
            get { return _ChannelNames.AsReadOnly(); }
            protected set
            {
                _ChannelNames.Clear();
                _ChannelNames.AddRange(value);
            }
        }

        private Amplifier _Amplifier;

        public Amplifier Amplifier
        {
            get { return _Amplifier; }
            set
            {
                _Amplifier = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }
        private SpectraPhysicsNitrogenLaser _Laser;

        public SpectraPhysicsNitrogenLaser Laser
        {
            get { return _Laser; }
            set
            {
                _Laser = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private Photodiode _Photodiode1;

        public Photodiode Photodiode1
        {
            get { return _Photodiode1; }
            set
            {
                _Photodiode1 = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private Photodiode _Photodiode2;

        public Photodiode Photodiode2
        {
            get { return _Photodiode2; }
            set
            {
                _Photodiode2 = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private FilterWheel _FilterWheel;
        public FilterWheel FilterWheel
        {
            get { return _FilterWheel; }
            set
            {
                _FilterWheel = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
            }
        }

        private int _LaserPulseFrequency = 20;

        public int LaserPulseFrequency
        {
            get { return _LaserPulseFrequency; }
            set { _LaserPulseFrequency = value; }
        }

        private float _PreFlashAcquisitionTime = 0.5F;

        public float PreFlashAcquisitionTime
        {
            get { return _PreFlashAcquisitionTime; }
            set { _PreFlashAcquisitionTime = value; }
        }
        private float _PostFlashAcquisitionTime = 1.5F;

        public float PostFlashAcquisitionTime
        {
            get { return _PostFlashAcquisitionTime; }
            set { _PostFlashAcquisitionTime = value; }
        }

        private bool _DiscardDataBetweenFlashes = true;

        public bool DiscardDataBetweenFlashes
        {
            get { return _DiscardDataBetweenFlashes; }
            set {
                _DiscardDataBetweenFlashes = value;
                FireSettingsChangedEvent(this, EventArgs.Empty);
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

        protected override void Initialize()
        {
            Data = null;
            if ((DOTask != null) || (AITask != null)) FinalizeProtocol();

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
            int nSamplesToKeep = Convert.ToInt32((PreFlashAcquisitionTime + PostFlashAcquisitionTime) * ((AcquisitionLength / 1000) * LaserPulseFrequency) * SampleRate / 1000);

            float[] time = new float[nSamplesToKeep];
            double[,] reducedData = new double[channelNames.Length, nSamplesToKeep];

            Data = new Recording();

            if (!DiscardDataBetweenFlashes)
            {
                nSamplesToKeep = nDataSamples;
                time = new float[nDataSamples];
                for (int i = 0; i < nDataSamples; i++)
                    time[i] = 1000F * ((float)i) / ((float)SampleRate);
                Data.AddData(channelNames, time, reducedData, units.ToArray());
            }
            else
            {
                float tPreFlashDiscard = Laser.MinimumChargingTime - PreFlashAcquisitionTime;
                float tPostFlashDiscard = Laser.MinimumChargingTime + PostFlashAcquisitionTime;
                float tLaserPeriod = 1000F / ((float) LaserPulseFrequency);

                int i_stored = 0; // Index for the next data point stored
                for (int i = 0; i < nDataSamples; i++)
                {
                    float t = 1000 * ((float)i) / ((float)SampleRate);
                    // Calculate the time relative to the laser period
                    float t_relative = t - (float) Math.Floor(t / tLaserPeriod)*tLaserPeriod; // tLaserPeriod + Math.IEEERemainder(t, tLaserPeriod);
                    // Keep data between tPreFlashDiscard and tPostFlashDiscard
                    if (t_relative > tPreFlashDiscard && t_relative <= tPostFlashDiscard)
                    {
                        time[i_stored] = t;
                        for (int j = 0; j < channelNames.Length; j++)
                            reducedData[j, i_stored] = data[j, i];
                        i_stored++;
                    }
                    else continue; // Otherwise discard
                }

                Data.AddData(channelNames, time, reducedData, units.ToArray());
            }

            ProcessData();
        }

        protected virtual void ConfigureChannels()
        {
            if ((Photodiode1 == null) && (Photodiode2 == null)) throw new ApplicationException("At least one photodiode must be set.");
            if (Photodiode1 != null)
                AITask.AIChannels.CreateVoltageChannel(Photodiode1.IntensityAI, Photodiode1.Name, NationalInstruments.DAQmx.AITerminalConfiguration.Rse, -10, 10, NationalInstruments.DAQmx.AIVoltageUnits.Volts);
            if (Photodiode2 != null && Photodiode2 != Photodiode1)
                AITask.AIChannels.CreateVoltageChannel(Photodiode2.IntensityAI, Photodiode2.Name, NationalInstruments.DAQmx.AITerminalConfiguration.Rse, -10, 10, NationalInstruments.DAQmx.AIVoltageUnits.Volts);

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

        protected override void AnnotateData()
        {
            Amplifier.AnnotateEquipmentData(Data);
            base.AnnotateData();
        }
    }
}
