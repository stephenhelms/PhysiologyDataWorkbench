namespace RRLab.PhysiologyWorkbench.GUI
{
    partial class QuickNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickNotes));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.NoteFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GoodButton = new System.Windows.Forms.Button();
            this.BadButton = new System.Windows.Forms.Button();
            this.OddButton = new System.Windows.Forms.Button();
            this.ProblemButton = new System.Windows.Forms.Button();
            this.QuickNotesLabel = new System.Windows.Forms.Label();
            this.CellRadioButton = new System.Windows.Forms.RadioButton();
            this.RecordingRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.NoteFlowLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ButtonFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.NoteTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NoteFlowLayoutPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(237, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(207, 122);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteTextBox.Location = new System.Drawing.Point(3, 3);
            this.NoteTextBox.MinimumSize = new System.Drawing.Size(184, 50);
            this.NoteTextBox.Multiline = true;
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NoteTextBox.Size = new System.Drawing.Size(201, 81);
            this.NoteTextBox.TabIndex = 0;
            this.NoteTextBox.TextChanged += new System.EventHandler(this.OnNoteTextChanged);
            this.NoteTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteTextBox_KeyDown);
            // 
            // NoteFlowLayoutPanel
            // 
            this.NoteFlowLayoutPanel.AutoSize = true;
            this.NoteFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoteFlowLayoutPanel.Controls.Add(this.AcceptButton);
            this.NoteFlowLayoutPanel.Controls.Add(this.ClearButton);
            this.NoteFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.NoteFlowLayoutPanel.Location = new System.Drawing.Point(87, 90);
            this.NoteFlowLayoutPanel.Name = "NoteFlowLayoutPanel";
            this.NoteFlowLayoutPanel.Size = new System.Drawing.Size(117, 29);
            this.NoteFlowLayoutPanel.TabIndex = 1;
            // 
            // AcceptButton
            // 
            this.AcceptButton.AutoSize = true;
            this.AcceptButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AcceptButton.Enabled = false;
            this.AcceptButton.Image = ((System.Drawing.Image)(resources.GetObject("AcceptButton.Image")));
            this.AcceptButton.Location = new System.Drawing.Point(3, 3);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(48, 23);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "OK";
            this.AcceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.OnAcceptButtonClicked);
            // 
            // ClearButton
            // 
            this.ClearButton.AutoSize = true;
            this.ClearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearButton.Enabled = false;
            this.ClearButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearButton.Image")));
            this.ClearButton.Location = new System.Drawing.Point(57, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(57, 23);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.OnClearButtonClicked);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ButtonFlowLayoutPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 122);
            this.panel1.TabIndex = 5;
            // 
            // ButtonFlowLayoutPanel
            // 
            this.ButtonFlowLayoutPanel.AutoScroll = true;
            this.ButtonFlowLayoutPanel.AutoSize = true;
            this.ButtonFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonFlowLayoutPanel.Controls.Add(this.QuickNotesLabel);
            this.ButtonFlowLayoutPanel.Controls.Add(this.CellRadioButton);
            this.ButtonFlowLayoutPanel.Controls.Add(this.RecordingRadioButton);
            this.ButtonFlowLayoutPanel.Controls.Add(this.GoodButton);
            this.ButtonFlowLayoutPanel.Controls.Add(this.BadButton);
            this.ButtonFlowLayoutPanel.Controls.Add(this.OddButton);
            this.ButtonFlowLayoutPanel.Controls.Add(this.ProblemButton);
            this.ButtonFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonFlowLayoutPanel.Name = "ButtonFlowLayoutPanel";
            this.ButtonFlowLayoutPanel.Size = new System.Drawing.Size(237, 122);
            this.ButtonFlowLayoutPanel.TabIndex = 7;
            // 
            // GoodButton
            // 
            this.GoodButton.AutoSize = true;
            this.GoodButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoodButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.GoodButton.Image = ((System.Drawing.Image)(resources.GetObject("GoodButton.Image")));
            this.GoodButton.Location = new System.Drawing.Point(1, 24);
            this.GoodButton.Margin = new System.Windows.Forms.Padding(1);
            this.GoodButton.Name = "GoodButton";
            this.GoodButton.Size = new System.Drawing.Size(54, 71);
            this.GoodButton.TabIndex = 0;
            this.GoodButton.Text = "Good";
            this.GoodButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GoodButton.UseVisualStyleBackColor = true;
            this.GoodButton.Click += new System.EventHandler(this.GoodButton_Click);
            // 
            // BadButton
            // 
            this.BadButton.AutoSize = true;
            this.BadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BadButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.BadButton.Image = ((System.Drawing.Image)(resources.GetObject("BadButton.Image")));
            this.BadButton.Location = new System.Drawing.Point(57, 24);
            this.BadButton.Margin = new System.Windows.Forms.Padding(1);
            this.BadButton.Name = "BadButton";
            this.BadButton.Size = new System.Drawing.Size(54, 71);
            this.BadButton.TabIndex = 1;
            this.BadButton.Text = "Bad";
            this.BadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BadButton.UseVisualStyleBackColor = true;
            this.BadButton.Click += new System.EventHandler(this.BadButton_Click);
            // 
            // OddButton
            // 
            this.OddButton.AutoSize = true;
            this.OddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.OddButton.Image = ((System.Drawing.Image)(resources.GetObject("OddButton.Image")));
            this.OddButton.Location = new System.Drawing.Point(113, 24);
            this.OddButton.Margin = new System.Windows.Forms.Padding(1);
            this.OddButton.Name = "OddButton";
            this.OddButton.Size = new System.Drawing.Size(54, 71);
            this.OddButton.TabIndex = 2;
            this.OddButton.Text = "Odd";
            this.OddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OddButton.UseVisualStyleBackColor = true;
            this.OddButton.Click += new System.EventHandler(this.OddButton_Click);
            // 
            // ProblemButton
            // 
            this.ProblemButton.AutoSize = true;
            this.ProblemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProblemButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProblemButton.Image = ((System.Drawing.Image)(resources.GetObject("ProblemButton.Image")));
            this.ProblemButton.Location = new System.Drawing.Point(169, 24);
            this.ProblemButton.Margin = new System.Windows.Forms.Padding(1);
            this.ProblemButton.Name = "ProblemButton";
            this.ProblemButton.Size = new System.Drawing.Size(55, 71);
            this.ProblemButton.TabIndex = 3;
            this.ProblemButton.Text = "Problem";
            this.ProblemButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ProblemButton.UseVisualStyleBackColor = true;
            this.ProblemButton.Click += new System.EventHandler(this.ProblemButton_Click);
            // 
            // QuickNotesLabel
            // 
            this.QuickNotesLabel.AutoSize = true;
            this.QuickNotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickNotesLabel.Location = new System.Drawing.Point(3, 0);
            this.QuickNotesLabel.Name = "QuickNotesLabel";
            this.QuickNotesLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.QuickNotesLabel.Size = new System.Drawing.Size(91, 22);
            this.QuickNotesLabel.TabIndex = 6;
            this.QuickNotesLabel.Text = "QuickNotes";
            // 
            // CellRadioButton
            // 
            this.CellRadioButton.AutoSize = true;
            this.CellRadioButton.Checked = true;
            this.CellRadioButton.Location = new System.Drawing.Point(100, 3);
            this.CellRadioButton.Name = "CellRadioButton";
            this.CellRadioButton.Size = new System.Drawing.Size(42, 17);
            this.CellRadioButton.TabIndex = 7;
            this.CellRadioButton.TabStop = true;
            this.CellRadioButton.Text = "Cell";
            this.CellRadioButton.UseVisualStyleBackColor = true;
            // 
            // RecordingRadioButton
            // 
            this.RecordingRadioButton.AutoSize = true;
            this.ButtonFlowLayoutPanel.SetFlowBreak(this.RecordingRadioButton, true);
            this.RecordingRadioButton.Location = new System.Drawing.Point(148, 3);
            this.RecordingRadioButton.Name = "RecordingRadioButton";
            this.RecordingRadioButton.Size = new System.Drawing.Size(74, 17);
            this.RecordingRadioButton.TabIndex = 8;
            this.RecordingRadioButton.Text = "Recording";
            this.RecordingRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuickNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Enabled = false;
            this.Name = "QuickNotes";
            this.Size = new System.Drawing.Size(444, 122);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.NoteFlowLayoutPanel.ResumeLayout(false);
            this.NoteFlowLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ButtonFlowLayoutPanel.ResumeLayout(false);
            this.ButtonFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.FlowLayoutPanel NoteFlowLayoutPanel;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel ButtonFlowLayoutPanel;
        private System.Windows.Forms.Button GoodButton;
        private System.Windows.Forms.Button BadButton;
        private System.Windows.Forms.Button OddButton;
        private System.Windows.Forms.Button ProblemButton;
        private System.Windows.Forms.Label QuickNotesLabel;
        private System.Windows.Forms.RadioButton CellRadioButton;
        private System.Windows.Forms.RadioButton RecordingRadioButton;
    }
}
