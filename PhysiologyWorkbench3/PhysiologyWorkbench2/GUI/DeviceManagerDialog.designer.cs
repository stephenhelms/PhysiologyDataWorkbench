namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class DeviceManagerDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceManagerDialog));
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.DeviceListBox = new System.Windows.Forms.ListBox();
            this.DeviceListLabel = new System.Windows.Forms.Label();
            this.DeviceButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddDeviceButton = new System.Windows.Forms.Button();
            this.RemoveDeviceButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.DeviceConfigurationReflectorPanel = new RRLab.PhysiologyWorkbench.Devices.DeviceConfigurationReflectorPanel();
            this.ButtonPanel.SuspendLayout();
            this.SidePanel.SuspendLayout();
            this.DeviceButtonPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.SaveButton);
            this.ButtonPanel.Controls.Add(this._CancelButton);
            resources.ApplyResources(this.ButtonPanel, "ButtonPanel");
            this.ButtonPanel.Name = "ButtonPanel";
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveClicked);
            // 
            // _CancelButton
            // 
            resources.ApplyResources(this._CancelButton, "_CancelButton");
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this.OnCancelClicked);
            // 
            // SidePanel
            // 
            this.SidePanel.Controls.Add(this.DeviceListBox);
            this.SidePanel.Controls.Add(this.DeviceListLabel);
            this.SidePanel.Controls.Add(this.DeviceButtonPanel);
            resources.ApplyResources(this.SidePanel, "SidePanel");
            this.SidePanel.Name = "SidePanel";
            // 
            // DeviceListBox
            // 
            resources.ApplyResources(this.DeviceListBox, "DeviceListBox");
            this.DeviceListBox.FormattingEnabled = true;
            this.DeviceListBox.Name = "DeviceListBox";
            this.DeviceListBox.SelectedIndexChanged += new System.EventHandler(this.OnDeviceListSelectedIndexChanged);
            // 
            // DeviceListLabel
            // 
            resources.ApplyResources(this.DeviceListLabel, "DeviceListLabel");
            this.DeviceListLabel.Name = "DeviceListLabel";
            // 
            // DeviceButtonPanel
            // 
            this.DeviceButtonPanel.Controls.Add(this.AddDeviceButton);
            this.DeviceButtonPanel.Controls.Add(this.RemoveDeviceButton);
            resources.ApplyResources(this.DeviceButtonPanel, "DeviceButtonPanel");
            this.DeviceButtonPanel.Name = "DeviceButtonPanel";
            // 
            // AddDeviceButton
            // 
            resources.ApplyResources(this.AddDeviceButton, "AddDeviceButton");
            this.AddDeviceButton.Name = "AddDeviceButton";
            this.AddDeviceButton.UseVisualStyleBackColor = true;
            this.AddDeviceButton.Click += new System.EventHandler(this.OnAddDeviceClicked);
            // 
            // RemoveDeviceButton
            // 
            resources.ApplyResources(this.RemoveDeviceButton, "RemoveDeviceButton");
            this.RemoveDeviceButton.Name = "RemoveDeviceButton";
            this.RemoveDeviceButton.UseVisualStyleBackColor = true;
            this.RemoveDeviceButton.Click += new System.EventHandler(this.OnRemoveDeviceClicked);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.DeviceConfigurationReflectorPanel);
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            // 
            // DeviceConfigurationReflectorPanel
            // 
            this.DeviceConfigurationReflectorPanel.Device = null;
            resources.ApplyResources(this.DeviceConfigurationReflectorPanel, "DeviceConfigurationReflectorPanel");
            this.DeviceConfigurationReflectorPanel.Name = "DeviceConfigurationReflectorPanel";
            // 
            // DeviceManagerDialog
            // 
            this.AcceptButton = this.SaveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.ButtonPanel);
            this.Name = "DeviceManagerDialog";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            this.DeviceButtonPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button _CancelButton;
        protected System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        protected System.Windows.Forms.Panel SidePanel;
        protected System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ListBox DeviceListBox;
        private System.Windows.Forms.Label DeviceListLabel;
        protected System.Windows.Forms.FlowLayoutPanel DeviceButtonPanel;
        private System.Windows.Forms.Button AddDeviceButton;
        private System.Windows.Forms.Button RemoveDeviceButton;
        protected DeviceConfigurationReflectorPanel DeviceConfigurationReflectorPanel;
    }
}