namespace RRLab.PhysiologyWorkbench.Daq
{
    partial class PulsedLaserLightRecordingProtocolConfigPanel
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
            this.components = new System.ComponentModel.Container();
            this.DevicesGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FilterWheelChooserControl = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProtocolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CompactFilterWheelConfigurationControl = new RRLab.PhysiologyWorkbench.GUI.CompactFilterWheelConfigurationControl();
            this.laserDeviceChooserControl = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AcquisitionLengthTextBox = new System.Windows.Forms.TextBox();
            this.FlashRateLabel = new System.Windows.Forms.Label();
            this.AcquisitionLengthLabel = new System.Windows.Forms.Label();
            this.FlashRateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DevicesGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DevicesGroupBox
            // 
            this.DevicesGroupBox.AutoSize = true;
            this.DevicesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DevicesGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.DevicesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DevicesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.DevicesGroupBox.Name = "DevicesGroupBox";
            this.DevicesGroupBox.Size = new System.Drawing.Size(210, 112);
            this.DevicesGroupBox.TabIndex = 0;
            this.DevicesGroupBox.TabStop = false;
            this.DevicesGroupBox.Text = "Devices";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.FilterWheelChooserControl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CompactFilterWheelConfigurationControl, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.laserDeviceChooserControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 93);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FilterWheelChooserControl
            // 
            this.FilterWheelChooserControl.AutoSize = true;
            this.FilterWheelChooserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterWheelChooserControl.ChoiceLabel = "Filter Wheel";
            this.tableLayoutPanel1.SetColumnSpan(this.FilterWheelChooserControl, 2);
            this.FilterWheelChooserControl.DataBindings.Add(new System.Windows.Forms.Binding("DeviceManager", this.ProgramBindingSource, "DeviceManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FilterWheelChooserControl.DataBindings.Add(new System.Windows.Forms.Binding("SelectedDevice", this.ProtocolBindingSource, "FilterWheel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FilterWheelChooserControl.DeviceManager = null;
            this.FilterWheelChooserControl.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.FilterWheelDevice);
            this.FilterWheelChooserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterWheelChooserControl.Location = new System.Drawing.Point(3, 34);
            this.FilterWheelChooserControl.MinimumSize = new System.Drawing.Size(200, 25);
            this.FilterWheelChooserControl.Name = "FilterWheelChooserControl";
            this.FilterWheelChooserControl.SelectedDevice = null;
            this.FilterWheelChooserControl.Size = new System.Drawing.Size(200, 25);
            this.FilterWheelChooserControl.TabIndex = 11;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // ProtocolBindingSource
            // 
            this.ProtocolBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.LaserFluorescenceRecordingProtocol);
            // 
            // CompactFilterWheelConfigurationControl
            // 
            this.CompactFilterWheelConfigurationControl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.CompactFilterWheelConfigurationControl, 2);
            this.CompactFilterWheelConfigurationControl.DataBindings.Add(new System.Windows.Forms.Binding("FilterWheel", this.ProtocolBindingSource, "FilterWheel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CompactFilterWheelConfigurationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompactFilterWheelConfigurationControl.FilterWheel = null;
            this.CompactFilterWheelConfigurationControl.Location = new System.Drawing.Point(3, 65);
            this.CompactFilterWheelConfigurationControl.MinimumSize = new System.Drawing.Size(0, 25);
            this.CompactFilterWheelConfigurationControl.Name = "CompactFilterWheelConfigurationControl";
            this.CompactFilterWheelConfigurationControl.Size = new System.Drawing.Size(200, 25);
            this.CompactFilterWheelConfigurationControl.TabIndex = 12;
            // 
            // laserDeviceChooserControl
            // 
            this.laserDeviceChooserControl.AutoSize = true;
            this.laserDeviceChooserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.laserDeviceChooserControl.ChoiceLabel = "Laser";
            this.laserDeviceChooserControl.DataBindings.Add(new System.Windows.Forms.Binding("DeviceManager", this.ProgramBindingSource, "DeviceManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.laserDeviceChooserControl.DataBindings.Add(new System.Windows.Forms.Binding("SelectedDevice", this.ProtocolBindingSource, "Laser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.laserDeviceChooserControl.DeviceManager = null;
            this.laserDeviceChooserControl.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.SpectraPhysicsNitrogenLaser);
            this.laserDeviceChooserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laserDeviceChooserControl.Location = new System.Drawing.Point(3, 3);
            this.laserDeviceChooserControl.MinimumSize = new System.Drawing.Size(200, 25);
            this.laserDeviceChooserControl.Name = "laserDeviceChooserControl";
            this.laserDeviceChooserControl.SelectedDevice = null;
            this.laserDeviceChooserControl.Size = new System.Drawing.Size(200, 25);
            this.laserDeviceChooserControl.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 97);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.76471F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.23529F));
            this.tableLayoutPanel2.Controls.Add(this.AcquisitionLengthTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.FlashRateLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.AcquisitionLengthLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FlashRateTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(204, 78);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // AcquisitionLengthTextBox
            // 
            this.AcquisitionLengthTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AcquisitionLengthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "AcquisitionLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.AcquisitionLengthTextBox.Location = new System.Drawing.Point(129, 29);
            this.AcquisitionLengthTextBox.Name = "AcquisitionLengthTextBox";
            this.AcquisitionLengthTextBox.Size = new System.Drawing.Size(72, 20);
            this.AcquisitionLengthTextBox.TabIndex = 3;
            this.AcquisitionLengthTextBox.Text = "10000";
            // 
            // FlashRateLabel
            // 
            this.FlashRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlashRateLabel.AutoSize = true;
            this.FlashRateLabel.Location = new System.Drawing.Point(3, 6);
            this.FlashRateLabel.Name = "FlashRateLabel";
            this.FlashRateLabel.Size = new System.Drawing.Size(83, 13);
            this.FlashRateLabel.TabIndex = 0;
            this.FlashRateLabel.Text = "Flash Rate (Hz):";
            this.FlashRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AcquisitionLengthLabel
            // 
            this.AcquisitionLengthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AcquisitionLengthLabel.AutoSize = true;
            this.AcquisitionLengthLabel.Location = new System.Drawing.Point(3, 32);
            this.AcquisitionLengthLabel.Name = "AcquisitionLengthLabel";
            this.AcquisitionLengthLabel.Size = new System.Drawing.Size(119, 13);
            this.AcquisitionLengthLabel.TabIndex = 1;
            this.AcquisitionLengthLabel.Text = "Acquisition Length (ms):";
            this.AcquisitionLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlashRateTextBox
            // 
            this.FlashRateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlashRateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "LaserPulseFrequency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.FlashRateTextBox.Location = new System.Drawing.Point(129, 3);
            this.FlashRateTextBox.Name = "FlashRateTextBox";
            this.FlashRateTextBox.Size = new System.Drawing.Size(72, 20);
            this.FlashRateTextBox.TabIndex = 2;
            this.FlashRateTextBox.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sample Rate (Hz):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "ProcessedSampleRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(129, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "2500";
            // 
            // PulsedLaserLightRecordingProtocolConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DevicesGroupBox);
            this.Name = "PulsedLaserLightRecordingProtocolConfigPanel";
            this.Size = new System.Drawing.Size(210, 215);
            this.DevicesGroupBox.ResumeLayout(false);
            this.DevicesGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DevicesGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl laserDeviceChooserControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox AcquisitionLengthTextBox;
        private System.Windows.Forms.Label FlashRateLabel;
        private System.Windows.Forms.Label AcquisitionLengthLabel;
        private System.Windows.Forms.TextBox FlashRateTextBox;
        private System.Windows.Forms.BindingSource ProtocolBindingSource;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl FilterWheelChooserControl;
        private RRLab.PhysiologyWorkbench.GUI.CompactFilterWheelConfigurationControl CompactFilterWheelConfigurationControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;

    }
}
