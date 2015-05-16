namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class InstallNewDeviceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallNewDeviceDialog));
            this.ChooseMessageLabel = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.InstallButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.DeviceTypesListBox = new System.Windows.Forms.ListBox();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseMessageLabel
            // 
            resources.ApplyResources(this.ChooseMessageLabel, "ChooseMessageLabel");
            this.ChooseMessageLabel.Name = "ChooseMessageLabel";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.InstallButton);
            this.ButtonPanel.Controls.Add(this._CancelButton);
            resources.ApplyResources(this.ButtonPanel, "ButtonPanel");
            this.ButtonPanel.Name = "ButtonPanel";
            // 
            // InstallButton
            // 
            resources.ApplyResources(this.InstallButton, "InstallButton");
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.OnInstallClicked);
            // 
            // _CancelButton
            // 
            resources.ApplyResources(this._CancelButton, "_CancelButton");
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.UseVisualStyleBackColor = true;
            // 
            // DeviceTypesListBox
            // 
            resources.ApplyResources(this.DeviceTypesListBox, "DeviceTypesListBox");
            this.DeviceTypesListBox.FormattingEnabled = true;
            this.DeviceTypesListBox.Name = "DeviceTypesListBox";
            // 
            // InstallNewDeviceDialog
            // 
            this.AcceptButton = this.InstallButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.Controls.Add(this.DeviceTypesListBox);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.ChooseMessageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InstallNewDeviceDialog";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label ChooseMessageLabel;
        protected System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        protected System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.ListBox DeviceTypesListBox;
    }
}