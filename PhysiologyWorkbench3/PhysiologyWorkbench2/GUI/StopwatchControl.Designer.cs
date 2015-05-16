namespace RRLab.PhysiologyWorkbench
{
    partial class StopwatchControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StopwatchControl));
            this.StopwatchButton = new System.Windows.Forms.Button();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StopwatchButton
            // 
            this.StopwatchButton.AutoSize = true;
            this.StopwatchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StopwatchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopwatchButton.Image = ((System.Drawing.Image)(resources.GetObject("StopwatchButton.Image")));
            this.StopwatchButton.Location = new System.Drawing.Point(0, 0);
            this.StopwatchButton.Name = "StopwatchButton";
            this.StopwatchButton.Size = new System.Drawing.Size(122, 23);
            this.StopwatchButton.TabIndex = 2;
            this.StopwatchButton.Text = "Click to Start Timer";
            this.StopwatchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopwatchButton.UseVisualStyleBackColor = true;
            this.StopwatchButton.Click += new System.EventHandler(this.OnStopwatchButtonClick);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // StopwatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CausesValidation = false;
            this.Controls.Add(this.StopwatchButton);
            this.Name = "StopwatchControl";
            this.Size = new System.Drawing.Size(122, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StopwatchButton;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}
