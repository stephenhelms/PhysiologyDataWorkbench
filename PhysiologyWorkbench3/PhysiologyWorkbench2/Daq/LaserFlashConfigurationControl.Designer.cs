namespace RRLab.PhysiologyWorkbench.Daq
{
    partial class LaserFlashConfigurationControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FilterWheelChooserControl = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProtocolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.PostFlashCollectionTimeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PreFlashCollectionTimeTextBox = new System.Windows.Forms.TextBox();
            this.LaserChooser = new RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl();
            this.CompactFilterWheelConfigurationControl = new RRLab.PhysiologyWorkbench.GUI.CompactFilterWheelConfigurationControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.FilterWheelChooserControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PostFlashCollectionTimeTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PreFlashCollectionTimeTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LaserChooser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CompactFilterWheelConfigurationControl, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 157);
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
            this.FilterWheelChooserControl.Size = new System.Drawing.Size(257, 25);
            this.FilterWheelChooserControl.TabIndex = 9;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // ProtocolBindingSource
            // 
            this.ProtocolBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.LaserFlashProtocol);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "PostFlash (ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PostFlashCollectionTimeTextBox
            // 
            this.PostFlashCollectionTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "PostFlashCollectionTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.PostFlashCollectionTimeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PostFlashCollectionTimeTextBox.Location = new System.Drawing.Point(84, 122);
            this.PostFlashCollectionTimeTextBox.Name = "PostFlashCollectionTimeTextBox";
            this.PostFlashCollectionTimeTextBox.Size = new System.Drawing.Size(176, 20);
            this.PostFlashCollectionTimeTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "PreFlash (ms)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PreFlashCollectionTimeTextBox
            // 
            this.PreFlashCollectionTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "PreFlashCollectionTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.PreFlashCollectionTimeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreFlashCollectionTimeTextBox.Location = new System.Drawing.Point(84, 96);
            this.PreFlashCollectionTimeTextBox.Name = "PreFlashCollectionTimeTextBox";
            this.PreFlashCollectionTimeTextBox.Size = new System.Drawing.Size(176, 20);
            this.PreFlashCollectionTimeTextBox.TabIndex = 2;
            // 
            // LaserChooser
            // 
            this.LaserChooser.AutoSize = true;
            this.LaserChooser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LaserChooser.ChoiceLabel = "Laser";
            this.tableLayoutPanel1.SetColumnSpan(this.LaserChooser, 2);
            this.LaserChooser.DataBindings.Add(new System.Windows.Forms.Binding("DeviceManager", this.ProgramBindingSource, "DeviceManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LaserChooser.DataBindings.Add(new System.Windows.Forms.Binding("SelectedDevice", this.ProtocolBindingSource, "Laser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LaserChooser.DeviceManager = null;
            this.LaserChooser.DeviceType = typeof(RRLab.PhysiologyWorkbench.Devices.SpectraPhysicsNitrogenLaser);
            this.LaserChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LaserChooser.Location = new System.Drawing.Point(3, 3);
            this.LaserChooser.MinimumSize = new System.Drawing.Size(200, 25);
            this.LaserChooser.Name = "LaserChooser";
            this.LaserChooser.SelectedDevice = null;
            this.LaserChooser.Size = new System.Drawing.Size(257, 25);
            this.LaserChooser.TabIndex = 7;
            this.LaserChooser.SelectedDeviceChanged += new System.EventHandler(this.OnSelectedLaserChanged);
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
            this.CompactFilterWheelConfigurationControl.Size = new System.Drawing.Size(257, 25);
            this.CompactFilterWheelConfigurationControl.TabIndex = 10;
            // 
            // LaserFlashConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LaserFlashConfigurationControl";
            this.Size = new System.Drawing.Size(263, 157);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox PostFlashCollectionTimeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PreFlashCollectionTimeTextBox;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl LaserChooser;
        private RRLab.PhysiologyWorkbench.GUI.DeviceChooserControl FilterWheelChooserControl;
        private System.Windows.Forms.BindingSource ProtocolBindingSource;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private RRLab.PhysiologyWorkbench.GUI.CompactFilterWheelConfigurationControl CompactFilterWheelConfigurationControl;
    }
}
