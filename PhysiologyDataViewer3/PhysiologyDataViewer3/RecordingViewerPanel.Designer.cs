namespace RRLab.PhysiologyDataWorkshop
{
    partial class RecordingViewerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordingViewerPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CellAnnotationsGroupBox = new System.Windows.Forms.GroupBox();
            this.CellAnnotationsDataGridView = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enteredDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKCellsCellsAnnotationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CellsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingSubtablesViewer = new RRLab.PhysiologyData.GUI.RecordingSubTablesViewer();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingAnnotationsGroupBox = new System.Windows.Forms.GroupBox();
            this.RecordingAnnotationsDataGridView = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enteredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKRecordingsRecordingsAnnotationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cellAndRecordingInfoPanel1 = new RRLab.PhysiologyData.GUI.CellAndRecordingInfoPanel();
            this.recordingDataGraphControl1 = new RRLab.PhysiologyData.GUI.RecordingDataGraphControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.recordingsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.RecordingIndexToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportMatlabToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ActionsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.recordingIDLabel = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.CellAnnotationsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellAnnotationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKCellsCellsAnnotationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            this.RecordingAnnotationsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingAnnotationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKRecordingsRecordingsAnnotationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingsBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.CellAnnotationsGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RecordingSubtablesViewer, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RecordingAnnotationsGroupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(241, 532);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CellAnnotationsGroupBox
            // 
            this.CellAnnotationsGroupBox.AutoSize = true;
            this.CellAnnotationsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CellAnnotationsGroupBox.Controls.Add(this.CellAnnotationsDataGridView);
            this.CellAnnotationsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellAnnotationsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.CellAnnotationsGroupBox.Name = "CellAnnotationsGroupBox";
            this.CellAnnotationsGroupBox.Size = new System.Drawing.Size(235, 171);
            this.CellAnnotationsGroupBox.TabIndex = 2;
            this.CellAnnotationsGroupBox.TabStop = false;
            this.CellAnnotationsGroupBox.Text = "Cell Annotations";
            // 
            // CellAnnotationsDataGridView
            // 
            this.CellAnnotationsDataGridView.AutoGenerateColumns = false;
            this.CellAnnotationsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.CellAnnotationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CellAnnotationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.enteredDataGridViewTextBoxColumn1,
            this.textDataGridViewTextBoxColumn1});
            this.CellAnnotationsDataGridView.DataSource = this.fKCellsCellsAnnotationsBindingSource;
            this.CellAnnotationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellAnnotationsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.CellAnnotationsDataGridView.Name = "CellAnnotationsDataGridView";
            this.CellAnnotationsDataGridView.Size = new System.Drawing.Size(229, 152);
            this.CellAnnotationsDataGridView.TabIndex = 0;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // enteredDataGridViewTextBoxColumn1
            // 
            this.enteredDataGridViewTextBoxColumn1.DataPropertyName = "Entered";
            this.enteredDataGridViewTextBoxColumn1.HeaderText = "Entered";
            this.enteredDataGridViewTextBoxColumn1.Name = "enteredDataGridViewTextBoxColumn1";
            this.enteredDataGridViewTextBoxColumn1.Width = 69;
            // 
            // textDataGridViewTextBoxColumn1
            // 
            this.textDataGridViewTextBoxColumn1.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn1.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn1.Name = "textDataGridViewTextBoxColumn1";
            this.textDataGridViewTextBoxColumn1.Width = 53;
            // 
            // fKCellsCellsAnnotationsBindingSource
            // 
            this.fKCellsCellsAnnotationsBindingSource.DataMember = "FK_Cells_Cells_Annotations";
            this.fKCellsCellsAnnotationsBindingSource.DataSource = this.CellsBindingSource;
            // 
            // CellsBindingSource
            // 
            this.CellsBindingSource.DataMember = "Cells";
            this.CellsBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet);
            // 
            // RecordingSubtablesViewer
            // 
            this.RecordingSubtablesViewer.CurrentRecordingID = ((long)(1));
            this.RecordingSubtablesViewer.DataBindings.Add(new System.Windows.Forms.Binding("CurrentRecordingID", this.ProgramBindingSource, "CurrentRecordingID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSubtablesViewer.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingSubtablesViewer.DataSet = null;
            this.RecordingSubtablesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingSubtablesViewer.Location = new System.Drawing.Point(3, 357);
            this.RecordingSubtablesViewer.Name = "RecordingSubtablesViewer";
            this.RecordingSubtablesViewer.Size = new System.Drawing.Size(235, 172);
            this.RecordingSubtablesViewer.TabIndex = 0;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyDataWorkshop.PhysiologyDataWorkshopProgram);
            // 
            // RecordingAnnotationsGroupBox
            // 
            this.RecordingAnnotationsGroupBox.AutoSize = true;
            this.RecordingAnnotationsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RecordingAnnotationsGroupBox.Controls.Add(this.RecordingAnnotationsDataGridView);
            this.RecordingAnnotationsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingAnnotationsGroupBox.Location = new System.Drawing.Point(3, 180);
            this.RecordingAnnotationsGroupBox.Name = "RecordingAnnotationsGroupBox";
            this.RecordingAnnotationsGroupBox.Size = new System.Drawing.Size(235, 171);
            this.RecordingAnnotationsGroupBox.TabIndex = 1;
            this.RecordingAnnotationsGroupBox.TabStop = false;
            this.RecordingAnnotationsGroupBox.Text = "Recording Annotations";
            // 
            // RecordingAnnotationsDataGridView
            // 
            this.RecordingAnnotationsDataGridView.AutoGenerateColumns = false;
            this.RecordingAnnotationsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.RecordingAnnotationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordingAnnotationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn1,
            this.enteredDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn});
            this.RecordingAnnotationsDataGridView.DataSource = this.fKRecordingsRecordingsAnnotationsBindingSource;
            this.RecordingAnnotationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingAnnotationsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.RecordingAnnotationsDataGridView.Name = "RecordingAnnotationsDataGridView";
            this.RecordingAnnotationsDataGridView.Size = new System.Drawing.Size(229, 152);
            this.RecordingAnnotationsDataGridView.TabIndex = 0;
            // 
            // userIDDataGridViewTextBoxColumn1
            // 
            this.userIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.userIDDataGridViewTextBoxColumn1.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn1.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn1.Name = "userIDDataGridViewTextBoxColumn1";
            this.userIDDataGridViewTextBoxColumn1.Width = 65;
            // 
            // enteredDataGridViewTextBoxColumn
            // 
            this.enteredDataGridViewTextBoxColumn.DataPropertyName = "Entered";
            this.enteredDataGridViewTextBoxColumn.HeaderText = "Entered";
            this.enteredDataGridViewTextBoxColumn.Name = "enteredDataGridViewTextBoxColumn";
            this.enteredDataGridViewTextBoxColumn.Width = 69;
            // 
            // textDataGridViewTextBoxColumn
            // 
            this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
            this.textDataGridViewTextBoxColumn.HeaderText = "Text";
            this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
            this.textDataGridViewTextBoxColumn.Width = 53;
            // 
            // fKRecordingsRecordingsAnnotationsBindingSource
            // 
            this.fKRecordingsRecordingsAnnotationsBindingSource.DataMember = "FK_Recordings_Recordings_Annotations";
            this.fKRecordingsRecordingsAnnotationsBindingSource.DataSource = this.RecordingsBindingSource;
            // 
            // RecordingsBindingSource
            // 
            this.RecordingsBindingSource.DataMember = "FK_Cells_Recordings";
            this.RecordingsBindingSource.DataSource = this.CellsBindingSource;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cellAndRecordingInfoPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.recordingDataGraphControl1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(641, 532);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cellAndRecordingInfoPanel1
            // 
            this.cellAndRecordingInfoPanel1.CurrentCellID = 1;
            this.cellAndRecordingInfoPanel1.CurrentRecordingID = ((long)(0));
            this.cellAndRecordingInfoPanel1.DataBindings.Add(new System.Windows.Forms.Binding("CurrentCellID", this.ProgramBindingSource, "CurrentCellID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cellAndRecordingInfoPanel1.DataBindings.Add(new System.Windows.Forms.Binding("CurrentRecordingID", this.ProgramBindingSource, "CurrentRecordingID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cellAndRecordingInfoPanel1.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cellAndRecordingInfoPanel1.DataSet = null;
            this.cellAndRecordingInfoPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cellAndRecordingInfoPanel1.Location = new System.Drawing.Point(3, 3);
            this.cellAndRecordingInfoPanel1.MinimumSize = new System.Drawing.Size(535, 250);
            this.cellAndRecordingInfoPanel1.Name = "cellAndRecordingInfoPanel1";
            this.cellAndRecordingInfoPanel1.Size = new System.Drawing.Size(635, 250);
            this.cellAndRecordingInfoPanel1.TabIndex = 0;
            // 
            // recordingDataGraphControl1
            // 
            this.recordingDataGraphControl1.CurrentRecordingID = ((long)(0));
            this.recordingDataGraphControl1.DataBindings.Add(new System.Windows.Forms.Binding("CurrentRecordingID", this.ProgramBindingSource, "CurrentRecordingID", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.recordingDataGraphControl1.DataBindings.Add(new System.Windows.Forms.Binding("DataSet", this.ProgramBindingSource, "DataSet", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.recordingDataGraphControl1.DataSet = null;
            this.recordingDataGraphControl1.DefaultAxisLocation = RRLab.PhysiologyData.GUI.RecordingDataGraphControl.AxisLocation.Left;
            this.recordingDataGraphControl1.DefaultAxisMode = RRLab.PhysiologyData.GUI.RecordingDataGraphControl.AxisMode.Auto;
            this.recordingDataGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingDataGraphControl1.GraphBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.recordingDataGraphControl1.Location = new System.Drawing.Point(3, 259);
            this.recordingDataGraphControl1.Name = "recordingDataGraphControl1";
            this.recordingDataGraphControl1.Size = new System.Drawing.Size(635, 270);
            this.recordingDataGraphControl1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.recordingsDropDownButton,
            this.toolStripButton5,
            this.recordingIDLabel,
            this.RecordingIndexToolStripLabel,
            this.toolStripButton6,
            this.toolStripButton4,
            this.toolStripButton2,
            this.ExportMatlabToolStripButton,
            this.ActionsDropDownButton,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(886, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "Select Cell";
            // 
            // recordingsDropDownButton
            // 
            this.recordingsDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.recordingsDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("recordingsDropDownButton.Image")));
            this.recordingsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recordingsDropDownButton.Name = "recordingsDropDownButton";
            this.recordingsDropDownButton.Size = new System.Drawing.Size(108, 22);
            this.recordingsDropDownButton.Text = "Select Recording";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton5.Text = "Previous";
            this.toolStripButton5.Click += new System.EventHandler(this.OnPreviousRecordingClicked);
            // 
            // RecordingIndexToolStripLabel
            // 
            this.RecordingIndexToolStripLabel.Name = "RecordingIndexToolStripLabel";
            this.RecordingIndexToolStripLabel.Size = new System.Drawing.Size(36, 22);
            this.RecordingIndexToolStripLabel.Text = "0 of 0";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton6.Text = "Next";
            this.toolStripButton6.Click += new System.EventHandler(this.OnNextRecordingClicked);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton4.Text = "Update";
            this.toolStripButton4.Click += new System.EventHandler(this.OnUpdateClicked);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cellToolStripMenuItem,
            this.recordingToolStripMenuItem});
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton2.Text = "Delete";
            // 
            // cellToolStripMenuItem
            // 
            this.cellToolStripMenuItem.Name = "cellToolStripMenuItem";
            this.cellToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.cellToolStripMenuItem.Text = "Cell";
            // 
            // recordingToolStripMenuItem
            // 
            this.recordingToolStripMenuItem.Name = "recordingToolStripMenuItem";
            this.recordingToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.recordingToolStripMenuItem.Text = "Recording";
            // 
            // ExportMatlabToolStripButton
            // 
            this.ExportMatlabToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExportMatlabToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportMatlabToolStripButton.Image")));
            this.ExportMatlabToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportMatlabToolStripButton.Name = "ExportMatlabToolStripButton";
            this.ExportMatlabToolStripButton.Size = new System.Drawing.Size(108, 22);
            this.ExportMatlabToolStripButton.Text = "Export to MATLAB";
            this.ExportMatlabToolStripButton.Click += new System.EventHandler(this.OnExportToMatlabClicked);
            // 
            // ActionsDropDownButton
            // 
            this.ActionsDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ActionsDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("ActionsDropDownButton.Image")));
            this.ActionsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionsDropDownButton.Name = "ActionsDropDownButton";
            this.ActionsDropDownButton.Size = new System.Drawing.Size(60, 22);
            this.ActionsDropDownButton.Text = "Actions";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(74, 22);
            this.toolStripButton3.Text = "Print Report";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.MainSplitContainer.Size = new System.Drawing.Size(886, 532);
            this.MainSplitContainer.SplitterDistance = 641;
            this.MainSplitContainer.TabIndex = 3;
            // 
            // recordingIDLabel
            // 
            this.recordingIDLabel.Name = "recordingIDLabel";
            this.recordingIDLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // RecordingViewerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RecordingViewerPanel";
            this.Size = new System.Drawing.Size(886, 557);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.CellAnnotationsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CellAnnotationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKCellsCellsAnnotationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.RecordingAnnotationsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecordingAnnotationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKRecordingsRecordingsAnnotationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingsBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox CellAnnotationsGroupBox;
        private System.Windows.Forms.DataGridView CellAnnotationsDataGridView;
        private RRLab.PhysiologyData.GUI.RecordingSubTablesViewer RecordingSubtablesViewer;
        private System.Windows.Forms.GroupBox RecordingAnnotationsGroupBox;
        private System.Windows.Forms.DataGridView RecordingAnnotationsDataGridView;
        private System.Windows.Forms.BindingSource CellsBindingSource;
        private System.Windows.Forms.BindingSource RecordingsBindingSource;
        private System.Windows.Forms.BindingSource fKCellsCellsAnnotationsBindingSource;
        private System.Windows.Forms.BindingSource fKRecordingsRecordingsAnnotationsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enteredDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn enteredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton recordingsDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem cellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private RRLab.PhysiologyData.GUI.CellAndRecordingInfoPanel cellAndRecordingInfoPanel1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private RRLab.PhysiologyData.GUI.RecordingDataGraphControl recordingDataGraphControl1;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripLabel RecordingIndexToolStripLabel;
        private System.Windows.Forms.ToolStripDropDownButton ActionsDropDownButton;
        private System.Windows.Forms.ToolStripButton ExportMatlabToolStripButton;
        private System.Windows.Forms.ToolStripLabel recordingIDLabel;
    }
}
