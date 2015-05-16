namespace RRLab.PhysiologyData.GUI
{
    partial class RecordingSubTablesViewer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MetaDataTabPage = new System.Windows.Forms.TabPage();
            this.MetaDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetaDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecordingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProtocolSettingsTabPage = new System.Windows.Forms.TabPage();
            this.ProtocolDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProtocolSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EquipmentSettingsTabPage = new System.Windows.Forms.TabPage();
            this.EquipmentDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.MetaDataTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MetaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).BeginInit();
            this.ProtocolSettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolSettingsBindingSource)).BeginInit();
            this.EquipmentSettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MetaDataTabPage);
            this.tabControl1.Controls.Add(this.ProtocolSettingsTabPage);
            this.tabControl1.Controls.Add(this.EquipmentSettingsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(220, 219);
            this.tabControl1.TabIndex = 0;
            // 
            // MetaDataTabPage
            // 
            this.MetaDataTabPage.Controls.Add(this.MetaDataGridView);
            this.MetaDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.MetaDataTabPage.Name = "MetaDataTabPage";
            this.MetaDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MetaDataTabPage.Size = new System.Drawing.Size(212, 193);
            this.MetaDataTabPage.TabIndex = 0;
            this.MetaDataTabPage.Text = "MetaData";
            this.MetaDataTabPage.UseVisualStyleBackColor = true;
            // 
            // MetaDataGridView
            // 
            this.MetaDataGridView.AutoGenerateColumns = false;
            this.MetaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.MetaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MetaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.MetaDataGridView.DataSource = this.MetaDataBindingSource;
            this.MetaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataGridView.Location = new System.Drawing.Point(3, 3);
            this.MetaDataGridView.Name = "MetaDataGridView";
            this.MetaDataGridView.Size = new System.Drawing.Size(206, 187);
            this.MetaDataGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 59;
            // 
            // MetaDataBindingSource
            // 
            this.MetaDataBindingSource.AllowNew = true;
            this.MetaDataBindingSource.DataMember = "FK_Recordings_Recording_MetaData";
            this.MetaDataBindingSource.DataSource = this.RecordingBindingSource;
            // 
            // RecordingBindingSource
            // 
            this.RecordingBindingSource.DataMember = "Recordings";
            this.RecordingBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.Data.PhysiologyDataSet);
            // 
            // ProtocolSettingsTabPage
            // 
            this.ProtocolSettingsTabPage.Controls.Add(this.ProtocolDataGridView);
            this.ProtocolSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProtocolSettingsTabPage.Name = "ProtocolSettingsTabPage";
            this.ProtocolSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProtocolSettingsTabPage.Size = new System.Drawing.Size(212, 193);
            this.ProtocolSettingsTabPage.TabIndex = 1;
            this.ProtocolSettingsTabPage.Text = "Protocol";
            this.ProtocolSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // ProtocolDataGridView
            // 
            this.ProtocolDataGridView.AutoGenerateColumns = false;
            this.ProtocolDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ProtocolDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProtocolDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.ProtocolDataGridView.DataSource = this.ProtocolSettingsBindingSource;
            this.ProtocolDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ProtocolDataGridView.Name = "ProtocolDataGridView";
            this.ProtocolDataGridView.Size = new System.Drawing.Size(206, 187);
            this.ProtocolDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 59;
            // 
            // ProtocolSettingsBindingSource
            // 
            this.ProtocolSettingsBindingSource.AllowNew = true;
            this.ProtocolSettingsBindingSource.DataMember = "FK_Recordings_Recordings_ProtocolSettings";
            this.ProtocolSettingsBindingSource.DataSource = this.RecordingBindingSource;
            // 
            // EquipmentSettingsTabPage
            // 
            this.EquipmentSettingsTabPage.Controls.Add(this.EquipmentDataGridView);
            this.EquipmentSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.EquipmentSettingsTabPage.Name = "EquipmentSettingsTabPage";
            this.EquipmentSettingsTabPage.Size = new System.Drawing.Size(212, 193);
            this.EquipmentSettingsTabPage.TabIndex = 2;
            this.EquipmentSettingsTabPage.Text = "Equipment";
            this.EquipmentSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // EquipmentDataGridView
            // 
            this.EquipmentDataGridView.AutoGenerateColumns = false;
            this.EquipmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.EquipmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.EquipmentDataGridView.DataSource = this.EquipmentSettingsBindingSource;
            this.EquipmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EquipmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.EquipmentDataGridView.Name = "EquipmentDataGridView";
            this.EquipmentDataGridView.Size = new System.Drawing.Size(212, 193);
            this.EquipmentDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 59;
            // 
            // EquipmentSettingsBindingSource
            // 
            this.EquipmentSettingsBindingSource.AllowNew = true;
            this.EquipmentSettingsBindingSource.DataMember = "Recordings_Recordings_EquipmentSettings";
            this.EquipmentSettingsBindingSource.DataSource = this.RecordingBindingSource;
            // 
            // RecordingSubTablesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "RecordingSubTablesViewer";
            this.Size = new System.Drawing.Size(220, 219);
            this.tabControl1.ResumeLayout(false);
            this.MetaDataTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MetaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MetaDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingBindingSource)).EndInit();
            this.ProtocolSettingsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolSettingsBindingSource)).EndInit();
            this.EquipmentSettingsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MetaDataTabPage;
        private System.Windows.Forms.TabPage ProtocolSettingsTabPage;
        private System.Windows.Forms.TabPage EquipmentSettingsTabPage;
        private System.Windows.Forms.BindingSource RecordingBindingSource;
        private System.Windows.Forms.DataGridView MetaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource MetaDataBindingSource;
        private System.Windows.Forms.DataGridView ProtocolDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource ProtocolSettingsBindingSource;
        private System.Windows.Forms.DataGridView EquipmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource EquipmentSettingsBindingSource;
    }
}
