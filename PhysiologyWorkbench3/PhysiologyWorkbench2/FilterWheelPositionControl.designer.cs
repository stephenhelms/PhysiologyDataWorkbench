namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class FilterWheelPositionControl
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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.WheelsBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FiltersBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SetFilterButton = new System.Windows.Forms.Button();
            this.TakeControlButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShutterStateComboBox = new System.Windows.Forms.ComboBox();
            this.ShutterLabel = new System.Windows.Forms.Label();
            this.SetShutterButton = new System.Windows.Forms.Button();
            this.TableLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 1;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.Controls.Add(this.label1, 0, 0);
            this.TableLayout.Controls.Add(this.WheelsBox, 0, 1);
            this.TableLayout.Controls.Add(this.label2, 0, 3);
            this.TableLayout.Controls.Add(this.FiltersBox, 0, 4);
            this.TableLayout.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.TableLayout.Controls.Add(this.panel1, 0, 2);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 6;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.Size = new System.Drawing.Size(200, 296);
            this.TableLayout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wheels";
            // 
            // WheelsBox
            // 
            this.WheelsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WheelsBox.FormattingEnabled = true;
            this.WheelsBox.Location = new System.Drawing.Point(3, 16);
            this.WheelsBox.Name = "WheelsBox";
            this.WheelsBox.Size = new System.Drawing.Size(194, 43);
            this.WheelsBox.TabIndex = 9;
            this.WheelsBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedWheelChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filters";
            // 
            // FiltersBox
            // 
            this.FiltersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersBox.FormattingEnabled = true;
            this.FiltersBox.Location = new System.Drawing.Point(3, 108);
            this.FiltersBox.Name = "FiltersBox";
            this.FiltersBox.Size = new System.Drawing.Size(194, 134);
            this.FiltersBox.TabIndex = 7;
            this.FiltersBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedFilterChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.SetFilterButton);
            this.flowLayoutPanel1.Controls.Add(this.TakeControlButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 258);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 31);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // SetFilterButton
            // 
            this.SetFilterButton.AutoSize = true;
            this.SetFilterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetFilterButton.Location = new System.Drawing.Point(133, 3);
            this.SetFilterButton.Name = "SetFilterButton";
            this.SetFilterButton.Size = new System.Drawing.Size(58, 23);
            this.SetFilterButton.TabIndex = 7;
            this.SetFilterButton.Text = "Set Filter";
            this.SetFilterButton.UseVisualStyleBackColor = true;
            this.SetFilterButton.Click += new System.EventHandler(this.OnSetFilterClicked);
            // 
            // TakeControlButton
            // 
            this.TakeControlButton.AutoSize = true;
            this.TakeControlButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TakeControlButton.Location = new System.Drawing.Point(49, 3);
            this.TakeControlButton.Name = "TakeControlButton";
            this.TakeControlButton.Size = new System.Drawing.Size(78, 23);
            this.TakeControlButton.TabIndex = 8;
            this.TakeControlButton.Text = "Take Control";
            this.TakeControlButton.UseVisualStyleBackColor = true;
            this.TakeControlButton.Click += new System.EventHandler(this.OnTakeControlClicked);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ShutterStateComboBox);
            this.panel1.Controls.Add(this.ShutterLabel);
            this.panel1.Controls.Add(this.SetShutterButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 23);
            this.panel1.TabIndex = 12;
            // 
            // ShutterStateComboBox
            // 
            this.ShutterStateComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShutterStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShutterStateComboBox.FormattingEnabled = true;
            this.ShutterStateComboBox.Location = new System.Drawing.Point(44, 0);
            this.ShutterStateComboBox.Name = "ShutterStateComboBox";
            this.ShutterStateComboBox.Size = new System.Drawing.Size(117, 21);
            this.ShutterStateComboBox.TabIndex = 1;
            // 
            // ShutterLabel
            // 
            this.ShutterLabel.AutoSize = true;
            this.ShutterLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ShutterLabel.Location = new System.Drawing.Point(0, 0);
            this.ShutterLabel.Name = "ShutterLabel";
            this.ShutterLabel.Size = new System.Drawing.Size(44, 13);
            this.ShutterLabel.TabIndex = 0;
            this.ShutterLabel.Text = "Shutter:";
            this.ShutterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetShutterButton
            // 
            this.SetShutterButton.AutoSize = true;
            this.SetShutterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetShutterButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SetShutterButton.Location = new System.Drawing.Point(161, 0);
            this.SetShutterButton.Name = "SetShutterButton";
            this.SetShutterButton.Size = new System.Drawing.Size(33, 23);
            this.SetShutterButton.TabIndex = 2;
            this.SetShutterButton.Text = "Set";
            this.SetShutterButton.UseVisualStyleBackColor = true;
            this.SetShutterButton.Click += new System.EventHandler(this.OnSetShutterClicked);
            // 
            // FilterWheelPositionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayout);
            this.Name = "FilterWheelPositionControl";
            this.Size = new System.Drawing.Size(200, 296);
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox WheelsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox FiltersBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SetFilterButton;
        private System.Windows.Forms.Button TakeControlButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ShutterStateComboBox;
        private System.Windows.Forms.Label ShutterLabel;
        private System.Windows.Forms.Button SetShutterButton;
    }
}
