using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyWorkbench.GUI;

namespace RRLab.PhysiologyWorkbench
{
    public partial class MainWindow : Form, IPhysiologyWorkbenchProgramProvider
    {
        public event EventHandler ProgramChanged;

        private PhysiologyWorkbenchProgram _Program;

        public PhysiologyWorkbenchProgram Program
        {
            get { return _Program; }
            set {
                _Program = value;
                OnProgramChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnProgramChanged(EventArgs e)
        {
            if (Program != null)
            {
                ProgramBindingSource.DataSource = Program;
                try
                {
                    this.DataBindings.Add("DataManager", Program, "DataManager");
                    this.DataBindings.Add("DeviceManager", Program, "DeviceManager");
                }
                catch (Exception x) { ; }

                if (Program.DataManager != null)
                {
                    try
                    {
                        Program.DataManager.StartingDatabaseUpdate -= new EventHandler(OnDatabaseUpdateStarted);
                        Program.DataManager.FinishedDatabaseUpdate -= new EventHandler(OnDatabaseUpdateFinished);
                    }
                    catch { ; }
                    Program.DataManager.StartingDatabaseUpdate += new EventHandler(OnDatabaseUpdateStarted);
                    Program.DataManager.FinishedDatabaseUpdate += new EventHandler(OnDatabaseUpdateFinished);
                }
            }
            else ProgramBindingSource.DataSource = typeof(PhysiologyWorkbenchProgram);
            
            if (ProgramChanged != null) ProgramChanged(this, e);
        }

        protected virtual void OnDatabaseUpdateStarted(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
            SuspendDataBinding();
        }
        protected virtual void OnDatabaseUpdateFinished(object sender, EventArgs e)
        {
            ResumeDataBinding();
        }

        public event EventHandler DeviceManagerChanged;

        public DeviceManager DeviceManager
        {
            get { return _DeviceManager; }
            set {
                _DeviceManager = value;
                if (DeviceManager != null) DeviceManagerBindingSource.DataSource = DeviceManager;
                else DeviceManagerBindingSource.DataSource = typeof(DeviceManager);
                if (DeviceManagerChanged != null) DeviceManagerChanged(this, EventArgs.Empty);
            }
        }
	

        public event EventHandler DataManagerChanged;

        public DataManager DataManager
        {
            get { return _DataManager; }
            set {
                if (DataManager != null)
                {
                    DataManager.DataChanged -= new EventHandler(OnDataSetChanged);
                    DataManager.CurrentCellChanged -= new EventHandler(OnCurrentCellChanged);
                    DataManager.CurrentRecordingChanged -= new EventHandler(OnCurrentRecordingChanged);
                }
                _DataManager = value;
                if (DataManager != null)
                {
                    DataManager.DataChanged += new EventHandler(OnDataSetChanged);
                    DataManager.CurrentCellChanged += new EventHandler(OnCurrentCellChanged);
                    DataManager.CurrentRecordingChanged += new EventHandler(OnCurrentRecordingChanged);
                    DataManagerBindingSource.DataSource = DataManager;
                }
                else DataManagerBindingSource.DataSource = typeof(DataManager);
                if (DataManagerChanged != null) DataManagerChanged(this, EventArgs.Empty);
                OnDataSetChanged(this, EventArgs.Empty);
            }
        }

        protected virtual void OnDataSetChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDataSetChanged), sender, e);
                return;
            }

            if (DataManager != null)
            {
                CellInfoControl.DataSet = DataManager.Data;
                RecordingInfoControl.DataSet = DataManager.Data;
            }

