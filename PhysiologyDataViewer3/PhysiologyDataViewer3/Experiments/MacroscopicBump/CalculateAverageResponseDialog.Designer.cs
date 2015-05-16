namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    partial class CalculateAverageResponseDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NormalizeAmplitudeCheckBox = new System.Windows.Forms.CheckBox();
            this.AdjustBaselineCheckBox = new System.Windows.Forms.CheckBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CalculateForEachGenotype = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the filter to use to select responses for calculation:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.NormalizeAmplitudeCheckBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.AdjustBaselineCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 99);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // NormalizeAmplitudeCheckBox
            // 
            this.NormalizeAmplitudeCheckBox.AutoSize = true;
            this.NormalizeAmplitudeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalizeAmplitudeCheckBox.Location = new System.Drawing.Point(148, 42);
            this.NormalizeAmplitudeCheckBox.Name = "NormalizeAmplitudeCheckBox";
            this.NormalizeAmplitudeCheckBox.Size = new System.Drawing.Size(140, 17);
            this.NormalizeAmplitudeCheckBox.TabIndex = 3;
            this.NormalizeAmplitudeCheckBox.Text = "Normalize Amplitude";
            this.NormalizeAmplitudeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdjustBaselineCheckBox
            // 
            this.AdjustBaselineCheckBox.AutoSize = true;
            this.AdjustBaselineCheckBox.Checked = true;
            this.AdjustBaselineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AdjustBaselineCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdjustBaselineCheckBox.Location = new System.Drawing.Point(3, 42);
            this.AdjustBaselineCheckBox.Name = "AdjustBaselineCheckBox";
            this.AdjustBaselineCheckBox.Size = new System.Drawing.Size(139, 17);
            this.AdjustBaselineCheckBox.TabIndex = 2;
            this.AdjustBaselineCheckBox.Text = "Adjust Baseline";
            this.AdjustBaselineCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.filterTextBox, 2);
            this.filterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTextBox.Location = new System.Drawing.Point(3, 16);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(285, 20);
            this.filterTextBox.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.okButton);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.CalculateForEachGenotype);
            this.flowLayoutPanel1.Controls.Add(this._cancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Location = new System.Drawing.Point(221, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(61, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Calculate";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.AutoSize = true;
            this._cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(18, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(50, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(162, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Per Cell";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CalculateForEachGenotype
            // 
            this.CalculateForEachGenotype.AutoSize = true;
            this.CalculateForEachGenotype.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CalculateForEachGenotype.Location = new System.Drawing.Point(74, 3);
            this.CalculateForEachGenotype.Name = "CalculateForEachGenotype";
            this.CalculateForEachGenotype.Size = new System.Drawing.Size(82, 23);
            this.CalculateForEachGenotype.TabIndex = 3;
            this.CalculateForEachGenotype.Text = "Per Genotype";
            this.CalculateForEachGenotype.UseVisualStyleBackColor = true;
            this.CalculateForEachGenotype.Click += new System.EventHandler(this.CalculateForEachGenotype_Click);
            // 
            // CalculateAverageResponseDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 99);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CalculateAverageResponseDialog";
            this.Text = "Calculate average response...";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.CheckBox NormalizeAmplitudeCheckBox;
        private System.Windows.Forms.CheckBox AdjustBaselineCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CalculateForEachGenotype;
    }
}