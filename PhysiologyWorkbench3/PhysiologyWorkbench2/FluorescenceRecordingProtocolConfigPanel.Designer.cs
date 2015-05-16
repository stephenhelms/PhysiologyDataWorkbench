namespace RRLab.PhysiologyWorkbench.Daq
{
    partial class LaserFluorescenceRecordingProtocolConfigPanel
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
            this.laserDeviceChooserControl = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.photodiodeDeviceChooserControl1 = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AcquisitionLengthTextBox = new System.Windows.Forms.TextBox();
            this.FlashRateLabel = new System.Windows.Forms.Label();
            this.AcquisitionLengthLabel = new System.Windows.Forms.Label();
            this.FlashRateTextBox = new System.Windows.Forms.TextBox();
            this.DiscardDataBetweenFlashesCheckBox = new System.Windows.Forms.CheckBox();
            this.photodiodeDeviceChooserControl2 = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.ProtocolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DevicesGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.laserDeviceChooserControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.photodiodeDeviceChooserControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.photodiodeDeviceChooserControl2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 93);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // photodiodeDeviceChooserControl1
            // 
            this.photodiodeDeviceChooserControl1.AutoSize = true;
            this.photodiodeDeviceChooserControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.photodiodeDeviceChooserControl1.ChoiceLabel = "Photodiode 1";
            this.photodiodeDeviceChooserControl1.DataBindings.Add(new System.Windows.Forms.Binding("DeviceManager", this.ProgramBindingSource, "DeviceManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.photodiodeDeviceChooserControl1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedDevice", this.ProtocolBindingSource, "Photodiode1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.photodiodeDeviceChooserControl1.DeviceManager = null;
            this.photodiodeDeviceChooserControl1.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.Photodiode);
            this.photodiodeDeviceChooserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photodiodeDeviceChooserControl1.Location = new System.Drawing.Point(3, 34);
            this.photodiodeDeviceChooserControl1.MinimumSize = new System.Drawing.Size(200, 25);
            this.photodiodeDeviceChooserControl1.Name = "photodiodeDeviceChooserControl1";
            this.photodiodeDeviceChooserControl1.SelectedDevice = null;
            this.photodiodeDeviceChooserControl1.Size = new System.Drawing.Size(200, 25);
            this.photodiodeDeviceChooserControl1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 94);
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
            this.tableLayoutPanel2.Controls.Add(this.DiscardDataBetweenFlashesCheckBox, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(204, 75);
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
            // 
            // DiscardDataBetweenFlashesCheckBox
            // 
            this.DiscardDataBetweenFlashesCheckBox.AutoSize = true;
            this.DiscardDataBetweenFlashesCheckBox.Checked = true;
            this.DiscardDataBetweenFlashesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.DiscardDataBetweenFlashesCheckBox, 2);
            this.DiscardDataBetweenFlashesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ProtocolBindingSource, "DiscardDataBetweenFlashes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DiscardDataBetweenFlashesCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiscardDataBetweenFlashesCheckBox.Location = new System.Drawing.Point(3, 55);
            this.DiscardDataBetweenFlashesCheckBox.Name = "DiscardDataBetweenFlashesCheckBox";
            this.DiscardDataBetweenFlashesCheckBox.Size = new System.Drawing.Size(198, 17);
            this.DiscardDataBetweenFlashesCheckBox.TabIndex = 6;
            this.DiscardDataBetweenFlashesCheckBox.Text = "Discard Data Between Flashes";
            this.DiscardDataBetweenFlashesCheckBox.UseVisualStyleBackColor = true;
            // 
            // photodiodeDeviceChooserControl2
            // 
            this.photodiodeDeviceChooserControl2.AutoSize = true;
            this.photodiodeDeviceChooserControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.photodiodeDeviceChooserControl2.ChoiceLabel = "Photodiode 2";
            this.photodiodeDeviceChooserControl2.DataBindings.Add(new System.Windows.Forms.Binding("DeviceManager", this.ProgramBindingSource, "DeviceManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.photodiodeDeviceChooserControl2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedDevice", this.ProtocolBindingSource, "Photodiode2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.photodiodeDeviceChooserControl2.DeviceManager = null;
            this.photodiodeDeviceChooserControl2.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.Photodiode);
            this.photodiodeDeviceChooserControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photodiodeDeviceChooserControl2.Location = new System.Drawing.Point(3, 65);
            this.photodiodeDeviceChooserControl2.MinimumSize = new System.Drawing.Size(200, 25);
            this.photodiodeDeviceChooserControl2.Name = "photodiodeDeviceChooserControl2";
            this.photodiodeDeviceChooserControl2.SelectedDevice = null;
            this.photodiodeDeviceChooserControl2.Size = new System.Drawing.Size(200, 25);
            this.photodiodeDeviceChooserControl2.TabIndex = 3;
            // 
            // ProtocolBindingSource
            // 
            this.ProtocolBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.LaserFluorescenceRecordingProtocol);
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // LaserFluorescenceRecordingProtocolConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DevicesGroupBox);
            this.Name = "LaserFluorescenceRecordingProtocolConfigPanel";
            this.Size = new System.Drawing.Size(210, 210);
            this.DevicesGroupBox.ResumeLayout(false);
            this.DevicesGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DevicesGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl laserDeviceChooserControl;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl photodiodeDeviceChooserControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox AcquisitionLengthTextBox;
        private System.Windows.Forms.Label FlashRateLabel;
        private System.Windows.Forms.Label AcquisitionLengthLabel;
        private System.Windows.Forms.TextBox FlashRateTextBox;
        private System.Windows.Forms.CheckBox DiscardDataBetweenFlashesCheckBox;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl photodiodeDeviceChooserControl2;
        private System.Windows.Forms.BindingSource ProtocolBindingSource;
        private System.Windows.Forms.BindingSource ProgramBindingSource;

    }
}
