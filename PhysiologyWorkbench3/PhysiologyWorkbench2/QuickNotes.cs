using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class QuickNotes : UserControl
    {
        public event EventHandler ProgramChanged;
        private PhysiologyWorkbenchProgram _Program;
        [Bindable(true)]
        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                if (Program != null && Program.DataManager != null) Program.DataManager.CurrentRecordingChanged -= new EventHandler(OnRecordingChanged);
                _Program = value;
                if (Program != null && Program.DataManager != null) Program.DataManager.CurrentRecordingChanged += new EventHandler(OnRecordingChanged);
                OnProgramChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnProgramChanged(EventArgs e)
        {
            OnHotkeyManagerChanged(e);
            OnRecordingChanged(this, e);

            if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
        }

        public AnnotationTarget AnnotationTarget
        {
            get
            {
                if (CellRadioButton.Checked) return AnnotationTarget.Cell;
                else return AnnotationTarget.Recording;
            }
        }

	

        public QuickNotes()
        {
            InitializeComponent();
            OnRecordingChanged(null, null);
        }

        protected virtual void OnHotkeyManagerChanged(EventArgs e)
        {
            if (Program != null && Program.HotkeyManager != null)
            {
                Program.HotkeyManager.RegisterAction("QuickNote -- Good", new System.Threading.ThreadStart(AddQuickNoteGood));
                Program.HotkeyManager.RegisterAction("QuickNote -- Bad", new System.Threading.ThreadStart(AddQuickNoteBad));
                Program.HotkeyManager.RegisterAction("QuickNote -- Odd", new System.Threading.ThreadStart(AddQuickNoteOdd));
                Program.HotkeyManager.RegisterAction("QuickNote -- Problem", new System.Threading.ThreadStart(AddQuickNoteProblem));
            }
        }

        protected virtual void OnRecordingChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRecordingChanged), sender, e);
                return;
            }
            if (Program == null || Program.DataManager == null || Program.DataManager.CurrentRecording == null)
                this.Enabled = false;
            else
                this.Enabled = true;
        }

        protected virtual void OnClearButtonClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnClearButtonClicked), sender, e);
                return;
            }
            NoteTextBox.Clear();

            AcceptButton.Enabled = false;
            ClearButton.Enabled = false;
        }

        private void OnAcceptButtonClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnAcceptButtonClicked), sender, e);
                return;
            }

            Annotate(NoteTextBox.Text);

            NoteTextBox.Clear();
            AcceptButton.Enabled = false;
            ClearButton.Enabled = false;
        }

        protected virtual void Annotate(string text)
        {
            if (AnnotationTarget == AnnotationTarget.Cell)
            {
                if (Program == null || Program.DataManager == null || Program.DataManager.CurrentCell == null)
                    return;
                Program.DataManager.CurrentCell.AddAnnotation(
                    new Annotation(text, Program.User));
            }
            else if (AnnotationTarget == AnnotationTarget.Recording)
            {
                if (Program == null || Program.DataManager == null || Program.DataManager.CurrentRecording == null)
                    return;
                Program.DataManager.CurrentRecording.AddAnnotation(
                    new Annotation(text, Program.User));
            }
        }

        protected virtual void OnNoteTextChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnNoteTextChanged), sender, e);
                return;
            }
            if (NoteTextBox.Text == "")
            {
                AcceptButton.Enabled = false;
                ClearButton.Enabled = false;
            }
            else
            {
                AcceptButton.Enabled = true;
                ClearButton.Enabled = true;
            }
        }

        private void GoodButton_Click(object sender, EventArgs e)
        {
            AddQuickNoteGood();
        }

        private void BadButton_Click(object sender, EventArgs e)
        {
            AddQuickNoteBad();
        }

        private void OddButton_Click(object sender, EventArgs e)
        {
            AddQuickNoteOdd();
        }

        private void ProblemButton_Click(object sender, EventArgs e)
        {
            AddQuickNoteProblem();
        }

        public virtual void AddQuickNoteGood()
        {
            Annotate("Good");
        }
        public virtual void AddQuickNoteBad()
        {
            Annotate("Bad");
        }
        public virtual void AddQuickNoteOdd()
        {
            Annotate("Odd");
        }
        public virtual void AddQuickNoteProblem()
        {
            Annotate("Problem");
        }

        private void NoteTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptButton.PerformClick();
                e.Handled = true;
            }
        }
    }

    public enum AnnotationTarget { Cell, Recording };
}
