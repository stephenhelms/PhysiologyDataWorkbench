using System;
using System.Collections.Generic;
using System.Text;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.Utilities;
using RRLab.PhysiologyData;
using NationalInstruments.DAQmx;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class LaserFlashWithSwitchProtocol : LaserFlashProtocol
    {
        #region Derived Properties
        public override string ProtocolName
        {
            get {
                if (Switch != null)
                    return String.Format("Laser Flash Protocol With {0}", Switch);
                else return "Laser Flash Protocol With Switch";
            }
        }

        public override string ProtocolDescription
        {
            get { return "Flashes the laser one time and records the current while triggering a switch."; }
        }
        #endregion

        #region Properties

        private SwitchDevice _Switch;

        public SwitchDevice Switch
        {
            get { return _Switch; }
            set {
                _Switch = value;
                NotifyPropertyChanged("Switch");
            }
        }
	

        private float _SwitchDelayTime = -200;
        public float SwitchDelayTime
        {
            get
            {
                return _SwitchDelayTime;
            }
            set
            {
                _SwitchDelayTime = value;
                NotifyPropertyChanged("SwitchDelayTime");
            }
        }

        private float _SwitchDuration = 700;
        public float SwitchDuration
        {
            get
            {
                return _SwitchDuration;
            }
            set
            {
                _SwitchDuration = value;
                NotifyPropertyChanged("SwitchDuration");
            }
        }

        protected string SwitchPortName
        {
            get
            {
                return GetPortFromLineName(Switch.Line);
            }
        }

        protected bool AreSwitchAndLaserOnSamePort
        {
            get
            {
                return SwitchPortName == LaserPortName;
            }
        }
        #endregion

        public LaserFlashWithSwitchProtocol()
        {
            PreFlashCollectionTime = 250;
            PostFlashCollectionTime = 600;
        }

        #region Protocol Methods

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            return new LaserFlashSwitchConfigurationControl(this);
        }

        protected override void ConfigureDOChannels()
        {
            if (!AreSwitchAndLaserOnSamePort)
            {
                base.ConfigureDOChannels();
                DOTask.DOChannels.CreateChannel(SwitchPortName, "SwitchPort", ChannelLineGrouping.OneChannelForAllLines);
            }
            else
            {
                DOTask.DOChannels.CreateChannel(LaserPortName, "DigitalOutput", ChannelLineGrouping.OneChannelForAllLines);
            }
        }

        protected override void WriteToDOChannels()
        {
            byte[] laserOutput = Laser.GenerateLaserFlashDaqOutput((int)SampleRate, TotalCollectionTime, PreFlashCollectionTime);
            byte[] switchOutput = Switch.GenerateSwitchDaqOutput((int)SampleRate, TotalCollectionTime,
                    SwitchDelayTime + PreFlashCollectionTime, SwitchDuration);

            if (AreSwitchAndLaserOnSamePort)
            {
                DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(DOTask.Stream);
                writer.WriteMultiSamplePort(false, CombineDigitalDataOR(new Array[] { laserOutput, switchOutput }));
            }
            else
            {
                base.WriteToDOChannels();

                DigitalMultiChannelWriter writer = new DigitalMultiChannelWriter(DOTask.Stream);
                writer.WriteMultiSamplePort(false, MergeDigitalData(new Array[] { laserOutput, switchOutput }));
            }
        }

        protected override void AnnotateData()
        {
            base.AnnotateData();

            Data.SetProtocolSetting("Switch Delay (ms)", SwitchDelayTime.ToString());
            Data.SetProtocolSetting("Switch Duration (ms)", SwitchDuration.ToString());
            Data.SetProtocolSetting("Switch", Switch.ToString());

            Switch.AnnotateEquipmentData(Data);
        }

        #endregion

        #region Utility Methods
        protected byte[] CombineDigitalDataOR(IEnumerable<Array> individualData)
        {
            byte[] output = null;
            foreach (Array data in individualData)
                if (!(data is byte[])) throw new ArgumentException("Arrays must be of type byte[]");
                else if (output == null) output = (byte[])data;
                else
                {
                    if (data.Length != output.Length) throw new ArgumentException("Arrays must be same length.");
                    for (int i = 0; i < output.Length; i++)
                    {
                        byte[] array = (byte[]) data;
                        output[i] = (byte) (output[i] | array[i]);
                    }
                }
            return output;
        }
        protected byte[,] MergeDigitalData(IEnumerable<Array> individualData)
        {
            List<Array> dataList = new List<Array>(individualData);

            if (!dataList.TrueForAll(new Predicate<Array>(delegate(Array array)
            {
                return array is byte[];
            }))) throw new ArgumentException("Arrays must be of type byte[].");

            byte[,] output = new byte[dataList.Count, dataList[0].Length];
            for (int i = 0; i < dataList.Count; i++)
                for (int j = 0; j < dataList[i].Length; j++)
                {
                    byte[] array = (byte[])dataList[i];
                    output[i, j] = array[j];
                }
            return output;
        }
        #endregion
    }
}
