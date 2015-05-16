namespace RRLab.PhysiologyWorkbench
{
    partial class RecordingInfoControl
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
            this.DescriptionTextbox = new System.Windows.Forms.TextBox();
            this.RecordingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.CreatedTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BathSolutionComboBox = new System.Windows.Forms.ComboBox();
            this.PipetteSolutionComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.DescriptionTextbox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.TitleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TitleTextbox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CreatedTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.BathSolutionComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PipetteSolutionComboBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 133);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DescriptionTextbox
            // 
            this.DescriptionTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DescriptionTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionTextbox.Location = new System.Drawing.Point(298, 29);
            this.DescriptionTextbox.Multiline = true;
            this.DescriptionTextbox.Name = "DescriptionTextbox";
            this.tableLayoutPanel1.SetRowSpan(this.DescriptionTextbox, 4);
            this.DescriptionTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextbox.Size = new System.Drawing.Size(215, 101);
            this.DescriptionTextbox.TabIndex = 6;
            // 
            // RecordingBindingSource
            // 
            this.RecordingBindingSource.AllowNew = false;
            this.RecordingBindingSource.DataMember = "Recordings";
            this.RecordingBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet);
            this.RecordingBindingSource.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.OnDataBinding);
            this.RecordingBindingSource.PositionChanged += new System.EventHandler(this.OnRecordingPositionChanged);
            this.RecordingBindingSource.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.OnDataBindingError);
            this.RecordingBindingSource.CurrentItemChanged += new System.EventHandler(this.OnRecordingUpdated);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Location = new System.Drawing.Point(3, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(89, 26);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recorded";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TitleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTextbox.Location = new System.Drawing.Point(98, 3);
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(194, 20);
            this.TitleTextbox.TabIndex = 3;
            // 
            // CreatedTimePicker
            // 
            this.CreatedTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.RecordingBindingSource, "Recorded", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CreatedTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatedTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.CreatedTimePicker.Location = new System.Drawing.Point(98, 29);
            this.CreatedTimePicker.Name = "CreatedTimePicker";
            this.CreatedTimePicker.Size = new System.Drawing.Size(194, 20);
            this.CreatedTimePicker.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(298, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bath Solution";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "Pipette Solution";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BathSolutionComboBox
            // 
            this.BathSolutionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingBindingSource, "BathSolution", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BathSolutionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BathSolutionComboBox.DropDownWidth = 350;
            this.BathSolutionComboBox.FormattingEnabled = true;
            this.BathSolutionComboBox.Items.AddRange(new object[] {
            "1 mM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM a" +
                "lanine pH 7.15",
            "0 mM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM a" +
                "lanine pH 7.15",
            "50 uM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM " +
                "alanine pH 7.15",
            "100 uM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM" +
                " alanine pH 7.15",
            "200 uM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM" +
                " alanine pH 7.15",
            "0.5 mM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM" +
                " alanine pH 7.15",
            "5 mM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM a" +
                "lanine pH 7.15",
            "10 mM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM " +
                "alanine pH 7.15",
            "20 mM CaCl2, 120 mM NaCl, 5 mM KCl, 10 mM HEPES, 4 mM MgCl2, 24 mM proline, 5 mM " +
                "alanine pH 7.15"});
            this.BathSolutionComboBox.Location = new System.Drawing.Point(98, 55);
            this.BathSolutionComboBox.Name = "BathSolutionComboBox";
            this.BathSolutionComboBox.Size = new System.Drawing.Size(194, 21);
            this.BathSolutionComboBox.TabIndex = 13;
            // 
            // PipetteSolutionComboBox
            // 
            this.PipetteSolutionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RecordingBindingSource, "PipetteSolution", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PipetteSolutionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PipetteSolutionComboBox.DropDownWidth = 350;
            this.PipetteSolutionComboBox.FormattingEnabled = true;
            this.PipetteSolutionComboBox.Items.AddRange(new object[] {
            "95 mM KGluconate, 40 mM KCl, 10 mM HEPES, 2 mM MgCl2, 4 mM MgATP, 0.5 mM NaGTP, 1" +
                " mM NAD+, pH 7.15"});
            this.PipetteSolutionComboBox.Location = new System.Drawing.Point(98, 82);
            this.PipetteSolutionComboBox.Name = "PipetteSolutionComboBox";
            this.PipetteSolutionComboBox.Size = new System.Drawing.Size(194, 21);
            this.PipetteSolutionComboBox.TabIndex = 14;
            // 
            // RecordingInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecordingInfoControl";
            this.Size = new System.Drawing.Size(516, 133);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.DateTimePicker CreatedTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource RecordingBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BathSolutionComboBox;
        private System.Windows.Forms.ComboBox PipetteSolutionComboBox;
        private System.Windows.Forms.TextBox DescriptionTextbox;
    }
}
