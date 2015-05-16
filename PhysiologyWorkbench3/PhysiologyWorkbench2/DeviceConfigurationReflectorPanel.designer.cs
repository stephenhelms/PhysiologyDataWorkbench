namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class DeviceConfigurationReflectorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceConfigurationReflectorPanel));
            this.DeviceSettingsPropertySheet = new System.Windows.Forms.PropertyGrid();
            this.HeadingFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DeviceNameLabel = new System.Windows.Forms.Label();
            this.DeviceTypeLabel = new System.Windows.Forms.Label();
            this.HeadingFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceSettingsPropertySheet
            // 
            resources.ApplyResources(this.DeviceSettingsPropertySheet, "DeviceSettingsPropertySheet");
            this.DeviceSettingsPropertySheet.Name = "DeviceSettingsPropertySheet";
            // 
            // HeadingFlowPanel
            // 
            resources.ApplyResources(this.HeadingFlowPanel, "HeadingFlowPanel");
            this.HeadingFlowPanel.Controls.Add(this.DeviceNameLabel);
            this.HeadingFlowPanel.Controls.Add(this.DeviceTypeLabel);
            this.HeadingFlowPanel.Name = "HeadingFlowPanel";
            // 
            // DeviceNameLabel
            // 
            resources.ApplyResources(this.DeviceNameLabel, "DeviceNameLabel");
            this.DeviceNameLabel.Name = "DeviceNameLabel";
            // 
            // DeviceTypeLabel
            // 
            resources.ApplyResources(this.DeviceTypeLabel, "DeviceTypeLabel");
            this.DeviceTypeLabel.Name = "DeviceTypeLabel";
            // 
            // DeviceConfigurationReflectorPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeviceSettingsPropertySheet);
            this.Controls.Add(this.HeadingFlowPanel);
            this.Name = "DeviceConfigurationReflectorPanel";
            this.HeadingFlowPanel.ResumeLayout(false);
            this.HeadingFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel HeadingFlowPanel;
        private System.Windows.Forms.Label DeviceNameLabel;
        private System.Windows.Forms.Label DeviceTypeLabel;
        protected System.Windows.Forms.PropertyGrid DeviceSettingsPropertySheet;
    }
}
