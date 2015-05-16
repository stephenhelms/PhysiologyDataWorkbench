using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using RRLab.PhysiologyDataConnectivity;
using RRLab.PhysiologyDataWorkshop.Experiments;

namespace RRLab.PhysiologyDataWorkshop
{
    public partial class MainWindow : Form
    {
        public event EventHandler ProgramChanged;
        private PhysiologyDataWorkshopProgram _Program;

        public PhysiologyDataWorkshopProgram Program
        {
            get { return _Program; }
            set {
                if (Program != null)
                {
                    Program.DataSetChanged -= new EventHandler(OnDataSetChanged);
                    Program.CurrentExperimentChanged -= new EventHandler(OnCurrentExperimentChanged);
                }
                _Program = value;
                if (Program != null)
                {
                    ProgramBindingSource.DataSource = Program;
                    Program.DataSetChanged += new EventHandler(OnDataSetChanged);
                    Program.CurrentExperimentChanged += new EventHandler(OnCurrentExperimentChanged);
                }
                else
                {
                    ProgramBindingSource.DataSource = typeof(PhysiologyDataWorkshopProgram);
                }

                OnDataSetChanged(this, EventArgs.Empty);

                if (ProgramChanged != null) ProgramChanged(this, EventArgs.Empty);
            }
        }
	

        public MainWindow()
        {
            InitializeComponent();
            MainWindowBindingSource.DataSource = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadExperiments();
            base.OnLoad(e);
        }

        protected virtual void OnDataSetChanged(object sender, EventArgs e)
        {
            if (Program != null && Program.DataSet != null)
                CellsBindingSource.DataSource = Program.DataSet;
            else CellsBindingSource.DataSource = typeof(PhysiologyDataSet);
        }

        protected virtual void LoadExperiments()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(LoadExperiments));
                return;
            }

            System.Diagnostics.Debug.Assert(Program != null, "MainWindow@LoadExperiments: Program is null.");

            ExperimentsComboBox.Items.Clear();
            ExperimentsComboBox.Items.AddRange(new List<IExperiment>(Program.GetExperiments()).ToArray());
        }

        protected virtual void OnCurrentExperimentChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCurrentExperimentChanged), sender, e);
                return;
            }

            ExperimentPanelHolder.Controls.Clear();

            System.Diagnostics.Debug.Assert(Program != null, "MainWindow@OnCurrentExperimentChanged: Program is null.");

            if (Program.CurrentExperiment != null)
            {
                Control experimentControl = Program.CurrentExperiment.GetExperimentPanelControl();
                experimentControl.Dock = DockStyle.Fill;
                ExperimentPanelHolder.Controls.Add(experimentControl);
            }
        }
    }
}