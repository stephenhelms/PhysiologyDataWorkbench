using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Daq;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench
{
    public partial class SaveTestPulseDataButton : UserControl
    {
        #region Appearance Properties
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
        #endregion

        #region Data Properties
        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;
        [Bindable(true)]
        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                if (DataSet == value) return;
                _DataSet = value;
                OnDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnDataSetChanged(EventArgs e)
        {
            UpdateView();
            if(DataSetChanged != null)
                try
                {
                    DataSetChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during DataSetChanged event: " + x.Message);
                }
        }

        public event EventHandler CellChanged;
        private PhysiologyDataSet.CellsRow _Cell;
        [Bindable(true)]
        public PhysiologyDataSet.CellsRow Cell
        {
            get { return _Cell; }
            set {
                if (Cell == value) return;
                _Cell = value;
                OnCellChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnCellChanged(EventArgs e)
        {
            UpdateView();
            if(CellChanged != null)
                try
                {
                    CellChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during CellChanged event: " + x.Message);
                }
        }
	
       

        public event EventHandler RecordingChanged;
        private PhysiologyDataSet.RecordingsRow _Recording;
        [Bindable(true)]
        public PhysiologyDataSet.RecordingsRow Recording
        {
            get
            {
                return _Recording;
            }
            set
            {
                if (Recording == value) return;
                _Recording = value;
                OnRecordingChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnRecordingChanged(EventArgs e)
        {
            UpdateView();
            if (RecordingChanged != null)
                try
                {
                    RecordingChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during RecordingChanged event: " + x.Message);
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
                if (TestPulseProtocol != null)
                {
                    TestPulseProtocol.ResistanceChanged -= new EventHandler(OnResistanceMeasured);
                    TestPulseProtocol.Annotated -= new EventHandler(OnProtocolAnnotated);
                    TestPulseProtocol.DataChanged -= new EventHandler(OnProtocolDataChanged);
                }
                _TestPulseProtocol = value;
                if (TestPulseProtocol != null)
                {
                    TestPulseProtocol.ResistanceChanged += new EventHandler(OnResistanceMeasured);
                    TestPulseProtocol.Annotated += new EventHandler(OnProtocolAnnotated);
                    TestPulseProtocol.DataChanged += new EventHandler(OnProtocolDataChanged);
                }
                OnTestPulseProtocolChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnTestPulseProtocolChanged(EventArgs e)
        {
            UpdateView();

            if(TestPulseProtocolChanged != null)
                try
                {
                    TestPulseProtocolChanged(this, e);
                }
                catch (Exception x)
                {
                    Console.WriteLine("Error during TestPulseProtocolChanged event: " + x.Message);
                }
        }

        private bool _TriggerCallSaveData = false;
        protected bool TriggerCallSaveData
        {
            get { return _TriggerCallSaveData; }
            set { _TriggerCallSaveData = value; }
        }
	

        protected virtual void OnProtocolAnnotated(object sender, EventArgs e)
        {
            OnProtocolDataChanged(this, EventArgs.Empty); // To refresh the cell/dataset/recording binding
            if (TriggerCallSaveData) SaveData();
        }
        protected virtual void OnProtocolDataChanged(object sender, EventArgs e)
        {
            if (TestPulseProtocol != null)
            {
                Cell = TestPulseProtocol.Cell;
                DataSet = TestPulseProtocol.DataSet;
                Recording = TestPulseProtocol.Data;
            }
            else
            {
                Cell = null;
                DataSet = null;
                Recording = null;
            }

            UpdateView();
        }

        #endregion


        public SaveTestPulseDataButton()
        {
            InitializeComponent();
        }

        protected virtual void UpdateView()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateView));
                return;
            }

            if (Cell == null || Recording == null || TestPulseProtocol == null || TestPulseProtocol.Resistance == 0)
                Enabled = false;
            else Enabled = true;

            if (!IsDataSaved)
                SaveButton.BackColor = AlertColor;
            else SaveButton.BackColor = NormalColor;
        }

        protected virtual void OnButtonClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnButtonClicked), sender, e);
                return;
            }
            TriggerCallSaveData = true;
        }

        protected virtual void OnResistanceMeasured(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnResistanceMeasured), sender, e);
                return;
            }
            UpdateView();
        }

        #region Methods to be derived
        public virtual void SaveData()
        {
            TestPulseProtocol.TriggerNewData = true;
        }

        protected virtual bool IsDataSaved
        {
            get
            {
                return false;
            }
        }
        #endregion
    }
}
