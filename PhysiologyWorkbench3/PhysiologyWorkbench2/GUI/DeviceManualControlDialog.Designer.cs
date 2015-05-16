namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class DeviceManualControlDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShutterControl = new RRLab.PhysiologyWorkbench.GUI.ShutterControl();
            this.LasersGroupBox = new System.Windows.Forms.GroupBox();
            this.LaserManualControl = new RRLab.PhysiologyWorkbench.GUI.LaserManualControl();
            this.FilterWheelGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.switchDeviceControl1 = new RRLab.PhysiologyWorkbench.Devices.SwitchDeviceControl();
            this.filterWheelDeviceManualControl1 = new RRLab.PhysiologyWorkbench.Devices.FilterWheelDeviceManualControl();
            this.groupBox1.SuspendLayout();
            this.LasersGroupBox.SuspendLayout();
            this.FilterWheelGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.ShutterControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shutters";
            // 
            // ShutterControl
            // 
            this.ShutterControl.AutoSize = true;
            this.ShutterControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ShutterControl.DeviceManager = null;
            this.ShutterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShutterControl.Location = new System.Drawing.Point(3, 16);
            this.ShutterControl.Name = "ShutterControl";
            this.ShutterControl.Shutter = null;
            this.ShutterControl.Size = new System.Drawing.Size(292, 56);
            this.ShutterControl.TabIndex = 0;
            // 
            // LasersGroupBox
            // 
            this.LasersGroupBox.AutoSize = true;
            this.LasersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LasersGroupBox.Controls.Add(this.LaserManualControl);
            this.LasersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LasersGroupBox.Location = new System.Drawing.Point(3, 151);
            this.LasersGroupBox.Name = "LasersGroupBox";
            this.LasersGroupBox.Size = new System.Drawing.Size(298, 75);
            this.LasersGroupBox.TabIndex = 1;
            this.LasersGroupBox.TabStop = false;
            this.LasersGroupBox.Text = "Lasers";
            // 
            // LaserManualControl
            // 
            this.LaserManualControl.AutoSize = true;
            this.LaserManualControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LaserManualControl.DeviceManager = null;
            this.LaserManualControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LaserManualControl.Enabled = false;
            this.LaserManualControl.Laser = null;
            this.LaserManualControl.Location = new System.Drawing.Point(3, 16);
            this.LaserManualControl.Name = "LaserManualControl";
            this.LaserManualControl.Size = new System.Drawing.Size(292, 56);
            this.LaserManualControl.TabIndex = 0;
            // 
            // FilterWheelGroupBox
            // 
            this.FilterWheelGroupBox.Controls.Add(this.filterWheelDeviceManualControl1);
            this.FilterWheelGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterWheelGroupBox.Location = new System.Drawing.Point(3, 226);
            this.FilterWheelGroupBox.Name = "FilterWheelGroupBox";
            this.FilterWheelGroupBox.Size = new System.Drawing.Size(298, 137);
            this.FilterWheelGroupBox.TabIndex = 2;
            this.FilterWheelGroupBox.TabStop = false;
            this.FilterWheelGroupBox.Text = "Filter Wheels";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.switchDeviceControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 73);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Switch Devices";
            // 
            // switchDeviceControl1
            // 
            this.switchDeviceControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.switchDeviceControl1.DeviceManager = null;
            this.switchDeviceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchDeviceControl1.Location = new System.Drawing.Point(3, 16);
            this.switchDeviceControl1.Name = "switchDeviceControl1";
            this.switchDeviceControl1.Size = new System.Drawing.Size(292, 54);
            this.switchDeviceControl1.TabIndex = 0;
            // 
            // filterWheelDeviceManualControl1
            // 
            this.filterWheelDeviceManualControl1.DeviceManager = null;
            this.filterWheelDeviceManualControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterWheelDeviceManualControl1.Location = new System.Drawing.Point(3, 16);
            this.filterWheelDeviceManualControl1.Name = "filterWheelDeviceManualControl1";
            this.filterWheelDeviceManualControl1.Size = new System.Drawing.Size(292, 118);
            this.filterWheelDeviceManualControl1.TabIndex = 0;
            // 
            // DeviceManualControlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 373);
            this.Controls.Add(this.FilterWheelGroupBox);
            this.Controls.Add(this.LasersGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DeviceManualControlDialog";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Manual Device Control";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LasersGroupBox.ResumeLayout(false);
            this.LasersGroupBox.PerformLayout();
            this.FilterWheelGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ShutterControl ShutterControl;
        private System.Windows.Forms.GroupBox LasersGroupBox;
        private LaserManualControl LaserManualControl;
        private System.Windows.Forms.GroupBox FilterWheelGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private RRLab.PhysiologyWorkbench.Devices.SwitchDeviceControl switchDeviceControl1;
        private RRLab.PhysiologyWorkbench.Devices.FilterWheelDeviceManualControl filterWheelDeviceManualControl1;
    }
}