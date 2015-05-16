namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class ProtocolPanel
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
            this.LeftSidebar = new System.Windows.Forms.Panel();
            this.ProtocolSidebarControl = new RRLab.PhysiologyWorkbench.GUI.ProtocolSidebarControl();
            this.ProtocolExecutionControl = new RRLab.PhysiologyWorkbench.GUI.ProtocolExecutionControl();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingGraphControl = new RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl();
            this.LeftSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftSidebar
            // 
            this.LeftSidebar.Controls.Add(this.ProtocolSidebarControl);
            this.LeftSidebar.Controls.Add(this.ProtocolExecutionControl);
            this.LeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.LeftSidebar.Name = "LeftSidebar";
            this.LeftSidebar.Size = new System.Drawing.Size(230, 563);
            this.LeftSidebar.TabIndex = 0;
            // 
            // ProtocolSidebarControl
            // 
            this.ProtocolSidebarControl.AutoSize = true;
            this.ProtocolSidebarControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProtocolSidebarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolSidebarControl.Location = new System.Drawing.Point(0, 0);
            this.ProtocolSidebarControl.MinimumSize = new System.Drawing.Size(196, 107);
            this.ProtocolSidebarControl.Name = "ProtocolSidebarControl";
            this.ProtocolSidebarControl.Program = null;
            this.ProtocolSidebarControl.Size = new System.Drawing.Size(230, 534);
            this.ProtocolSidebarControl.TabIndex = 1;
            // 
            // ProtocolExecutionControl
            // 
            this.ProtocolExecutionControl.AutoSize = true;
            this.ProtocolExecutionControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProtocolExecutionControl.DataBindings.Add(new System.Windows.Forms.Binding("DataManager", this.ProgramBindingSource, "DataManager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolExecutionControl.DataBindings.Add(new System.Windows.Forms.Binding("Protocol", this.ProgramBindingSource, "CurrentProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolExecutionControl.DataManager = null;
            this.ProtocolExecutionControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProtocolExecutionControl.Enabled = false;
            this.ProtocolExecutionControl.Location = new System.Drawing.Point(0, 534);
            this.ProtocolExecutionControl.Name = "ProtocolExecutionControl";
            this.ProtocolExecutionControl.Protocol = null;
            this.ProtocolExecutionControl.RunningColor = System.Drawing.Color.Empty;
            this.ProtocolExecutionControl.Size = new System.Drawing.Size(230, 29);
            this.ProtocolExecutionControl.StoppedColor = System.Drawing.Color.LawnGreen;
            this.ProtocolExecutionControl.TabIndex = 0;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // RecordingGraphControl
            // 
            this.RecordingGraphControl.DataSet = null;
            this.RecordingGraphControl.DefaultAxisLocation = RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl.AxisLocation.Left;
            this.RecordingGraphControl.DefaultAxisMode = RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl.AxisMode.Auto;
            this.RecordingGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingGraphControl.GraphBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.RecordingGraphControl.Location = new System.Drawing.Point(230, 0);
            this.RecordingGraphControl.Name = "RecordingGraphControl";
            this.RecordingGraphControl.Recording = null;
            this.RecordingGraphControl.Size = new System.Drawing.Size(516, 563);
            this.RecordingGraphControl.TabIndex = 1;
            // 
            // ProtocolPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecordingGraphControl);
            this.Controls.Add(this.LeftSidebar);
            this.Name = "ProtocolPanel";
            this.Size = new System.Drawing.Size(746, 563);
            this.LeftSidebar.ResumeLayout(false);
            this.LeftSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftSidebar;
        private ProtocolExecutionControl ProtocolExecutionControl;
        private ProtocolSidebarControl ProtocolSidebarControl;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private RRLab.PhysiologyData.GUI.NIRecordingDataGraphControl RecordingGraphControl;
    }
}
