using System;
using System.Collections.Generic;
using System.Text;
using NationalInstruments.DAQmx;

namespace RRLab.PhysiologyWorkbench.Daq
{
    public class MultiFlashProtocol : LaserFlashProtocol
    {
        public MultiFlashProtocol()
        {
        }

        #region Derived Properties
        public override string ProtocolName
        {
            get
            {
                return "Multi Laser Flash Protocol";
            }
        }

        public override string ProtocolDescription
        {
            get { return "Flashes the laser multiple times and records the current."; }
        }

        public override float TotalCollectionTime
        {
            get
            {
                return ((float)NumberOfFlashes) * base.TotalCollectionTime;
            }
        }

        #endregion

        #region Protocol Properties

        private int _NumberOfFlashes = 100;

        public int NumberOfFlashes
        {
            get { return _NumberOfFlashes; }
            set {
                _NumberOfFlashes = value;
                NotifyPropertyChanged("NumberOfFlashes");
            }
        }	

        #endregion

        #region Derived Methods

        public override System.Windows.Forms.Control GetConfigurationControl()
        {
            return new MultiLaserFlashConfigurationControl(this);
        }

        protected override void ConfigureDOChannels()
        {
            base.ConfigureDOChannels();
            DOTask.Stream.WriteRegenerationMode = NationalInstruments.DAQmx.WriteRegenerationMode.AllowRegeneration;
        }

        protected override void WriteToDOChannels()
        {
            DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(DOTask.Stream);
            byte[] output = Laser.GenerateLaserFlashDaqOutput((int)SampleRate, TotalCollectionTime/((float)NumberOfFlashes), PreFlashCollectionTime);
            writer.WriteMultiSamplePort(false, output);
        }

        protected override void AnnotateData()
        {
            base.AnnotateData();

            if(FilterWheel != null && Laser != null)
                Data.Title = String.Format("MultiFlashProtocol: {0}X {1} {2} nm Flashes", NumberOfFlashes, FilterWheel.CurrentFilter, Laser.Wavelength);
            Data.AddProtocolSetting("NumberOfFlashes", NumberOfFlashes.ToString());
        }

        #endregion
    }
}
