namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class SaveWholeCellTestPulseButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveWholeCellTestPulseButton));
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(0, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Whole Cell";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // SaveWholeCellTestPulseButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveButton);
            this.Name = "SaveWholeCellTestPulseButton";
            this.Size = new System.Drawing.Size(84, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
    }
}
