namespace RRLab.PhysiologyWorkbench
{
    partial class RecordingViewer
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
                Recording = null;
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Graph = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.RecordingViewerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowTitleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLegendMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scatterPlot1 = new NationalInstruments.UI.ScatterPlot();
            this.TimeAxis = new NationalInstruments.UI.XAxis();
            this.CurrentAxis = new NationalInstruments.UI.YAxis();
            this.VoltageAxis = new NationalInstruments.UI.YAxis();
            this.Title = new System.Windows.Forms.Label();
            this.RecordingViewerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Legend = new NationalInstruments.UI.WindowsForms.Legend();
            this.SidebarPanel = new System.Windows.Forms.Panel();
            this.HideablePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChannelsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.AxesGroupBox = new System.Windows.Forms.GroupBox();
            this.AxesTabControl = new System.Windows.Forms.TabControl();
            this.CurrentTab = new System.Windows.Forms.TabPage();
            this.CurrentAxisTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentMaxTextBox = new System.Windows.Forms.TextBox();
            this.CurrentMinTextBox = new System.Windows.Forms.TextBox();
            this.MaximumLabel = new System.Windows.Forms.Label();
            this.CurrentAxisMinLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CurrentAxisModeComboBox = new System.Windows.Forms.ComboBox();
            this.VoltageTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.VoltageAxisModeComboBox = new System.Windows.Forms.ComboBox();
            this.VoltageMaxTextBox = new System.Windows.Forms.TextBox();
            this.VoltageMinTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AmplifierInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.AmplifierInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CapacTextbox = new System.Windows.Forms.TextBox();
            this.GainTextbox = new System.Windows.Forms.TextBox();
            this.CapacitanceLabel = new System.Windows.Forms.Label();
            this.GainLabel = new System.Windows.Forms.Label();
            this.HideButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RecordingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.RecordingViewerContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingViewerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Legend)).BeginInit();
            this.SidebarPanel.SuspendLayout();
            this.HideablePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AxesGroupBox.SuspendLayout();
            this.AxesTabControl.SuspendLayout();
            this.CurrentTab.SuspendLayout();
            this.CurrentAxisTableLayoutPanel.SuspendLayout();
            this.VoltageTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.AmplifierInfoGroupBox.SuspendLayout();
            this.AmplifierInfoTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.Graph);
            this.MainPanel.Controls.Add(this.Title);
            this.MainPanel.Controls.Add(this.Legend);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(477, 469);
            this.MainPanel.TabIndex = 0;
            // 
            // Graph
            // 
            this.Graph.ContextMenuStrip = this.RecordingViewerContextMenuStrip;
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph.Location = new System.Drawing.Point(0, 13);
            this.Graph.Name = "Graph";
            this.Graph.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot1});
            this.Graph.Size = new System.Drawing.Size(477, 392);
            this.Graph.TabIndex = 0;
            this.Graph.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.TimeAxis});
            this.Graph.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.CurrentAxis,
            this.VoltageAxis});
            // 
            // RecordingViewerContextMenuStrip
            // 
            this.RecordingViewerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowTitleMenuItem,
            this.ShowLegendMenuItem});
            this.RecordingViewerContextMenuStrip.Name = "RecordingViewerContextMenuStrip";
            this.RecordingViewerContextMenuStrip.Size = new System.Drawing.Size(146, 48);
            // 
            // ShowTitleMenuItem
            // 
            this.ShowTitleMenuItem.CheckOnClick = true;
            this.ShowTitleMenuItem.Name = "ShowTitleMenuItem";
            this.ShowTitleMenuItem.Size = new System.Drawing.Size(145, 22);
            this.ShowTitleMenuItem.Text = "Show Title";
            this.ShowTitleMenuItem.Click += new System.EventHandler(this.OnShowTitleClicked);
            // 
            // ShowLegendMenuItem
            // 
            this.ShowLegendMenuItem.CheckOnClick = true;
            this.ShowLegendMenuItem.Name = "ShowLegendMenuItem";
            this.ShowLegendMenuItem.Size = new System.Drawing.Size(145, 22);
            this.ShowLegendMenuItem.Text = "Show Legend";
            this.ShowLegendMenuItem.Click += new System.EventHandler(this.OnShowLegendClicked);
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.XAxis = this.TimeAxis;
            this.scatterPlot1.YAxis = this.CurrentAxis;
            // 
            // TimeAxis
            // 
            this.TimeAxis.Caption = "Time (ms)";
            // 
            // CurrentAxis
            // 
            this.CurrentAxis.Caption = "Current (pA)";
            // 
            // VoltageAxis
            // 
            this.VoltageAxis.Caption = "Voltage (V)";
            this.VoltageAxis.CaptionPosition = NationalInstruments.UI.YAxisPosition.Right;
            this.VoltageAxis.Position = NationalInstruments.UI.YAxisPosition.Right;
            this.VoltageAxis.Range = new NationalInstruments.UI.Range(-10, 10);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.RecordingViewerBindingSource, "IsTitleVisible", true));
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(33, 13);
            this.Title.TabIndex = 2;
            this.Title.Text = "[Title]";
            // 
            // RecordingViewerBindingSource
            // 
            this.RecordingViewerBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.RecordingViewer);
            // 
            // Legend
            // 
            this.Legend.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.RecordingViewerBindingSource, "IsLegendVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Legend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Legend.Location = new System.Drawing.Point(0, 405);
            this.Legend.Name = "Legend";
            this.Legend.Size = new System.Drawing.Size(477, 64);
            this.Legend.TabIndex = 1;
            // 
            // SidebarPanel
            // 
            this.SidebarPanel.AutoSize = true;
            this.SidebarPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SidebarPanel.Controls.Add(this.HideablePanel);
            this.SidebarPanel.Controls.Add(this.HideButton);
            this.SidebarPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SidebarPanel.Location = new System.Drawing.Point(477, 0);
            this.SidebarPanel.MinimumSize = new System.Drawing.Size(180, 0);
            this.SidebarPanel.Name = "SidebarPanel";
            this.SidebarPanel.Size = new System.Drawing.Size(180, 469);
            this.SidebarPanel.TabIndex = 1;
            // 
            // HideablePanel
            // 
            this.HideablePanel.AutoScroll = true;
            this.HideablePanel.AutoSize = true;
            this.HideablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HideablePanel.Controls.Add(this.groupBox1);
            this.HideablePanel.Controls.Add(this.AxesGroupBox);
            this.HideablePanel.Controls.Add(this.AmplifierInfoGroupBox);
            this.HideablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideablePanel.Location = new System.Drawing.Point(0, 23);
            this.HideablePanel.MinimumSize = new System.Drawing.Size(169, 0);
            this.HideablePanel.Name = "HideablePanel";
            this.HideablePanel.Size = new System.Drawing.Size(180, 446);
            this.HideablePanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChannelsCheckListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(169, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 242);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // ChannelsCheckListBox
            // 
            this.ChannelsCheckListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChannelsCheckListBox.FormattingEnabled = true;
            this.ChannelsCheckListBox.Location = new System.Drawing.Point(3, 16);
            this.ChannelsCheckListBox.Name = "ChannelsCheckListBox";
            this.ChannelsCheckListBox.Size = new System.Drawing.Size(174, 214);
            this.ChannelsCheckListBox.TabIndex = 0;
            this.ChannelsCheckListBox.SelectedIndexChanged += new System.EventHandler(this.OnCheckedChannelsChanged);
            // 
            // AxesGroupBox
            // 
            this.AxesGroupBox.Controls.Add(this.AxesTabControl);
            this.AxesGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AxesGroupBox.Location = new System.Drawing.Point(0, 242);
            this.AxesGroupBox.Name = "AxesGroupBox";
            this.AxesGroupBox.Size = new System.Drawing.Size(180, 133);
            this.AxesGroupBox.TabIndex = 8;
            this.AxesGroupBox.TabStop = false;
            this.AxesGroupBox.Text = "Axes";
            // 
            // AxesTabControl
            // 
            this.AxesTabControl.Controls.Add(this.CurrentTab);
            this.AxesTabControl.Controls.Add(this.VoltageTab);
            this.AxesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxesTabControl.Location = new System.Drawing.Point(3, 16);
            this.AxesTabControl.Name = "AxesTabControl";
            this.AxesTabControl.SelectedIndex = 0;
            this.AxesTabControl.Size = new System.Drawing.Size(174, 114);
            this.AxesTabControl.TabIndex = 8;
            // 
            // CurrentTab
            // 
            this.CurrentTab.Controls.Add(this.CurrentAxisTableLayoutPanel);
            this.CurrentTab.Location = new System.Drawing.Point(4, 22);
            this.CurrentTab.Name = "CurrentTab";
            this.CurrentTab.Padding = new System.Windows.Forms.Padding(3);
            this.CurrentTab.Size = new System.Drawing.Size(166, 88);
            this.CurrentTab.TabIndex = 0;
            this.CurrentTab.Text = "Current";
            this.CurrentTab.UseVisualStyleBackColor = true;
            // 
            // CurrentAxisTableLayoutPanel
            // 
            this.CurrentAxisTableLayoutPanel.AutoSize = true;
            this.CurrentAxisTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CurrentAxisTableLayoutPanel.ColumnCount = 2;
            this.CurrentAxisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CurrentAxisTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CurrentAxisTableLayoutPanel.Controls.Add(this.CurrentMaxTextBox, 1, 1);
            this.CurrentAxisTableLayoutPanel.Controls.Add(this.CurrentMinTextBox, 1, 0);
            this.CurrentAxisTableLayoutPanel.Controls.Add(this.MaximumLabel, 0, 1);
            this.CurrentAxisTableLayoutPanel.Controls.Add(this.CurrentAxisMinLabel, 0, 0);
            this.CurrentAxisTableLayoutPanel.Controls.Add(this.label4, 0, 2);
            this.CurrentAxisTableLayoutPanel.Controls.Add(this.CurrentAxisModeComboBox, 1, 2);
            this.CurrentAxisTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentAxisTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.CurrentAxisTableLayoutPanel.Name = "CurrentAxisTableLayoutPanel";
            this.CurrentAxisTableLayoutPanel.RowCount = 3;
            this.CurrentAxisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CurrentAxisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CurrentAxisTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CurrentAxisTableLayoutPanel.Size = new System.Drawing.Size(160, 82);
            this.CurrentAxisTableLayoutPanel.TabIndex = 1;
            // 
            // CurrentMaxTextBox
            // 
            this.CurrentMaxTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentMaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingViewerBindingSource, "CurrentMaxDaqVoltage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CurrentMaxTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentMaxTextBox.Enabled = false;
            this.CurrentMaxTextBox.Location = new System.Drawing.Point(65, 29);
            this.CurrentMaxTextBox.Name = "CurrentMaxTextBox";
            this.CurrentMaxTextBox.ReadOnly = true;
            this.CurrentMaxTextBox.Size = new System.Drawing.Size(92, 20);
            this.CurrentMaxTextBox.TabIndex = 4;
            // 
            // CurrentMinTextBox
            // 
            this.CurrentMinTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentMinTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingViewerBindingSource, "CurrentMinDaqVoltage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CurrentMinTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentMinTextBox.Enabled = false;
            this.CurrentMinTextBox.Location = new System.Drawing.Point(65, 3);
            this.CurrentMinTextBox.Name = "CurrentMinTextBox";
            this.CurrentMinTextBox.ReadOnly = true;
            this.CurrentMinTextBox.Size = new System.Drawing.Size(92, 20);
            this.CurrentMinTextBox.TabIndex = 3;
            // 
            // MaximumLabel
            // 
            this.MaximumLabel.AutoSize = true;
            this.MaximumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaximumLabel.Location = new System.Drawing.Point(3, 26);
            this.MaximumLabel.Name = "MaximumLabel";
            this.MaximumLabel.Size = new System.Drawing.Size(56, 26);
            this.MaximumLabel.TabIndex = 1;
            this.MaximumLabel.Text = "Maximum";
            this.MaximumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentAxisMinLabel
            // 
            this.CurrentAxisMinLabel.AutoSize = true;
            this.CurrentAxisMinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentAxisMinLabel.Location = new System.Drawing.Point(3, 0);
            this.CurrentAxisMinLabel.Name = "CurrentAxisMinLabel";
            this.CurrentAxisMinLabel.Size = new System.Drawing.Size(56, 26);
            this.CurrentAxisMinLabel.TabIndex = 0;
            this.CurrentAxisMinLabel.Text = "Minimum";
            this.CurrentAxisMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Axis Mode";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentAxisModeComboBox
            // 
            this.CurrentAxisModeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentAxisModeComboBox.FormattingEnabled = true;
            this.CurrentAxisModeComboBox.Items.AddRange(new object[] {
            "Fixed",
            "Data",
            "DynamicRange"});
            this.CurrentAxisModeComboBox.Location = new System.Drawing.Point(65, 55);
            this.CurrentAxisModeComboBox.Name = "CurrentAxisModeComboBox";
            this.CurrentAxisModeComboBox.Size = new System.Drawing.Size(92, 21);
            this.CurrentAxisModeComboBox.TabIndex = 6;
            this.CurrentAxisModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnCurrentAxisModeComboBoxSelectionChanged);
            // 
            // VoltageTab
            // 
            this.VoltageTab.Controls.Add(this.tableLayoutPanel2);
            this.VoltageTab.Location = new System.Drawing.Point(4, 22);
            this.VoltageTab.Name = "VoltageTab";
            this.VoltageTab.Padding = new System.Windows.Forms.Padding(3);
            this.VoltageTab.Size = new System.Drawing.Size(166, 88);
            this.VoltageTab.TabIndex = 1;
            this.VoltageTab.Text = "Voltage";
            this.VoltageTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.VoltageAxisModeComboBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.VoltageMaxTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.VoltageMinTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(160, 82);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // VoltageAxisModeComboBox
            // 
            this.VoltageAxisModeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoltageAxisModeComboBox.FormattingEnabled = true;
            this.VoltageAxisModeComboBox.Items.AddRange(new object[] {
            "Fixed",
            "Data",
            "DynamicRange"});
            this.VoltageAxisModeComboBox.Location = new System.Drawing.Point(65, 55);
            this.VoltageAxisModeComboBox.Name = "VoltageAxisModeComboBox";
            this.VoltageAxisModeComboBox.Size = new System.Drawing.Size(92, 21);
            this.VoltageAxisModeComboBox.TabIndex = 7;
            this.VoltageAxisModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnVoltageAxisModeComboBoxSelectionChanged);
            // 
            // VoltageMaxTextBox
            // 
            this.VoltageMaxTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.VoltageMaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingViewerBindingSource, "VoltageMaxDaqVoltage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VoltageMaxTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoltageMaxTextBox.Enabled = false;
            this.VoltageMaxTextBox.Location = new System.Drawing.Point(65, 29);
            this.VoltageMaxTextBox.Name = "VoltageMaxTextBox";
            this.VoltageMaxTextBox.ReadOnly = true;
            this.VoltageMaxTextBox.Size = new System.Drawing.Size(92, 20);
            this.VoltageMaxTextBox.TabIndex = 4;
            // 
            // VoltageMinTextBox
            // 
            this.VoltageMinTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.VoltageMinTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingViewerBindingSource, "VoltageMinDaqVoltage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VoltageMinTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoltageMinTextBox.Enabled = false;
            this.VoltageMinTextBox.Location = new System.Drawing.Point(65, 3);
            this.VoltageMinTextBox.Name = "VoltageMinTextBox";
            this.VoltageMinTextBox.ReadOnly = true;
            this.VoltageMinTextBox.Size = new System.Drawing.Size(92, 20);
            this.VoltageMinTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Minimum";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "Axis Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmplifierInfoGroupBox
            // 
            this.AmplifierInfoGroupBox.AutoSize = true;
            this.AmplifierInfoGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AmplifierInfoGroupBox.Controls.Add(this.AmplifierInfoTableLayoutPanel);
            this.AmplifierInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AmplifierInfoGroupBox.Location = new System.Drawing.Point(0, 375);
            this.AmplifierInfoGroupBox.MinimumSize = new System.Drawing.Size(169, 0);
            this.AmplifierInfoGroupBox.Name = "AmplifierInfoGroupBox";
            this.AmplifierInfoGroupBox.Size = new System.Drawing.Size(180, 71);
            this.AmplifierInfoGroupBox.TabIndex = 5;
            this.AmplifierInfoGroupBox.TabStop = false;
            this.AmplifierInfoGroupBox.Text = "Amplifier Info";
            // 
            // AmplifierInfoTableLayoutPanel
            // 
            this.AmplifierInfoTableLayoutPanel.AutoSize = true;
            this.AmplifierInfoTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AmplifierInfoTableLayoutPanel.ColumnCount = 2;
            this.AmplifierInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AmplifierInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AmplifierInfoTableLayoutPanel.Controls.Add(this.CapacTextbox, 1, 1);
            this.AmplifierInfoTableLayoutPanel.Controls.Add(this.GainTextbox, 1, 0);
            this.AmplifierInfoTableLayoutPanel.Controls.Add(this.CapacitanceLabel, 0, 1);
            this.AmplifierInfoTableLayoutPanel.Controls.Add(this.GainLabel, 0, 0);
            this.AmplifierInfoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmplifierInfoTableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.AmplifierInfoTableLayoutPanel.Name = "AmplifierInfoTableLayoutPanel";
            this.AmplifierInfoTableLayoutPanel.RowCount = 2;
            this.AmplifierInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AmplifierInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AmplifierInfoTableLayoutPanel.Size = new System.Drawing.Size(174, 52);
            this.AmplifierInfoTableLayoutPanel.TabIndex = 0;
            // 
            // CapacTextbox
            // 
            this.CapacTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CapacTextbox.Location = new System.Drawing.Point(114, 29);
            this.CapacTextbox.Name = "CapacTextbox";
            this.CapacTextbox.ReadOnly = true;
            this.CapacTextbox.Size = new System.Drawing.Size(77, 20);
            this.CapacTextbox.TabIndex = 3;
            // 
            // GainTextbox
            // 
            this.GainTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GainTextbox.Location = new System.Drawing.Point(114, 3);
            this.GainTextbox.Name = "GainTextbox";
            this.GainTextbox.ReadOnly = true;
            this.GainTextbox.Size = new System.Drawing.Size(77, 20);
            this.GainTextbox.TabIndex = 2;
            // 
            // CapacitanceLabel
            // 
            this.CapacitanceLabel.AutoSize = true;
            this.CapacitanceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CapacitanceLabel.Location = new System.Drawing.Point(3, 26);
            this.CapacitanceLabel.Name = "CapacitanceLabel";
            this.CapacitanceLabel.Size = new System.Drawing.Size(105, 26);
            this.CapacitanceLabel.TabIndex = 1;
            this.CapacitanceLabel.Text = "CellCapacitance (pF)";
            this.CapacitanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GainLabel
            // 
            this.GainLabel.AutoSize = true;
            this.GainLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GainLabel.Location = new System.Drawing.Point(3, 0);
            this.GainLabel.Name = "GainLabel";
            this.GainLabel.Size = new System.Drawing.Size(105, 26);
            this.GainLabel.TabIndex = 0;
            this.GainLabel.Text = "Gain (pA/mV)";
            this.GainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HideButton
            // 
            this.HideButton.AutoSize = true;
            this.HideButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HideButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.HideButton.Location = new System.Drawing.Point(0, 0);
            this.HideButton.MinimumSize = new System.Drawing.Size(50, 0);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(180, 23);
            this.HideButton.TabIndex = 1;
            this.HideButton.Text = "Hide >>>";
            this.HideButton.UseVisualStyleBackColor = true;
            this.HideButton.Click += new System.EventHandler(this.OnHideButtonClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(194, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(194, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximum";
            // 
            // RecordingBindingSource
            // 
            this.RecordingBindingSource.DataMember = "Recordings";
            this.RecordingBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyData);
            this.RecordingBindingSource.CurrentChanged += new System.EventHandler(this.OnCurrentRecordingChanged);
            // 
            // RecordingViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.SidebarPanel);
            this.Name = "RecordingViewer";
            this.Size = new System.Drawing.Size(657, 469);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.RecordingViewerContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecordingViewerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Legend)).EndInit();
            this.SidebarPanel.ResumeLayout(false);
            this.SidebarPanel.PerformLayout();
            this.HideablePanel.ResumeLayout(false);
            this.HideablePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.AxesGroupBox.ResumeLayout(false);
            this.AxesTabControl.ResumeLayout(false);
            this.CurrentTab.ResumeLayout(false);
            this.CurrentTab.PerformLayout();
            this.CurrentAxisTableLayoutPanel.ResumeLayout(false);
            this.CurrentAxisTableLayoutPanel.PerformLayout();
            this.VoltageTab.ResumeLayout(false);
            this.VoltageTab.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.AmplifierInfoGroupBox.ResumeLayout(false);
            this.AmplifierInfoGroupBox.PerformLayout();
            this.AmplifierInfoTableLayoutPanel.ResumeLayout(false);
            this.AmplifierInfoTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel MainPanel;
        private NationalInstruments.UI.WindowsForms.ScatterGraph Graph;
        private NationalInstruments.UI.ScatterPlot scatterPlot1;
        private NationalInstruments.UI.XAxis TimeAxis;
        private NationalInstruments.UI.YAxis CurrentAxis;
        protected System.Windows.Forms.Panel SidebarPanel;
        private System.Windows.Forms.Panel HideablePanel;
        private System.Windows.Forms.Button HideButton;
        private NationalInstruments.UI.WindowsForms.Legend Legend;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox ChannelsCheckListBox;
        private System.Windows.Forms.GroupBox AmplifierInfoGroupBox;
        private System.Windows.Forms.TableLayoutPanel AmplifierInfoTableLayoutPanel;
        private System.Windows.Forms.TextBox CapacTextbox;
        private System.Windows.Forms.TextBox GainTextbox;
        private System.Windows.Forms.Label CapacitanceLabel;
        private System.Windows.Forms.Label GainLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.UI.YAxis VoltageAxis;
        private System.Windows.Forms.ContextMenuStrip RecordingViewerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowTitleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLegendMenuItem;
        private System.Windows.Forms.GroupBox AxesGroupBox;
        private System.Windows.Forms.TabControl AxesTabControl;
        private System.Windows.Forms.TabPage CurrentTab;
        private System.Windows.Forms.TableLayoutPanel CurrentAxisTableLayoutPanel;
        private System.Windows.Forms.TextBox CurrentMaxTextBox;
        private System.Windows.Forms.TextBox CurrentMinTextBox;
        private System.Windows.Forms.Label MaximumLabel;
        private System.Windows.Forms.Label CurrentAxisMinLabel;
        private System.Windows.Forms.TabPage VoltageTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox VoltageMaxTextBox;
        private System.Windows.Forms.TextBox VoltageMinTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource RecordingViewerBindingSource;
        private System.Windows.Forms.BindingSource RecordingBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CurrentAxisModeComboBox;
        private System.Windows.Forms.ComboBox VoltageAxisModeComboBox;
        private System.Windows.Forms.Label label5;
    }
}
