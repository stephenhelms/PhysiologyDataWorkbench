namespace RRLab.Utilities
{
    partial class DataSetHistogramControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.GraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // GraphControl
            // 
            this.GraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphControl.Location = new System.Drawing.Point(0, 0);
            this.GraphControl.Name = "GraphControl";
            this.GraphControl.ScrollMaxX = 0;
            this.GraphControl.ScrollMaxY = 0;
            this.GraphControl.ScrollMaxY2 = 0;
            this.GraphControl.ScrollMinX = 0;
            this.GraphControl.ScrollMinY = 0;
            this.GraphControl.ScrollMinY2 = 0;
            this.GraphControl.Size = new System.Drawing.Size(239, 237);
            this.GraphControl.TabIndex = 0;
            // 
            // DataSetHistogramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GraphControl);
            this.Name = "DataSetHistogramControl";
            this.Size = new System.Drawing.Size(239, 237);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl GraphControl;
    }
}
