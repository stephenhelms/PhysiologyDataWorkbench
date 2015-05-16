namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class AnnotationViewer
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
            this.ChooseLabel = new System.Windows.Forms.Label();
            this.AnnotationsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ChooseLabel
            // 
            this.ChooseLabel.AutoSize = true;
            this.ChooseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChooseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseLabel.Location = new System.Drawing.Point(0, 0);
            this.ChooseLabel.Name = "ChooseLabel";
            this.ChooseLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ChooseLabel.Size = new System.Drawing.Size(78, 16);
            this.ChooseLabel.TabIndex = 1;
            this.ChooseLabel.Text = "Annotations:";
            // 
            // AnnotationsRichTextBox
            // 
            this.AnnotationsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnnotationsRichTextBox.Location = new System.Drawing.Point(0, 16);
            this.AnnotationsRichTextBox.Name = "AnnotationsRichTextBox";
            this.AnnotationsRichTextBox.Size = new System.Drawing.Size(204, 140);
            this.AnnotationsRichTextBox.TabIndex = 2;
            this.AnnotationsRichTextBox.Text = "";
            // 
            // AnnotationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.AnnotationsRichTextBox);
            this.Controls.Add(this.ChooseLabel);
            this.MinimumSize = new System.Drawing.Size(204, 156);
            this.Name = "AnnotationViewer";
            this.Size = new System.Drawing.Size(204, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChooseLabel;
        private System.Windows.Forms.RichTextBox AnnotationsRichTextBox;

    }
}
