namespace RRLab.Utilities
{
    partial class DataSetGroupedScatterPlotControl
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
            this.DataSettingsControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.XColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.YColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.GraphControl = new ZedGraph.ZedGraphControl();
            this.DataSettingsControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSettingsControlPanel
            // 
            this.DataSettingsControlPanel.AutoSize = true;
            this.DataSettingsControlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DataSettingsControlPanel.Controls.Add(this.label1);
            this.DataSettingsControlPanel.Controls.Add(this.XColumnComboBox);
            this.DataSettingsControlPanel.Controls.Add(this.label2);
            this.DataSettingsControlPanel.Controls.Add(this.YColumnComboBox);
            this.DataSettingsControlPanel.Controls.Add(this.label3);
            this.DataSettingsControlPanel.Controls.Add(this.GroupColumnComboBox);
            this.DataSettingsControlPanel.Controls.Add(this.label4);
            this.DataSettingsControlPanel.Controls.Add(this.FilterTextBox);
            this.DataSettingsControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataSettingsControlPanel.Location = new System.Drawing.Point(0, 0);
            this.DataSettingsControlPanel.Name = "DataSettingsControlPanel";
            this.DataSettingsControlPanel.Size = new System.Drawing.Size(628, 53);
            this.DataSettingsControlPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "X Column:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XColumnComboBox
            // 
            this.XColumnComboBox.DisplayMember = "Caption";
            this.XColumnComboBox.FormattingEnabled = true;
            this.XColumnComboBox.Location = new System.Drawing.Point(64, 3);
            this.XColumnComboBox.Name = "XColumnComboBox";
            this.XColumnComboBox.Size = new System.Drawing.Size(121, 21);
            this.XColumnComboBox.TabIndex = 4;
            this.XColumnComboBox.ValueMember = "ColumnName";
            this.XColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedXColumnChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(191, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y Column:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // YColumnComboBox
            // 
            this.YColumnComboBox.DisplayMember = "Caption";
            this.YColumnComboBox.FormattingEnabled = true;
            this.YColumnComboBox.Location = new System.Drawing.Point(252, 3);
            this.YColumnComboBox.Name = "YColumnComboBox";
            this.YColumnComboBox.Size = new System.Drawing.Size(121, 21);
            this.YColumnComboBox.TabIndex = 5;
            this.YColumnComboBox.ValueMember = "ColumnName";
            this.YColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedYColumnChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(379, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Group Column:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupColumnComboBox
            // 
            this.GroupColumnComboBox.DisplayMember = "Caption";
            this.DataSettingsControlPanel.SetFlowBreak(this.GroupColumnComboBox, true);
            this.GroupColumnComboBox.FormattingEnabled = true;
            this.GroupColumnComboBox.Location = new System.Drawing.Point(462, 3);
            this.GroupColumnComboBox.Name = "GroupColumnComboBox";
            this.GroupColumnComboBox.Size = new System.Drawing.Size(121, 21);
            this.GroupColumnComboBox.TabIndex = 6;
            this.GroupColumnComboBox.ValueMember = "ColumnName";
            this.GroupColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedGroupColumnChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Filter:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(41, 30);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(332, 20);
            this.FilterTextBox.TabIndex = 7;
            this.FilterTextBox.TextChanged += new System.EventHandler(this.OnFilterTextChanged);
            // 
            // GraphControl
            // 
            this.GraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphControl.Location = new System.Drawing.Point(0, 53);
            this.GraphControl.Name = "GraphControl";
            this.GraphControl.ScrollMaxX = 0;
            this.GraphControl.ScrollMaxY = 0;
            this.GraphControl.ScrollMaxY2 = 0;
            this.GraphControl.ScrollMinX = 0;
            this.GraphControl.ScrollMinY = 0;
            this.GraphControl.ScrollMinY2 = 0;
            this.GraphControl.Size = new System.Drawing.Size(628, 280);
            this.GraphControl.TabIndex = 1;
            // 
            // DataSetGroupedScatterPlotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GraphControl);
            this.Controls.Add(this.DataSettingsControlPanel);
            this.Name = "DataSetGroupedScatterPlotControl";
            this.Size = new System.Drawing.Size(628, 333);
            this.DataSettingsControlPanel.ResumeLayout(false);
            this.DataSettingsControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel DataSettingsControlPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox XColumnComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox YColumnComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox GroupColumnComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FilterTextBox;
        private ZedGraph.ZedGraphControl GraphControl;
    }
}
