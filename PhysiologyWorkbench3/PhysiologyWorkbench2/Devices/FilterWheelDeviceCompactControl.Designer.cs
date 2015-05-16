namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class FilterWheelDeviceCompactControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FiltersComboBox = new System.Windows.Forms.ComboBox();
            this.ShutterAComboBox = new System.Windows.Forms.ComboBox();
            this.ShutterBComboBox = new System.Windows.Forms.ComboBox();
            this.SelectFilterButton = new System.Windows.Forms.Button();
            this.SetShutterAButton = new System.Windows.Forms.Button();
            this.SetShutterBButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.SetShutterBButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.SetShutterAButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShutterBComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ShutterAComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FiltersComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SelectFilterButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(231, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Shutter A:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Shutter B:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FiltersComboBox
            // 
            this.FiltersComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FiltersComboBox.FormattingEnabled = true;
            this.FiltersComboBox.Location = new System.Drawing.Point(63, 3);
            this.FiltersComboBox.Name = "FiltersComboBox";
            this.FiltersComboBox.Size = new System.Drawing.Size(112, 21);
            this.FiltersComboBox.TabIndex = 3;
            // 
            // ShutterAComboBox
            // 
            this.ShutterAComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShutterAComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShutterAComboBox.FormattingEnabled = true;
            this.ShutterAComboBox.Items.AddRange(new object[] {
            "Closed",
            "Conditional Open",
            "Open"});
            this.ShutterAComboBox.Location = new System.Drawing.Point(63, 32);
            this.ShutterAComboBox.Name = "ShutterAComboBox";
            this.ShutterAComboBox.Size = new System.Drawing.Size(112, 21);
            this.ShutterAComboBox.TabIndex = 4;
            // 
            // ShutterBComboBox
            // 
            this.ShutterBComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShutterBComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShutterBComboBox.FormattingEnabled = true;
            this.ShutterBComboBox.Items.AddRange(new object[] {
            "Closed",
            "Conditional Open",
            "Open"});
            this.ShutterBComboBox.Location = new System.Drawing.Point(63, 61);
            this.ShutterBComboBox.Name = "ShutterBComboBox";
            this.ShutterBComboBox.Size = new System.Drawing.Size(112, 21);
            this.ShutterBComboBox.TabIndex = 5;
            // 
            // SelectFilterButton
            // 
            this.SelectFilterButton.AutoSize = true;
            this.SelectFilterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectFilterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectFilterButton.Location = new System.Drawing.Point(181, 3);
            this.SelectFilterButton.Name = "SelectFilterButton";
            this.SelectFilterButton.Size = new System.Drawing.Size(47, 23);
            this.SelectFilterButton.TabIndex = 6;
            this.SelectFilterButton.Text = "Select";
            this.SelectFilterButton.UseVisualStyleBackColor = true;
            this.SelectFilterButton.Click += new System.EventHandler(this.SelectFilterButton_Click);
            // 
            // SetShutterAButton
            // 
            this.SetShutterAButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetShutterAButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetShutterAButton.Location = new System.Drawing.Point(181, 32);
            this.SetShutterAButton.Name = "SetShutterAButton";
            this.SetShutterAButton.Size = new System.Drawing.Size(47, 23);
            this.SetShutterAButton.TabIndex = 7;
            this.SetShutterAButton.Text = "Set";
            this.SetShutterAButton.UseVisualStyleBackColor = true;
            this.SetShutterAButton.Click += new System.EventHandler(this.SetShutterAButton_Click);
            // 
            // SetShutterBButton
            // 
            this.SetShutterBButton.AutoSize = true;
            this.SetShutterBButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetShutterBButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetShutterBButton.Location = new System.Drawing.Point(181, 61);
            this.SetShutterBButton.Name = "SetShutterBButton";
            this.SetShutterBButton.Size = new System.Drawing.Size(47, 23);
            this.SetShutterBButton.TabIndex = 8;
            this.SetShutterBButton.Text = "Set";
            this.SetShutterBButton.UseVisualStyleBackColor = true;
            this.SetShutterBButton.Click += new System.EventHandler(this.SetShutterBButton_Click);
            // 
            // FilterWheelDeviceManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FilterWheelDeviceManualControl";
            this.Size = new System.Drawing.Size(231, 87);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox ShutterBComboBox;
        private System.Windows.Forms.ComboBox ShutterAComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FiltersComboBox;
        private System.Windows.Forms.Button SetShutterBButton;
        private System.Windows.Forms.Button SetShutterAButton;
        private System.Windows.Forms.Button SelectFilterButton;
    }
}
