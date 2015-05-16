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
            this.testPulseSidebar1 = new RRLab.PhysiologyWorkbench.TestPulseSidebar();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AutoStartTestPulseCheckBox = new System.Windows.Forms.CheckBox();
            this.ProtocolExecutionControl = new RRLab.PhysiologyWorkbench.GUI.ProtocolExecutionControl();
            this.SaveInBathTestPulseDataButton = new RRLab.PhysiologyWorkbench.GUI.SaveInBathTestPulseDataButton();
            this.TestPulseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SaveCellAttachedTestPulseData = new RRLab.PhysiologyWorkbench.GUI.SaveCellAttachedTestPulseData();
            this.saveWholeCellTestPulseDataButton1 = new RRLab.PhysiologyWorkbench.GUI.SaveWholeCellTestPulseDataButton();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RecordingDataGraphControl = new RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl();
            this.LeftSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).BeginInit();
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
            // testPulseSidebar1
            // 
            this.testPulseSidebar1.DataBindings.Add(new System.Windows.Forms.Binding("Protocol", this.ProgramBindingSource, "TestPulseProtocol", true));
            this.testPulseSidebar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testPulseSidebar1.Location = new System.Drawing.Point(0, 0);
            this.testPulseSidebar1.Name = "testPulseSidebar1";
            this.testPulseSidebar1.Protocol = null;
            this.testPulseSidebar1.Size = new System.Drawing.Size(233, 447);
            this.testPulseSidebar1.TabIndex = 2;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.AutoStartTestPulseCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.ProtocolExecutionControl);
            this.flowLayoutPanel1.Controls.Add(this.SaveInBathTestPulseDataButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveCellAttachedTestPulseData);
            this.flowLayoutPanel1.Controls.Add(this.saveWholeCellTestPulseDataButton1);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 447);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(233, 110);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // AutoStartTestPulseCheckBox
            // 
            this.AutoStartTestPulseCheckBox.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.AutoStartTestPulseCheckBox, true);
            this.AutoStartTestPulseCheckBox.Location = new System.Drawing.Point(3, 3);
            this.AutoStartTestPulseCheckBox.Name = "AutoStartTestPulseCheckBox";
            this.AutoStartTestPulseCheckBox.Size = new System.Drawing.Size(166, 17);
            this.AutoStartTestPulseCheckBox.TabIndex = 6;
            this.AutoStartTestPulseCheckBox.Text = "Automatically Start Test Pulse";
            this.AutoStartTestPulseCheckBox.UseVisualStyleBackColor = true;
            this.AutoStartTestPulseCheckBox.CheckedChanged += new System.EventHandler(this.OnAutoStartTestPulseChecked);
            // 
            // ProtocolExecutionControl
            // 
            this.ProtocolExecutionControl.AutoSize = true;
            this.ProtocolExecutionControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProtocolExecutionControl.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolExecutionControl.DataBindings.Add(new System.Windows.Forms.Binding("Protocol", this.ProgramBindingSource, "TestPulseProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            // SaveInBathTestPulseDataButton
            // 
            this.SaveInBathTestPulseDataButton.AlertColor = System.Drawing.Color.Gold;
            this.SaveInBathTestPulseDataButton.Cell = null;
            this.SaveInBathTestPulseDataButton.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ProgramBindingSource, "TestPulseProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveInBathTestPulseDataButton.DataSet = null;
            this.SaveInBathTestPulseDataButton.Location = new System.Drawing.Point(0, 58);
            this.SaveInBathTestPulseDataButton.Margin = new System.Windows.Forms.Padding(0);
            this.SaveInBathTestPulseDataButton.Name = "SaveInBathTestPulseDataButton";
            this.SaveInBathTestPulseDataButton.NormalColor = System.Drawing.SystemColors.Control;
            this.SaveInBathTestPulseDataButton.Recording = null;
            this.SaveInBathTestPulseDataButton.Size = new System.Drawing.Size(57, 50);
            this.SaveInBathTestPulseDataButton.TabIndex = 11;
            this.SaveInBathTestPulseDataButton.TestPulseProtocol = null;
            // 
            // TestPulseBindingSource
            // 
            this.TestPulseBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.TestPulseProtocol);
            // 
            // SaveCellAttachedTestPulseData
            // 
            this.SaveCellAttachedTestPulseData.AlertColor = System.Drawing.Color.Gold;
            this.SaveCellAttachedTestPulseData.Cell = null;
            this.SaveCellAttachedTestPulseData.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ProgramBindingSource, "TestPulseProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveCellAttachedTestPulseData.DataSet = null;
            this.SaveCellAttachedTestPulseData.Location = new System.Drawing.Point(58, 59);
            this.SaveCellAttachedTestPulseData.Margin = new System.Windows.Forms.Padding(1);
            this.SaveCellAttachedTestPulseData.Name = "SaveCellAttachedTestPulseData";
            this.SaveCellAttachedTestPulseData.NormalColor = System.Drawing.SystemColors.Control;
            this.SaveCellAttachedTestPulseData.Recording = null;
            this.SaveCellAttachedTestPulseData.Size = new System.Drawing.Size(74, 50);
            this.SaveCellAttachedTestPulseData.TabIndex = 9;
            this.SaveCellAttachedTestPulseData.TestPulseProtocol = null;
            // 
            // saveWholeCellTestPulseDataButton1
            // 
            this.saveWholeCellTestPulseDataButton1.AlertColor = System.Drawing.Color.Gold;
            this.saveWholeCellTestPulseDataButton1.Cell = null;
            this.saveWholeCellTestPulseDataButton1.DataBindings.Add(new System.Windows.Forms.Binding("TestPulseProtocol", this.ProgramBindingSource, "TestPulseProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saveWholeCellTestPulseDataButton1.DataSet = null;
            this.saveWholeCellTestPulseDataButton1.Location = new System.Drawing.Point(134, 59);
            this.saveWholeCellTestPulseDataButton1.Margin = new System.Windows.Forms.Padding(1);
            this.saveWholeCellTestPulseDataButton1.Name = "saveWholeCellTestPulseDataButton1";
            this.saveWholeCellTestPulseDataButton1.NormalColor = System.Drawing.SystemColors.Control;
            this.saveWholeCellTestPulseDataButton1.Recording = null;
            this.saveWholeCellTestPulseDataButton1.Size = new System.Drawing.Size(64, 50);
            this.saveWholeCellTestPulseDataButton1.TabIndex = 10;
            this.saveWholeCellTestPulseDataButton1.TestPulseProtocol = null;
            // 
            // SaveButton
            // 
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(200, 59);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(1);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(26, 50);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // RecordingDataGraphControl
            // 
            this.RecordingDataGraphControl.DataSet = null;
            this.RecordingDataGraphControl.DefaultAxisLocation = RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl.AxisLocation.Left;
            this.RecordingDataGraphControl.DefaultAxisMode = RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl.AxisMode.DynamicRange;
            this.RecordingDataGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingDataGraphControl.GraphBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.RecordingDataGraphControl.IsAutoUpdateDisabled = true;
            this.RecordingDataGraphControl.IsLegendVisible = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.TestPulseLegendVisible;
            this.RecordingDataGraphControl.IsSidebarVisible = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.TestPulseSidebarVisible;
            this.RecordingDataGraphControl.Location = new System.Drawing.Point(233, 0);
            this.RecordingDataGraphControl.Name = "RecordingDataGraphControl";
            this.RecordingDataGraphControl.Recording = null;
            this.RecordingDataGraphControl.Size = new System.Drawing.Size(506, 557);
            this.RecordingDataGraphControl.TabIndex = 1;
            // 
            // TestPulsePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecordingDataGraphControl);
            this.Controls.Add(this.LeftSidebar);
            this.Name = "TestPulsePanel";
            this.Size = new System.Drawing.Size(739, 557);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.LeftSidebar.ResumeLayout(false);
            this.LeftSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RRLab.PhysiologyWorkbench.TestPulseSidebar testPulseSidebar1;
        private System.Windows.Forms.Panel LeftSidebar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private RRLab.PhysiologyWorkbench.GUI.ProtocolExecutionControl ProtocolExecutionControl;
        private System.Windows.Forms.CheckBox AutoStartTestPulseCheckBox;
        private System.Windows.Forms.BindingSource TestPulseBindingSource;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private System.Windows.Forms.Button SaveButton;
        private RRLab.PhysiologyData.GUI.RecordingDataGraphControl RecordingGraphControl;
        private RRLab.PhysiologyWorkbench.GUI.SaveCellAttachedTestPulseData SaveCellAttachedTestPulseData;
        private RRLab.PhysiologyWorkbench.GUI.SaveWholeCellTestPulseDataButton saveWholeCellTestPulseDataButton1;
        private SaveInBathTestPulseDataButton SaveInBathTestPulseDataButton;
        private RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl RecordingDataGraphControl;
    }
}
