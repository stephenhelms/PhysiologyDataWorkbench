namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class ProtocolExecutionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolExecutionControl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.RunButton = new System.Windows.Forms.Button();
            this.StartContButton = new System.Windows.Forms.Button();
            this.TrashButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.RunButton);
            this.flowLayoutPanel1.Controls.Add(this.StartContButton);
            this.flowLayoutPanel1.Controls.Add(this.TrashButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(228, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // RunButton
            // 
            this.RunButton.AutoSize = true;
            this.RunButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.Image = ((System.Drawing.Image)(resources.GetObject("RunButton.Image")));
            this.RunButton.Location = new System.Drawing.Point(3, 3);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(90, 23);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "Run Once";
            this.RunButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StartContButton
            // 
            this.StartContButton.AutoSize = true;
            this.StartContButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartContButton.Enabled = false;
            this.StartContButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartContButton.Image = ((System.Drawing.Image)(resources.GetObject("StartContButton.Image")));
            this.StartContButton.Location = new System.Drawing.Point(99, 3);
            this.StartContButton.Name = "StartContButton";
            this.StartContButton.Size = new System.Drawing.Size(60, 23);
            this.StartContButton.TabIndex = 1;
            this.StartContButton.Text = "Start";
            this.StartContButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartContButton.UseVisualStyleBackColor = false;
            this.StartContButton.Click += new System.EventHandler(this.StartContButton_Click);
            // 
            // TrashButton
            // 
            this.TrashButton.AutoSize = true;
            this.TrashButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TrashButton.Enabled = false;
            this.TrashButton.Image = ((System.Drawing.Image)(resources.GetObject("TrashButton.Image")));
            this.TrashButton.Location = new System.Drawing.Point(165, 3);
            this.TrashButton.Name = "TrashButton";
            this.TrashButton.Size = new System.Drawing.Size(60, 23);
            this.TrashButton.TabIndex = 2;
            this.TrashButton.Text = "&Trash";
            this.TrashButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TrashButton.UseVisualStyleBackColor = true;
            this.TrashButton.Click += new System.EventHandler(this.TrashButton_Click);
            // 
            // ProtocolExecutionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ProtocolExecutionControl";
            this.Size = new System.Drawing.Size(228, 29);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button StartContButton;
        private System.Windows.Forms.Button TrashButton;
    }
}
