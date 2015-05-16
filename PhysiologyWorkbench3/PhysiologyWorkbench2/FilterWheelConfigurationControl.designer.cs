namespace RRLab.PhysiologyWorkbench.Devices
{
    partial class FilterWheelConfigurationControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.FiltersBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WheelsBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FilterDescriptionBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.TableLayout.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout.Controls.Add(this.panel2, 1, 0);
            this.TableLayout.Controls.Add(this.panel1, 0, 0);
            this.TableLayout.Controls.Add(this.panel3, 0, 1);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 2;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayout.Size = new System.Drawing.Size(276, 205);
            this.TableLayout.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.FiltersBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(141, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(132, 169);
            this.panel2.TabIndex = 1;
            // 
            // FiltersBox
            // 
            this.FiltersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltersBox.FormattingEnabled = true;
            this.FiltersBox.Location = new System.Drawing.Point(0, 13);
            this.FiltersBox.Name = "FiltersBox";
            this.FiltersBox.Size = new System.Drawing.Size(132, 147);
            this.FiltersBox.TabIndex = 2;
            this.FiltersBox.EnabledChanged += new System.EventHandler(this.OnFiltersBoxEnabledChanged);
            this.FiltersBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedFilterChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filters";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.WheelsBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 169);
            this.panel1.TabIndex = 0;
            // 
            // WheelsBox
            // 
            this.WheelsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WheelsBox.FormattingEnabled = true;
            this.WheelsBox.Location = new System.Drawing.Point(0, 13);
            this.WheelsBox.Name = "WheelsBox";
            this.WheelsBox.Size = new System.Drawing.Size(132, 147);
            this.WheelsBox.TabIndex = 1;
            this.WheelsBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedWheelChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wheels";
            // 
            // panel3
            // 
            this.TableLayout.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.FilterDescriptionBox);
            this.panel3.Controls.Add(this.UpdateButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 24);
            this.panel3.TabIndex = 2;
            // 
            // FilterDescriptionBox
            // 
            this.FilterDescriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterDescriptionBox.Location = new System.Drawing.Point(0, 0);
            this.FilterDescriptionBox.Name = "FilterDescriptionBox";
            this.FilterDescriptionBox.Size = new System.Drawing.Size(209, 20);
            this.FilterDescriptionBox.TabIndex = 4;
            this.FilterDescriptionBox.TextChanged += new System.EventHandler(this.OnDescriptionTextChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.UpdateButton.Location = new System.Drawing.Point(209, 0);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(61, 24);
            this.UpdateButton.TabIndex = 5;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.OnUpdateButtonClicked);
            // 
            // FilterWheelConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayout);
            this.Name = "FilterWheelConfigurationControl";
            this.Size = new System.Drawing.Size(276, 205);
            this.TableLayout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox WheelsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox FiltersBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox FilterDescriptionBox;
        private System.Windows.Forms.Button UpdateButton;
    }
}
