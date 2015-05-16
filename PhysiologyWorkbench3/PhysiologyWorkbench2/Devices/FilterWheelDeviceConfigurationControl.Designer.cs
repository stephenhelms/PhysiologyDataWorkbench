namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class FilterWheelDeviceConfigurationControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WheelBNumericControl = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.FiltersListBox = new System.Windows.Forms.ListBox();
            this.FilterNameTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WheelANumericControl = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WheelBNumericControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WheelANumericControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.WheelBNumericControl, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.FiltersListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FilterNameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AddButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RemoveButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.WheelANumericControl, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(223, 160);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WheelBNumericControl
            // 
            this.WheelBNumericControl.AutoSize = true;
            this.WheelBNumericControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WheelBNumericControl.Location = new System.Drawing.Point(163, 137);
            this.WheelBNumericControl.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.WheelBNumericControl.Name = "WheelBNumericControl";
            this.WheelBNumericControl.Size = new System.Drawing.Size(57, 20);
            this.WheelBNumericControl.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(163, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wheel B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FiltersListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.FiltersListBox, 3);
            this.FiltersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersListBox.FormattingEnabled = true;
            this.FiltersListBox.Location = new System.Drawing.Point(3, 3);
            this.FiltersListBox.Name = "FiltersListBox";
            this.FiltersListBox.Size = new System.Drawing.Size(217, 82);
            this.FiltersListBox.TabIndex = 0;
            this.FiltersListBox.SelectedIndexChanged += new System.EventHandler(this.FiltersListBox_SelectedIndexChanged);
            // 
            // FilterNameTextBox
            // 
            this.FilterNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterNameTextBox.Location = new System.Drawing.Point(3, 95);
            this.FilterNameTextBox.MinimumSize = new System.Drawing.Size(50, 4);
            this.FilterNameTextBox.Name = "FilterNameTextBox";
            this.FilterNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.FilterNameTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(109, 95);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(48, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(163, 95);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(57, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(109, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wheel A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WheelANumericControl
            // 
            this.WheelANumericControl.AutoSize = true;
            this.WheelANumericControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WheelANumericControl.Location = new System.Drawing.Point(109, 137);
            this.WheelANumericControl.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.WheelANumericControl.Name = "WheelANumericControl";
            this.WheelANumericControl.Size = new System.Drawing.Size(48, 20);
            this.WheelANumericControl.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Position:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterWheelDeviceConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FilterWheelDeviceConfigurationControl";
            this.Size = new System.Drawing.Size(223, 160);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WheelBNumericControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WheelANumericControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox FiltersListBox;
        private System.Windows.Forms.TextBox FilterNameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown WheelBNumericControl;
        private System.Windows.Forms.NumericUpDown WheelANumericControl;
        private System.Windows.Forms.Label label3;

    }
}
