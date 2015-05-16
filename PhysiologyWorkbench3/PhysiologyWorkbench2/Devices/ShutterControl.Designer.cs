namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class ShutterControl
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
            this.ChooseShutterLabel = new System.Windows.Forms.Label();
            this.ShutterComboBox = new System.Windows.Forms.ComboBox();
            this.OpenShutterButton = new System.Windows.Forms.Button();
            this.CloseShutterButton = new System.Windows.Forms.Button();
            this.ShutterFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShutterFlowLayoutPanel
            // 
            this.ShutterFlowLayoutPanel.AutoSize = true;
            this.ShutterFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ShutterFlowLayoutPanel.Controls.Add(this.ChooseShutterLabel);
            this.ShutterFlowLayoutPanel.Controls.Add(this.ShutterComboBox);
            this.ShutterFlowLayoutPanel.Controls.Add(this.OpenShutterButton);
            this.ShutterFlowLayoutPanel.Controls.Add(this.CloseShutterButton);
            this.ShutterFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShutterFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ShutterFlowLayoutPanel.Name = "ShutterFlowLayoutPanel";
            this.ShutterFlowLayoutPanel.Size = new System.Drawing.Size(214, 58);
            this.ShutterFlowLayoutPanel.TabIndex = 1;
            // 
            // ChooseShutterLabel
            // 
            this.ChooseShutterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChooseShutterLabel.AutoSize = true;
            this.ChooseShutterLabel.Location = new System.Drawing.Point(3, 7);
            this.ChooseShutterLabel.Name = "ChooseShutterLabel";
            this.ChooseShutterLabel.Size = new System.Drawing.Size(81, 13);
            this.ChooseShutterLabel.TabIndex = 0;
            this.ChooseShutterLabel.Text = "Choose shutter:";
            // 
            // ShutterComboBox
            // 
            this.ShutterFlowLayoutPanel.SetFlowBreak(this.ShutterComboBox, true);
            this.ShutterComboBox.FormattingEnabled = true;
            this.ShutterComboBox.Location = new System.Drawing.Point(90, 3);
            this.ShutterComboBox.Name = "ShutterComboBox";
            this.ShutterComboBox.Size = new System.Drawing.Size(114, 21);
            this.ShutterComboBox.TabIndex = 1;
            this.ShutterComboBox.SelectedValueChanged += new System.EventHandler(this.OnComboBoxSelectedShutterChanged);
            // 
            // OpenShutterButton
            // 
            this.OpenShutterButton.AutoSize = true;
            this.OpenShutterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenShutterButton.Location = new System.Drawing.Point(3, 30);
            this.OpenShutterButton.Name = "OpenShutterButton";
            this.OpenShutterButton.Size = new System.Drawing.Size(43, 23);
            this.OpenShutterButton.TabIndex = 2;
            this.OpenShutterButton.Text = "Open";
            this.OpenShutterButton.UseVisualStyleBackColor = true;
            this.OpenShutterButton.Click += new System.EventHandler(this.OnOpenClicked);
            // 
            // CloseShutterButton
            // 
            this.CloseShutterButton.AutoSize = true;
            this.CloseShutterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CloseShutterButton.Location = new System.Drawing.Point(52, 30);
            this.CloseShutterButton.Name = "CloseShutterButton";
            this.CloseShutterButton.Size = new System.Drawing.Size(43, 23);
            this.CloseShutterButton.TabIndex = 3;
            this.CloseShutterButton.Text = "Close";
            this.CloseShutterButton.UseVisualStyleBackColor = true;
            this.CloseShutterButton.Click += new System.EventHandler(this.OnCloseClicked);
            // 
            // ShutterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShutterFlowLayoutPanel);
            this.Name = "ShutterControl";
            this.Size = new System.Drawing.Size(214, 58);
            this.ShutterFlowLayoutPanel.ResumeLayout(false);
            this.ShutterFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ShutterFlowLayoutPanel;
        private System.Windows.Forms.Label ChooseShutterLabel;
        private System.Windows.Forms.ComboBox ShutterComboBox;
        private System.Windows.Forms.Button OpenShutterButton;
        private System.Windows.Forms.Button CloseShutterButton;
    }
}
