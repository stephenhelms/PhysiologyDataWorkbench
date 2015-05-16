namespace RRLab.PhysiologyDataWorkshop
{
    partial class HomePanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SummaryGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RecordingsRecordedHistogramControl = new RRLab.Utilities.DataSetHistogramControl();
            this.CellRecordedHistogramGraph = new RRLab.Utilities.DataSetHistogramControl();
            this.RecentDataGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.DateRangeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WhoseDataComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CellsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CellsDataGridView = new System.Windows.Forms.DataGridView();
            this.cellIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flyStockIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pipetteResistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sealResistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellCapacitanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesResistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membraneResistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membranePotentialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breakInTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roughAppearanceRatingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthAppearanceRatingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeAppearanceRatingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appearanceScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfRecordingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.SummaryGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.RecentDataGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SummaryGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RecentDataGroupBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 495);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SummaryGroupBox
            // 
            this.SummaryGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.SummaryGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryGroupBox.Location = new System.Drawing.Point(3, 248);
            this.SummaryGroupBox.Name = "SummaryGroupBox";
            this.SummaryGroupBox.Size = new System.Drawing.Size(715, 244);
            this.SummaryGroupBox.TabIndex = 3;
            this.SummaryGroupBox.TabStop = false;
            this.SummaryGroupBox.Text = "Summary";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.RecordingsRecordedHistogramControl, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.CellRecordedHistogramGraph, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(709, 225);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // RecordingsRecordedHistogramControl
            // 
            this.RecordingsRecordedHistogramControl.BarColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.RecordingsRecordedHistogramControl.Column = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MainPanelRecordingsRecordedHistogramDateColumn;
            this.RecordingsRecordedHistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingsRecordedHistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("BarColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingsRecordedHistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingsRecordedHistogramControl.DataBindings.Add(new System.Windows.Forms.Binding("Column", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "MainPanelRecordingsRecordedHistogramDateColumn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingsRecordedHistogramControl.DataSet = null;
            this.RecordingsRecordedHistogramControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingsRecordedHistogramControl.Filter = null;
            this.RecordingsRecordedHistogramControl.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.RecordingsRecordedHistogramControl.Location = new System.Drawing.Point(357, 3);
            this.RecordingsRecordedHistogramControl.Name = "RecordingsRecordedHistogramControl";
            this.RecordingsRecordedHistogramControl.Size = new System.Drawing.Size(349, 219);
            this.RecordingsRecordedHistogramControl.TabIndex = 1;
            this.RecordingsRecordedHistogramControl.Table = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MainPanelRecordingsRecordedHistogramTable;
            this.RecordingsRecordedHistogramControl.Title = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MainPanelRecordingsRecordedHistogramTitle;
            // 
            // CellRecordedHistogramGraph
            // 
            this.CellRecordedHistogramGraph.BarColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.CellRecordedHistogramGraph.Column = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MainPanelCellRecordedHistogramColumn;
            this.CellRecordedHistogramGraph.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CellRecordedHistogramGraph.DataBindings.Add(new System.Windows.Forms.Binding("BarColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CellRecordedHistogramGraph.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CellRecordedHistogramGraph.DataSet = null;
            this.CellRecordedHistogramGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellRecordedHistogramGraph.Filter = null;
            this.CellRecordedHistogramGraph.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.CellRecordedHistogramGraph.Location = new System.Drawing.Point(3, 3);
            this.CellRecordedHistogramGraph.Name = "CellRecordedHistogramGraph";
            this.CellRecordedHistogramGraph.Size = new System.Drawing.Size(348, 219);
            this.CellRecordedHistogramGraph.TabIndex = 0;
            this.CellRecordedHistogramGraph.Table = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MainPanelCellRecordedHistogramTable;
            this.CellRecordedHistogramGraph.Title = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.MainPanelCellRecordedHistogramTitle;
            // 
            // RecentDataGroupBox
            // 
            this.RecentDataGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.RecentDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecentDataGroupBox.Location = new System.Drawing.Point(3, 3);
            this.RecentDataGroupBox.Name = "RecentDataGroupBox";
            this.RecentDataGroupBox.Size = new System.Drawing.Size(715, 239);
            this.RecentDataGroupBox.TabIndex = 2;
            this.RecentDataGroupBox.TabStop = false;
            this.RecentDataGroupBox.Text = "Recently Collected Data";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.CellsDataGridView, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(709, 220);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.DateRangeComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.WhoseDataComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(703, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show me data from";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DateRangeComboBox
            // 
            this.DateRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DateRangeComboBox.FormattingEnabled = true;
            this.DateRangeComboBox.Items.AddRange(new object[] {
            "Today",
            "This Week",
            "This Month",
            "Anytime"});
            this.DateRangeComboBox.Location = new System.Drawing.Point(107, 3);
            this.DateRangeComboBox.Name = "DateRangeComboBox";
            this.DateRangeComboBox.Size = new System.Drawing.Size(90, 21);
            this.DateRangeComboBox.TabIndex = 2;
            this.DateRangeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnDatesToShowSelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(203, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "collected by";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WhoseDataComboBox
            // 
            this.WhoseDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WhoseDataComboBox.FormattingEnabled = true;
            this.WhoseDataComboBox.Items.AddRange(new object[] {
            "Me",
            "Everyone"});
            this.WhoseDataComboBox.Location = new System.Drawing.Point(273, 3);
            this.WhoseDataComboBox.Name = "WhoseDataComboBox";
            this.WhoseDataComboBox.Size = new System.Drawing.Size(90, 21);
            this.WhoseDataComboBox.TabIndex = 4;
            this.WhoseDataComboBox.SelectedIndexChanged += new System.EventHandler(this.OnWhoseDataSelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(369, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(703, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Recently collected data:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(703, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "(Select a row to make it the current cell.)";
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.PhysiologyDataWorkshopProgram);
            // 
            // CellsBindingSource
            // 
            this.CellsBindingSource.AllowNew = false;
            this.CellsBindingSource.DataMember = "Cells";
            this.CellsBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet);
            // 
            // CellsDataGridView
            // 
            this.CellsDataGridView.AutoGenerateColumns = false;
            this.CellsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.CellsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CellsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellIDDataGridViewTextBoxColumn,
            this.flyStockIDDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.createdDataGridViewTextBoxColumn,
            this.pipetteResistanceDataGridViewTextBoxColumn,
            this.sealResistanceDataGridViewTextBoxColumn,
            this.cellCapacitanceDataGridViewTextBoxColumn,
            this.seriesResistanceDataGridViewTextBoxColumn,
            this.membraneResistanceDataGridViewTextBoxColumn,
            this.membranePotentialDataGridViewTextBoxColumn,
            this.breakInTimeDataGridViewTextBoxColumn,
            this.roughAppearanceRatingDataGridViewTextBoxColumn,
            this.lengthAppearanceRatingDataGridViewTextBoxColumn,
            this.shapeAppearanceRatingDataGridViewTextBoxColumn,
            this.appearanceScoreDataGridViewTextBoxColumn,
            this.numberOfRecordingsDataGridViewTextBoxColumn});
            this.CellsDataGridView.DataSource = this.CellsBindingSource;
            this.CellsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellsDataGridView.Location = new System.Drawing.Point(3, 62);
            this.CellsDataGridView.Name = "CellsDataGridView";
            this.CellsDataGridView.Size = new System.Drawing.Size(703, 155);
            this.CellsDataGridView.TabIndex = 4;
            this.CellsDataGridView.CurrentCellChanged += new System.EventHandler(this.OnCurrentCellChanged);
            // 
            // cellIDDataGridViewTextBoxColumn
            // 
            this.cellIDDataGridViewTextBoxColumn.DataPropertyName = "CellID";
            this.cellIDDataGridViewTextBoxColumn.HeaderText = "CellID";
            this.cellIDDataGridViewTextBoxColumn.Name = "cellIDDataGridViewTextBoxColumn";
            this.cellIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // flyStockIDDataGridViewTextBoxColumn
            // 
            this.flyStockIDDataGridViewTextBoxColumn.DataPropertyName = "FlyStockID";
            this.flyStockIDDataGridViewTextBoxColumn.HeaderText = "FlyStockID";
            this.flyStockIDDataGridViewTextBoxColumn.Name = "flyStockIDDataGridViewTextBoxColumn";
            this.flyStockIDDataGridViewTextBoxColumn.Width = 84;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // createdDataGridViewTextBoxColumn
            // 
            this.createdDataGridViewTextBoxColumn.DataPropertyName = "Created";
            this.createdDataGridViewTextBoxColumn.HeaderText = "Created";
            this.createdDataGridViewTextBoxColumn.Name = "createdDataGridViewTextBoxColumn";
            this.createdDataGridViewTextBoxColumn.Width = 69;
            // 
            // pipetteResistanceDataGridViewTextBoxColumn
            // 
            this.pipetteResistanceDataGridViewTextBoxColumn.DataPropertyName = "PipetteResistance";
            this.pipetteResistanceDataGridViewTextBoxColumn.HeaderText = "PipetteResistance";
            this.pipetteResistanceDataGridViewTextBoxColumn.Name = "pipetteResistanceDataGridViewTextBoxColumn";
            this.pipetteResistanceDataGridViewTextBoxColumn.Width = 118;
            // 
            // sealResistanceDataGridViewTextBoxColumn
            // 
            this.sealResistanceDataGridViewTextBoxColumn.DataPropertyName = "SealResistance";
            this.sealResistanceDataGridViewTextBoxColumn.HeaderText = "SealResistance";
            this.sealResistanceDataGridViewTextBoxColumn.Name = "sealResistanceDataGridViewTextBoxColumn";
            this.sealResistanceDataGridViewTextBoxColumn.Width = 106;
            // 
            // cellCapacitanceDataGridViewTextBoxColumn
            // 
            this.cellCapacitanceDataGridViewTextBoxColumn.DataPropertyName = "CellCapacitance";
            this.cellCapacitanceDataGridViewTextBoxColumn.HeaderText = "CellCapacitance";
            this.cellCapacitanceDataGridViewTextBoxColumn.Name = "cellCapacitanceDataGridViewTextBoxColumn";
            this.cellCapacitanceDataGridViewTextBoxColumn.Width = 109;
            // 
            // seriesResistanceDataGridViewTextBoxColumn
            // 
            this.seriesResistanceDataGridViewTextBoxColumn.DataPropertyName = "SeriesResistance";
            this.seriesResistanceDataGridViewTextBoxColumn.HeaderText = "SeriesResistance";
            this.seriesResistanceDataGridViewTextBoxColumn.Name = "seriesResistanceDataGridViewTextBoxColumn";
            this.seriesResistanceDataGridViewTextBoxColumn.Width = 114;
            // 
            // membraneResistanceDataGridViewTextBoxColumn
            // 
            this.membraneResistanceDataGridViewTextBoxColumn.DataPropertyName = "MembraneResistance";
            this.membraneResistanceDataGridViewTextBoxColumn.HeaderText = "MembraneResistance";
            this.membraneResistanceDataGridViewTextBoxColumn.Name = "membraneResistanceDataGridViewTextBoxColumn";
            this.membraneResistanceDataGridViewTextBoxColumn.Width = 135;
            // 
            // membranePotentialDataGridViewTextBoxColumn
            // 
            this.membranePotentialDataGridViewTextBoxColumn.DataPropertyName = "MembranePotential";
            this.membranePotentialDataGridViewTextBoxColumn.HeaderText = "MembranePotential";
            this.membranePotentialDataGridViewTextBoxColumn.Name = "membranePotentialDataGridViewTextBoxColumn";
            this.membranePotentialDataGridViewTextBoxColumn.Width = 123;
            // 
            // breakInTimeDataGridViewTextBoxColumn
            // 
            this.breakInTimeDataGridViewTextBoxColumn.DataPropertyName = "BreakInTime";
            this.breakInTimeDataGridViewTextBoxColumn.HeaderText = "BreakInTime";
            this.breakInTimeDataGridViewTextBoxColumn.Name = "breakInTimeDataGridViewTextBoxColumn";
            this.breakInTimeDataGridViewTextBoxColumn.Width = 92;
            // 
            // roughAppearanceRatingDataGridViewTextBoxColumn
            // 
            this.roughAppearanceRatingDataGridViewTextBoxColumn.DataPropertyName = "RoughAppearanceRating";
            this.roughAppearanceRatingDataGridViewTextBoxColumn.HeaderText = "RoughAppearanceRating";
            this.roughAppearanceRatingDataGridViewTextBoxColumn.Name = "roughAppearanceRatingDataGridViewTextBoxColumn";
            this.roughAppearanceRatingDataGridViewTextBoxColumn.Width = 153;
            // 
            // lengthAppearanceRatingDataGridViewTextBoxColumn
            // 
            this.lengthAppearanceRatingDataGridViewTextBoxColumn.DataPropertyName = "LengthAppearanceRating";
            this.lengthAppearanceRatingDataGridViewTextBoxColumn.HeaderText = "LengthAppearanceRating";
            this.lengthAppearanceRatingDataGridViewTextBoxColumn.Name = "lengthAppearanceRatingDataGridViewTextBoxColumn";
            this.lengthAppearanceRatingDataGridViewTextBoxColumn.Width = 154;
            // 
            // shapeAppearanceRatingDataGridViewTextBoxColumn
            // 
            this.shapeAppearanceRatingDataGridViewTextBoxColumn.DataPropertyName = "ShapeAppearanceRating";
            this.shapeAppearanceRatingDataGridViewTextBoxColumn.HeaderText = "ShapeAppearanceRating";
            this.shapeAppearanceRatingDataGridViewTextBoxColumn.Name = "shapeAppearanceRatingDataGridViewTextBoxColumn";
            this.shapeAppearanceRatingDataGridViewTextBoxColumn.Width = 152;
            // 
            // appearanceScoreDataGridViewTextBoxColumn
            // 
            this.appearanceScoreDataGridViewTextBoxColumn.DataPropertyName = "AppearanceScore";
            this.appearanceScoreDataGridViewTextBoxColumn.HeaderText = "AppearanceScore";
            this.appearanceScoreDataGridViewTextBoxColumn.Name = "appearanceScoreDataGridViewTextBoxColumn";
            this.appearanceScoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.appearanceScoreDataGridViewTextBoxColumn.Width = 118;
            // 
            // numberOfRecordingsDataGridViewTextBoxColumn
            // 
            this.numberOfRecordingsDataGridViewTextBoxColumn.DataPropertyName = "NumberOfRecordings";
            this.numberOfRecordingsDataGridViewTextBoxColumn.HeaderText = "NumberOfRecordings";
            this.numberOfRecordingsDataGridViewTextBoxColumn.Name = "numberOfRecordingsDataGridViewTextBoxColumn";
            this.numberOfRecordingsDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfRecordingsDataGridViewTextBoxColumn.Width = 134;
            // 
            // HomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HomePanel";
            this.Size = new System.Drawing.Size(721, 495);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.SummaryGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.RecentDataGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox SummaryGroupBox;
        private System.Windows.Forms.GroupBox RecentDataGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DateRangeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WhoseDataComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource CellsBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private RRLab.Utilities.DataSetHistogramControl CellRecordedHistogramGraph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private RRLab.Utilities.DataSetHistogramControl RecordingsRecordedHistogramControl;
        private System.Windows.Forms.DataGridView CellsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flyStockIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pipetteResistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sealResistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellCapacitanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesResistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn membraneResistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn membranePotentialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn breakInTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roughAppearanceRatingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthAppearanceRatingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shapeAppearanceRatingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appearanceScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfRecordingsDataGridViewTextBoxColumn;
    }
}
