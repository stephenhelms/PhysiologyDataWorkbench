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
    public partial class SaveWholeCellTestPulseButton : UserControl
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


        public SaveWholeCellTestPulseButton()
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
            if ((DataManager != null) && (DataManager.CurrentCell != null) &&
                (DataManager.CurrentCell.MembranePotential == 0 ||
                DataManager.CurrentCell.MembraneResistance == 0 ||
                DataManager.CurrentCell.CellCapacitance == 0))
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
            Save();
        }

        public virtual void Save()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(Save));
                return;
            }

            if ((DataManager == null) || (DataManager.CurrentCell == null) || (TestPulseProtocol == null) || TestPulseProtocol.Data == null)
                return;

            // Save membrane potential, membrane resistance, and cell capacitance
            DataManager.CurrentCell.MembranePotential = (float) TestPulseProtocol.Data.HoldingPotential;
            DataManager.CurrentCell.MembraneResistance = (float) (TestPulseProtocol.Resistance * 1E3);
            if (TestPulseProtocol.Data.EquipmentSettings.ContainsKey("AmplifierCapacitanceCorrection"))
                try
                {
                    DataManager.CurrentCell.CellCapacitance = Single.Parse(TestPulseProtocol.Data.EquipmentSettings["AmplifierCapacitanceCorrection"]);
                }
                catch (Exception x) { ; }
            TestPulseProtocol.Data.Description = "Test pulse in whole cell configuration. Autosaved membrane potential, resistance, and capacitance.";
            DataManager.StoreRecording(TestPulseProtocol.Data);
            TestPulseProtocol.TriggerNewData = true;
            SaveButton.BackColor = NormalColor;
        }
    }
}
