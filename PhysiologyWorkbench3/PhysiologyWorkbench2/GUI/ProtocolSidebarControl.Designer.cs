namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class ProtocolSidebarControl
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
            foreach (object o in ProtocolComboBox.Items)
                if (o is System.IDisposable) (o as System.IDisposable).Dispose();
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
            this.ChooseProtocolLabel = new System.Windows.Forms.Label();
            this.ProtocolComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.AdvancedTab = new System.Windows.Forms.TabPage();
            this.ProtocolAdvancedSettingsPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.AdvancedTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ChooseProtocolLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProtocolComboBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ChooseProtocolLabel
            // 
            this.ChooseProtocolLabel.AutoSize = true;
            this.ChooseProtocolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseProtocolLabel.Location = new System.Drawing.Point(3, 0);
            this.ChooseProtocolLabel.Name = "ChooseProtocolLabel";
            this.ChooseProtocolLabel.Size = new System.Drawing.Size(190, 13);
            this.ChooseProtocolLabel.TabIndex = 0;
            this.ChooseProtocolLabel.Text = "Choose a protocol:";
            // 
            // ProtocolComboBox
            // 
            this.ProtocolComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.ProgramBindingSource, "CurrentProtocol", true));
            this.ProtocolComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProtocolComboBox.FormattingEnabled = true;
            this.ProtocolComboBox.Location = new System.Drawing.Point(3, 16);
            this.ProtocolComboBox.Name = "ProtocolComboBox";
            this.ProtocolComboBox.Size = new System.Drawing.Size(190, 21);
            this.ProtocolComboBox.TabIndex = 1;
            this.ProtocolComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnSelectedProtocolCommitted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SettingsTab);
            this.tabControl1.Controls.Add(this.AdvancedTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 40);
            this.tabControl1.MinimumSize = new System.Drawing.Size(0, 200);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(196, 210);
            this.tabControl1.TabIndex = 1;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(188, 184);
            this.SettingsTab.TabIndex = 0;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // AdvancedTab
            // 
            this.AdvancedTab.Controls.Add(this.ProtocolAdvancedSettingsPropertyGrid);
            this.AdvancedTab.Location = new System.Drawing.Point(4, 22);
            this.AdvancedTab.Name = "AdvancedTab";
            this.AdvancedTab.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedTab.Size = new System.Drawing.Size(188, 184);
            this.AdvancedTab.TabIndex = 1;
            this.AdvancedTab.Text = "Advanced";
            this.AdvancedTab.UseVisualStyleBackColor = true;
            // 
            // ProtocolAdvancedSettingsPropertyGrid
            // 
            this.ProtocolAdvancedSettingsPropertyGrid.DataBindings.Add(new System.Windows.Forms.Binding("SelectedObject", this.ProgramBindingSource, "CurrentProtocol", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ProtocolAdvancedSettingsPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProtocolAdvancedSettingsPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.ProtocolAdvancedSettingsPropertyGrid.Name = "ProtocolAdvancedSettingsPropertyGrid";
            this.ProtocolAdvancedSettingsPropertyGrid.Size = new System.Drawing.Size(182, 178);
            this.ProtocolAdvancedSettingsPropertyGrid.TabIndex = 0;
            // 
            // ProgramBindingSource
            // 
            this.ProgramBindingSource.DataSource = typeof(RRLab.PhysiologyWorkbench.PhysiologyWorkbenchProgram);
            // 
            // ProtocolSidebarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(196, 250);
            this.Name = "ProtocolSidebarControl";
            this.Size = new System.Drawing.Size(196, 250);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.AdvancedTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ChooseProtocolLabel;
        private System.Windows.Forms.ComboBox ProtocolComboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.TabPage AdvancedTab;
        private System.Windows.Forms.PropertyGrid ProtocolAdvancedSettingsPropertyGrid;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
    }
}
