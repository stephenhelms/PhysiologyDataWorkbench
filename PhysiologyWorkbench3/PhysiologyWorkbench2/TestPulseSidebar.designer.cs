namespace RRLab.PhysiologyWorkbench
{
    partial class TestPulseSidebar
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
            this.ControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TestPulseSettingsBox = new RRLab.PhysiologyWorkbench.TestPulseSettingsBox();
            this.amplifierAnalysisControl1 = new RRLab.PhysiologyWorkbench.GUI.AmplifierAnalysisControl();
            this.TestPulseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TestPulseSealResistanceMonitor = new RRLab.PhysiologyWorkbench.TestPulseSealResistanceTextMonitor();
            this.TestPulseSealResistanceTank = new RRLab.PhysiologyWorkbench.TestPulseSealResistanceTank();
            ((System.ComponentModel.ISupportInitialize)(this.ControlBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlBindingSource
            // 
            this.ControlBindingSource.DataSource = this;
            this.ControlBindingSource.Position = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TestPulseSettingsBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.amplifierAnalysisControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 90);
            this.panel1.TabIndex = 4;
            // 
            // TestPulseSettingsBox
            // 
            this.TestPulseSettingsBox.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ControlBindingSource, "Protocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TestPulseSettingsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestPulseSettingsBox.Location = new System.Drawing.Point(3, 16);
            this.TestPulseSettingsBox.Name = "TestPulseSettingsBox";
            this.TestPulseSettingsBox.Size = new System.Drawing.Size(140, 241);
            this.TestPulseSettingsBox.TabIndex = 2;
            // 
            // amplifierAnalysisControl1
            // 
            this.amplifierAnalysisControl1.DataBindings.Add(new System.Windows.Forms.Binding("Recording", this.TestPulseBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.amplifierAnalysisControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amplifierAnalysisControl1.Location = new System.Drawing.Point(0, 0);
            this.amplifierAnalysisControl1.Name = "amplifierAnalysisControl1";
            this.amplifierAnalysisControl1.Recording = null;
            this.amplifierAnalysisControl1.Size = new System.Drawing.Size(146, 90);
            this.amplifierAnalysisControl1.TabIndex = 0;
            // 
            // TestPulseBindingSource
            // 
            this.TestPulseBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.TestPulseProtocol);
            // 
            // TestPulseSealResistanceMonitor
            // 
            this.TestPulseSealResistanceMonitor.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ControlBindingSource, "Protocol", true));
            this.TestPulseSealResistanceMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.TestPulseSealResistanceMonitor.Location = new System.Drawing.Point(0, 0);
            this.TestPulseSealResistanceMonitor.MinimumSize = new System.Drawing.Size(129, 40);
            this.TestPulseSealResistanceMonitor.Name = "TestPulseSealResistanceMonitor";
            this.TestPulseSealResistanceMonitor.SealResistance = 0;
            this.TestPulseSealResistanceMonitor.Size = new System.Drawing.Size(146, 40);
            this.TestPulseSealResistanceMonitor.TabIndex = 0;
            // 
            // TestPulseSealResistanceTank
            // 
            this.TestPulseSealResistanceTank.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ControlBindingSource, "Protocol", true));
            this.TestPulseSealResistanceTank.Dock = System.Windows.Forms.DockStyle.Right;
            this.TestPulseSealResistanceTank.Location = new System.Drawing.Point(146, 0);
            this.TestPulseSealResistanceTank.Name = "TestPulseSealResistanceTank";
            this.TestPulseSealResistanceTank.Size = new System.Drawing.Size(61, 390);
            this.TestPulseSealResistanceTank.TabIndex = 1;
            // 
            // TestPulseSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TestPulseSealResistanceMonitor);
            this.Controls.Add(this.TestPulseSealResistanceTank);
            this.Name = "TestPulseSidebar";
            this.Size = new System.Drawing.Size(207, 390);
            ((System.ComponentModel.ISupportInitialize)(this.ControlBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TestPulseSealResistanceTextMonitor TestPulseSealResistanceMonitor;
        private TestPulseSealResistanceTank TestPulseSealResistanceTank;
        private TestPulseSettingsBox TestPulseSettingsBox;
        private System.Windows.Forms.BindingSource ControlBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private RRLab.PhysiologyWorkbench.GUI.AmplifierAnalysisControl amplifierAnalysisControl1;
        private System.Windows.Forms.BindingSource TestPulseBindingSource;
    }
}
