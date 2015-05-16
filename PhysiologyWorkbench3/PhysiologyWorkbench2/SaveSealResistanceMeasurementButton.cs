using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyWorkbench.Daq;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class SaveSealResistanceMeasurementButton : UserControl
    {
        public event EventHandler DataManagerChanged;
        private DataManager _DataManager;
        [Bindable(true)]
        public DataManager DataManager
        {
            get { return _DataManager; }
            set
            {
                _DataManager = value;
                UpdateView();
                if (DataManagerChanged != null) DataManagerChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler TestPulseProtocolChanged;
        private TestPulseProtocol _TestPulseProtocol;
        [Bindable(true)]
        public TestPulseProtocol TestPulseProtocol
        {
            get { return _TestPulseProtocol; }
            set
            {
                if (TestPulseProtocol != null) TestPulseProtocol.ResistanceChanged -= new EventHandler(OnResistanceMeasured);
                _TestPulseProtocol = value;
                if (TestPulseProtocol != null) TestPulseProtocol.ResistanceChanged += new EventHandler(OnResistanceMeasured);
                UpdateView();
                if (TestPulseProtocolChanged != null) TestPulseProtocolChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler NormalColorChanged;
        private Color _NormalColor = System.Drawing.SystemColors.Control;
        public Color NormalColor
        {
            get { return _NormalColor; }
            set
            {
                _NormalColor = value;
                if (NormalColorChanged != null) NormalColorChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler AlertColorChanged;
        private Color _AlertColor = Color.Gold;
        [SettingsBindable(true)]
        public Color AlertColor
        {
            get { return _AlertColor; }
            set
            {
                _AlertColor = value;
                if (AlertColorChanged != null) AlertColorChanged(this, EventArgs.Empty);
            }
        }
	

        public SaveSealResistanceMeasurementButton()
        {
            InitializeComponent();
        }

        protected virtual void OnResistanceMeasured(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnResistanceMeasured), sender, e);
                return;
            }
            UpdateView();
            if ((DataManager != null) && (DataManager.CurrentCell != null) && (DataManager.CurrentCell.SealResistance == 0))
                SaveButton.BackColor = AlertColor;
        }

        protected virtual void UpdateView()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateView));
                return;
            }
            if ((DataManager == null) || (DataManager.CurrentCell == null) || (TestPulseProtocol == null) || (TestPulseProtocol.Resistance == 0))
                Enabled = false;
            else Enabled = true;
        }

        protected virtual void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSaveButtonClicked), sender, e);
                return;
            }
            SaveResistance();
        }

        public virtual void SaveResistance()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SaveResistance));
                return;
            }
            if ((DataManager == null) || (DataManager.CurrentCell == null) || (TestPulseProtocol == null)) return;
            DataManager.CurrentCell.SealResistance = (float) TestPulseProtocol.Resistance;
            if (DataManager.CurrentRecording != null)
                DataManager.CurrentRecording.Description = "Test pulse in cell attached configuration. Autosaved seal resistance.";
            DataManager.StoreRecording(TestPulseProtocol.Data);
            TestPulseProtocol.TriggerNewData = true;
            SaveButton.BackColor = NormalColor;
        }
    }
}
