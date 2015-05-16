using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Data;
using NationalInstruments.DAQmx;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class LaserFlashProtocol : DaqProtocol
    {
        public override string ProtocolName
        {
            get { return "Laser Flash Protocol"; }
        }

        public override string ProtocolDescription
        {
            get { return "Flashes the laser one time and records the current."; }
        }

        private SpectraPhysicsNitrogenLaser _Laser;

        public SpectraPhysicsNitrogenLaser Laser
        {
            get { return _Laser; }
            set { _Laser = value; }
        }

        private FilterWheel _FilterWheel;

        public FilterWheel FilterWheel
        {
            get { return _FilterWheel; }
            set { _FilterWheel = value; }
        }

        private Amplifier _Amplifier;

        public Amplifier Amplifier
        {
            get { return _Amplifier; }
            set { _Amplifier = value; }
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

        private SortedList<string, string> _ChannelUnits = new SortedList<string, string>();
        protected SortedList<string, string> ChannelUnits
        {
            get { return _ChannelUnits; }
            set { _ChannelUnits = value; }
        }

        private double _SampleRate = 2500;

        public double SampleRate
        {
            get { return _SampleRate; }
            set { _SampleRate = value; }
        }
        private float _PreFlashCollectionTime = 50;

        public float PreFlashCollectionTime
        {
            get { return _PreFlashCollectionTime; }
            set { _PreFlashCollectionTime = value; }
        }
        private float _PostFlashCollectionTime = 500;

        public float PostFlashCollectionTime
        {
            get { return _PostFlashCollectionTime; }
            set { _PostFlashCollectionTime = value; }
        }

        public float TotalCollectionTime
        {
            get { return PreFlashCollectionTime + PostFlashCollectionTime; }
        }

        private Task _AITask;

        protected Task AITask
        {
            get { return _AITask; }
            set { _AITask = value; }
        }
        private Task _DOTask;

        protected Task DOTask
        {
            get { return _DOTask; }
            set { _DOTask = value; }
        }

        protected AnalogMultiChannelReader AIChannelReader;

        public LaserFlashProtocol()
        {
        }

        protected override void Initialize()
        {
            _ChannelNames.Clear();
            _ChannelUnits.Clear();

            try
            {
                AITask = new Task("AI");
                DOTask = new Task("DO");

                ConfigureChannels();

                int nsamples = Convert.ToInt32(TotalCollectionTime * SampleRate / 1000);
                if (Math.IEEERemainder(nsamples, 2) != 0) nsamples++;
                AITask.Timing.ConfigureSampleClock("", SampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, nsamples);
                DOTask.Timing.ConfigureSampleClock("", SampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, nsamples);

                int nsamplesPreFlash = Convert.ToInt32(PreFlashCollectionTime * SampleRate / 1000);
                AITask.Triggers.ReferenceTrigger.ConfigureDigitalEdgeTrigger(Laser.InternalTriggerPFI, DigitalEdgeReferenceTriggerEdge.Rising, nsamplesPreFlash);
                
                //DOTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger("/dev1/ai/StartTrigger", DigitalEdgeStartTriggerEdge.Rising);

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

        protected virtual void ConfigureChannels()
        {
            AITask.AIChannels.CreateVoltageChannel(Amplifier.CurrentAI, "Current", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);
            ChannelNames.Add("Current");
            ChannelUnits.Add("Current", "pA");

            AITask.AIChannels.CreateVoltageChannel(Amplifier.GainAI, "Gain", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);
            ChannelNames.Add("Gain");
            ChannelUnits.Add("Gain", "V");
            
            AITask.AIChannels.CreateVoltageChannel(Laser.PowerAI, "LaserPower", AITerminalConfiguration.Rse, -10, 10, AIVoltageUnits.Volts);
            ChannelNames.Add("LaserPower");
            ChannelUnits.Add("LaserPower", "V");

            DOTask.DOChannels.CreateChannel("/dev2/port0", "LaserOutput", ChannelLineGrouping.OneChannelForAllLines);
        }

        public override void StartContinuousExecute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Execute()
        {
            try
            {
                GenerateChannelReaders();

                WriteToDOChannels();
                
                AITask.Start();
                DOTask.Start();
                

                // make sure the reference trigger fired before recording
                //DOTask.WaitUntilDone();
                AsyncRecordFromAIChannels();
                
                AITask.WaitUntilDone();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error during execution: " + e.Message);
                FinalizeProtocol();
            }
        }

        protected virtual void WriteToDOChannels()
        {
            DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(DOTask.Stream);
            byte[] output = Laser.GenerateLaserFlashDaqOutput((int)SampleRate, TotalCollectionTime, PreFlashCollectionTime); // Add laser method
            writer.WriteMultiSamplePort(false, output);
        }
        protected virtual void GenerateChannelReaders()
        {
            AIChannelReader = new AnalogMultiChannelReader(AITask.Stream);
        }
        protected virtual void AsyncRecordFromAIChannels()
        {
            int nsamples = Convert.ToInt32(TotalCollectionTime * SampleRate / 1000);
            AIChannelReader.BeginReadMultiSample(nsamples, new AsyncCallback(OnAIReadCompleted), null);
        }

        public override void StopContinuousExecute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void FinalizeProtocol()
        {
            if (AITask != null)
            {
                AITask.Dispose();
                AITask = null;
            }
            if (DOTask != null)
            {
                DOTask.Dispose();
                DOTask = null;
            }
            FireFinishedEvent(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (AITask != null) AITask.Dispose();
            if (DOTask != null) DOTask.Dispose();
        }

        protected virtual void OnAIReadCompleted(IAsyncResult ar)
        {
            if (Disposing) return;
            try
            {
                double[,] data = AIChannelReader.EndReadMultiSample(ar);

                float[] time = new float[Convert.ToInt32(TotalCollectionTime * SampleRate / 1000)];
                for (int i = 0; i < (SampleRate * TotalCollectionTime / 1000); i++)
                {
                    time[i] = ((float)i) * 1000 / ((float)SampleRate) - (float) PreFlashCollectionTime;
                }

                string[] channelNames = new string[ChannelNames.Count];
                ChannelNames.CopyTo(channelNames, 0);

                string[] units = new string[ChannelUnits.Count];
                for (int i = 0; i < channelNames.Length; i++)
                    if (ChannelUnits.ContainsKey(channelNames[i]))
                        units[i] = ChannelUnits[channelNames[i]];
                    else units[i] = "Unknown";

                StoreCollectedData(time, channelNames, data, units);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while reading data: " + e.Message);
                FinalizeProtocol();
            }
        }

        protected virtual void StoreCollectedData(float[] time, string[] channelNames, double[,] data, string[] units)
        {
            Data = CreateNewRecording();
            Data.AddData(channelNames, time, data, units);
            ProcessData();
        }

        protected override void ProcessData()
        {
            // Get mean gain from Gain dataName
            double gain = RRLab.PhysiologyWorkbench.Utilities.MathHelper.CalculateMean(Data.Data["Gain"].Values);
            Data.RemoveData("Gain");

            // Convert current using amplifier gain information
            double currentScalingFactor = Amplifier.CalculateVtoIFactorFromTTL(gain);
            Data.SetEquipmentSetting("AmplifierGain", currentScalingFactor.ToString());
            double[] currentData = Data.Data["Current"].Values;
            for (int i = 0; i < currentData.Length; i++)
                currentData[i] *= 1000 / currentScalingFactor; // *1000 b/c we want pA/V
            Data.SetChannelData("Current", currentData);

            double baselineCurrent = RRLab.PhysiologyWorkbench.Utilities.MathHelper.CalculateMeanOverTimeRange(Data.Data["Current"].Time, Data.Data["Current"].Values, -PreFlashCollectionTime, 0);
            Data.SetMetaData("BaselineCurrent",baselineCurrent.ToString("f0"));
            double currentNoise = RRLab.PhysiologyWorkbench.Utilities.MathHelper.CalculateMeanOverTimeRange(Data.Data["Current"].Time, Data.Data["Current"].Values, -PreFlashCollectionTime, 0);
            Data.SetMetaData("CurrentNoise", currentNoise.ToString("f2"));
            //double peakCurrent = RRLab.PhysiologyWorkbench.Utilities.MathHelper.C

            base.ProcessData();
        }

        protected override void AnnotateData()
        {
            if (Data == null) return;

            Data.SetProtocolSetting("Flash Delay (ms)", PreFlashCollectionTime.ToString());
            Data.SetProtocolSetting("Post-flash Collection Time (ms)", PostFlashCollectionTime.ToString());
            Data.SetProtocolSetting("Laser", Laser.ToString());
            Data.SetProtocolSetting("Amplifier", Amplifier.ToString());

            Data.SetEquipmentSetting("Sample Rate (Hz)", SampleRate.ToString());
            Amplifier.AnnotateEquipmentData(Data);
            //Laser.AnnotateEquipmentData(Data);

            Data.SetMetaData("DataToShow", "Current");

            base.AnnotateData();
        }

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            return new LaserFlashConfigurationControl(this);
        }
    }
}
