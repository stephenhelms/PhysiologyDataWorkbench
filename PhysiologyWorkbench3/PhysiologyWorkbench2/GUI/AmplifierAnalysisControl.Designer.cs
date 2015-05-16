namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class AmplifierAnalysisControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param genotype="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.StDevTextBox = new System.Windows.Forms.TextBox();
            this.PeakCurrentTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaselineCurrentTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StDevTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PeakCurrentTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BaselineCurrentTextBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 76);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StDevTextBox
            // 
            this.StDevTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StDevTextBox.Location = new System.Drawing.Point(78, 55);
            this.StDevTextBox.Name = "StDevTextBox";
            this.StDevTextBox.ReadOnly = true;
            this.StDevTextBox.Size = new System.Drawing.Size(69, 20);
            this.StDevTextBox.TabIndex = 5;
            // 
            // PeakCurrentTextBox
            // 
            this.PeakCurrentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PeakCurrentTextBox.Location = new System.Drawing.Point(78, 29);
            this.PeakCurrentTextBox.Name = "PeakCurrentTextBox";
            this.PeakCurrentTextBox.ReadOnly = true;
            this.PeakCurrentTextBox.Size = new System.Drawing.Size(69, 20);
            this.PeakCurrentTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "StDev (pA)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Peak (pA)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Baseline (pA)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaselineCurrentTextBox
            // 
            this.BaselineCurrentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaselineCurrentTextBox.Location = new System.Drawing.Point(78, 3);
            this.BaselineCurrentTextBox.Name = "BaselineCurrentTextBox";
            this.BaselineCurrentTextBox.ReadOnly = true;
            this.BaselineCurrentTextBox.Size = new System.Drawing.Size(69, 20);
            this.BaselineCurrentTextBox.TabIndex = 3;
            // 
            // AmplifierAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AmplifierAnalysisControl";
            this.Size = new System.Drawing.Size(150, 76);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox StDevTextBox;
        private System.Windows.Forms.TextBox PeakCurrentTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BaselineCurrentTextBox;
    }
}
