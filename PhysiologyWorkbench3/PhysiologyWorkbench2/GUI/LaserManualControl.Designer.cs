namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class LaserManualControl
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
            this.ShutterFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ChooseLaserLabel = new System.Windows.Forms.Label();
            this.LaserComboBox = new System.Windows.Forms.ComboBox();
            this.FlashLaserButton = new System.Windows.Forms.Button();
            this.ShutterFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShutterFlowLayoutPanel
            // 
            this.ShutterFlowLayoutPanel.AutoSize = true;
            this.ShutterFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ShutterFlowLayoutPanel.Controls.Add(this.ChooseLaserLabel);
            this.ShutterFlowLayoutPanel.Controls.Add(this.LaserComboBox);
            this.ShutterFlowLayoutPanel.Controls.Add(this.FlashLaserButton);
            this.ShutterFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShutterFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ShutterFlowLayoutPanel.Name = "ShutterFlowLayoutPanel";
            this.ShutterFlowLayoutPanel.Size = new System.Drawing.Size(197, 56);
            this.ShutterFlowLayoutPanel.TabIndex = 2;
            // 
            // ChooseLaserLabel
            // 
            this.ChooseLaserLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChooseLaserLabel.AutoSize = true;
            this.ChooseLaserLabel.Location = new System.Drawing.Point(3, 7);
            this.ChooseLaserLabel.Name = "ChooseLaserLabel";
            this.ChooseLaserLabel.Size = new System.Drawing.Size(71, 13);
            this.ChooseLaserLabel.TabIndex = 0;
            this.ChooseLaserLabel.Text = "Choose laser:";
            // 
            // LaserComboBox
            // 
            this.ShutterFlowLayoutPanel.SetFlowBreak(this.LaserComboBox, true);
            this.LaserComboBox.FormattingEnabled = true;
            this.LaserComboBox.Location = new System.Drawing.Point(80, 3);
            this.LaserComboBox.Name = "LaserComboBox";
            this.LaserComboBox.Size = new System.Drawing.Size(114, 21);
            this.LaserComboBox.TabIndex = 1;
            this.LaserComboBox.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxSelectedLaserChanged);
            // 
            // FlashLaserButton
            // 
            this.FlashLaserButton.AutoSize = true;
            this.FlashLaserButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlashLaserButton.Location = new System.Drawing.Point(3, 30);
            this.FlashLaserButton.Name = "FlashLaserButton";
            this.FlashLaserButton.Size = new System.Drawing.Size(42, 23);
            this.FlashLaserButton.TabIndex = 2;
            this.FlashLaserButton.Text = "Flash";
            this.FlashLaserButton.UseVisualStyleBackColor = true;
            this.FlashLaserButton.Click += new System.EventHandler(this.OnFlashClicked);
            // 
            // LaserManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ShutterFlowLayoutPanel);
            this.Enabled = false;
            this.Name = "LaserManualControl";
            this.Size = new System.Drawing.Size(197, 56);
            this.ShutterFlowLayoutPanel.ResumeLayout(false);
            this.ShutterFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ShutterFlowLayoutPanel;
        private System.Windows.Forms.Label ChooseLaserLabel;
        private System.Windows.Forms.ComboBox LaserComboBox;
        private System.Windows.Forms.Button FlashLaserButton;
    }
}
