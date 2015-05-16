namespace RRLab.PhysiologyWorkbench
{
    partial class TestPulseSettingsBox
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
            this.tbPulseTime = new System.Windows.Forms.TextBox();
            this.TestPulseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbPulsePotential = new System.Windows.Forms.TextBox();
            this.tbRestingPotential = new System.Windows.Forms.TextBox();
            this.tbRestingTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbPulseTime, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbPulsePotential, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbRestingPotential, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbRestingTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(129, 155);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // tbPulseTime
            // 
            this.tbPulseTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TestPulseBindingSource, "PulseLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPulseTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPulseTime.Location = new System.Drawing.Point(87, 88);
            this.tbPulseTime.Name = "tbPulseTime";
            this.tbPulseTime.Size = new System.Drawing.Size(39, 20);
            this.tbPulseTime.TabIndex = 25;
            // 
            // TestPulseBindingSource
            // 
            this.TestPulseBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.TestPulseProtocol);
            // 
            // tbPulsePotential
            // 
            this.tbPulsePotential.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TestPulseBindingSource, "PulsePotential", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPulsePotential.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPulsePotential.Location = new System.Drawing.Point(87, 114);
            this.tbPulsePotential.Name = "tbPulsePotential";
            this.tbPulsePotential.Size = new System.Drawing.Size(39, 20);
            this.tbPulsePotential.TabIndex = 24;
            // 
            // tbRestingPotential
            // 
            this.tbRestingPotential.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TestPulseBindingSource, "RestingPotential", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRestingPotential.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRestingPotential.Location = new System.Drawing.Point(87, 49);
            this.tbRestingPotential.Name = "tbRestingPotential";
            this.tbRestingPotential.Size = new System.Drawing.Size(39, 20);
            this.tbRestingPotential.TabIndex = 23;
            // 
            // tbRestingTime
            // 
            this.tbRestingTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.TestPulseBindingSource, "RestingLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRestingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRestingTime.Location = new System.Drawing.Point(87, 23);
            this.tbRestingTime.Name = "tbRestingTime";
            this.tbRestingTime.Size = new System.Drawing.Size(39, 20);
            this.tbRestingTime.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Length (ms)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Length (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 26);
            this.label2.TabIndex = 19;
            this.label2.Text = "Potential (mV)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "Potential (mV)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Pulse";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rest";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TestPulseSettingsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestPulseSettingsBox";
            this.Size = new System.Drawing.Size(129, 155);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestPulseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbPulseTime;
        private System.Windows.Forms.TextBox tbPulsePotential;
        private System.Windows.Forms.TextBox tbRestingPotential;
        private System.Windows.Forms.TextBox tbRestingTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource TestPulseBindingSource;
    }
}
