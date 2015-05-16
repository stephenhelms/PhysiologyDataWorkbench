namespace RRLab.PhysiologyWorkbench.Daq
{
    partial class OscilloscopeConfigurationControl
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SampleRateTextBox = new System.Windows.Forms.TextBox();
            this.UpdateTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChannelNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PhysicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.ChannelsListBox = new System.Windows.Forms.ListBox();
            this.ChannelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ProtocolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SampleRateTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.UpdateTimeTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChannelNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PhysicalChannelComboBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 92);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(182, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.AddButton);
            this.flowLayoutPanel1.Controls.Add(this.RemoveButton);
            this.flowLayoutPanel1.Controls.Add(this.UpdateButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 56);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(177, 29);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddButton.AutoSize = true;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Location = new System.Drawing.Point(3, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(36, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.OnAddChannelClicked);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveButton.Location = new System.Drawing.Point(45, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(57, 23);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.OnRemoveChannelClicked);
            // 
            // SampleRateTextBox
            // 
            this.SampleRateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "SampleRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.SampleRateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SampleRateTextBox.Location = new System.Drawing.Point(99, 117);
            this.SampleRateTextBox.Name = "SampleRateTextBox";
            this.SampleRateTextBox.Size = new System.Drawing.Size(81, 20);
            this.SampleRateTextBox.TabIndex = 9;
            // 
            // UpdateTimeTextBox
            // 
            this.UpdateTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProtocolBindingSource, "UpdateTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.UpdateTimeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateTimeTextBox.Location = new System.Drawing.Point(99, 91);
            this.UpdateTimeTextBox.Name = "UpdateTimeTextBox";
            this.UpdateTimeTextBox.Size = new System.Drawing.Size(81, 20);
            this.UpdateTimeTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Channel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChannelNameTextBox
            // 
            this.ChannelNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChannelNameTextBox.Location = new System.Drawing.Point(99, 3);
            this.ChannelNameTextBox.Name = "ChannelNameTextBox";
            this.ChannelNameTextBox.Size = new System.Drawing.Size(81, 20);
            this.ChannelNameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Update Time (ms)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sample Rate (Hz)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PhysicalChannelComboBox
            // 
            this.PhysicalChannelComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhysicalChannelComboBox.FormattingEnabled = true;
            this.PhysicalChannelComboBox.Location = new System.Drawing.Point(99, 29);
            this.PhysicalChannelComboBox.Name = "PhysicalChannelComboBox";
            this.PhysicalChannelComboBox.Size = new System.Drawing.Size(81, 21);
            this.PhysicalChannelComboBox.TabIndex = 11;
            // 
            // ChannelsListBox
            // 
            this.ChannelsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChannelsListBox.FormattingEnabled = true;
            this.ChannelsListBox.Location = new System.Drawing.Point(0, 0);
            this.ChannelsListBox.Name = "ChannelsListBox";
            this.ChannelsListBox.Size = new System.Drawing.Size(182, 82);
            this.ChannelsListBox.TabIndex = 1;
            this.ChannelsListBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedChannelChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.AutoSize = true;
            this.UpdateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UpdateButton.Location = new System.Drawing.Point(108, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(52, 23);
            this.UpdateButton.TabIndex = 8;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.OnUpdateClicked);
            // 
            // ProtocolBindingSource
            // 
            this.ProtocolBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.OscilloscopeProtocol);
            // 
            // OscilloscopeConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ChannelsListBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Enabled = false;
            this.Name = "OscilloscopeConfigurationControl";
            this.Size = new System.Drawing.Size(182, 232);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChannelNameTextBox;
        private System.Windows.Forms.ListBox ChannelsListBox;
        private System.Windows.Forms.TextBox SampleRateTextBox;
        private System.Windows.Forms.TextBox UpdateTimeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ComboBox PhysicalChannelComboBox;
        private System.Windows.Forms.BindingSource ProtocolBindingSource;
        private System.Windows.Forms.BindingSource ChannelsBindingSource;
        private System.Windows.Forms.Button UpdateButton;
    }
}
