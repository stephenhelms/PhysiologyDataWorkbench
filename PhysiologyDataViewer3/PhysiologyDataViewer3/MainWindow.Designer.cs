namespace RRLab.PhysiologyDataWorkshop
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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.HomePanel = new RRLab.PhysiologyDataWorkshop.HomePanel();
            this.MainWindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExamineTabPage = new System.Windows.Forms.TabPage();
            this.recordingViewerPanel1 = new RRLab.PhysiologyDataWorkshop.RecordingViewerPanel();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CompareTabPage = new System.Windows.Forms.TabPage();
            this.dataSetHistogramControl1 = new RRLab.Utilities.DataSetHistogramControl();
            this.HistogramControlFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TablesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ColumnsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataSetScatterPlotControl4 = new RRLab.Utilities.DataSetScatterPlotControl();
            this.dataSetScatterPlotControl3 = new RRLab.Utilities.DataSetScatterPlotControl();
            this.dataSetScatterPlotControl1 = new RRLab.Utilities.DataSetScatterPlotControl();
            this.ScatterPlotControl = new RRLab.Utilities.DataSetScatterPlotControl();
            this.ExperimentsTabPage = new System.Windows.Forms.TabPage();
            this.ExperimentPanelHolder = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.ExperimentsComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mySQLDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDATAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripLabel();
            this.UserComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CellsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainWindowBindingSource)).BeginInit();
            this.ExamineTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            this.CompareTabPage.SuspendLayout();
            this.HistogramControlFlowLayoutPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ExperimentsTabPage.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.HomeTabPage);
            this.tabControl1.Controls.Add(this.ExamineTabPage);
            this.tabControl1.Controls.Add(this.CompareTabPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.ExperimentsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 515);
            this.tabControl1.TabIndex = 1;
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.Controls.Add(this.HomePanel);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 22);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(892, 489);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            this.HomeTabPage.UseVisualStyleBackColor = true;
            // 
            // HomePanel
            // 
            this.HomePanel.AutoScroll = true;
            this.HomePanel.DataBindings.Add(new System.Windows.Forms.Binding("Program", this.MainWindowBindingSource, "Program", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePanel.Location = new System.Drawing.Point(3, 3);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Program = null;
            this.HomePanel.Size = new System.Drawing.Size(886, 483);
            this.HomePanel.TabIndex = 0;
            // 
            // MainWindowBindingSource
            // 
            this.MainWindowBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.MainWindow);
            // 
            // ExamineTabPage
            // 
            this.ExamineTabPage.Controls.Add(this.recordingViewerPanel1);
            this.ExamineTabPage.Location = new System.Drawing.Point(4, 22);
            this.ExamineTabPage.Name = "ExamineTabPage";
            this.ExamineTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ExamineTabPage.Size = new System.Drawing.Size(892, 489);
            this.ExamineTabPage.TabIndex = 1;
            this.ExamineTabPage.Text = "Examine";
            this.ExamineTabPage.UseVisualStyleBackColor = true;
            // 
            // recordingViewerPanel1
            // 
            this.recordingViewerPanel1.CurrentCellID = 0;
            this.recordingViewerPanel1.CurrentRecordingID = ((long)(0));
            this.recordingViewerPanel1.DataBindings.Add(new System.Windows.Forms.Binding("CurrentCellID", this.ProgramBindingSource, "CurrentCellID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.recordingViewerPanel1.DataBindings.Add(new System.Windows.Forms.Binding("CurrentRecordingID", this.ProgramBindingSource, "CurrentRecordingID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.recordingViewerPanel1.DataBindings.Add(new System.Windows.Forms.Binding("Program", this.MainWindowBindingSource, "Program", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.recordingViewerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingViewerPanel1.Location = new System.Drawing.Point(3, 3);
            this.recordingViewerPanel1.Name = "recordingViewerPanel1";
            this.recordingViewerPanel1.Program = null;
            this.recordingViewerPanel1.Size = new System.Drawing.Size(886, 483);
            this.recordingViewerPanel1.TabIndex = 0;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.PhysiologyDataWorkshopProgram);
            // 
            // CompareTabPage
            // 
            this.CompareTabPage.Controls.Add(this.dataSetHistogramControl1);
            this.CompareTabPage.Controls.Add(this.HistogramControlFlowLayoutPanel);
            this.CompareTabPage.Location = new System.Drawing.Point(4, 22);
            this.CompareTabPage.Name = "CompareTabPage";
            this.CompareTabPage.Size = new System.Drawing.Size(892, 489);
            this.CompareTabPage.TabIndex = 2;
            this.CompareTabPage.Text = "Compare";
            this.CompareTabPage.UseVisualStyleBackColor = true;
            // 
            // dataSetHistogramControl1
            // 
            this.dataSetHistogramControl1.BarColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.dataSetHistogramControl1.Column = "HoldingPotential";
            this.dataSetHistogramControl1.DataBindings.Add(new System.Windows.Forms.Binding("Column", this.ProgramBindingSource, "HistogramColumn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetHistogramControl1.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetHistogramControl1.DataBindings.Add(new System.Windows.Forms.Binding("Filter", this.ProgramBindingSource, "HistogramFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetHistogramControl1.DataBindings.Add(new System.Windows.Forms.Binding("Table", this.ProgramBindingSource, "HistogramTable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetHistogramControl1.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetHistogramControl1.DataBindings.Add(new System.Windows.Forms.Binding("BarColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetHistogramControl1.DataSet = null;
            this.dataSetHistogramControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSetHistogramControl1.Filter = null;
            this.dataSetHistogramControl1.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.dataSetHistogramControl1.Location = new System.Drawing.Point(0, 0);
            this.dataSetHistogramControl1.Name = "dataSetHistogramControl1";
            this.dataSetHistogramControl1.Size = new System.Drawing.Size(892, 458);
            this.dataSetHistogramControl1.TabIndex = 0;
            this.dataSetHistogramControl1.Table = "Recordings";
            this.dataSetHistogramControl1.Title = null;
            // 
            // HistogramControlFlowLayoutPanel
            // 
            this.HistogramControlFlowLayoutPanel.Controls.Add(this.label1);
            this.HistogramControlFlowLayoutPanel.Controls.Add(this.TablesComboBox);
            this.HistogramControlFlowLayoutPanel.Controls.Add(this.label2);
            this.HistogramControlFlowLayoutPanel.Controls.Add(this.ColumnsComboBox);
            this.HistogramControlFlowLayoutPanel.Controls.Add(this.label3);
            this.HistogramControlFlowLayoutPanel.Controls.Add(this.FilterTextBox);
            this.HistogramControlFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HistogramControlFlowLayoutPanel.Location = new System.Drawing.Point(0, 458);
            this.HistogramControlFlowLayoutPanel.Name = "HistogramControlFlowLayoutPanel";
            this.HistogramControlFlowLayoutPanel.Size = new System.Drawing.Size(892, 31);
            this.HistogramControlFlowLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table";
            // 
            // TablesComboBox
            // 
            this.TablesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProgramBindingSource, "HistogramTable", true));
            this.TablesComboBox.FormattingEnabled = true;
            this.TablesComboBox.Location = new System.Drawing.Point(43, 3);
            this.TablesComboBox.Name = "TablesComboBox";
            this.TablesComboBox.Size = new System.Drawing.Size(121, 21);
            this.TablesComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "XColumn";
            // 
            // ColumnsComboBox
            // 
            this.ColumnsComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProgramBindingSource, "HistogramColumn", true));
            this.ColumnsComboBox.FormattingEnabled = true;
            this.ColumnsComboBox.Location = new System.Drawing.Point(225, 3);
            this.ColumnsComboBox.Name = "ColumnsComboBox";
            this.ColumnsComboBox.Size = new System.Drawing.Size(121, 21);
            this.ColumnsComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filter";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProgramBindingSource, "HistogramFilter", true));
            this.FilterTextBox.Location = new System.Drawing.Point(387, 3);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.FilterTextBox.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(892, 489);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Trends";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.dataSetScatterPlotControl4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataSetScatterPlotControl3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataSetScatterPlotControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ScatterPlotControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 483);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dataSetScatterPlotControl4
            // 
            this.dataSetScatterPlotControl4.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl4.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl4.DataBindings.Add(new System.Windows.Forms.Binding("PointsColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl4.DataSet = null;
            this.dataSetScatterPlotControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSetScatterPlotControl4.Filter = null;
            this.dataSetScatterPlotControl4.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.dataSetScatterPlotControl4.Location = new System.Drawing.Point(446, 244);
            this.dataSetScatterPlotControl4.Name = "dataSetScatterPlotControl4";
            this.dataSetScatterPlotControl4.PointsColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.dataSetScatterPlotControl4.Size = new System.Drawing.Size(437, 236);
            this.dataSetScatterPlotControl4.SymbolType = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.ScatterPlotSymbolType;
            this.dataSetScatterPlotControl4.TabIndex = 7;
            this.dataSetScatterPlotControl4.Table = "Cells";
            this.dataSetScatterPlotControl4.TagColumn = "CellID";
            this.dataSetScatterPlotControl4.Title = "Membrane Potential vs. Membrane Resistance";
            this.dataSetScatterPlotControl4.XColumn = "MembraneResistance";
            this.dataSetScatterPlotControl4.YColumn = "MembranePotential";
            // 
            // dataSetScatterPlotControl3
            // 
            this.dataSetScatterPlotControl3.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl3.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl3.DataBindings.Add(new System.Windows.Forms.Binding("PointsColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl3.DataSet = null;
            this.dataSetScatterPlotControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSetScatterPlotControl3.Filter = null;
            this.dataSetScatterPlotControl3.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.dataSetScatterPlotControl3.Location = new System.Drawing.Point(3, 244);
            this.dataSetScatterPlotControl3.Name = "dataSetScatterPlotControl3";
            this.dataSetScatterPlotControl3.PointsColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.dataSetScatterPlotControl3.Size = new System.Drawing.Size(437, 236);
            this.dataSetScatterPlotControl3.SymbolType = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.ScatterPlotSymbolType;
            this.dataSetScatterPlotControl3.TabIndex = 6;
            this.dataSetScatterPlotControl3.Table = "Cells";
            this.dataSetScatterPlotControl3.TagColumn = "CellID";
            this.dataSetScatterPlotControl3.Title = "Cell Capacitance vs. Seal Resistance";
            this.dataSetScatterPlotControl3.XColumn = "SealResistance";
            this.dataSetScatterPlotControl3.YColumn = "CellCapacitance";
            // 
            // dataSetScatterPlotControl1
            // 
            this.dataSetScatterPlotControl1.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl1.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl1.DataBindings.Add(new System.Windows.Forms.Binding("PointsColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataSetScatterPlotControl1.DataSet = null;
            this.dataSetScatterPlotControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSetScatterPlotControl1.Filter = null;
            this.dataSetScatterPlotControl1.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.dataSetScatterPlotControl1.Location = new System.Drawing.Point(446, 3);
            this.dataSetScatterPlotControl1.Name = "dataSetScatterPlotControl1";
            this.dataSetScatterPlotControl1.PointsColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.dataSetScatterPlotControl1.Size = new System.Drawing.Size(437, 235);
            this.dataSetScatterPlotControl1.SymbolType = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.ScatterPlotSymbolType;
            this.dataSetScatterPlotControl1.TabIndex = 4;
            this.dataSetScatterPlotControl1.Table = "Cells";
            this.dataSetScatterPlotControl1.TagColumn = "CellID";
            this.dataSetScatterPlotControl1.Title = "Membrane Resistance vs. Seal Resistance";
            this.dataSetScatterPlotControl1.XColumn = "SealResistance";
            this.dataSetScatterPlotControl1.YColumn = "MembraneResistance";
            // 
            // ScatterPlotControl
            // 
            this.ScatterPlotControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ScatterPlotControl.DataBindings.Add(new System.Windows.Forms.Binding("GraphColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "GraphBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ScatterPlotControl.DataBindings.Add(new System.Windows.Forms.Binding("PointsColor", global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default, "HistogramBarColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ScatterPlotControl.DataSet = null;
            this.ScatterPlotControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScatterPlotControl.Filter = null;
            this.ScatterPlotControl.GraphColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.GraphBackColor;
            this.ScatterPlotControl.Location = new System.Drawing.Point(3, 3);
            this.ScatterPlotControl.Name = "ScatterPlotControl";
            this.ScatterPlotControl.PointsColor = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.HistogramBarColor;
            this.ScatterPlotControl.Size = new System.Drawing.Size(437, 235);
            this.ScatterPlotControl.SymbolType = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.ScatterPlotSymbolType;
            this.ScatterPlotControl.TabIndex = 3;
            this.ScatterPlotControl.Table = "Cells";
            this.ScatterPlotControl.TagColumn = "CellID";
            this.ScatterPlotControl.Title = global::RRLab.PhysiologyDataWorkshop.Properties.Settings.Default.ScatterPlot1Title;
            this.ScatterPlotControl.XColumn = "Created";
            this.ScatterPlotControl.YColumn = "SealResistance";
            // 
            // ExperimentsTabPage
            // 
            this.ExperimentsTabPage.Controls.Add(this.ExperimentPanelHolder);
            this.ExperimentsTabPage.Controls.Add(this.flowLayoutPanel1);
            this.ExperimentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ExperimentsTabPage.Name = "ExperimentsTabPage";
            this.ExperimentsTabPage.Size = new System.Drawing.Size(892, 489);
            this.ExperimentsTabPage.TabIndex = 3;
            this.ExperimentsTabPage.Text = "Experiments";
            this.ExperimentsTabPage.UseVisualStyleBackColor = true;
            // 
            // ExperimentPanelHolder
            // 
            this.ExperimentPanelHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExperimentPanelHolder.Location = new System.Drawing.Point(0, 27);
            this.ExperimentPanelHolder.Name = "ExperimentPanelHolder";
            this.ExperimentPanelHolder.Size = new System.Drawing.Size(892, 462);
            this.ExperimentPanelHolder.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.ExperimentsComboBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(892, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "Choose an experiment:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExperimentsComboBox
            // 
            this.ExperimentsComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.ProgramBindingSource, "CurrentExperiment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ExperimentsComboBox.DisplayMember = "Name";
            this.ExperimentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExperimentsComboBox.FormattingEnabled = true;
            this.ExperimentsComboBox.Location = new System.Drawing.Point(124, 3);
            this.ExperimentsComboBox.Name = "ExperimentsComboBox";
            this.ExperimentsComboBox.Size = new System.Drawing.Size(242, 21);
            this.ExperimentsComboBox.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton1,
            this.toolStripTextBox1,
            this.UserComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mySQLDatabaseToolStripMenuItem,
            this.pDATAFileToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(83, 22);
            this.toolStripDropDownButton1.Text = "Data Source";
            // 
            // mySQLDatabaseToolStripMenuItem
            // 
            this.mySQLDatabaseToolStripMenuItem.Name = "mySQLDatabaseToolStripMenuItem";
            this.mySQLDatabaseToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.mySQLDatabaseToolStripMenuItem.Text = "MySQL Database";
            // 
            // pDATAFileToolStripMenuItem
            // 
            this.pDATAFileToolStripMenuItem.Name = "pDATAFileToolStripMenuItem";
            this.pDATAFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pDATAFileToolStripMenuItem.Text = "PDATA File";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton1.Text = "Refresh Data";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(33, 22);
            this.toolStripTextBox1.Text = "I am:";
            // 
            // UserComboBox
            // 
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(121, 25);
            this.UserComboBox.Text = "Select User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Table";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProgramBindingSource, "HistogramTable", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(43, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "XColumn";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProgramBindingSource, "HistogramColumn", true));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(225, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Filter";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProgramBindingSource, "HistogramFilter", true));
            this.textBox1.Location = new System.Drawing.Point(387, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // CellsBindingSource
            // 
            this.CellsBindingSource.DataMember = "Cells";
            this.CellsBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainWindow";
            this.Text = "Physiology Data Workshop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainWindowBindingSource)).EndInit();
            this.ExamineTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.CompareTabPage.ResumeLayout(false);
            this.HistogramControlFlowLayoutPanel.ResumeLayout(false);
            this.HistogramControlFlowLayoutPanel.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ExperimentsTabPage.ResumeLayout(false);
            this.ExperimentsTabPage.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.TabPage ExamineTabPage;
        private System.Windows.Forms.TabPage CompareTabPage;
        private System.Windows.Forms.TabPage ExperimentsTabPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private System.Windows.Forms.BindingSource CellsBindingSource;
        private RecordingViewerPanel recordingViewerPanel1;
        private System.Windows.Forms.BindingSource MainWindowBindingSource;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mySQLDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDATAFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox UserComboBox;
        private RRLab.Utilities.DataSetHistogramControl dataSetHistogramControl1;
        private System.Windows.Forms.FlowLayoutPanel HistogramControlFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TablesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ColumnsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FilterTextBox;
        private RRLab.PhysiologyDataWorkshop.HomePanel HomePanel;
        private System.Windows.Forms.TabPage tabPage1;
        private RRLab.Utilities.DataSetScatterPlotControl ScatterPlotControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RRLab.Utilities.DataSetScatterPlotControl dataSetScatterPlotControl4;
        private RRLab.Utilities.DataSetScatterPlotControl dataSetScatterPlotControl3;
        private RRLab.Utilities.DataSetScatterPlotControl dataSetScatterPlotControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ExperimentsComboBox;
        private System.Windows.Forms.Panel ExperimentPanelHolder;
    }
}

