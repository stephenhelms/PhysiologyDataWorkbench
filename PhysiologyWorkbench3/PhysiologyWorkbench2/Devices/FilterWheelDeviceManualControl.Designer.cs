namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class FilterWheelDeviceManualControl
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
            this.DeviceChooserControl = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.FilterWheelDeviceCompactControl = new RRLab.PhysiologyWorkbench.Devices.FilterWheelDeviceCompactControl();
            this.SuspendLayout();
            // 
            // DeviceChooserControl
            // 
            this.DeviceChooserControl.AutoSize = true;
            this.DeviceChooserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeviceChooserControl.ChoiceLabel = "Filter Wheel:";
            this.DeviceChooserControl.DeviceManager = null;
            this.DeviceChooserControl.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.FilterWheelDevice);
            this.DeviceChooserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeviceChooserControl.Location = new System.Drawing.Point(0, 0);
            this.DeviceChooserControl.MinimumSize = new System.Drawing.Size(200, 25);
            this.DeviceChooserControl.Name = "DeviceChooserControl";
            this.DeviceChooserControl.SelectedDevice = null;
            this.DeviceChooserControl.Size = new System.Drawing.Size(228, 25);
            this.DeviceChooserControl.TabIndex = 0;
            this.DeviceChooserControl.SelectedDeviceChanged += new System.EventHandler(this.DeviceChooserControl_SelectedDeviceChanged);
            // 
            // FilterWheelDeviceCompactControl
            // 
            this.FilterWheelDeviceCompactControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterWheelDeviceCompactControl.Enabled = false;
            this.FilterWheelDeviceCompactControl.FilterWheel = null;
            this.FilterWheelDeviceCompactControl.Location = new System.Drawing.Point(0, 25);
            this.FilterWheelDeviceCompactControl.Name = "FilterWheelDeviceCompactControl";
            this.FilterWheelDeviceCompactControl.Size = new System.Drawing.Size(228, 87);
            this.FilterWheelDeviceCompactControl.TabIndex = 1;
            // 
            // FilterWheelDeviceManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FilterWheelDeviceCompactControl);
            this.Controls.Add(this.DeviceChooserControl);
            this.Name = "FilterWheelDeviceManualControl";
            this.Size = new System.Drawing.Size(228, 112);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl DeviceChooserControl;
        private FilterWheelDeviceCompactControl FilterWheelDeviceCompactControl;
    }
}
