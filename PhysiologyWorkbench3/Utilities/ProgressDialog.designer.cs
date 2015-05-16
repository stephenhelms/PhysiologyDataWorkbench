namespace RRLab.Utilities
{
    partial class ProgressDialog
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
            this.TaskInfoLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelTaskButton = new System.Windows.Forms.Button();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskInfoLabel
            // 
            this.TaskInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.TaskInfoLabel.MinimumSize = new System.Drawing.Size(300, 40);
            this.TaskInfoLabel.Name = "TaskInfoLabel";
            this.TaskInfoLabel.Size = new System.Drawing.Size(300, 99);
            this.TaskInfoLabel.TabIndex = 0;
            this.TaskInfoLabel.Text = "Executing task...";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.CancelTaskButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.MinimumSize = new System.Drawing.Size(300, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(300, 31);
            this.panel1.TabIndex = 1;
            // 
            // CancelTaskButton
            // 
            this.CancelTaskButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CancelTaskButton.AutoSize = true;
            this.CancelTaskButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelTaskButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelTaskButton.Location = new System.Drawing.Point(125, 5);
            this.CancelTaskButton.Name = "CancelTaskButton";
            this.CancelTaskButton.Size = new System.Drawing.Size(50, 23);
            this.CancelTaskButton.TabIndex = 0;
            this.CancelTaskButton.Text = "&Cancel";
            this.CancelTaskButton.UseVisualStyleBackColor = true;
            this.CancelTaskButton.Click += new System.EventHandler(this.OnCancelClicked);
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TaskProgressBar.Location = new System.Drawing.Point(0, 43);
            this.TaskProgressBar.MinimumSize = new System.Drawing.Size(300, 25);
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(300, 25);
            this.TaskProgressBar.TabIndex = 2;
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CancelTaskButton;
            this.ClientSize = new System.Drawing.Size(299, 99);
            this.Controls.Add(this.TaskProgressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TaskInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(305, 125);
            this.Name = "ProgressDialog";
            this.Text = "Executing task...";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskInfoLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelTaskButton;
        private System.Windows.Forms.ProgressBar TaskProgressBar;
    }
}