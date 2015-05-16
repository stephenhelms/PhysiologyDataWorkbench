namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    partial class AddNewRecordingDialog
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RelativeLogIntensityTextBox = new System.Windows.Forms.TextBox();
            this.CalciumConcentrationTextBox = new System.Windows.Forms.TextBox();
            this.CommentsTextBox = new System.Windows.Forms.TextBox();
            this.AutoFitInMATLABButton = new System.Windows.Forms.Button();
            this.AcceptActionButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.KeepFitCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(475, 252);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.55705F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.22148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.22148F));
            this.tableLayoutPanel1.Controls.Add(this.CommentsTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.CalciumConcentrationTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RelativeLogIntensityTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.AutoFitInMATLABButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.AcceptActionButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.CancelActionButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.KeepFitCheckBox, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 252);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 110);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relative Log Intensity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Calcium Concentration (uM)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(257, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comments";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RelativeLogIntensityTextBox
            // 
            this.RelativeLogIntensityTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RelativeLogIntensityTextBox.Location = new System.Drawing.Point(146, 3);
            this.RelativeLogIntensityTextBox.Name = "RelativeLogIntensityTextBox";
            this.RelativeLogIntensityTextBox.Size = new System.Drawing.Size(105, 20);
            this.RelativeLogIntensityTextBox.TabIndex = 3;
            // 
            // CalciumConcentrationTextBox
            // 
            this.CalciumConcentrationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalciumConcentrationTextBox.Location = new System.Drawing.Point(146, 29);
            this.CalciumConcentrationTextBox.Name = "CalciumConcentrationTextBox";
            this.CalciumConcentrationTextBox.Size = new System.Drawing.Size(105, 20);
            this.CalciumConcentrationTextBox.TabIndex = 4;
            // 
            // CommentsTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CommentsTextBox, 2);
            this.CommentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsTextBox.Location = new System.Drawing.Point(257, 29);
            this.CommentsTextBox.Multiline = true;
            this.CommentsTextBox.Name = "CommentsTextBox";
            this.tableLayoutPanel1.SetRowSpan(this.CommentsTextBox, 2);
            this.CommentsTextBox.Size = new System.Drawing.Size(215, 49);
            this.CommentsTextBox.TabIndex = 5;
            // 
            // AutoFitInMATLABButton
            // 
            this.AutoFitInMATLABButton.AutoSize = true;
            this.AutoFitInMATLABButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoFitInMATLABButton.Location = new System.Drawing.Point(3, 55);
            this.AutoFitInMATLABButton.Name = "AutoFitInMATLABButton";
            this.AutoFitInMATLABButton.Size = new System.Drawing.Size(107, 23);
            this.AutoFitInMATLABButton.TabIndex = 6;
            this.AutoFitInMATLABButton.Text = "AutoFit in MATLAB";
            this.AutoFitInMATLABButton.UseVisualStyleBackColor = true;
            this.AutoFitInMATLABButton.Click += new System.EventHandler(this.OnAutoFitInMATLABClicked);
            // 
            // AcceptActionButton
            // 
            this.AcceptActionButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AcceptActionButton.AutoSize = true;
            this.AcceptActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AcceptActionButton.Location = new System.Drawing.Point(394, 84);
            this.AcceptActionButton.Name = "AcceptActionButton";
            this.AcceptActionButton.Size = new System.Drawing.Size(51, 23);
            this.AcceptActionButton.TabIndex = 8;
            this.AcceptActionButton.Text = "&Accept";
            this.AcceptActionButton.UseVisualStyleBackColor = true;
            this.AcceptActionButton.Click += new System.EventHandler(this.OnAcceptClicked);
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CancelActionButton.AutoSize = true;
            this.CancelActionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Location = new System.Drawing.Point(284, 84);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(50, 23);
            this.CancelActionButton.TabIndex = 9;
            this.CancelActionButton.Text = "&Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            this.CancelActionButton.Click += new System.EventHandler(this.OnCancelClicked);
            // 
            // KeepFitCheckBox
            // 
            this.KeepFitCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.KeepFitCheckBox, 2);
            this.KeepFitCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeepFitCheckBox.Location = new System.Drawing.Point(3, 84);
            this.KeepFitCheckBox.Name = "KeepFitCheckBox";
            this.KeepFitCheckBox.Size = new System.Drawing.Size(248, 23);
            this.KeepFitCheckBox.TabIndex = 10;
            this.KeepFitCheckBox.Text = "Keep fit";
            this.KeepFitCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddNewRecordingDialog
            // 
            this.AcceptButton = this.AcceptActionButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(475, 362);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddNewRecordingDialog";
            this.Text = "Add New Macroscopic Bump Recording...";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CommentsTextBox;
        private System.Windows.Forms.TextBox CalciumConcentrationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RelativeLogIntensityTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AutoFitInMATLABButton;
        private System.Windows.Forms.Button AcceptActionButton;
        private System.Windows.Forms.Button CancelActionButton;
        private System.Windows.Forms.CheckBox KeepFitCheckBox;
    }
}