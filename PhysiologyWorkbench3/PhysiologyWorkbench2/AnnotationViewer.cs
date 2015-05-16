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
    public partial class AnnotationViewer : UserControl
    {
        private DataManager _DataManager;

        public DataManager DataManager
        {
            get { return _DataManager; }
            set {
                if (DataManager != null)
                {
                    DataManager.CurrentRecordingChanged -= new EventHandler(OnRecordingChanged);
                    DataManager.RecordingUpdated -= new EventHandler(OnRecordingChanged);
                }
                _DataManager = value;
                if (DataManager != null)
                {
                    DataManager.CurrentRecordingChanged += new EventHandler(OnRecordingChanged);
                    DataManager.RecordingUpdated += new EventHandler(OnRecordingChanged);
                }
                OnRecordingChanged(this, EventArgs.Empty);
            }
        }
	

        public AnnotationViewer()
        {
            InitializeComponent();
        }

        protected virtual void OnRecordingChanged(object sender, EventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new EventHandler(OnRecordingChanged), sender, e);
            //    return;
            //}
            //if ((DataManager == null) || (DataManager.CurrentRecording == null))
            //{
            //    Enabled = false;
            //    AnnotationsRichTextBox.Clear();
            //    return;
            //}

            //Enabled = true;
            //WriteAnnotationsToTextBox();
        }

        protected virtual void WriteAnnotationsToTextBox()
        {
            //AnnotationsRichTextBox.Clear();
            //if (DataManager.CurrentRecording == null)
            //    return;
            //foreach (Annotation note in DataManager.CurrentRecording.Annotations)
            //    AppendAnnotationToTextBox(note);
        }
        protected virtual void AppendAnnotationToTextBox(Annotation note)
        {
            string dateTimeString = note.Time.ToLocalTime().ToShortDateString() + " " + note.Time.ToLocalTime().ToShortTimeString() + ": ";
            AnnotationsRichTextBox.AppendText(dateTimeString);
            // Apply formatting
            string text = note.Text;
            AnnotationsRichTextBox.AppendText(text);
            AnnotationsRichTextBox.AppendText(System.Environment.NewLine);
        }
    }
}
