namespace RRLab.PhysiologyWorkbench
{
    partial class TestPulseSealResistanceTextMonitor
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
            this.tbSealResistance = new System.Windows.Forms.TextBox();
            this.TestPulseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSealResistance
            // 
            this.tbSealResistance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TestPulseBindingSource, "Resistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "n/a", "N4"));
            this.tbSealResistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSealResistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSealResistance.Location = new System.Drawing.Point(0, 16);
            this.tbSealResistance.Name = "tbSealResistance";
            this.tbSealResistance.ReadOnly = true;
            this.tbSealResistance.Size = new System.Drawing.Size(129, 20);
            this.tbSealResistance.TabIndex = 3;
            this.tbSealResistance.Text = "n/a";
            // 
            // TestPulseBindingSource
            // 
            this.TestPulseBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.TestPulseProtocol);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Seal Resistance (GOhms)";
            // 
            // TestPulseSealResistanceTextMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSealResistance);
            this.Controls.Add(this.label5);
            this.Name = "TestPulseSealResistanceTextMonitor";
            this.Size = new System.Drawing.Size(129, 39);
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSealResistance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource TestPulseBindingSource;
    }
}
