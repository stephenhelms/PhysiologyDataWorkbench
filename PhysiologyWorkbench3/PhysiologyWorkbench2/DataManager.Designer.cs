namespace RRLab.PhysiologyWorkbench
{
    partial class DataManager
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
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "pdata";
            this.SaveFileDialog.Filter = "Physiology Data (*.pdata) |*.pdata";
            this.SaveFileDialog.SupportMultiDottedExtensions = true;
            this.SaveFileDialog.Title = "Save collected data...";

        }

        #endregion

        protected System.Windows.Forms.SaveFileDialog SaveFileDialog;

    }
}
