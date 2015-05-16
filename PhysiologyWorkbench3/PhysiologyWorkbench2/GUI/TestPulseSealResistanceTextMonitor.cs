using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;
using NationalInstruments.UI;

namespace RRLab.PhysiologyWorkbench
{
    public partial class TestPulseSealResistanceTextMonitor : UserControl
    {
        public event EventHandler TestPulseProtocolChanged;
        private TestPulseProtocol _TestPulseProtocol;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true)]
        public TestPulseProtocol TestPulseProtocol
        {
            get { return _TestPulseProtocol; }
            set
            {
                _TestPulseProtocol = value;
                if (TestPulseProtocol != null) TestPulseBindingSource.DataSource = value;
                else TestPulseBindingSource.DataSource = typeof(TestPulseProtocol);
                if (TestPulseProtocolChanged != null) TestPulseProtocolChanged(this, EventArgs.Empty);
            }
        }

        private double _SealResistance = 0;
        public double SealResistance
        {
            get { return _SealResistance; }
            set
            {
                _SealResistance = value;
                if (value > 0.001)
                {
                    this.tbSealResistance.Text = value.ToString("E3"); // Update the seal tank with the measurement
                }
                else
                {
                    this.tbSealResistance.Text = "<0.001";
                }
            }
        }

        public TestPulseSealResistanceTextMonitor()
        {
            InitializeComponent();
        }
        public TestPulseSealResistanceTextMonitor(TestPulseProtocol protocol)
        {
            InitializeComponent();
            this.TestPulseProtocol = protocol;
        }
    }
}
