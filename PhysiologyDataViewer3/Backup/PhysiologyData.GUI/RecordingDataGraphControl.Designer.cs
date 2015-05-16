namespace RRLab.PhysiologyData.GUI
{
    partial class RecordingDataGraphControl
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
            this.RecordingDataGraph = new ZedGraph.ZedGraphControl();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.HideablePanel = new System.Windows.Forms.Panel();
            this.AvailableDataGroupBox = new System.Windows.Forms.GroupBox();
            this.AvailableDataCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ShowTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowLegendCheckBox = new System.Windows.Forms.CheckBox();
            this.DarkRoomCheckBox = new System.Windows.Forms.CheckBox();
            this.AxesGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.AxisComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AxisPlacementComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AxisModeComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToggleHiddenButton = new System.Windows.Forms.Button();
            this.RecordingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AntialiasCheckBox = new System.Windows.Forms.CheckBox();
            this.SidePanel.SuspendLayout();
            this.HideablePanel.SuspendLayout();
            this.AvailableDataGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.AxesGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordingDataGraph
            // 
            this.RecordingDataGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingDataGraph.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.RecordingDataGraph.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.RecordingDataGraph.IsShowPointValues = true;
            this.RecordingDataGraph.IsZoomOnMouseCenter = true;
            this.RecordingDataGraph.Location = new System.Drawing.Point(0, 0);
            this.RecordingDataGraph.Name = "RecordingDataGraph";
            this.RecordingDataGraph.ScrollMaxX = 0;
            this.RecordingDataGraph.ScrollMaxY = 0;
            this.RecordingDataGraph.ScrollMaxY2 = 0;
            this.RecordingDataGraph.ScrollMinX = 0;
            this.RecordingDataGraph.ScrollMinY = 0;
            this.RecordingDataGraph.ScrollMinY2 = 0;
            this.RecordingDataGraph.Size = new System.Drawing.Size(440, 397);
            this.RecordingDataGraph.TabIndex = 0;
            // 
            // SidePanel
            // 
            this.SidePanel.AutoSize = true;
            this.SidePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SidePanel.Controls.Add(this.HideablePanel);
            this.SidePanel.Controls.Add(this.ToggleHiddenButton);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SidePanel.Location = new System.Drawing.Point(440, 0);
            this.SidePanel.MinimumSize = new System.Drawing.Size(50, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(185, 397);
            this.SidePanel.TabIndex = 1;
            // 
            // HideablePanel
            // 
            this.HideablePanel.AutoSize = true;
            this.HideablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HideablePanel.Controls.Add(this.AvailableDataGroupBox);
            this.HideablePanel.Controls.Add(this.OptionsGroupBox);
            this.HideablePanel.Controls.Add(this.AxesGroupBox);
            this.HideablePanel.Controls.Add(this.toolStrip1);
            this.HideablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideablePanel.Location = new System.Drawing.Point(0, 23);
            this.HideablePanel.MinimumSize = new System.Drawing.Size(185, 0);
            this.HideablePanel.Name = "HideablePanel";
            this.HideablePanel.Size = new System.Drawing.Size(185, 374);
            this.HideablePanel.TabIndex = 0;
            // 
            // AvailableDataGroupBox
            // 
            this.AvailableDataGroupBox.Controls.Add(this.AvailableDataCheckedListBox);
            this.AvailableDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvailableDataGroupBox.Location = new System.Drawing.Point(0, 25);
            this.AvailableDataGroupBox.Name = "AvailableDataGroupBox";
            this.AvailableDataGroupBox.Size = new System.Drawing.Size(185, 138);
            this.AvailableDataGroupBox.TabIndex = 0;
            this.AvailableDataGroupBox.TabStop = false;
            this.AvailableDataGroupBox.Text = "Available Data";
            // 
            // AvailableDataCheckedListBox
            // 
            this.AvailableDataCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvailableDataCheckedListBox.FormattingEnabled = true;
            this.AvailableDataCheckedListBox.Location = new System.Drawing.Point(3, 16);
            this.AvailableDataCheckedListBox.Name = "AvailableDataCheckedListBox";
            this.AvailableDataCheckedListBox.Size = new System.Drawing.Size(179, 109);
            this.AvailableDataCheckedListBox.TabIndex = 0;
            this.AvailableDataCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnAvailableDataItemChecked);
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.AutoSize = true;
            this.OptionsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.OptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OptionsGroupBox.Location = new System.Drawing.Point(0, 163);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(185, 111);
            this.OptionsGroupBox.TabIndex = 3;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Graph Options";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.AntialiasCheckBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ShowTitleCheckBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ShowLegendCheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.DarkRoomCheckBox, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(179, 92);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ShowTitleCheckBox
            // 
            this.ShowTitleCheckBox.AutoSize = true;
            this.ShowTitleCheckBox.Checked = true;
            this.ShowTitleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowTitleCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowTitleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.ShowTitleCheckBox.Name = "ShowTitleCheckBox";
            this.ShowTitleCheckBox.Size = new System.Drawing.Size(173, 17);
            this.ShowTitleCheckBox.TabIndex = 0;
            this.ShowTitleCheckBox.Text = "Show Title";
            this.ShowTitleCheckBox.UseVisualStyleBackColor = true;
            this.ShowTitleCheckBox.CheckedChanged += new System.EventHandler(this.OnShowTitleChecked);
            // 
            // ShowLegendCheckBox
            // 
            this.ShowLegendCheckBox.AutoSize = true;
            this.ShowLegendCheckBox.Checked = true;
            this.ShowLegendCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowLegendCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowLegendCheckBox.Location = new System.Drawing.Point(3, 26);
            this.ShowLegendCheckBox.Name = "ShowLegendCheckBox";
            this.ShowLegendCheckBox.Size = new System.Drawing.Size(173, 17);
            this.ShowLegendCheckBox.TabIndex = 1;
            this.ShowLegendCheckBox.Text = "Show Legend";
            this.ShowLegendCheckBox.UseVisualStyleBackColor = true;
            this.ShowLegendCheckBox.CheckedChanged += new System.EventHandler(this.OnShowLegendChecked);
            // 
            // DarkRoomCheckBox
            // 
            this.DarkRoomCheckBox.AutoSize = true;
            this.DarkRoomCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DarkRoomCheckBox.Location = new System.Drawing.Point(3, 72);
            this.DarkRoomCheckBox.Name = "DarkRoomCheckBox";
            this.DarkRoomCheckBox.Size = new System.Drawing.Size(173, 17);
            this.DarkRoomCheckBox.TabIndex = 2;
            this.DarkRoomCheckBox.Text = "Use Dark Room Style";
            this.DarkRoomCheckBox.UseVisualStyleBackColor = true;
            this.DarkRoomCheckBox.CheckedChanged += new System.EventHandler(this.OnUseDarkRoomStyleChecked);
            // 
            // AxesGroupBox
            // 
            this.AxesGroupBox.AutoSize = true;
            this.AxesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AxesGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.AxesGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AxesGroupBox.Location = new System.Drawing.Point(0, 274);
            this.AxesGroupBox.Name = "AxesGroupBox";
            this.AxesGroupBox.Size = new System.Drawing.Size(185, 100);
            this.AxesGroupBox.TabIndex = 2;
            this.AxesGroupBox.TabStop = false;
            this.AxesGroupBox.Text = "Axes";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AxisComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AxisPlacementComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.AxisModeComboBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(179, 81);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Axis";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AxisComboBox
            // 
            this.AxisComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxisComboBox.FormattingEnabled = true;
            this.AxisComboBox.Location = new System.Drawing.Point(66, 3);
            this.AxisComboBox.Name = "AxisComboBox";
            this.AxisComboBox.Size = new System.Drawing.Size(110, 21);
            this.AxisComboBox.TabIndex = 1;
            this.AxisComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedAxisChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Placement";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AxisPlacementComboBox
            // 
            this.AxisPlacementComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxisPlacementComboBox.FormattingEnabled = true;
            this.AxisPlacementComboBox.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.AxisPlacementComboBox.Location = new System.Drawing.Point(66, 30);
            this.AxisPlacementComboBox.Name = "AxisPlacementComboBox";
            this.AxisPlacementComboBox.Size = new System.Drawing.Size(110, 21);
            this.AxisPlacementComboBox.TabIndex = 3;
            this.AxisPlacementComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedPlacementChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AxisModeComboBox
            // 
            this.AxisModeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxisModeComboBox.FormattingEnabled = true;
            this.AxisModeComboBox.Items.AddRange(new object[] {
            "Data",
            "Dynamic Range"});
            this.AxisModeComboBox.Location = new System.Drawing.Point(66, 57);
            this.AxisModeComboBox.Name = "AxisModeComboBox";
            this.AxisModeComboBox.Size = new System.Drawing.Size(110, 21);
            this.AxisModeComboBox.TabIndex = 5;
            this.AxisModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedModeChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(185, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToggleHiddenButton
            // 
            this.ToggleHiddenButton.AutoSize = true;
            this.ToggleHiddenButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ToggleHiddenButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToggleHiddenButton.Location = new System.Drawing.Point(0, 0);
            this.ToggleHiddenButton.MinimumSize = new System.Drawing.Size(50, 0);
            this.ToggleHiddenButton.Name = "ToggleHiddenButton";
            this.ToggleHiddenButton.Size = new System.Drawing.Size(185, 23);
            this.ToggleHiddenButton.TabIndex = 1;
            this.ToggleHiddenButton.Text = "Hide >>>";
            this.ToggleHiddenButton.UseVisualStyleBackColor = true;
            this.ToggleHiddenButton.Click += new System.EventHandler(this.OnToggleHiddenClicked);
            // 
            // RecordingBindingSource
            // 
            this.RecordingBindingSource.DataMember = "Recordings";
            this.RecordingBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet);
            this.RecordingBindingSource.CurrentItemChanged += new System.EventHandler(this.OnCurrentRecordingChanged);
            // 
            // RecordingDataBindingSource
            // 
            this.RecordingDataBindingSource.DataMember = "FK_Recordings_Recording_Data";
            this.RecordingDataBindingSource.DataSource = this.RecordingBindingSource;
            this.RecordingDataBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.OnRecordingDataChanged);
            // 
            // AntialiasCheckBox
            // 
            this.AntialiasCheckBox.AutoSize = true;
            this.AntialiasCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AntialiasCheckBox.Location = new System.Drawing.Point(3, 49);
            this.AntialiasCheckBox.Name = "AntialiasCheckBox";
            this.AntialiasCheckBox.Size = new System.Drawing.Size(173, 17);
            this.AntialiasCheckBox.TabIndex = 3;
            this.AntialiasCheckBox.Text = "Antialias Curves";
            this.AntialiasCheckBox.UseVisualStyleBackColor = true;
            this.AntialiasCheckBox.CheckedChanged += new System.EventHandler(this.OnAntialiasCurvesChecked);
            // 
            // RecordingDataGraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecordingDataGraph);
            this.Controls.Add(this.SidePanel);
            this.Name = "RecordingDataGraphControl";
            this.Size = new System.Drawing.Size(625, 397);
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            this.HideablePanel.ResumeLayout(false);
            this.HideablePanel.PerformLayout();
            this.AvailableDataGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.AxesGroupBox.ResumeLayout(false);
            this.AxesGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl RecordingDataGraph;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel HideablePanel;
        private System.Windows.Forms.Button ToggleHiddenButton;
        private System.Windows.Forms.GroupBox AvailableDataGroupBox;
        private System.Windows.Forms.GroupBox AxesGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox AxisComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AxisPlacementComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AxisModeComboBox;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox ShowTitleCheckBox;
        private System.Windows.Forms.CheckBox ShowLegendCheckBox;
        private System.Windows.Forms.CheckBox DarkRoomCheckBox;
        private System.Windows.Forms.BindingSource RecordingBindingSource;
        private System.Windows.Forms.BindingSource RecordingDataBindingSource;
        private System.Windows.Forms.CheckedListBox AvailableDataCheckedListBox;
        private System.Windows.Forms.CheckBox AntialiasCheckBox;
    }
}
