namespace RRLab.PhysiologyWorkbench
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAllDataToDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAllDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.currentRecordingAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentRecordingInExcelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TrashCurrentRecordingSetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrashCurrentRecordingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDeviceManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeyManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OpenManualControlButton = new System.Windows.Forms.Button();
            this.TopButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TestPulseTabPage = new System.Windows.Forms.TabPage();
            this.ProtocolTabPage = new System.Windows.Forms.TabPage();
            this.CollectedDataTab = new System.Windows.Forms.TabPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainWindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.protocolPanel1 = new RRLab.PhysiologyWorkbench.GUI.ProtocolPanel();
            this.QuickNotesControl = new RRLab.PhysiologyWorkbench.GUI.QuickNotes();
            this.RecordingInfoControl = new RRLab.PhysiologyWorkbench.RecordingInfoControl();
            this.DataManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DataManager = new RRLab.PhysiologyWorkbench.DataManager();
            this.absoluteVHoldController1 = new RRLab.PhysiologyWorkbench.GUI.AbsoluteVHoldController();
            this.DeviceManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DeviceManager = new RRLab.PhysiologyWorkbench.Devices.DeviceManager();
            this._HotkeyManager = new RRLab.PhysiologyWorkbench.HotkeyManager();
            this.TestPulsePanel = new RRLab.PhysiologyWorkbench.GUI.TestPulsePanel();
            this.StopwatchControl1 = new RRLab.PhysiologyWorkbench.StopwatchControl();
            this.BreakInTimerControl = new RRLab.PhysiologyWorkbench.GUI.BreakInTimerControl();
            this.RecordingSetInfoControl = new RRLab.PhysiologyWorkbench.CellInfoControl();
            this.menuStrip1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TestPulseTabPage.SuspendLayout();
            this.ProtocolTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceManagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.ExitMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "&New Cell";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewCellMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSaveMenuItem,
            this.toolStripSeparator3,
            this.saveAllDataToDatabaseMenuItem,
            this.toolStripSeparator4,
            this.saveAllDataMenuItem,
            this.saveCurrentCellToolStripMenuItem,
            this.saveCurrentRecordingToolStripMenuItem,
            this.toolStripSeparator2,
            this.currentRecordingAsTextToolStripMenuItem,
            this.saveCurrentRecordingInExcelMenuItem});
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // autoSaveMenuItem
            // 
            this.autoSaveMenuItem.Checked = true;
            this.autoSaveMenuItem.CheckOnClick = true;
            this.autoSaveMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSaveMenuItem.Name = "autoSaveMenuItem";
            this.autoSaveMenuItem.Size = new System.Drawing.Size(213, 22);
            this.autoSaveMenuItem.Text = "&Enable AutoSave";
            this.autoSaveMenuItem.Click += new System.EventHandler(this.autoSaveMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(210, 6);
            // 
            // saveAllDataToDatabaseMenuItem
            // 
            this.saveAllDataToDatabaseMenuItem.Name = "saveAllDataToDatabaseMenuItem";
            this.saveAllDataToDatabaseMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveAllDataToDatabaseMenuItem.Text = "All Data to &Database";
            this.saveAllDataToDatabaseMenuItem.Click += new System.EventHandler(this.saveAllDataToDatabaseMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(210, 6);
            // 
            // saveAllDataMenuItem
            // 
            this.saveAllDataMenuItem.Name = "saveAllDataMenuItem";
            this.saveAllDataMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveAllDataMenuItem.Text = "&All Data";
            this.saveAllDataMenuItem.Click += new System.EventHandler(this.OnSaveAllDataClicked);
            // 
            // saveCurrentCellToolStripMenuItem
            // 
            this.saveCurrentCellToolStripMenuItem.Name = "saveCurrentCellToolStripMenuItem";
            this.saveCurrentCellToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveCurrentCellToolStripMenuItem.Text = "Current &Cell";
            this.saveCurrentCellToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentCellToolStripMenuItem_Click);
            // 
            // saveCurrentRecordingToolStripMenuItem
            // 
            this.saveCurrentRecordingToolStripMenuItem.Name = "saveCurrentRecordingToolStripMenuItem";
            this.saveCurrentRecordingToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveCurrentRecordingToolStripMenuItem.Text = "Current &Recording";
            this.saveCurrentRecordingToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentRecordingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // currentRecordingAsTextToolStripMenuItem
            // 
            this.currentRecordingAsTextToolStripMenuItem.Name = "currentRecordingAsTextToolStripMenuItem";
            this.currentRecordingAsTextToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.currentRecordingAsTextToolStripMenuItem.Text = "Current Recording as Text";
            // 
            // saveCurrentRecordingInExcelMenuItem
            // 
            this.saveCurrentRecordingInExcelMenuItem.Name = "saveCurrentRecordingInExcelMenuItem";
            this.saveCurrentRecordingInExcelMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveCurrentRecordingInExcelMenuItem.Text = "Current Recording in E&xcel";
            this.saveCurrentRecordingInExcelMenuItem.Click += new System.EventHandler(this.OnSaveCurrentRecordingInExcelClicked);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrashCurrentRecordingSetMenuItem,
            this.TrashCurrentRecordingMenuItem});
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem1.Text = "&Trash";
            // 
            // TrashCurrentRecordingSetMenuItem
            // 
            this.TrashCurrentRecordingSetMenuItem.Name = "TrashCurrentRecordingSetMenuItem";
            this.TrashCurrentRecordingSetMenuItem.Size = new System.Drawing.Size(190, 22);
            this.TrashCurrentRecordingSetMenuItem.Text = "Current Recording &Set";
            this.TrashCurrentRecordingSetMenuItem.Click += new System.EventHandler(this.TrashCurrentRecordingSetMenuItem_Click);
            // 
            // TrashCurrentRecordingMenuItem
            // 
            this.TrashCurrentRecordingMenuItem.Name = "TrashCurrentRecordingMenuItem";
            this.TrashCurrentRecordingMenuItem.Size = new System.Drawing.Size(190, 22);
            this.TrashCurrentRecordingMenuItem.Text = "Current &Recording";
            this.TrashCurrentRecordingMenuItem.Click += new System.EventHandler(this.TrashCurrentRecordingMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitMenuItem.Image")));
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenDeviceManagerMenuItem,
            this.hotkeyManagerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // OpenDeviceManagerMenuItem
            // 
            this.OpenDeviceManagerMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenDeviceManagerMenuItem.Image")));
            this.OpenDeviceManagerMenuItem.Name = "OpenDeviceManagerMenuItem";
            this.OpenDeviceManagerMenuItem.Size = new System.Drawing.Size(162, 22);
            this.OpenDeviceManagerMenuItem.Text = "&Device Manager";
            this.OpenDeviceManagerMenuItem.Click += new System.EventHandler(this.OpenDeviceManagerMenuItem_Click);
            // 
            // hotkeyManagerToolStripMenuItem
            // 
            this.hotkeyManagerToolStripMenuItem.Name = "hotkeyManagerToolStripMenuItem";
            this.hotkeyManagerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.hotkeyManagerToolStripMenuItem.Text = "&Hotkey Manager";
            this.hotkeyManagerToolStripMenuItem.Click += new System.EventHandler(this.OnOpenHotkeyManagerClicked);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.tableLayoutPanel1);
            this.TopPanel.Controls.Add(this.TopButtonFlowLayoutPanel);
            this.TopPanel.Controls.Add(this.RecordingSetInfoControl);
            this.TopPanel.Controls.Add(this.absoluteVHoldController1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 24);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(986, 115);
            this.TopPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.StopwatchControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BreakInTimerControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OpenManualControlButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(406, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(147, 115);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // OpenManualControlButton
            // 
            this.OpenManualControlButton.AutoSize = true;
            this.OpenManualControlButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenManualControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenManualControlButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenManualControlButton.Image")));
            this.OpenManualControlButton.Location = new System.Drawing.Point(3, 3);
            this.OpenManualControlButton.Name = "OpenManualControlButton";
            this.OpenManualControlButton.Padding = new System.Windows.Forms.Padding(1);
            this.OpenManualControlButton.Size = new System.Drawing.Size(141, 32);
            this.OpenManualControlButton.TabIndex = 0;
            this.OpenManualControlButton.Text = "Manual Control";
            this.OpenManualControlButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OpenManualControlButton.UseVisualStyleBackColor = true;
            this.OpenManualControlButton.Click += new System.EventHandler(this.OpenManualControlButton_Click);
            // 
            // TopButtonFlowLayoutPanel
            // 
            this.TopButtonFlowLayoutPanel.AutoSize = true;
            this.TopButtonFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TopButtonFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TopButtonFlowLayoutPanel.Location = new System.Drawing.Point(406, 0);
            this.TopButtonFlowLayoutPanel.Name = "TopButtonFlowLayoutPanel";
            this.TopButtonFlowLayoutPanel.Size = new System.Drawing.Size(0, 115);
            this.TopButtonFlowLayoutPanel.TabIndex = 4;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.QuickNotesControl);
            this.BottomPanel.Controls.Add(this.RecordingInfoControl);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 481);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(986, 136);
            this.BottomPanel.TabIndex = 2;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TestPulseTabPage);
            this.TabControl.Controls.Add(this.ProtocolTabPage);
            this.TabControl.Controls.Add(this.CollectedDataTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 139);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(986, 342);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.OnSelectedTabChanged);
            // 
            // TestPulseTabPage
            // 
            this.TestPulseTabPage.Controls.Add(this.TestPulsePanel);
            this.TestPulseTabPage.Location = new System.Drawing.Point(4, 22);
            this.TestPulseTabPage.Name = "TestPulseTabPage";
            this.TestPulseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TestPulseTabPage.Size = new System.Drawing.Size(978, 316);
            this.TestPulseTabPage.TabIndex = 0;
            this.TestPulseTabPage.Text = "Test Pulse";
            this.TestPulseTabPage.UseVisualStyleBackColor = true;
            // 
            // ProtocolTabPage
            // 
            this.ProtocolTabPage.Controls.Add(this.protocolPanel1);
            this.ProtocolTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProtocolTabPage.Name = "ProtocolTabPage";
            this.ProtocolTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProtocolTabPage.Size = new System.Drawing.Size(978, 316);
            this.ProtocolTabPage.TabIndex = 1;
            this.ProtocolTabPage.Text = "Protocols";
            this.ProtocolTabPage.UseVisualStyleBackColor = true;
            // 
            // CollectedDataTab
            // 
            this.CollectedDataTab.Location = new System.Drawing.Point(4, 22);
            this.CollectedDataTab.Name = "CollectedDataTab";
            this.CollectedDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.CollectedDataTab.Size = new System.Drawing.Size(978, 316);
            this.CollectedDataTab.TabIndex = 2;
            this.CollectedDataTab.Text = "Collected Data";
            this.CollectedDataTab.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // mainWindowBindingSource
            // 
            this.mainWindowBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.MainWindow);
            // 
            // protocolPanel1
            // 
            this.protocolPanel1.DataBindings.Add(new System.Windows.Forms.Binding("Program", this.mainWindowBindingSource, "Program", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.protocolPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolPanel1.Location = new System.Drawing.Point(3, 3);
            this.protocolPanel1.Name = "protocolPanel1";
            this.protocolPanel1.Program = null;
            this.protocolPanel1.Size = new System.Drawing.Size(972, 310);
            this.protocolPanel1.TabIndex = 0;
            // 
            // QuickNotesControl
            // 
            this.QuickNotesControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuickNotesControl.DataBindings.Add(new System.Windows.Forms.Binding("Program", this.mainWindowBindingSource, "Program", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.QuickNotesControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.QuickNotesControl.Enabled = false;
            this.QuickNotesControl.Location = new System.Drawing.Point(551, 0);
            this.QuickNotesControl.Name = "QuickNotesControl";
            this.QuickNotesControl.Program = null;
            this.QuickNotesControl.Size = new System.Drawing.Size(435, 136);
            this.QuickNotesControl.TabIndex = 1;
            // 
            // RecordingInfoControl
            // 
            this.RecordingInfoControl.AutoSize = true;
            this.RecordingInfoControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordingInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("PhysiologyData", this.DataManagerBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("Recording", this.DataManagerBindingSource, "CurrentRecording", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingInfoControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.RecordingInfoControl.Location = new System.Drawing.Point(0, 0);
            this.RecordingInfoControl.Name = "RecordingInfoControl";
            this.RecordingInfoControl.PhysiologyData = null;
            this.RecordingInfoControl.Size = new System.Drawing.Size(516, 136);
            this.RecordingInfoControl.TabIndex = 0;
            // 
            // DataManagerBindingSource
            // 
            this.DataManagerBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.DataManager);
            // 
            // _DataManager
            // 
            this._DataManager.AutoSavePath = "C:\\Users\\Stephen\\Documents\\Physiology Workbench Data\\Autosave.pdata";
            this._DataManager.CurrentCell = null;
            this._DataManager.CurrentRecording = null;
            this._DataManager.Program = null;
            this._DataManager.TemplateCell = null;
            this._DataManager.TemplateRecording = null;
            // 
            // absoluteVHoldController1
            // 
            this.absoluteVHoldController1.Amplifier = null;
            this.absoluteVHoldController1.DataBindings.Add(new System.Windows.Forms.Binding("Amplifier", this.DeviceManagerBindingSource, "DefaultAmplifier", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.absoluteVHoldController1.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.absoluteVHoldController1.DataBindings.Add(new System.Windows.Forms.Binding("DeviceManager", this.ProgramBindingSource, "DeviceManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.absoluteVHoldController1.DataBindings.Add(new System.Windows.Forms.Binding("HotkeyManager", this.ProgramBindingSource, "HotkeyManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.absoluteVHoldController1.DataManager = this._DataManager;
            this.absoluteVHoldController1.DeviceManager = this._DeviceManager;
            this.absoluteVHoldController1.Dock = System.Windows.Forms.DockStyle.Right;
            this.absoluteVHoldController1.HotkeyManager = this._HotkeyManager;
            this.absoluteVHoldController1.Location = new System.Drawing.Point(562, 0);
            this.absoluteVHoldController1.Name = "absoluteVHoldController1";
            this.absoluteVHoldController1.Size = new System.Drawing.Size(424, 115);
            this.absoluteVHoldController1.TabIndex = 2;
            // 
            // DeviceManagerBindingSource
            // 
            this.DeviceManagerBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Devices.DeviceManager);
            // 
            // _DeviceManager
            // 
            this._DeviceManager.DefaultAmplifier = null;
            this._DeviceManager.DefaultLaser = null;
            // 
            // TestPulsePanel
            // 
            this.TestPulsePanel.AutoStartTestPulse = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.AutoStartTestPulse;
            this.TestPulsePanel.DataBindings.Add(new System.Windows.Forms.Binding("AutoStartTestPulse", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "AutoStartTestPulse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TestPulsePanel.DataBindings.Add(new System.Windows.Forms.Binding("Protocol", this.ProgramBindingSource, "TestPulseProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TestPulsePanel.DataBindings.Add(new System.Windows.Forms.Binding("Program", this.mainWindowBindingSource, "Program", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TestPulsePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestPulsePanel.Location = new System.Drawing.Point(3, 3);
            this.TestPulsePanel.Name = "TestPulsePanel";
            this.TestPulsePanel.Program = null;
            this.TestPulsePanel.Size = new System.Drawing.Size(972, 310);
            this.TestPulsePanel.TabIndex = 0;
            // 
            // StopwatchControl1
            // 
            this.StopwatchControl1.ActiveColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.AccentColor;
            this.StopwatchControl1.AutoSize = true;
            this.StopwatchControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StopwatchControl1.CausesValidation = false;
            this.StopwatchControl1.DataBindings.Add(new System.Windows.Forms.Binding("ActiveColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "AccentColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StopwatchControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopwatchControl1.InactiveColor = System.Drawing.SystemColors.Control;
            this.StopwatchControl1.Location = new System.Drawing.Point(3, 84);
            this.StopwatchControl1.Name = "StopwatchControl1";
            this.StopwatchControl1.Size = new System.Drawing.Size(141, 28);
            this.StopwatchControl1.TabIndex = 4;
            // 
            // BreakInTimerControl
            // 
            this.BreakInTimerControl.AutoSize = true;
            this.BreakInTimerControl.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BreakInTimerControl.DataBindings.Add(new System.Windows.Forms.Binding("WarningColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "WarningColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BreakInTimerControl.DataBindings.Add(new System.Windows.Forms.Binding("WarningTime", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "BreakInWarningTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BreakInTimerControl.DataManager = this._DataManager;
            this.BreakInTimerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BreakInTimerControl.Location = new System.Drawing.Point(3, 41);
            this.BreakInTimerControl.Name = "BreakInTimerControl";
            this.BreakInTimerControl.Size = new System.Drawing.Size(141, 37);
            this.BreakInTimerControl.TabIndex = 3;
            this.BreakInTimerControl.WarningColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.WarningColor;
            this.BreakInTimerControl.WarningTime = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.BreakInWarningTime;
            // 
            // RecordingSetInfoControl
            // 
            this.RecordingSetInfoControl.AutoSize = true;
            this.RecordingSetInfoControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordingSetInfoControl.Cell = null;
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("Cell", this.DataManagerBindingSource, "CurrentCell", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("PhysiologyData", this.DataManagerBindingSource, "Data", true));
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("WarningColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "WarningColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("MinimumCellCapacitance", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "MinimumCellCapacitance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("MinimumMembranePotential", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "MinimumMembranePotential", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("MinimumSealResistance", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "MinimumSealResistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSetInfoControl.DataBindings.Add(new System.Windows.Forms.Binding("UsingElectrophysiologyValidation", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "UseElectrophysiologyValidation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSetInfoControl.DataManager = null;
            this.RecordingSetInfoControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.RecordingSetInfoControl.Location = new System.Drawing.Point(0, 0);
            this.RecordingSetInfoControl.MinimumCellCapacitance = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.MinimumCellCapacitance;
            this.RecordingSetInfoControl.MinimumMembranePotential = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.MinimumMembranePotential;
            this.RecordingSetInfoControl.MinimumSealResistance = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.MinimumSealResistance;
            this.RecordingSetInfoControl.Name = "RecordingSetInfoControl";
            this.RecordingSetInfoControl.NormalColor = System.Drawing.SystemColors.ControlLight;
            this.RecordingSetInfoControl.PhysiologyData = null;
            this.RecordingSetInfoControl.Size = new System.Drawing.Size(406, 115);
            this.RecordingSetInfoControl.TabIndex = 1;
            this.RecordingSetInfoControl.UsingElectrophysiologyValidation = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.UseElectrophysiologyValidation;
            this.RecordingSetInfoControl.WarningColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.WarningColor;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 617);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Physiology Workbench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TestPulseTabPage.ResumeLayout(false);
            this.ProtocolTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceManagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TestPulseTabPage;
        private System.Windows.Forms.TabPage ProtocolTabPage;
        private RRLab.PhysiologyWorkbench.RecordingInfoControl RecordingInfoControl;
        private RRLab.PhysiologyWorkbench.CellInfoControl RecordingSetInfoControl;
        protected RRLab.PhysiologyWorkbench.DataManager _DataManager;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.TabPage CollectedDataTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TrashCurrentRecordingSetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrashCurrentRecordingMenuItem;
        private RRLab.PhysiologyWorkbench.GUI.TestPulsePanel TestPulsePanel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDeviceManagerMenuItem;
        protected RRLab.PhysiologyWorkbench.Devices.DeviceManager _DeviceManager;
        private RRLab.PhysiologyWorkbench.GUI.AbsoluteVHoldController absoluteVHoldController1;
        private RRLab.PhysiologyWorkbench.GUI.BreakInTimerControl BreakInTimerControl;
        private RRLab.PhysiologyWorkbench.GUI.QuickNotes QuickNotesControl;
        private System.Windows.Forms.FlowLayoutPanel TopButtonFlowLayoutPanel;
        private System.Windows.Forms.Button OpenManualControlButton;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentRecordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem currentRecordingAsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentRecordingInExcelMenuItem;
        private RRLab.PhysiologyWorkbench.GUI.ProtocolPanel protocolPanel1;
        private HotkeyManager _HotkeyManager;
        private System.Windows.Forms.ToolStripMenuItem hotkeyManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.BindingSource DataManagerBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private System.Windows.Forms.BindingSource mainWindowBindingSource;
        private System.Windows.Forms.BindingSource DeviceManagerBindingSource;
        private StopwatchControl StopwatchControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem saveAllDataToDatabaseMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}