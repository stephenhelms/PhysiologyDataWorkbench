namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class FilterWheelManualControl
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
            this.DeviceChooserControl = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.FilterWheelPositionControl = new RRLab.PhysiologyWorkbench.Devices.FilterWheelPositionControl();
            this.SuspendLayout();
            // 
            // DeviceChooserControl
            // 
            this.DeviceChooserControl.AutoSize = true;
            this.DeviceChooserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeviceChooserControl.ChoiceLabel = "Filter Wheel";
            this.DeviceChooserControl.DeviceManager = null;
            this.DeviceChooserControl.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.FilterWheel);
            this.DeviceChooserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeviceChooserControl.Location = new System.Drawing.Point(0, 0);
            this.DeviceChooserControl.MinimumSize = new System.Drawing.Size(200, 25);
            this.DeviceChooserControl.Name = "DeviceChooserControl";
            this.DeviceChooserControl.SelectedDevice = null;
            this.DeviceChooserControl.Size = new System.Drawing.Size(227, 25);
            this.DeviceChooserControl.TabIndex = 1;
            this.DeviceChooserControl.SelectedDeviceChanged += new System.EventHandler(this.OnSelectedDeviceChanged);
            // 
            // FilterWheelPositionControl
            // 
            this.FilterWheelPositionControl.CurrentPosition = -1;
            this.FilterWheelPositionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterWheelPositionControl.FilterWheel = null;
            this.FilterWheelPositionControl.Location = new System.Drawing.Point(0, 25);
            this.FilterWheelPositionControl.Name = "FilterWheelPositionControl";
            this.FilterWheelPositionControl.Size = new System.Drawing.Size(227, 271);
            this.FilterWheelPositionControl.TabIndex = 2;
            // 
            // FilterWheelManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FilterWheelPositionControl);
            this.Controls.Add(this.DeviceChooserControl);
            this.Name = "FilterWheelManualControl";
            this.Size = new System.Drawing.Size(227, 296);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DeviceChooserControl DeviceChooserControl;
        private RRLab.PhysiologyWorkbench.Devices.FilterWheelPositionControl FilterWheelPositionControl;
    }
}
