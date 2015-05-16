using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench
{
    public partial class CellInfoControl : UserControl
    {
        public event EventHandler PhysiologyDataChanged;
        private PhysiologyData _PhysiologyData;
        [Bindable(true)]
        public PhysiologyData PhysiologyData
        {
            get { return _PhysiologyData; }
            set {
                _PhysiologyData = value;
                if (PhysiologyData != null)
                {
                    GenotypesBindingSource.DataSource = value;
                    UsersBindingSource.DataSource = value;
                }
                else
                {
                    GenotypesBindingSource.DataSource = typeof(PhysiologyData);
                    UsersBindingSource.DataSource = typeof(PhysiologyData);
                }

                if (PhysiologyDataChanged != null) PhysiologyDataChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler DataManagerChanged;
        private DataManager _DataManager;
        [Bindable(true)]
        public DataManager DataManager
        {
            get { return _DataManager; }
            set {
                _DataManager = value;
                if (DataManager != null)
                {
                    this.DataBindings.Add("PhysiologyData", DataManager, "PhysiologyData", false, DataSourceUpdateMode.OnPropertyChanged);
                    this.DataBindings.Add("Cell", DataManager, "CurrentCell");
                }
                if (DataManagerChanged != null) DataManagerChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CellChanged;
        private Cell _Cell;
        [Bindable(true)]
        public Cell Cell
        {
            get { return _Cell; }
            set {
                _Cell = value;

                if (Cell != null) CellBindingSource.DataSource = Cell;
                else CellBindingSource.DataSource = typeof(Cell);

                OnCellChanged(EventArgs.Empty);
            }
        }

        public event EventHandler NormalColorChanged;
        private Color _NormalColor = System.Drawing.SystemColors.Window;
        [SettingsBindable(true)]
        public Color NormalColor
        {
            get { return _NormalColor; }
            set {
                _NormalColor = value;
                if (NormalColorChanged != null) NormalColorChanged(this, EventArgs.Empty);
            }
        }
	

        public event EventHandler WarningColorChanged;
        private Color _WarningColor = Color.Gold;
        [SettingsBindable(true)]
        public Color WarningColor
        {
            get { return _WarningColor; }
            set {
                _WarningColor = value;
                if (WarningColorChanged != null) WarningColorChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler UsingElectrophysiologyValidationChanged;

        private bool _UsingElectrophysiologyValidation = false;
        [DefaultValue(false)]
        [SettingsBindable(true)]
        [Bindable(true)]
        public bool UsingElectrophysiologyValidation
        {
            get { return _UsingElectrophysiologyValidation; }
            set {
                _UsingElectrophysiologyValidation = value;
                if (UsingElectrophysiologyValidationChanged != null) UsingElectrophysiologyValidationChanged(this, EventArgs.Empty);
            }
        }
	
	

        public CellInfoControl()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            e.Cancel = !ValidateChildren(ValidationConstraints.TabStop);
            base.OnValidating(e);
        }

        protected virtual void OnCellChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnCellChanged), e);
                return;
            }

            Enabled = (Cell != null);

            if (CellChanged != null) CellChanged(this, EventArgs.Empty);
        }

        protected virtual void OnGenotypeValidating(object sender, CancelEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CancelEventHandler(OnGenotypeValidating), sender, e);
                return;
            }

            if (GenotypesComboBox.Text == null || GenotypesComboBox.Text == "")
            {
                GenotypesComboBox.BackColor = WarningColor;
                e.Cancel = true;
            }
            else
            {
                GenotypesComboBox.BackColor = NormalColor;
            }
        }

        public event EventHandler MinimumMembranePotentialChanged;
        private float _MinimumMembranePotential = -20;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(-20)]
        public float MinimumMembranePotential
        {
            get { return _MinimumMembranePotential; }
            set {
                _MinimumMembranePotential = value;
                if (MinimumMembranePotentialChanged != null)
                    MinimumMembranePotentialChanged(this, EventArgs.Empty);
            }
        }
	

        protected virtual void OnVMembraneValidating(object sender, CancelEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CancelEventHandler(OnVMembraneValidating), sender, e);
                return;
            }

            if (VMembraneTextbox.Text == null || VMembraneTextbox.Text == "")
            {
                if (UsingElectrophysiologyValidation)
                {
                    VMembraneTextbox.BackColor = WarningColor;
                    // Can be null, so don't cancel
                }
            }
            else
            {
                float value;
                if (Single.TryParse(VMembraneTextbox.Text, out value))
                {
                    if (value > MinimumMembranePotential)
                        VMembraneTextbox.BackColor = WarningColor;
                    else VMembraneTextbox.BackColor = NormalColor;
                }
                else VMembraneTextbox.BackColor = WarningColor;
            }
        }

        private void OnRPipetteValidating(object sender, CancelEventArgs e)
        {

        }

        public event EventHandler MinimumSealResistanceChanged;
        private float _MinimumSealResistance = 1;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(1)]
        public float MinimumSealResistance
        {
            get { return _MinimumSealResistance; }
            set {
                _MinimumSealResistance = value;
                if (MinimumSealResistanceChanged != null) MinimumSealResistanceChanged(this, EventArgs.Empty);
            }
        }
	

        protected virtual void OnRSealValidating(object sender, CancelEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CancelEventHandler(OnRSealValidating), sender, e);
                return;
            }

            if (RSealTextBox.Text == null || RSealTextBox.Text == "")
            {
                if (UsingElectrophysiologyValidation)
                {
                    RSealTextBox.BackColor = WarningColor;
                    // Can be null, so don't cancel
                }
            }
            else
            {
                float value;
                if (Single.TryParse(RSealTextBox.Text, out value))
                {
                    if (value < MinimumSealResistance)
                        RSealTextBox.BackColor = WarningColor;
                    else RSealTextBox.BackColor = NormalColor;
                }
                else RSealTextBox.BackColor = WarningColor;
            }
        }

        private void OnRMembraneValidating(object sender, CancelEventArgs e)
        {

        }

        public event EventHandler MinimumCellCapacitanceChanged;
        private float _MinimumCellCapacitance = 20;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(20)]
        public float MinimumCellCapacitance
        {
            get { return _MinimumCellCapacitance; }
            set {
                _MinimumCellCapacitance = value;
                if (MinimumCellCapacitanceChanged != null) MinimumCellCapacitanceChanged(this, EventArgs.Empty);
            }
        }
	

        private void OnCellCapacValidating(object sender, CancelEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CancelEventHandler(OnCellCapacValidating), sender, e);
                return;
            }

            if (CellCapacitanceTextBox.Text == null
                || CellCapacitanceTextBox.Text == "")
            {
                if (UsingElectrophysiologyValidation)
                {
                    CellCapacitanceTextBox.BackColor = WarningColor;
                    // Can be null, so don't cancel
                }
            }
            else
            {
                float value;
                if (Single.TryParse(CellCapacitanceTextBox.Text, out value))
                {
                    if (value < MinimumCellCapacitance)
                        CellCapacitanceTextBox.BackColor = WarningColor;
                    else CellCapacitanceTextBox.BackColor = NormalColor;
                }
                else CellCapacitanceTextBox.BackColor = WarningColor;
            }
        }

        private void OnRSeriesValidating(object sender, CancelEventArgs e)
        {

        }

        private void useElectrophysiologyValidationToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            UsingElectrophysiologyValidation = true;
        }


    }
}