            OnCurrentCellChanged(this, e);
            OnCurrentRecordingChanged(this, e);
        }
        protected virtual void OnCurrentCellChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCurrentCellChanged), sender, e);
                return;
            }

            if (DataManager != null)
                CellInfoControl.Cell = DataManager.CurrentCell;
        }
        protected virtual void OnCurrentRecordingChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCurrentRecordingChanged), sender, e);
                return;
            }

            if (DataManager != null)
                RecordingInfoControl.Recording = DataManager.CurrentRecording;
        }
	

        public MainWindow()
        {
            InitializeComponent();
            mainWindowBindingSource.DataSource = this;
        }
        public MainWindow(PhysiologyWorkbenchProgram program)
        {
            InitializeComponent();

            Program = program;
            if (Program == null) Program = new PhysiologyWorkbenchProgram();

            Program.DeviceManager.RestoreSavedDeviceSettings();
            Program.HotkeyManager.RestoreSavedHotkeys();

            mainWindowBindingSource.DataSource = this;
        }

        private void NewCellMenuItem_Click(object sender, EventArgs e)
        {
            if (Program == null || Program.DataManager == null) return;
            else Program.DataManager.CreateNewCell();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Request save first before exiting
            Application.Exit();
        }

        private void TrashCurrentRecordingSetMenuItem_Click(object sender, EventArgs e)
        {
            if (Program == null || Program.DataManager == null) return;
            // TODO: Request confirmation
            //Program.DataManager.TrashCurrentCell();
        }

        private void TrashCurrentRecordingMenuItem_Click(object sender, EventArgs e)
        {
            if (Program == null || Program.DataManager == null) return;
            // TODO: Request confirmation
            //Program.DataManager.TrashCurrentRecording();
        }

        private void OpenDeviceManagerMenuItem_Click(object sender, EventArgs e)
        {
            if (Program == null || Program.DeviceManager == null) return;

            if (InvokeRequired)
            {
                Invoke(new EventHandler(OpenDeviceManagerMenuItem_Click), sender, e);
                return;
            }
            DeviceManagerDialog dialog = new DeviceManagerDialog(Program.DeviceManager);
            dialog.ShowDialog(this);
        }

        protected virtual void OpenManualControlButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OpenManualControlButton_Click), sender, e);
                return;
            }
            RRLab.PhysiologyWorkbench.GUI.DeviceManualControlDialog dialog =
                new RRLab.PhysiologyWorkbench.GUI.DeviceManualControlDialog(Program.DeviceManager);
            dialog.Show();
        }

        private void saveCurrentCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program == null || Program.DataManager == null)
            {
                MessageBox.Show("File not saved.");
                return;
            }
            //else Program.DataManager.SaveCell();
        }

        private void saveCurrentRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program == null || Program.DataManager == null)
            {
                MessageBox.Show("File not saved.");
                return;
            }
            //else Program.DataManager.SaveRecording();
        }        

        protected virtual void OnSaveAllDataClicked(object sender, EventArgs e)
        {
            if (Program != null) Program.DataManager.RequestUserToSaveDataToFile();
        }

        protected virtual void OnSaveCurrentRecordingInExcelClicked(object sender, EventArgs e)
        {
            //if ((DataManager == null) || (DataManager.CurrentRecording == null)) return;
            //RRLab.PhysiologyWorkbench.ExcelExporter.ExcelExporterComponent excel = new RRLab.PhysiologyWorkbench.ExcelExporter.ExcelExporterComponent();
            //excel.ExportRecordingToExcel(DataManager.CurrentRecording);
        }
        private void OnOpenHotkeyManagerClicked(object sender, EventArgs e)
        {
            if (Program.HotkeyManager == null) return;

            HotkeyManagerDialog dialog = new HotkeyManagerDialog();
            dialog.HotkeyManager = Program.HotkeyManager;
            dialog.ShowDialog(this);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(Program != null && Program.HotkeyManager != null) Program.HotkeyManager.ProcessKeyDownEvent(e);
        }

        private void OnSelectedTabChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex != 0)
                TestPulsePanel.NotifyNotVisible();
        }

        private void autoSaveMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void saveAllDataToDatabaseMenuItem_Click(object sender, EventArgs e)
        {
            if (Program != null && Program.DataManager != null)
                Program.DataManager.UpdateAllToDatabase();
        }

        public virtual void SuspendDataBinding()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SuspendDataBinding));
                return;
            }

            DataManagerBindingSource.SuspendBinding();
            CellInfoControl.SuspendDataBinding();
            RecordingInfoControl.SuspendDataBinding();
        }
        public virtual void ResumeDataBinding()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResumeDataBinding));
                return;
            }

            DataManagerBindingSource.ResumeBinding();
            CellInfoControl.ResumeDataBinding();
            RecordingInfoControl.ResumeDataBinding();

            DataManagerBindingSource.ResetBindings(false);
        }
    }
}