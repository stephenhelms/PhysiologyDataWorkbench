using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;
using NationalInstruments.UI.WindowsForms;

namespace RRLab.PhysiologyWorkbench
{
    public partial class TestPulseSealResistanceTank : UserControl
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

        public TestPulseSealResistanceTank()
        {
            InitializeComponent();
        }
        public TestPulseSealResistanceTank(TestPulseProtocol protocol)
        {
            InitializeComponent();
            TestPulseProtocol = protocol;
        }
    }
}
