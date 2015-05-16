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
        private FilterWheelDevice _FilterWheel;

        public FilterWheelDevice FilterWheel
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
            FiltersComboBox.Items.Clear();

            if (FilterWheel == null) this.Enabled = false;
            else
            {
                this.Enabled = true;

                FiltersComboBox.Items.Clear();
                foreach (string filterName in FilterWheel.Filters.Keys)
                    FiltersComboBox.Items.Add(filterName);
                try
                {
                    FiltersComboBox.SelectedItem = FilterWheel.CurrentFilter;
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Could not select current filter", x.Message);
                }
            }
        }

        protected virtual void OnWheelASelectedFilterChanged(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.SelectFilter(FiltersComboBox.SelectedItem.ToString());
            }
            catch (Exception x)
            {
                MessageBox.Show("Error while setting filter wheel: " + x.Message);
            }
        }
    }
}
