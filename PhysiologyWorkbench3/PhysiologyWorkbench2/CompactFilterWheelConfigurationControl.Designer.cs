namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class CompactFilterWheelConfigurationControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.WheelBComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WheelAComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WheelBComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.WheelAComboBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wheel B";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WheelBComboBox
            // 
            this.WheelBComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WheelBComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WheelBComboBox.DropDownWidth = 100;
            this.WheelBComboBox.FormattingEnabled = true;
            this.WheelBComboBox.Location = new System.Drawing.Point(57, 30);
            this.WheelBComboBox.Name = "WheelBComboBox";
            this.WheelBComboBox.Size = new System.Drawing.Size(125, 21);
            this.WheelBComboBox.TabIndex = 5;
            this.WheelBComboBox.SelectedIndexChanged += new System.EventHandler(this.OnWheelBSelectedFilterChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Wheel A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WheelAComboBox
            // 
            this.WheelAComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WheelAComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WheelAComboBox.DropDownWidth = 100;
            this.WheelAComboBox.FormattingEnabled = true;
            this.WheelAComboBox.Location = new System.Drawing.Point(57, 3);
            this.WheelAComboBox.Name = "WheelAComboBox";
            this.WheelAComboBox.Size = new System.Drawing.Size(125, 21);
            this.WheelAComboBox.TabIndex = 7;
            this.WheelAComboBox.SelectedIndexChanged += new System.EventHandler(this.OnWheelASelectedFilterChanged);
            // 
            // CompactFilterWheelConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CompactFilterWheelConfigurationControl";
            this.Size = new System.Drawing.Size(185, 57);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox WheelBComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WheelAComboBox;

    }
}
