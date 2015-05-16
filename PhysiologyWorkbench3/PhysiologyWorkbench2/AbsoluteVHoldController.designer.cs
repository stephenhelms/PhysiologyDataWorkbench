namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class AbsoluteVHoldController
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.amplifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.VHoldLabel = new System.Windows.Forms.Label();
            this.VHoldSlider = new NationalInstruments.UI.WindowsForms.Slide();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SetZeroVHoldButton = new System.Windows.Forms.Button();
            this.SetBreakInVHoldButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VHoldSlider)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amplifierToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 26);
            // 
            // amplifierToolStripMenuItem
            // 
            this.amplifierToolStripMenuItem.Name = "amplifierToolStripMenuItem";
            this.amplifierToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.amplifierToolStripMenuItem.Text = "&Amplifier";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.VHoldLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(105, 109);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "VHold (mV)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VHoldLabel
            // 
            this.VHoldLabel.AutoSize = true;
            this.VHoldLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VHoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VHoldLabel.Location = new System.Drawing.Point(3, 16);
            this.VHoldLabel.Name = "VHoldLabel";
            this.VHoldLabel.Size = new System.Drawing.Size(99, 93);
            this.VHoldLabel.TabIndex = 8;
            this.VHoldLabel.Text = "0";
            this.VHoldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VHoldSlider
            // 
            this.VHoldSlider.AutoDivisionSpacing = false;
            this.VHoldSlider.CoercionInterval = 5;
            this.VHoldSlider.CoercionMode = NationalInstruments.UI.NumericCoercionMode.ToInterval;
            this.VHoldSlider.DataBindings.Add(new System.Windows.Forms.Binding("FillColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "AccentColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VHoldSlider.DataBindings.Add(new System.Windows.Forms.Binding("FillBackColor", global::RRLab.PhysiologyWorkbench.Properties.Settings.Default, "AccentBackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VHoldSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VHoldSlider.FillBackColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.AccentBackgroundColor;
            this.VHoldSlider.FillColor = global::RRLab.PhysiologyWorkbench.Properties.Settings.Default.AccentColor;
            this.VHoldSlider.Location = new System.Drawing.Point(105, 29);
            this.VHoldSlider.Name = "VHoldSlider";
            this.VHoldSlider.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.VHoldSlider.Range = new NationalInstruments.UI.Range(-100, 60);
            this.VHoldSlider.ScalePosition = NationalInstruments.UI.NumericScalePosition.Bottom;
            this.VHoldSlider.Size = new System.Drawing.Size(415, 80);
            this.VHoldSlider.TabIndex = 12;
            this.VHoldSlider.ValueChanged += new System.EventHandler(this.VHoldSlider_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.SetZeroVHoldButton);
            this.flowLayoutPanel1.Controls.Add(this.SetBreakInVHoldButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(105, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(415, 29);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // SetZeroVHoldButton
            // 
            this.SetZeroVHoldButton.AutoSize = true;
            this.SetZeroVHoldButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetZeroVHoldButton.Location = new System.Drawing.Point(3, 3);
            this.SetZeroVHoldButton.Name = "SetZeroVHoldButton";
            this.SetZeroVHoldButton.Size = new System.Drawing.Size(41, 23);
            this.SetZeroVHoldButton.TabIndex = 0;
            this.SetZeroVHoldButton.Text = "0 mV";
            this.SetZeroVHoldButton.UseVisualStyleBackColor = true;
            this.SetZeroVHoldButton.Click += new System.EventHandler(this.OnSetZeroVHoldClicked);
            // 
            // SetBreakInVHoldButton
            // 
            this.SetBreakInVHoldButton.AutoSize = true;
            this.SetBreakInVHoldButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetBreakInVHoldButton.Location = new System.Drawing.Point(50, 3);
            this.SetBreakInVHoldButton.Name = "SetBreakInVHoldButton";
            this.SetBreakInVHoldButton.Size = new System.Drawing.Size(50, 23);
            this.SetBreakInVHoldButton.TabIndex = 1;
            this.SetBreakInVHoldButton.Text = "-40 mV";
            this.SetBreakInVHoldButton.UseVisualStyleBackColor = true;
            this.SetBreakInVHoldButton.Click += new System.EventHandler(this.OnSetBreakInVHoldClicked);
            // 
            // AbsoluteVHoldController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.VHoldSlider);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AbsoluteVHoldController";
            this.Size = new System.Drawing.Size(520, 109);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VHoldSlider)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem amplifierToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label VHoldLabel;
        protected NationalInstruments.UI.WindowsForms.Slide VHoldSlider;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SetZeroVHoldButton;
        private System.Windows.Forms.Button SetBreakInVHoldButton;
    }
}
