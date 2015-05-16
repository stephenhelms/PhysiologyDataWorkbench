using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Devices;

namespace RRLab.PhysiologyWorkbench.GUI
{
    public partial class CompactFilterWheelConfigurationControl : UserControl
    {
        private FilterWheel _FilterWheel;

        public FilterWheel FilterWheel
        {
            get { return _FilterWheel; }
            set {
                _FilterWheel = value;
                LoadFilterWheelSettings();
            }
        }
	

        public CompactFilterWheelConfigurationControl()
        {
            InitializeComponent();
        }

        protected virtual void LoadFilterWheelSettings()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(LoadFilterWheelSettings));
                return;
            }
            WheelBComboBox.Items.Clear();
            WheelAComboBox.Items.Clear();

            if (FilterWheel == null) this.Enabled = false;
            else
            {
                this.Enabled = true;

                for (int i = 0; i < FilterWheel.NumberOfFilters; i++)
                {
                    WheelBComboBox.Items.Add(FilterWheel.GetFilterDescription('A', i));
                    WheelAComboBox.Items.Add(FilterWheel.GetFilterDescription('B', i));
                }
            }
        }

        protected virtual void OnWheelASelectedFilterChanged(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.SetFilterWheelPosition('A', WheelAComboBox.SelectedIndex, FilterWheel.DefaultSpeed);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error while setting filter wheel: " + x.Message);
            }
        }

        protected virtual void OnWheelBSelectedFilterChanged(object sender, EventArgs e)
        {
            FilterWheel.SetFilterWheelPosition('B', WheelBComboBox.SelectedIndex, FilterWheel.DefaultSpeed);
        }
    }
}
