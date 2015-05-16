namespace RRLab.PhysiologyDataConnectivity
{
    partial class LogInDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StoredLocationsComboBox = new System.Windows.Forms.ComboBox();
            this.DatabaseServerTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseComboBox = new System.Windows.Forms.ComboBox();
            this.ProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonFlowLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonFlowLayoutPanel
            // 
            this.ButtonFlowLayoutPanel.AutoSize = true;
            this.ButtonFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonFlowLayoutPanel.Controls.Add(this.button_ok);
            this.ButtonFlowLayoutPanel.Controls.Add(this.button_cancel);
            this.ButtonFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonFlowLayoutPanel.Location = new System.Drawing.Point(0, 132);
            this.ButtonFlowLayoutPanel.Name = "ButtonFlowLayoutPanel";
            this.ButtonFlowLayoutPanel.Size = new System.Drawing.Size(221, 29);
            this.ButtonFlowLayoutPanel.TabIndex = 0;
            // 
            // button_ok
            // 
            this.button_ok.AutoSize = true;
            this.button_ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_ok.Location = new System.Drawing.Point(186, 3);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(32, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "&OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.OnOkClicked);
            // 
            // button_cancel
            // 
            this.button_cancel.AutoSize = true;
            this.button_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(130, 3);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(50, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "&Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.OnCancelClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StoredLocationsComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DatabaseServerTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UsernameTextbox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PasswordTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DatabaseComboBox, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(221, 132);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "Database:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Username:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Server Address:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stored Locations:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StoredLocationsComboBox
            // 
            this.StoredLocationsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StoredLocationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StoredLocationsComboBox.FormattingEnabled = true;
            this.StoredLocationsComboBox.Items.AddRange(new object[] {
            "IMG_PHYS",
            "129.112.108.86 (IMG_PHYS)",
            "localhost"});
            this.StoredLocationsComboBox.Location = new System.Drawing.Point(99, 3);
            this.StoredLocationsComboBox.Name = "StoredLocationsComboBox";
            this.StoredLocationsComboBox.Size = new System.Drawing.Size(121, 21);
            this.StoredLocationsComboBox.TabIndex = 3;
            this.StoredLocationsComboBox.SelectedIndexChanged += new System.EventHandler(this.DataSourceComboBox_SelectedIndexChanged);
            // 
            // DatabaseServerTextBox
            // 
            this.DatabaseServerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseServerTextBox.Location = new System.Drawing.Point(99, 30);
            this.DatabaseServerTextBox.Name = "DatabaseServerTextBox";
            this.DatabaseServerTextBox.Size = new System.Drawing.Size(121, 20);
            this.DatabaseServerTextBox.TabIndex = 4;
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameTextbox.Location = new System.Drawing.Point(99, 56);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(121, 20);
            this.UsernameTextbox.TabIndex = 5;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTextBox.Location = new System.Drawing.Point(99, 82);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(121, 20);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // DatabaseComboBox
            // 
            this.DatabaseComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseComboBox.FormattingEnabled = true;
            this.DatabaseComboBox.Items.AddRange(new object[] {
            "physiology_data",
            "test"});
            this.DatabaseComboBox.Location = new System.Drawing.Point(99, 108);
            this.DatabaseComboBox.Name = "DatabaseComboBox";
            this.DatabaseComboBox.Size = new System.Drawing.Size(121, 21);
            this.DatabaseComboBox.TabIndex = 10;
            this.DatabaseComboBox.Text = "physiology_data";
            // 
            // LogInDialog
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(221, 161);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ButtonFlowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LogInDialog";
            this.Text = "Log in...";
            this.ButtonFlowLayoutPanel.ResumeLayout(false);
            this.ButtonFlowLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ButtonFlowLayoutPanel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource UsersBindingSource;
        private System.Windows.Forms.BindingSource ProgramBindingSource;
        private System.Windows.Forms.TextBox DatabaseServerTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DatabaseComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox StoredLocationsComboBox;
    }
}