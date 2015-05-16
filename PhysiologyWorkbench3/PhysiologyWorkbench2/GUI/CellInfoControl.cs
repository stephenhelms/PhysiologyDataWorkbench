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
        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;
        [Bindable(true)]
        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                _DataSet = value;
                if (DataSet != null)
                {
                    CellBindingSource.DataSource = value;
                    GenotypesBindingSource.DataSource = value;
                    UsersBindingSource.DataSource = value;
                }
                else
                {
                    CellBindingSource.DataSource = typeof(PhysiologyDataSet);
                    GenotypesBindingSource.DataSource = typeof(PhysiologyDataSet);
                    UsersBindingSource.DataSource = typeof(PhysiologyDataSet);
                }

                if (DataSetChanged != null) DataSetChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CellChanged;
        private PhysiologyDataSet.CellsRow _Cell;
        [Bindable(true)]
        public PhysiologyDataSet.CellsRow Cell
        {
            get { return _Cell; }
            set {
                _Cell = value;
                
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
        protected override void OnValidated(EventArgs e)
        {
            //CellBindingSource.EndEdit();
            //UsersBindingSource.EndEdit();
            //GenotypesBindingSource.EndEdit();

            base.OnValidated(e);
        }

        protected virtual void OnCellChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnCellChanged), e);
                return;
            }

            Enabled = DataSet != null && Cell != null;
            
            CellBindingSource.EndEdit();
            UsersBindingSource.EndEdit();
            GenotypesBindingSource.EndEdit();

            if (Cell == null)
            {
                CellBindingSource.Position = -1;
                System.Diagnostics.Debug.WriteLine("CellInfoControl: Cell set to null.");
            }
            if (Cell != null)
            {
                int position = CellBindingSource.Find("CellID", Cell.CellID);
                System.Diagnostics.Debug.Assert(position >= 0, "CellInfoControl: Cell not found.");
                CellBindingSource.Position = position;
                System.Diagnostics.Debug.WriteLine("CellInfoControl: Cell set to " + Cell.CellID);
            }   

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

        private void OnCellDataBinding(object sender, BindingCompleteEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(String.Format(
                "CellInfoControl: Databound {0}.{1} {2}.", e.Binding.Control.Name, e.Binding.PropertyName, e.BindingCompleteContext), "DataBinding");
        }

        private void OnCellDataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Fail("CellInfoControl: Error during databinding.", e.Exception.Message);
        }

        private void OnCellPositionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CellInfoControl: Cell position changed.");
        }

        private void OnCellCurrentChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCellCurrentChanged), sender, e);
                return;
            }

            //CellBindingSource.CancelEdit();

            System.Diagnostics.Debug.WriteLine("CellInfoControl: Current item updated.");
        }

        private void OnUsersDataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            if (UserComboBox.Items.Count == 0)
            {
                UserComboBox.SelectedIndex = -1;
                return;
            }

            System.Diagnostics.Debug.Fail("CellInfoControl: Error during users databinding.", e.Exception.Message);
        }

        private void OnGenotypesDataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            if (GenotypesComboBox.Items.Count == 0)
            {
                GenotypesComboBox.SelectedIndex = -1;
                return;
            }

            System.Diagnostics.Debug.Fail("CellInfoControl: Error during genotypes databinding.", e.Exception.Message);
        }

        private void OnRoughnessTrackBarValueChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRoughnessTrackBarValueChanged), sender, e);
                return;
            }

            RoughnessNumericUpDown.Value = RoughnessTrackBar.Value;
        }

        private void OnLengthTrackBarValueChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnLengthTrackBarValueChanged), sender, e);
                return;
            }

            LengthNumericUpDown.Value = LengthTrackBar.Value;
        }

        private void OnBlebbinessTrackBarValueChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnBlebbinessTrackBarValueChanged), sender, e);
                return;
            }

            BlebbinessNumericUpDown.Value = BlebbinessTrackBar.Value;
        }

        private void OnRoughnessNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRoughnessNumericUpDownValueChanged), sender, e);
                return;
            }

            System.Diagnostics.Debug.WriteLine("RoughnessNumericUpDown value changed.");
            if (RoughnessTrackBar.Value != RoughnessNumericUpDown.Value)
                RoughnessTrackBar.Value = Convert.ToInt32(RoughnessNumericUpDown.Value);
        }

        private void OnLengthNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnLengthNumericUpDownValueChanged), sender, e);
                return;
            }

            if (LengthTrackBar.Value != LengthNumericUpDown.Value)
                LengthTrackBar.Value = Convert.ToInt32(LengthNumericUpDown.Value);
        }

        private void OnBlebbinessNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnBlebbinessNumericUpDownValueChanged), sender, e);
                return;
            }

            if (BlebbinessTrackBar.Value != BlebbinessNumericUpDown.Value)
                BlebbinessTrackBar.Value = Convert.ToInt32(BlebbinessNumericUpDown.Value);
        }

        public virtual void SuspendDataBinding()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SuspendDataBinding));
                return;
            }

            CellBindingSource.SuspendBinding();
            GenotypesBindingSource.SuspendBinding();
            UsersBindingSource.SuspendBinding();
        }
        public virtual void ResumeDataBinding()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResumeDataBinding));
                return;
            }

            CellBindingSource.ResumeBinding();
            GenotypesBindingSource.ResumeBinding();
            UsersBindingSource.ResumeBinding();

            OnCellChanged(EventArgs.Empty);

            CellBindingSource.ResetCurrentItem();
            GenotypesBindingSource.ResetCurrentItem();
            UsersBindingSource.ResetCurrentItem();
        }
    }
}
