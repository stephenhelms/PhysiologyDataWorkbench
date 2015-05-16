namespace RRLab.PhysiologyDataWorkshop.Experiments.CalciumImaging
{
    partial class CalciumImagingPanelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalciumImagingPanelControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BumpFitTab = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HistogramControl = new RRLab.Utilities.DataSetHistogramControl();
            this.ExperimentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.HistogramColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HistogramFilterTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataSetGroupedScatterPlotControl = new RRLab.Utilities.DataSetGroupedScatterPlotControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ExperimentsFilterTextBox = new System.Windows.Forms.TextBox();
            this.ExperimentsDataGridView = new System.Windows.Forms.DataGridView();
            this.TimeToSteadyState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analyzedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experimenterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genotypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calciumConcentrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDarkAdaptedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.signalRecordingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highRecordingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowRecordingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steadyStateCalciumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.steadyStateCalciumErrorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialCalciumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialCalciumErrorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peakCalciumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peakCalciumErrorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeToPeakDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSinceBreakInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highMeasurementDelayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowMeasurementDelayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExperimentDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoadDataButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateDataButton = new System.Windows.Forms.ToolStripButton();
            this.ViewCellRecordingDetailsButton = new System.Windows.Forms.ToolStripButton();
            this.ReanalyzeExptButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentBindingSource)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentDataSetBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExperimentsDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(672, 545);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.BumpFitTab);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 206);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(666, 336);
            this.tabControl1.TabIndex = 3;
            // 
            // BumpFitTab
            // 
            this.BumpFitTab.Location = new System.Drawing.Point(4, 22);
            this.BumpFitTab.Name = "BumpFitTab";
            this.BumpFitTab.Padding = new System.Windows.Forms.Padding(3);
            this.BumpFitTab.Size = new System.Drawing.Size(658, 310);
            this.BumpFitTab.TabIndex = 2;
            this.BumpFitTab.Text = "Calcium Signal";
            this.BumpFitTab.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HistogramControl);
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(658, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Histogram";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HistogramControl
            // 
            this.HistogramControl.BarColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.HistogramControl.Column = null;
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("BarColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("Column", this.ExperimentBindingSource, "HistogramColumn", true));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ExperimentBindingSource, "SteadyStateCalciumDataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("Filter", this.ExperimentBindingSource, "HistogramFilter", true));
            this.HistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HistogramControl.DataSet = null;
            this.HistogramControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistogramControl.Filter = null;
            this.HistogramControl.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.HistogramControl.Location = new System.Drawing.Point(3, 30);
            this.HistogramControl.Name = "HistogramControl";
            this.HistogramControl.Size = new System.Drawing.Size(652, 277);
            this.HistogramControl.TabIndex = 1;
            this.HistogramControl.Table = "SteadyStateCalciumExperiments";
            this.HistogramControl.Title = null;
            // 
            // ExperimentBindingSource
            // 
            this.ExperimentBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.Experiments.CalciumImaging.CalciumImagingExperiment);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.HistogramColumnComboBox);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.HistogramFilterTextBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(652, 27);
            this.flowLayoutPanel2.TabIndex = 0;
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
            this.tabPage2.Controls.Add(this.DataSetGroupedScatterPlotControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(658, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scatter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataSetGroupedScatterPlotControl
            // 
            this.DataSetGroupedScatterPlotControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ExperimentBindingSource, "SteadyStateCalciumDataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataSetGroupedScatterPlotControl.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataSetGroupedScatterPlotControl.DataSet = null;
            this.DataSetGroupedScatterPlotControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataSetGroupedScatterPlotControl.Filter = null;
            this.DataSetGroupedScatterPlotControl.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.DataSetGroupedScatterPlotControl.GroupColumn = "Genotype";
            this.DataSetGroupedScatterPlotControl.Location = new System.Drawing.Point(3, 3);
            this.DataSetGroupedScatterPlotControl.Name = "DataSetGroupedScatterPlotControl";
            this.DataSetGroupedScatterPlotControl.PointsColor = System.Drawing.Color.Crimson;
            this.DataSetGroupedScatterPlotControl.Size = new System.Drawing.Size(652, 304);
            this.DataSetGroupedScatterPlotControl.TabIndex = 1;
            this.DataSetGroupedScatterPlotControl.Table = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.CalciumExperimentGraphDataTable;
            this.DataSetGroupedScatterPlotControl.TagColumn = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.CalciumExperimentsTagColumn;
            this.DataSetGroupedScatterPlotControl.Title = null;
            this.DataSetGroupedScatterPlotControl.XColumn = "Analyzed";
            this.DataSetGroupedScatterPlotControl.YColumn = "SteadyStateCalcium";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.ExperimentsFilterTextBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(666, 26);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Results:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExperimentsFilterTextBox
            // 
            this.ExperimentsFilterTextBox.Location = new System.Drawing.Point(79, 3);
            this.ExperimentsFilterTextBox.Name = "ExperimentsFilterTextBox";
            this.ExperimentsFilterTextBox.Size = new System.Drawing.Size(369, 20);
            this.ExperimentsFilterTextBox.TabIndex = 1;
            this.ExperimentsFilterTextBox.TextChanged += new System.EventHandler(this.OnExperimentsFilterTextChanged);
            // 
            // ExperimentsDataGridView
            // 
            this.ExperimentsDataGridView.AllowUserToOrderColumns = true;
            this.ExperimentsDataGridView.AutoGenerateColumns = false;
            this.ExperimentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ExperimentsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.ExperimentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExperimentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeToSteadyState,
            this.cellIDDataGridViewTextBoxColumn,
            this.analyzedDataGridViewTextBoxColumn,
            this.recordedDataGridViewTextBoxColumn,
            this.experimenterDataGridViewTextBoxColumn,
            this.genotypeDataGridViewTextBoxColumn,
            this.calciumConcentrationDataGridViewTextBoxColumn,
            this.isDarkAdaptedDataGridViewCheckBoxColumn,
            this.signalRecordingIDDataGridViewTextBoxColumn,
            this.highRecordingIDDataGridViewTextBoxColumn,
            this.lowRecordingIDDataGridViewTextBoxColumn,
            this.steadyStateCalciumDataGridViewTextBoxColumn,
            this.steadyStateCalciumErrorDataGridViewTextBoxColumn,
            this.initialCalciumDataGridViewTextBoxColumn,
            this.initialCalciumErrorDataGridViewTextBoxColumn,
            this.peakCalciumDataGridViewTextBoxColumn,
            this.peakCalciumErrorDataGridViewTextBoxColumn,
            this.timeToPeakDataGridViewTextBoxColumn,
            this.timeSinceBreakInDataGridViewTextBoxColumn,
            this.highMeasurementDelayDataGridViewTextBoxColumn,
            this.lowMeasurementDelayDataGridViewTextBoxColumn,
            this.commentsDataGridViewTextBoxColumn});
            this.ExperimentsDataGridView.DataSource = this.ExperimentDataSetBindingSource;
            this.ExperimentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExperimentsDataGridView.Location = new System.Drawing.Point(3, 35);
            this.ExperimentsDataGridView.Name = "ExperimentsDataGridView";
            this.ExperimentsDataGridView.Size = new System.Drawing.Size(666, 165);
            this.ExperimentsDataGridView.TabIndex = 2;
            this.ExperimentsDataGridView.CurrentCellChanged += new System.EventHandler(this.OnCurrentExperimentGridViewCellChanged);
            // 
            // TimeToSteadyState
            // 
            this.TimeToSteadyState.DataPropertyName = "TimeToSteadyState";
            this.TimeToSteadyState.HeaderText = "TimeToSteadyState";
            this.TimeToSteadyState.Name = "TimeToSteadyState";
            this.TimeToSteadyState.ReadOnly = true;
            this.TimeToSteadyState.Width = 126;
            // 
            // cellIDDataGridViewTextBoxColumn
            // 
            this.cellIDDataGridViewTextBoxColumn.DataPropertyName = "CellID";
            this.cellIDDataGridViewTextBoxColumn.HeaderText = "CellID";
            this.cellIDDataGridViewTextBoxColumn.Name = "cellIDDataGridViewTextBoxColumn";
            this.cellIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // analyzedDataGridViewTextBoxColumn
            // 
            this.analyzedDataGridViewTextBoxColumn.DataPropertyName = "Analyzed";
            this.analyzedDataGridViewTextBoxColumn.HeaderText = "Analyzed";
            this.analyzedDataGridViewTextBoxColumn.Name = "analyzedDataGridViewTextBoxColumn";
            this.analyzedDataGridViewTextBoxColumn.Width = 75;
            // 
            // recordedDataGridViewTextBoxColumn
            // 
            this.recordedDataGridViewTextBoxColumn.DataPropertyName = "Recorded";
            this.recordedDataGridViewTextBoxColumn.HeaderText = "Recorded";
            this.recordedDataGridViewTextBoxColumn.Name = "recordedDataGridViewTextBoxColumn";
            this.recordedDataGridViewTextBoxColumn.ReadOnly = true;
            this.recordedDataGridViewTextBoxColumn.Width = 79;
            // 
            // experimenterDataGridViewTextBoxColumn
            // 
            this.experimenterDataGridViewTextBoxColumn.DataPropertyName = "Experimenter";
            this.experimenterDataGridViewTextBoxColumn.HeaderText = "Experimenter";
            this.experimenterDataGridViewTextBoxColumn.Name = "experimenterDataGridViewTextBoxColumn";
            this.experimenterDataGridViewTextBoxColumn.ReadOnly = true;
            this.experimenterDataGridViewTextBoxColumn.Width = 93;
            // 
            // genotypeDataGridViewTextBoxColumn
            // 
            this.genotypeDataGridViewTextBoxColumn.DataPropertyName = "Genotype";
            this.genotypeDataGridViewTextBoxColumn.HeaderText = "Genotype";
            this.genotypeDataGridViewTextBoxColumn.Name = "genotypeDataGridViewTextBoxColumn";
            this.genotypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.genotypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // calciumConcentrationDataGridViewTextBoxColumn
            // 
            this.calciumConcentrationDataGridViewTextBoxColumn.DataPropertyName = "CalciumConcentration";
            this.calciumConcentrationDataGridViewTextBoxColumn.HeaderText = "CalciumConcentration";
            this.calciumConcentrationDataGridViewTextBoxColumn.Name = "calciumConcentrationDataGridViewTextBoxColumn";
            this.calciumConcentrationDataGridViewTextBoxColumn.Width = 135;
            // 
            // isDarkAdaptedDataGridViewCheckBoxColumn
            // 
            this.isDarkAdaptedDataGridViewCheckBoxColumn.DataPropertyName = "IsDarkAdapted";
            this.isDarkAdaptedDataGridViewCheckBoxColumn.HeaderText = "IsDarkAdapted";
            this.isDarkAdaptedDataGridViewCheckBoxColumn.Name = "isDarkAdaptedDataGridViewCheckBoxColumn";
            this.isDarkAdaptedDataGridViewCheckBoxColumn.Width = 84;
            // 
            // signalRecordingIDDataGridViewTextBoxColumn
            // 
            this.signalRecordingIDDataGridViewTextBoxColumn.DataPropertyName = "SignalRecordingID";
            this.signalRecordingIDDataGridViewTextBoxColumn.HeaderText = "SignalRecordingID";
            this.signalRecordingIDDataGridViewTextBoxColumn.Name = "signalRecordingIDDataGridViewTextBoxColumn";
            this.signalRecordingIDDataGridViewTextBoxColumn.Width = 121;
            // 
            // highRecordingIDDataGridViewTextBoxColumn
            // 
            this.highRecordingIDDataGridViewTextBoxColumn.DataPropertyName = "HighRecordingID";
            this.highRecordingIDDataGridViewTextBoxColumn.HeaderText = "HighRecordingID";
            this.highRecordingIDDataGridViewTextBoxColumn.Name = "highRecordingIDDataGridViewTextBoxColumn";
            this.highRecordingIDDataGridViewTextBoxColumn.Width = 114;
            // 
            // lowRecordingIDDataGridViewTextBoxColumn
            // 
            this.lowRecordingIDDataGridViewTextBoxColumn.DataPropertyName = "LowRecordingID";
            this.lowRecordingIDDataGridViewTextBoxColumn.HeaderText = "LowRecordingID";
            this.lowRecordingIDDataGridViewTextBoxColumn.Name = "lowRecordingIDDataGridViewTextBoxColumn";
            this.lowRecordingIDDataGridViewTextBoxColumn.Width = 112;
            // 
            // steadyStateCalciumDataGridViewTextBoxColumn
            // 
            this.steadyStateCalciumDataGridViewTextBoxColumn.DataPropertyName = "SteadyStateCalcium";
            this.steadyStateCalciumDataGridViewTextBoxColumn.HeaderText = "SteadyStateCalcium";
            this.steadyStateCalciumDataGridViewTextBoxColumn.Name = "steadyStateCalciumDataGridViewTextBoxColumn";
            this.steadyStateCalciumDataGridViewTextBoxColumn.Width = 127;
            // 
            // steadyStateCalciumErrorDataGridViewTextBoxColumn
            // 
            this.steadyStateCalciumErrorDataGridViewTextBoxColumn.DataPropertyName = "SteadyStateCalciumError";
            this.steadyStateCalciumErrorDataGridViewTextBoxColumn.HeaderText = "SteadyStateCalciumError";
            this.steadyStateCalciumErrorDataGridViewTextBoxColumn.Name = "steadyStateCalciumErrorDataGridViewTextBoxColumn";
            this.steadyStateCalciumErrorDataGridViewTextBoxColumn.Width = 149;
            // 
            // initialCalciumDataGridViewTextBoxColumn
            // 
            this.initialCalciumDataGridViewTextBoxColumn.DataPropertyName = "InitialCalcium";
            this.initialCalciumDataGridViewTextBoxColumn.HeaderText = "InitialCalcium";
            this.initialCalciumDataGridViewTextBoxColumn.Name = "initialCalciumDataGridViewTextBoxColumn";
            this.initialCalciumDataGridViewTextBoxColumn.Width = 93;
            // 
            // initialCalciumErrorDataGridViewTextBoxColumn
            // 
            this.initialCalciumErrorDataGridViewTextBoxColumn.DataPropertyName = "InitialCalciumError";
            this.initialCalciumErrorDataGridViewTextBoxColumn.HeaderText = "InitialCalciumError";
            this.initialCalciumErrorDataGridViewTextBoxColumn.Name = "initialCalciumErrorDataGridViewTextBoxColumn";
            this.initialCalciumErrorDataGridViewTextBoxColumn.Width = 115;
            // 
            // peakCalciumDataGridViewTextBoxColumn
            // 
            this.peakCalciumDataGridViewTextBoxColumn.DataPropertyName = "PeakCalcium";
            this.peakCalciumDataGridViewTextBoxColumn.HeaderText = "PeakCalcium";
            this.peakCalciumDataGridViewTextBoxColumn.Name = "peakCalciumDataGridViewTextBoxColumn";
            this.peakCalciumDataGridViewTextBoxColumn.Width = 94;
            // 
            // peakCalciumErrorDataGridViewTextBoxColumn
            // 
            this.peakCalciumErrorDataGridViewTextBoxColumn.DataPropertyName = "PeakCalciumError";
            this.peakCalciumErrorDataGridViewTextBoxColumn.HeaderText = "PeakCalciumError";
            this.peakCalciumErrorDataGridViewTextBoxColumn.Name = "peakCalciumErrorDataGridViewTextBoxColumn";
            this.peakCalciumErrorDataGridViewTextBoxColumn.Width = 116;
            // 
            // timeToPeakDataGridViewTextBoxColumn
            // 
            this.timeToPeakDataGridViewTextBoxColumn.DataPropertyName = "TimeToPeak";
            this.timeToPeakDataGridViewTextBoxColumn.HeaderText = "TimeToPeak";
            this.timeToPeakDataGridViewTextBoxColumn.Name = "timeToPeakDataGridViewTextBoxColumn";
            this.timeToPeakDataGridViewTextBoxColumn.Width = 93;
            // 
            // timeSinceBreakInDataGridViewTextBoxColumn
            // 
            this.timeSinceBreakInDataGridViewTextBoxColumn.DataPropertyName = "TimeSinceBreakIn";
            this.timeSinceBreakInDataGridViewTextBoxColumn.HeaderText = "TimeSinceBreakIn";
            this.timeSinceBreakInDataGridViewTextBoxColumn.Name = "timeSinceBreakInDataGridViewTextBoxColumn";
            this.timeSinceBreakInDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeSinceBreakInDataGridViewTextBoxColumn.Width = 119;
            // 
            // highMeasurementDelayDataGridViewTextBoxColumn
            // 
            this.highMeasurementDelayDataGridViewTextBoxColumn.DataPropertyName = "HighMeasurementDelay";
            this.highMeasurementDelayDataGridViewTextBoxColumn.HeaderText = "HighMeasurementDelay";
            this.highMeasurementDelayDataGridViewTextBoxColumn.Name = "highMeasurementDelayDataGridViewTextBoxColumn";
            this.highMeasurementDelayDataGridViewTextBoxColumn.ReadOnly = true;
            this.highMeasurementDelayDataGridViewTextBoxColumn.Width = 145;
            // 
            // lowMeasurementDelayDataGridViewTextBoxColumn
            // 
            this.lowMeasurementDelayDataGridViewTextBoxColumn.DataPropertyName = "LowMeasurementDelay";
            this.lowMeasurementDelayDataGridViewTextBoxColumn.HeaderText = "LowMeasurementDelay";
            this.lowMeasurementDelayDataGridViewTextBoxColumn.Name = "lowMeasurementDelayDataGridViewTextBoxColumn";
            this.lowMeasurementDelayDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowMeasurementDelayDataGridViewTextBoxColumn.Width = 143;
            // 
            // commentsDataGridViewTextBoxColumn
            // 
            this.commentsDataGridViewTextBoxColumn.DataPropertyName = "Comments";
            this.commentsDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.commentsDataGridViewTextBoxColumn.Name = "commentsDataGridViewTextBoxColumn";
            this.commentsDataGridViewTextBoxColumn.Width = 81;
            // 
            // ExperimentDataSetBindingSource
            // 
            this.ExperimentDataSetBindingSource.DataMember = "SteadyStateCalciumExperiments";
            this.ExperimentDataSetBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.Experiments.CalciumImaging.SteadyStateCalciumDataSet);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadDataButton,
            this.UpdateDataButton,
            this.ViewCellRecordingDetailsButton,
            this.ReanalyzeExptButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(672, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadDataButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadDataButton.Image")));
            this.LoadDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(144, 22);
            this.LoadDataButton.Text = "Load Data from Database";
            this.LoadDataButton.Click += new System.EventHandler(this.OnLoadDataClicked);
            // 
            // UpdateDataButton
            // 
            this.UpdateDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UpdateDataButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateDataButton.Image")));
            this.UpdateDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateDataButton.Name = "UpdateDataButton";
            this.UpdateDataButton.Size = new System.Drawing.Size(141, 22);
            this.UpdateDataButton.Text = "Update Data to Database";
            this.UpdateDataButton.Click += new System.EventHandler(this.OnUpdateButtonClicked);
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
            // ReanalyzeExptButton
            // 
            this.ReanalyzeExptButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReanalyzeExptButton.Image = ((System.Drawing.Image)(resources.GetObject("ReanalyzeExptButton.Image")));
            this.ReanalyzeExptButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReanalyzeExptButton.Name = "ReanalyzeExptButton";
            this.ReanalyzeExptButton.Size = new System.Drawing.Size(88, 22);
            this.ReanalyzeExptButton.Text = "Reanalyze Expt";
            this.ReanalyzeExptButton.Click += new System.EventHandler(this.ReanalyzeExptButton_Click);
            // 
            // CalciumImagingPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CalciumImagingPanelControl";
            this.Size = new System.Drawing.Size(672, 570);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentBindingSource)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentDataSetBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExperimentsFilterTextBox;
        private System.Windows.Forms.ToolStripButton LoadDataButton;
        private System.Windows.Forms.ToolStripButton UpdateDataButton;
        private System.Windows.Forms.DataGridView ExperimentsDataGridView;
        private System.Windows.Forms.BindingSource ExperimentDataSetBindingSource;
        private System.Windows.Forms.BindingSource ExperimentBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BumpFitTab;
        private System.Windows.Forms.TabPage tabPage1;
        private RRLab.Utilities.DataSetHistogramControl HistogramControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox HistogramColumnComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HistogramFilterTextBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton ViewCellRecordingDetailsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn processedRecordingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn analyzedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn experimenterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genotypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calciumConcentrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDarkAdaptedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signalRecordingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highRecordingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowRecordingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn steadyStateCalciumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn steadyStateCalciumErrorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialCalciumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialCalciumErrorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn peakCalciumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn peakCalciumErrorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeToPeakDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeToSteadyState;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSinceBreakInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highMeasurementDelayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowMeasurementDelayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDataGridViewTextBoxColumn;
        private RRLab.Utilities.DataSetGroupedScatterPlotControl DataSetGroupedScatterPlotControl;
        private System.Windows.Forms.ToolStripButton ReanalyzeExptButton;
    }
}
