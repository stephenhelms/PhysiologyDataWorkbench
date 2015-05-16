namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class HotkeyManagerDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._SaveButton = new System.Windows.Forms.Button();
            this._CancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MappingsListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HotkeyTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this._SaveButton);
            this.flowLayoutPanel1.Controls.Add(this._CancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 295);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _SaveButton
            // 
            this._SaveButton.AutoSize = true;
            this._SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SaveButton.Location = new System.Drawing.Point(215, 3);
            this._SaveButton.Name = "_SaveButton";
            this._SaveButton.Size = new System.Drawing.Size(42, 23);
            this._SaveButton.TabIndex = 0;
            this._SaveButton.Text = "&Save";
            this._SaveButton.UseVisualStyleBackColor = true;
            this._SaveButton.Click += new System.EventHandler(this.OnSaveClicked);
            // 
            // _CancelButton
            // 
            this._CancelButton.AutoSize = true;
            this._CancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._CancelButton.Location = new System.Drawing.Point(159, 3);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(50, 23);
            this._CancelButton.TabIndex = 1;
            this._CancelButton.Text = "&Cancel";
            this._CancelButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MappingsListBox);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 233);
            this.panel1.TabIndex = 1;
            // 
            // MappingsListBox
            // 
            this.MappingsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingsListBox.FormattingEnabled = true;
            this.MappingsListBox.Location = new System.Drawing.Point(0, 0);
            this.MappingsListBox.Name = "MappingsListBox";
            this.MappingsListBox.Size = new System.Drawing.Size(260, 199);
            this.MappingsListBox.TabIndex = 2;
            this.MappingsListBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedHotkeyMappingChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.RemoveButton);
            this.flowLayoutPanel3.Controls.Add(this.AddButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 204);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(260, 29);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveButton.Location = new System.Drawing.Point(200, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(57, 23);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.Text = "&Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.OnRemoveClicked);
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Location = new System.Drawing.Point(158, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(36, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "&Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.OnAddClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ActionsComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HotkeyTextBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 233);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 62);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Action:";
            // 
            // ActionsComboBox
            // 
            this.ActionsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsComboBox.FormattingEnabled = true;
            this.ActionsComboBox.Location = new System.Drawing.Point(53, 3);
            this.ActionsComboBox.Name = "ActionsComboBox";
            this.ActionsComboBox.Size = new System.Drawing.Size(204, 21);
            this.ActionsComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hotkey:";
            // 
            // HotkeyTextBox
            // 
            this.HotkeyTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HotkeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotkeyTextBox.Location = new System.Drawing.Point(53, 30);
            this.HotkeyTextBox.Name = "HotkeyTextBox";
            this.HotkeyTextBox.ReadOnly = true;
            this.HotkeyTextBox.Size = new System.Drawing.Size(204, 20);
            this.HotkeyTextBox.TabIndex = 5;
            this.HotkeyTextBox.Text = "Press the desired hotkey";
            this.HotkeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnHotkeyEntered);
            // 
            // HotkeyManagerDialog
            // 
            this.AcceptButton = this._SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._CancelButton;
            this.ClientSize = new System.Drawing.Size(260, 324);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HotkeyManagerDialog";
            this.Text = "Configure Hotkeys...";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _SaveButton;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox MappingsListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ActionsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HotkeyTextBox;
    }
}