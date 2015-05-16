namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class TestPulsePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestPulsePanel));
            this.LeftSidebar = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AutoStartTestPulseCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RecordingViewer = new RRLab.PhysiologyWorkbench.RecordingViewer();
            this.TestPulseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testPulseSidebar1 = new RRLab.PhysiologyWorkbench.TestPulseSidebar();
            this.ControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProtocolExecutionControl = new RRLab.PhysiologyWorkbench.GUI.ProtocolExecutionControl();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SavePipetteResistanceButton = new RRLab.PhysiologyWorkbench.GUI.SavePipetteResistanceButton();
            this.SaveSealResistanceMeasurementButton = new RRLab.PhysiologyWorkbench.GUI.SaveSealResistanceMeasurementButton();
            this.SaveSeriesResistanceButton = new RRLab.PhysiologyWorkbench.GUI.SaveWholeCellTestPulseButton();
            this.LeftSidebar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftSidebar
            // 
            this.LeftSidebar.Controls.Add(this.testPulseSidebar1);
            this.LeftSidebar.Controls.Add(this.flowLayoutPanel1);
            this.LeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.LeftSidebar.Name = "LeftSidebar";
            this.LeftSidebar.Size = new System.Drawing.Size(233, 557);
            this.LeftSidebar.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.AutoStartTestPulseCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.ProtocolExecutionControl);
            this.flowLayoutPanel1.Controls.Add(this.SavePipetteResistanceButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveSealResistanceMeasurementButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveSeriesResistanceButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 461);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(233, 96);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // AutoStartTestPulseCheckBox
            // 
            this.AutoStartTestPulseCheckBox.AutoSize = true;
            this.AutoStartTestPulseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ControlBindingSource, "AutoStartTestPulse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.flowLayoutPanel1.SetFlowBreak(this.AutoStartTestPulseCheckBox, true);
            this.AutoStartTestPulseCheckBox.Location = new System.Drawing.Point(3, 3);
            this.AutoStartTestPulseCheckBox.Name = "AutoStartTestPulseCheckBox";
            this.AutoStartTestPulseCheckBox.Size = new System.Drawing.Size(166, 17);
            this.AutoStartTestPulseCheckBox.TabIndex = 6;
            this.AutoStartTestPulseCheckBox.Text = "Automatically Start Test Pulse";
            this.AutoStartTestPulseCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(199, 59);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(1);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(26, 36);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // RecordingViewer
            // 
            this.RecordingViewer.AutoSize = true;
            this.RecordingViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordingViewer.CurrentAxisRange = new NationalInstruments.UI.Range(-10, 10);
            this.RecordingViewer.CurrentAxisScaling = RRLab.PhysiologyWorkbench.AutoAxisMode.DynamicRange;
            this.RecordingViewer.CurrentMaxDaqVoltage = 10;
            this.RecordingViewer.CurrentMinDaqVoltage = -10;
            this.RecordingViewer.DataBindings.Add(new System.Windows.Forms.Binding("Recording", this.TestPulseBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingViewer.IsLegendVisible = false;
            this.RecordingViewer.IsTitleVisible = false;
            this.RecordingViewer.Location = new System.Drawing.Point(233, 0);
            this.RecordingViewer.Name = "RecordingViewer";
            this.RecordingViewer.Recording = null;
            this.RecordingViewer.Size = new System.Drawing.Size(506, 557);
            this.RecordingViewer.TabIndex = 1;
            this.RecordingViewer.VoltageAxisRange = new NationalInstruments.UI.Range(-10, 10);
            this.RecordingViewer.VoltageAxisScaling = RRLab.PhysiologyWorkbench.AutoAxisMode.DynamicRange;
            this.RecordingViewer.VoltageMaxDaqVoltage = 10;
            this.RecordingViewer.VoltageMinDaqVoltage = -10;
            // 
            // TestPulseBindingSource
            // 
            this.TestPulseBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.TestPulseProtocol);
            // 
            // testPulseSidebar1
            // 
            this.testPulseSidebar1.DataBindings.Add(new System.Windows.Forms.Binding("Protocol", this.ControlBindingSource, "Protocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.testPulseSidebar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testPulseSidebar1.Location = new System.Drawing.Point(0, 0);
            this.testPulseSidebar1.Name = "testPulseSidebar1";
            this.testPulseSidebar1.Protocol = null;
            this.testPulseSidebar1.Size = new System.Drawing.Size(233, 461);
            this.testPulseSidebar1.TabIndex = 2;
            // 
            // ControlBindingSource
            // 
            this.ControlBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.GUI.TestPulsePanel);
            // 
            // ProtocolExecutionControl
            // 
            this.ProtocolExecutionControl.AutoSize = true;
            this.ProtocolExecutionControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProtocolExecutionControl.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolExecutionControl.DataBindings.Add(new System.Windows.Forms.Binding("Protocol", this.ControlBindingSource, "Protocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolExecutionControl.DataManager = null;
            this.ProtocolExecutionControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProtocolExecutionControl.Enabled = false;
            this.flowLayoutPanel1.SetFlowBreak(this.ProtocolExecutionControl, true);
            this.ProtocolExecutionControl.Location = new System.Drawing.Point(3, 26);
            this.ProtocolExecutionControl.Name = "ProtocolExecutionControl";
            this.ProtocolExecutionControl.Protocol = null;
            this.ProtocolExecutionControl.RunningColor = System.Drawing.Color.Empty;
            this.ProtocolExecutionControl.Size = new System.Drawing.Size(228, 29);
            this.ProtocolExecutionControl.StoppedColor = System.Drawing.Color.LawnGreen;
            this.ProtocolExecutionControl.TabIndex = 2;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // SavePipetteResistanceButton
            // 
            this.SavePipetteResistanceButton.AlertColor = System.Drawing.Color.Yellow;
            this.SavePipetteResistanceButton.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SavePipetteResistanceButton.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ControlBindingSource, "Protocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SavePipetteResistanceButton.DataManager = null;
            this.SavePipetteResistanceButton.Location = new System.Drawing.Point(1, 59);
            this.SavePipetteResistanceButton.Margin = new System.Windows.Forms.Padding(1);
            this.SavePipetteResistanceButton.Name = "SavePipetteResistanceButton";
            this.SavePipetteResistanceButton.NormalColor = System.Drawing.SystemColors.Control;
            this.SavePipetteResistanceButton.Size = new System.Drawing.Size(55, 36);
            this.SavePipetteResistanceButton.TabIndex = 4;
            this.SavePipetteResistanceButton.TestPulseProtocol = null;
            // 
            // SaveSealResistanceMeasurementButton
            // 
            this.SaveSealResistanceMeasurementButton.AlertColor = System.Drawing.Color.Yellow;
            this.SaveSealResistanceMeasurementButton.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveSealResistanceMeasurementButton.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ControlBindingSource, "Protocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveSealResistanceMeasurementButton.DataManager = null;
            this.SaveSealResistanceMeasurementButton.Location = new System.Drawing.Point(58, 59);
            this.SaveSealResistanceMeasurementButton.Margin = new System.Windows.Forms.Padding(1);
            this.SaveSealResistanceMeasurementButton.Name = "SaveSealResistanceMeasurementButton";
            this.SaveSealResistanceMeasurementButton.NormalColor = System.Drawing.SystemColors.Control;
            this.SaveSealResistanceMeasurementButton.Size = new System.Drawing.Size(75, 36);
            this.SaveSealResistanceMeasurementButton.TabIndex = 3;
            this.SaveSealResistanceMeasurementButton.TestPulseProtocol = null;
            // 
            // SaveSeriesResistanceButton
            // 
            this.SaveSeriesResistanceButton.AlertColor = System.Drawing.Color.Yellow;
            this.SaveSeriesResistanceButton.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveSeriesResistanceButton.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ControlBindingSource, "Protocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveSeriesResistanceButton.DataManager = null;
            this.SaveSeriesResistanceButton.Location = new System.Drawing.Point(135, 59);
            this.SaveSeriesResistanceButton.Margin = new System.Windows.Forms.Padding(1);
            this.SaveSeriesResistanceButton.Name = "SaveSeriesResistanceButton";
            this.SaveSeriesResistanceButton.NormalColor = System.Drawing.SystemColors.Control;
            this.SaveSeriesResistanceButton.Size = new System.Drawing.Size(62, 36);
            this.SaveSeriesResistanceButton.TabIndex = 5;
            this.SaveSeriesResistanceButton.TestPulseProtocol = null;
            // 
            // TestPulsePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecordingViewer);
            this.Controls.Add(this.LeftSidebar);
            this.Name = "TestPulsePanel";
            this.Size = new System.Drawing.Size(739, 557);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.LeftSidebar.ResumeLayout(false);
            this.LeftSidebar.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftSidebar;
        //private RRLab.PhysiologyWorkbench.TestPulseSidebar TestPulseSidebarControl;
        private RRLab.PhysiologyWorkbench.RecordingViewer RecordingViewer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ProtocolExecutionControl ProtocolExecutionControl;
        private SaveSealResistanceMeasurementButton SaveSealResistanceMeasurementButton;
        private SavePipetteResistanceButton SavePipetteResistanceButton;
        private SaveWholeCellTestPulseButton SaveSeriesResistanceButton;
        private System.Windows.Forms.CheckBox AutoStartTestPulseCheckBox;
        private System.Windows.Forms.BindingSource ControlBindingSource;
        private System.Windows.Forms.BindingSource TestPulseBindingSource;
        private TestPulseSidebar testPulseSidebar1;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private System.Windows.Forms.Button SaveButton;
    }
}
