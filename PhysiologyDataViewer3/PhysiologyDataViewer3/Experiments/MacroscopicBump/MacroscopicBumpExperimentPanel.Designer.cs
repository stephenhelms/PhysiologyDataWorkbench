namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    partial class MacroscopicBumpExperimentPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroscopicBumpExperimentPanel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ViewCellRecordingDetailsButton = new System.Windows.Forms.ToolStripButton();
            this.calcAvgResponseButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MacroscopicBumpsDataGridView = new System.Windows.Forms.DataGridView();
            this.ResponseHalfWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genotypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analysisDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativeLogIntensityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calciumConcentrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amplitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeIntegralDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latencyTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOfPeakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowActivationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastActivationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastInactivationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slowInactivationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSinceBreakInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MacroscopicBumpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BumpFitTab = new System.Windows.Forms.TabPage();
            this.MacroscopicBumpViewerControl = new RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump.MacroscopicBumpViewerControl();
            this.ExperimentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HistogramControl = new RRLab.Utilities.DataSetHistogramControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.HistogramColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HistogramFilterTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataSetGroupedScatterPlotControl1 = new RRLab.Utilities.DataSetGroupedScatterPlotControl();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MacroscopicBumpsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroscopicBumpBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.BumpFitTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentBindingSource)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.ViewCellRecordingDetailsButton,
            this.calcAvgResponseButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(146, 22);
            this.toolStripButton1.Text = "Load Data From Database";
            this.toolStripButton1.Click += new System.EventHandler(this.OnLoadDataFromDatabaseClicked);
            // 
            // ViewCellRecordingDetailsButton
            // 
            this.ViewCellRecordingDetailsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ViewCellRecordingDetailsButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewCellRecordingDetailsButton.Image")));
            this.ViewCellRecordingDetailsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ViewCellRecordingDetailsButton.Name = "ViewCellRecordingDetailsButton";
            this.ViewCellRecordingDetailsButton.Size = new System.Drawing.Size(156, 22);
            this.ViewCellRecordingDetailsButton.Text = "View Cell/Recording Details";
            this.ViewCellRecordingDetailsButton.Click += new System.EventHandler(this.OnViewCellRecordingDetailsClicked);
            // 
            // calcAvgResponseButton
            // 
            this.calcAvgResponseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.calcAvgResponseButton.Image = ((System.Drawing.Image)(resources.GetObject("calcAvgResponseButton.Image")));
            this.calcAvgResponseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.calcAvgResponseButton.Name = "calcAvgResponseButton";
            this.calcAvgResponseButton.Size = new System.Drawing.Size(159, 22);
            this.calcAvgResponseButton.Text = "Calculate Average Response";
            this.calcAvgResponseButton.Click += new System.EventHandler(this.calcAvgResponseButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 548);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MacroscopicBumpsDataGridView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 213);
            this.panel1.TabIndex = 0;
            // 
            // MacroscopicBumpsDataGridView
            // 
            this.MacroscopicBumpsDataGridView.AllowUserToOrderColumns = true;
            this.MacroscopicBumpsDataGridView.AutoGenerateColumns = false;
            this.MacroscopicBumpsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.MacroscopicBumpsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.MacroscopicBumpsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MacroscopicBumpsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ResponseHalfWidth,
            this.cellIDDataGridViewTextBoxColumn,
            this.recordingIDDataGridViewTextBoxColumn,
            this.genotypeDataGridViewTextBoxColumn,
            this.analysisDateDataGridViewTextBoxColumn,
            this.recordedDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.relativeLogIntensityDataGridViewTextBoxColumn,
            this.calciumConcentrationDataGridViewTextBoxColumn,
            this.amplitudeDataGridViewTextBoxColumn,
            this.chargeIntegralDataGridViewTextBoxColumn,
            this.latencyTimeDataGridViewTextBoxColumn,
            this.timeOfPeakDataGridViewTextBoxColumn,
            this.slowActivationTimeDataGridViewTextBoxColumn,
            this.fastActivationTimeDataGridViewTextBoxColumn,
            this.fastInactivationTimeDataGridViewTextBoxColumn,
            this.slowInactivationTimeDataGridViewTextBoxColumn,
            this.timeSinceBreakInDataGridViewTextBoxColumn,
            this.commentsDataGridViewTextBoxColumn});
            this.MacroscopicBumpsDataGridView.DataSource = this.MacroscopicBumpBindingSource;
            this.MacroscopicBumpsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MacroscopicBumpsDataGridView.Location = new System.Drawing.Point(0, 13);
            this.MacroscopicBumpsDataGridView.Name = "MacroscopicBumpsDataGridView";
            this.MacroscopicBumpsDataGridView.Size = new System.Drawing.Size(661, 200);
            this.MacroscopicBumpsDataGridView.TabIndex = 1;
            this.MacroscopicBumpsDataGridView.CurrentCellChanged += new System.EventHandler(this.OnCurrentMacroscopicBumpRecordingGridViewCellChanged);
            // 
            // ResponseHalfWidth
            // 
            this.ResponseHalfWidth.DataPropertyName = "ResponseHalfWidth";
            this.ResponseHalfWidth.HeaderText = "ResponseHalfWidth";
            this.ResponseHalfWidth.Name = "ResponseHalfWidth";
            this.ResponseHalfWidth.ReadOnly = true;
            this.ResponseHalfWidth.Width = 127;
            // 
            // cellIDDataGridViewTextBoxColumn
            // 
            this.cellIDDataGridViewTextBoxColumn.DataPropertyName = "CellID";
            this.cellIDDataGridViewTextBoxColumn.HeaderText = "CellID";
            this.cellIDDataGridViewTextBoxColumn.Name = "cellIDDataGridViewTextBoxColumn";
            this.cellIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cellIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // recordingIDDataGridViewTextBoxColumn
            // 
            this.recordingIDDataGridViewTextBoxColumn.DataPropertyName = "RecordingID";
            this.recordingIDDataGridViewTextBoxColumn.HeaderText = "RecordingID";
            this.recordingIDDataGridViewTextBoxColumn.Name = "recordingIDDataGridViewTextBoxColumn";
            this.recordingIDDataGridViewTextBoxColumn.Width = 92;
            // 
            // genotypeDataGridViewTextBoxColumn
            // 
            this.genotypeDataGridViewTextBoxColumn.DataPropertyName = "Genotype";
            this.genotypeDataGridViewTextBoxColumn.HeaderText = "Genotype";
            this.genotypeDataGridViewTextBoxColumn.Name = "genotypeDataGridViewTextBoxColumn";
            this.genotypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.genotypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // analysisDateDataGridViewTextBoxColumn
            // 
            this.analysisDateDataGridViewTextBoxColumn.DataPropertyName = "AnalysisDate";
            this.analysisDateDataGridViewTextBoxColumn.HeaderText = "AnalysisDate";
            this.analysisDateDataGridViewTextBoxColumn.Name = "analysisDateDataGridViewTextBoxColumn";
            this.analysisDateDataGridViewTextBoxColumn.Width = 93;
            // 
            // recordedDataGridViewTextBoxColumn
            // 
            this.recordedDataGridViewTextBoxColumn.DataPropertyName = "Recorded";
            this.recordedDataGridViewTextBoxColumn.HeaderText = "Recorded";
            this.recordedDataGridViewTextBoxColumn.Name = "recordedDataGridViewTextBoxColumn";
            this.recordedDataGridViewTextBoxColumn.ReadOnly = true;
            this.recordedDataGridViewTextBoxColumn.Width = 79;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // relativeLogIntensityDataGridViewTextBoxColumn
            // 
            this.relativeLogIntensityDataGridViewTextBoxColumn.DataPropertyName = "RelativeLogIntensity";
            this.relativeLogIntensityDataGridViewTextBoxColumn.HeaderText = "RelativeLogIntensity";
            this.relativeLogIntensityDataGridViewTextBoxColumn.Name = "relativeLogIntensityDataGridViewTextBoxColumn";
            this.relativeLogIntensityDataGridViewTextBoxColumn.Width = 128;
            // 
            // calciumConcentrationDataGridViewTextBoxColumn
            // 
            this.calciumConcentrationDataGridViewTextBoxColumn.DataPropertyName = "CalciumConcentration";
            this.calciumConcentrationDataGridViewTextBoxColumn.HeaderText = "CalciumConcentration";
            this.calciumConcentrationDataGridViewTextBoxColumn.Name = "calciumConcentrationDataGridViewTextBoxColumn";
            this.calciumConcentrationDataGridViewTextBoxColumn.Width = 135;
            // 
            // amplitudeDataGridViewTextBoxColumn
            // 
            this.amplitudeDataGridViewTextBoxColumn.DataPropertyName = "Amplitude";
            this.amplitudeDataGridViewTextBoxColumn.HeaderText = "Amplitude";
            this.amplitudeDataGridViewTextBoxColumn.Name = "amplitudeDataGridViewTextBoxColumn";
            this.amplitudeDataGridViewTextBoxColumn.Width = 78;
            // 
            // chargeIntegralDataGridViewTextBoxColumn
            // 
            this.chargeIntegralDataGridViewTextBoxColumn.DataPropertyName = "ChargeIntegral";
            this.chargeIntegralDataGridViewTextBoxColumn.HeaderText = "ChargeIntegral";
            this.chargeIntegralDataGridViewTextBoxColumn.Name = "chargeIntegralDataGridViewTextBoxColumn";
            this.chargeIntegralDataGridViewTextBoxColumn.Width = 101;
            // 
            // latencyTimeDataGridViewTextBoxColumn
            // 
            this.latencyTimeDataGridViewTextBoxColumn.DataPropertyName = "LatencyTime";
            this.latencyTimeDataGridViewTextBoxColumn.HeaderText = "LatencyTime";
            this.latencyTimeDataGridViewTextBoxColumn.Name = "latencyTimeDataGridViewTextBoxColumn";
            this.latencyTimeDataGridViewTextBoxColumn.Width = 93;
            // 
            // timeOfPeakDataGridViewTextBoxColumn
            // 
            this.timeOfPeakDataGridViewTextBoxColumn.DataPropertyName = "TimeOfPeak";
            this.timeOfPeakDataGridViewTextBoxColumn.HeaderText = "TimeOfPeak";
            this.timeOfPeakDataGridViewTextBoxColumn.Name = "timeOfPeakDataGridViewTextBoxColumn";
            this.timeOfPeakDataGridViewTextBoxColumn.Width = 91;
            // 
            // slowActivationTimeDataGridViewTextBoxColumn
            // 
            this.slowActivationTimeDataGridViewTextBoxColumn.DataPropertyName = "SlowActivationTime";
            this.slowActivationTimeDataGridViewTextBoxColumn.HeaderText = "SlowActivationTime";
            this.slowActivationTimeDataGridViewTextBoxColumn.Name = "slowActivationTimeDataGridViewTextBoxColumn";
            this.slowActivationTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // fastActivationTimeDataGridViewTextBoxColumn
            // 
            this.fastActivationTimeDataGridViewTextBoxColumn.DataPropertyName = "FastActivationTime";
            this.fastActivationTimeDataGridViewTextBoxColumn.HeaderText = "FastActivationTime";
            this.fastActivationTimeDataGridViewTextBoxColumn.Name = "fastActivationTimeDataGridViewTextBoxColumn";
            this.fastActivationTimeDataGridViewTextBoxColumn.Width = 122;
            // 
            // fastInactivationTimeDataGridViewTextBoxColumn
            // 
            this.fastInactivationTimeDataGridViewTextBoxColumn.DataPropertyName = "FastInactivationTime";
            this.fastInactivationTimeDataGridViewTextBoxColumn.HeaderText = "FastInactivationTime";
            this.fastInactivationTimeDataGridViewTextBoxColumn.Name = "fastInactivationTimeDataGridViewTextBoxColumn";
            this.fastInactivationTimeDataGridViewTextBoxColumn.Width = 130;
            // 
            // slowInactivationTimeDataGridViewTextBoxColumn
            // 
            this.slowInactivationTimeDataGridViewTextBoxColumn.DataPropertyName = "SlowInactivationTime";
            this.slowInactivationTimeDataGridViewTextBoxColumn.HeaderText = "SlowInactivationTime";
            this.slowInactivationTimeDataGridViewTextBoxColumn.Name = "slowInactivationTimeDataGridViewTextBoxColumn";
            this.slowInactivationTimeDataGridViewTextBoxColumn.Width = 133;
            // 
            // timeSinceBreakInDataGridViewTextBoxColumn
            // 
            this.timeSinceBreakInDataGridViewTextBoxColumn.DataPropertyName = "TimeSinceBreakIn";
            this.timeSinceBreakInDataGridViewTextBoxColumn.HeaderText = "TimeSinceBreakIn";
            this.timeSinceBreakInDataGridViewTextBoxColumn.Name = "timeSinceBreakInDataGridViewTextBoxColumn";
            this.timeSinceBreakInDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeSinceBreakInDataGridViewTextBoxColumn.Width = 119;
            // 
            // commentsDataGridViewTextBoxColumn
            // 
            this.commentsDataGridViewTextBoxColumn.DataPropertyName = "Comments";
            this.commentsDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.commentsDataGridViewTextBoxColumn.Name = "commentsDataGridViewTextBoxColumn";
            this.commentsDataGridViewTextBoxColumn.Width = 81;
            // 
            // MacroscopicBumpBindingSource
            // 
            this.MacroscopicBumpBindingSource.DataMember = "MacroscopicRecordings";
            this.MacroscopicBumpBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump.MacroscopicRecordingsDataSet);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Macroscopic Bump Recordings:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.BumpFitTab);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 222);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 323);
            this.tabControl1.TabIndex = 1;
            // 
            // BumpFitTab
            // 
            this.BumpFitTab.Controls.Add(this.MacroscopicBumpViewerControl);
            this.BumpFitTab.Location = new System.Drawing.Point(4, 22);
            this.BumpFitTab.Name = "BumpFitTab";
            this.BumpFitTab.Padding = new System.Windows.Forms.Padding(3);
            this.BumpFitTab.Size = new System.Drawing.Size(653, 297);
            this.BumpFitTab.TabIndex = 2;
            this.BumpFitTab.Text = "Bump Fit";
            this.BumpFitTab.UseVisualStyleBackColor = true;
            // 
            // MacroscopicBumpViewerControl
            // 
            this.MacroscopicBumpViewerControl.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MacroscopicBumpViewerControl.DataBindings.Add(new System.Windows.Forms.Binding("MacroscopicBump", this.ExperimentBindingSource, "CurrentMacroscopicBump", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MacroscopicBumpViewerControl.DataBindings.Add(new System.Windows.Forms.Binding("PhysiologyDataSet", this.ExperimentBindingSource, "PhysiologyDataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MacroscopicBumpViewerControl.DataBindings.Add(new System.Windows.Forms.Binding("PointsColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MacroscopicBumpViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MacroscopicBumpViewerControl.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.MacroscopicBumpViewerControl.LineColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.LineColor;
            this.MacroscopicBumpViewerControl.Location = new System.Drawing.Point(3, 3);
            this.MacroscopicBumpViewerControl.MacroscopicBump = null;
            this.MacroscopicBumpViewerControl.Name = "MacroscopicBumpViewerControl";
            this.MacroscopicBumpViewerControl.PhysiologyDataSet = null;
            this.MacroscopicBumpViewerControl.PointsColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.MacroscopicBumpViewerControl.Size = new System.Drawing.Size(647, 291);
            this.MacroscopicBumpViewerControl.SymbolType = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.ScatterPlotSymbolType;
            this.MacroscopicBumpViewerControl.TabIndex = 0;
            // 
            // ExperimentBindingSource
            // 
            this.ExperimentBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump.MacroscopicBumpExperiment);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HistogramControl);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Histogram";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HistogramControl
            // 
            this.HistogramControl.BarColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.HistogramControl.Column = null;
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("BarColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("Filter", this.ExperimentBindingSource, "HistogramFilter", true));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ExperimentBindingSource, "MacroscopicBumpsDataSet", true));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("Column", this.ExperimentBindingSource, "HistogramColumn", true));
            this.HistogramControl.DataSet = null;
            this.HistogramControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistogramControl.Filter = null;
            this.HistogramControl.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.HistogramControl.Location = new System.Drawing.Point(3, 30);
            this.HistogramControl.Name = "HistogramControl";
            this.HistogramControl.Size = new System.Drawing.Size(647, 264);
            this.HistogramControl.TabIndex = 1;
            this.HistogramControl.Table = "MacroscopicRecordings";
            this.HistogramControl.Title = null;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.HistogramColumnComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.HistogramFilterTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(647, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Column:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HistogramColumnComboBox
            // 
            this.HistogramColumnComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ExperimentBindingSource, "HistogramColumn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramColumnComboBox.DisplayMember = "Name";
            this.HistogramColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HistogramColumnComboBox.FormattingEnabled = true;
            this.HistogramColumnComboBox.Location = new System.Drawing.Point(54, 3);
            this.HistogramColumnComboBox.Name = "HistogramColumnComboBox";
            this.HistogramColumnComboBox.Size = new System.Drawing.Size(121, 21);
            this.HistogramColumnComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(181, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filter:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HistogramFilterTextBox
            // 
            this.HistogramFilterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ExperimentBindingSource, "HistogramFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramFilterTextBox.Location = new System.Drawing.Point(219, 3);
            this.HistogramFilterTextBox.Name = "HistogramFilterTextBox";
            this.HistogramFilterTextBox.Size = new System.Drawing.Size(154, 20);
            this.HistogramFilterTextBox.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataSetGroupedScatterPlotControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scatter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataSetGroupedScatterPlotControl1
            // 
            this.dataSetGroupedScatterPlotControl1.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ExperimentBindingSource, "MacroscopicBumpsDataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetGroupedScatterPlotControl1.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetGroupedScatterPlotControl1.DataSet = null;
            this.dataSetGroupedScatterPlotControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSetGroupedScatterPlotControl1.Filter = null;
            this.dataSetGroupedScatterPlotControl1.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.dataSetGroupedScatterPlotControl1.GroupColumn = null;
            this.dataSetGroupedScatterPlotControl1.Location = new System.Drawing.Point(3, 3);
            this.dataSetGroupedScatterPlotControl1.Name = "dataSetGroupedScatterPlotControl1";
            this.dataSetGroupedScatterPlotControl1.PointsColor = System.Drawing.Color.Crimson;
            this.dataSetGroupedScatterPlotControl1.Size = new System.Drawing.Size(647, 291);
            this.dataSetGroupedScatterPlotControl1.TabIndex = 0;
            this.dataSetGroupedScatterPlotControl1.Table = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MacroscopicResponsesGraphDataTable;
            this.dataSetGroupedScatterPlotControl1.TagColumn = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MacroscopicResponsesGraphTagColumn;
            this.dataSetGroupedScatterPlotControl1.Title = null;
            this.dataSetGroupedScatterPlotControl1.XColumn = null;
            this.dataSetGroupedScatterPlotControl1.YColumn = null;
            // 
            // MacroscopicBumpExperimentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MacroscopicBumpExperimentPanel";
            this.Size = new System.Drawing.Size(667, 573);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MacroscopicBumpsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MacroscopicBumpBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.BumpFitTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentBindingSource)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView MacroscopicBumpsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource MacroscopicBumpBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private RRLab.Utilities.DataSetHistogramControl HistogramControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox HistogramColumnComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HistogramFilterTextBox;
        private System.Windows.Forms.BindingSource ExperimentBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton ViewCellRecordingDetailsButton;
        private System.Windows.Forms.TabPage BumpFitTab;
        private MacroscopicBumpViewerControl MacroscopicBumpViewerControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genotypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn analysisDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativeLogIntensityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calciumConcentrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amplitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeIntegralDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latencyTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOfPeakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponseHalfWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowActivationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastActivationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastInactivationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slowInactivationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSinceBreakInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDataGridViewTextBoxColumn;
        private RRLab.Utilities.DataSetGroupedScatterPlotControl dataSetGroupedScatterPlotControl1;
        private System.Windows.Forms.ToolStripButton calcAvgResponseButton;
    }
}
