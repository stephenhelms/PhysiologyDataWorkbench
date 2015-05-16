using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;

namespace RRLab.PhysiologyWorkbench
{
    public partial class TestPulseSidebar : UserControl
    {
        public event EventHandler ProtocolChanged;
        private TestPulseProtocol _Protocol = null;
        [Bindable(true)]
        public TestPulseProtocol Protocol
        {
            get { return _Protocol; }
            set {
                _Protocol = value;
                if (Protocol != null) TestPulseBindingSource.DataSource = value;
                else TestPulseBindingSource.DataSource = typeof(TestPulseProtocol);
                if (ProtocolChanged != null) ProtocolChanged(this, EventArgs.Empty);
            }
        }

        public TestPulseSidebar()
        {
            InitializeComponent();
            ControlBindingSource.DataSource = this;
            Disposed += new EventHandler(OnDisposing);
        }

        protected virtual void OnDisposing(object sender, EventArgs e)
        {
            if (Protocol != null) Protocol.Dispose();
        }
    }
}
