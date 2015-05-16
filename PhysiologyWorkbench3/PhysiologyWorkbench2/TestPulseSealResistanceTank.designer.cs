namespace RRLab.PhysiologyWorkbench
{
    partial class TestPulseSealResistanceTank
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param genotype="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TestPulseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sealQualityTank = new NationalInstruments.UI.WindowsForms.Tank();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sealQualityTank)).BeginInit();
            this.SuspendLayout();
            // 
            // TestPulseBindingSource
            // 
            this.TestPulseBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.TestPulseProtocol);
            // 
            // sealQualityTank
            // 
            this.sealQualityTank.Caption = "GOhm";
            this.sealQualityTank.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.sealQualityTank.CaptionPosition = NationalInstruments.UI.CaptionPosition.Bottom;
            this.sealQualityTank.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.TestPulseBindingSource, "Resistance", true));
            this.sealQualityTank.DataBindings.Add(new System.Windows.Forms.Binding("FillColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "AccentColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sealQualityTank.DataBindings.Add(new System.Windows.Forms.Binding("FillBackColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "AccentBackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sealQualityTank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sealQualityTank.FillBackColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.AccentBackgroundColor;
            this.sealQualityTank.FillColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.AccentColor;
            this.sealQualityTank.Location = new System.Drawing.Point(0, 0);
            this.sealQualityTank.MajorDivisions.Interval = 10;
            this.sealQualityTank.Name = "sealQualityTank";
            this.sealQualityTank.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.sealQualityTank.Range = new NationalInstruments.UI.Range(0.01, 10);
            this.sealQualityTank.ScaleType = NationalInstruments.UI.ScaleType.Logarithmic;
            this.sealQualityTank.Size = new System.Drawing.Size(61, 269);
            this.sealQualityTank.TabIndex = 3;
            this.sealQualityTank.Value = 0.01;
            // 
            // TestPulseSealResistanceTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sealQualityTank);
            this.Name = "TestPulseSealResistanceTank";
            this.Size = new System.Drawing.Size(61, 269);
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sealQualityTank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Tank sealQualityTank;
        private System.Windows.Forms.BindingSource TestPulseBindingSource;
    }
}
