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
            this.ControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProtocolExecutionControl = new RRLab.PhysiologyWorkbench.GUI.ProtocolExecutionControl();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingViewer = new RRLab.PhysiologyWorkbench.RecordingViewer();
            this.ProtocolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LeftSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).BeginInit();
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
            this.ProtocolSidebarControl.DataBindings.Add(new System.Windows.Forms.Binding("Program", this.ControlBindingSource, "Program", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolSidebarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolSidebarControl.Location = new System.Drawing.Point(0, 0);
            this.ProtocolSidebarControl.MinimumSize = new System.Drawing.Size(196, 107);
            this.ProtocolSidebarControl.Name = "ProtocolSidebarControl";
            this.ProtocolSidebarControl.Program = null;
            this.ProtocolSidebarControl.Size = new System.Drawing.Size(230, 534);
            this.ProtocolSidebarControl.TabIndex = 1;
            // 
            // ControlBindingSource
            // 
            this.ControlBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.GUI.ProtocolPanel);
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
            this.ProtocolExecutionControl.RunningColor = System.Drawing.Color.Empty;
            this.ProtocolExecutionControl.Size = new System.Drawing.Size(230, 29);
            this.ProtocolExecutionControl.StoppedColor = System.Drawing.Color.LawnGreen;
            this.ProtocolExecutionControl.TabIndex = 0;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // RecordingViewer
            // 
            this.RecordingViewer.AutoSize = true;
            this.RecordingViewer.CurrentAxisRange = new NationalInstruments.UI.Range(-10, 10);
            this.RecordingViewer.CurrentAxisScaling = RRLab.PhysiologyWorkbench.AutoAxisMode.DynamicRange;
            this.RecordingViewer.CurrentMaxDaqVoltage = 10;
            this.RecordingViewer.CurrentMinDaqVoltage = -10;
            this.RecordingViewer.DataBindings.Add(new System.Windows.Forms.Binding("Recording", this.ProtocolBindingSource, "Data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RecordingViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingViewer.IsTitleVisible = false;
            this.RecordingViewer.Location = new System.Drawing.Point(230, 0);
            this.RecordingViewer.Name = "RecordingViewer";
            this.RecordingViewer.Recording = null;
            this.RecordingViewer.Size = new System.Drawing.Size(516, 563);
            this.RecordingViewer.TabIndex = 1;
            this.RecordingViewer.VoltageAxisRange = new NationalInstruments.UI.Range(-10, 10);
            this.RecordingViewer.VoltageAxisScaling = RRLab.PhysiologyWorkbench.AutoAxisMode.DynamicRange;
            this.RecordingViewer.VoltageMaxDaqVoltage = 10;
            this.RecordingViewer.VoltageMinDaqVoltage = -10;
            // 
            // ProtocolBindingSource
            // 
            this.ProtocolBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Daq.DaqProtocol);
            // 
            // ProtocolPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RecordingViewer);
            this.Controls.Add(this.LeftSidebar);
            this.Name = "ProtocolPanel";
            this.Size = new System.Drawing.Size(746, 563);
            this.LeftSidebar.ResumeLayout(false);
            this.LeftSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftSidebar;
        private RRLab.PhysiologyWorkbench.RecordingViewer RecordingViewer;
        private ProtocolExecutionControl ProtocolExecutionControl;
        private ProtocolSidebarControl ProtocolSidebarControl;
        private System.Windows.Forms.BindingSource ControlBindingSource;
        private System.Windows.Forms.BindingSource ProtocolBindingSource;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
    }
}
