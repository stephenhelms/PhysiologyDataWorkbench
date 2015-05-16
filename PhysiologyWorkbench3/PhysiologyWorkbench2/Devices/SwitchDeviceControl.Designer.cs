namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class SwitchDeviceControl
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.OnButton = new System.Windows.Forms.Button();
            this.OffButton = new System.Windows.Forms.Button();
            this.deviceChooserControl1 = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.OnButton);
            this.flowLayoutPanel1.Controls.Add(this.OffButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // OnButton
            // 
            this.OnButton.AutoSize = true;
            this.OnButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OnButton.Location = new System.Drawing.Point(3, 3);
            this.OnButton.Name = "OnButton";
            this.OnButton.Size = new System.Drawing.Size(31, 23);
            this.OnButton.TabIndex = 0;
            this.OnButton.Text = "On";
            this.OnButton.UseVisualStyleBackColor = true;
            this.OnButton.Click += new System.EventHandler(this.OnButton_Click);
            // 
            // OffButton
            // 
            this.OffButton.AutoSize = true;
            this.OffButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OffButton.Location = new System.Drawing.Point(40, 3);
            this.OffButton.Name = "OffButton";
            this.OffButton.Size = new System.Drawing.Size(31, 23);
            this.OffButton.TabIndex = 1;
            this.OffButton.Text = "Off";
            this.OffButton.UseVisualStyleBackColor = true;
            this.OffButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // deviceChooserControl1
            // 
            this.deviceChooserControl1.AutoSize = true;
            this.deviceChooserControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deviceChooserControl1.ChoiceLabel = "Switch";
            this.deviceChooserControl1.DeviceManager = null;
            this.deviceChooserControl1.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.SwitchDevice);
            this.deviceChooserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.deviceChooserControl1.Location = new System.Drawing.Point(0, 0);
            this.deviceChooserControl1.MaximumSize = new System.Drawing.Size(200, 0);
            this.deviceChooserControl1.MinimumSize = new System.Drawing.Size(200, 25);
            this.deviceChooserControl1.Name = "deviceChooserControl1";
            this.deviceChooserControl1.SelectedDevice = null;
            this.deviceChooserControl1.Size = new System.Drawing.Size(200, 25);
            this.deviceChooserControl1.TabIndex = 1;
            // 
            // SwitchDeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.deviceChooserControl1);
            this.Name = "SwitchDeviceControl";
            this.Size = new System.Drawing.Size(212, 57);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl deviceChooserControl1;
        private System.Windows.Forms.Button OnButton;
        private System.Windows.Forms.Button OffButton;
    }
}
