using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class FilterWheelDeviceCompactControl : UserControl
    {
        public event EventHandler FilterWheelChanged;
        private FilterWheelDevice _FilterWheel;

        public FilterWheelDevice FilterWheel
        {
            get { return _FilterWheel; }
            set {
                if (FilterWheel == value) return;
                _FilterWheel = value;
                OnFilterWheelChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnFilterWheelChanged(EventArgs e)
        {
            LoadFilterWheelSettings();

            if(FilterWheelChanged != null)
                try
                {
                    FilterWheelChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during FilterWheelChanged event.", x.Message);
                }
        }
	

        public FilterWheelDeviceCompactControl()
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
            if (FilterWheel == null)
            {
                Enabled = false;
                FiltersComboBox.SelectedIndex = -1;
                ShutterAComboBox.SelectedIndex = -1;
                ShutterBComboBox.SelectedIndex = -1;
            }
            else
            {
                foreach (string filterName in FilterWheel.Filters.Keys)
                    FiltersComboBox.Items.Add(filterName);
                string currentFilter = "";
                if (FilterWheel.CurrentFilter != null && FiltersComboBox.Items.Contains(FilterWheel.CurrentFilter))
                    currentFilter = FilterWheel.CurrentFilter;
                FiltersComboBox.SelectedValue = currentFilter;

                ShutterAComboBox.SelectedIndex = (int)FilterWheel.ShutterAStatus;
                ShutterBComboBox.SelectedIndex = (int)FilterWheel.ShutterBStatus;

                Enabled = true;
            }
        }

        protected virtual void SelectFilterButton_Click(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.SelectFilter(FiltersComboBox.SelectedItem.ToString());
            }
            catch (Exception x)
            {
                MessageBox.Show("Error selecting filter: " + x.Message);
            }
        }

        protected virtual void SetShutterAButton_Click(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.SetShutterState('A', (FilterWheelShutterStatus)ShutterAComboBox.SelectedIndex);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error setting shutter state: " + x.Message);
            }
        }

        protected virtual void SetShutterBButton_Click(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.SetShutterState('B', (FilterWheelShutterStatus)ShutterBComboBox.SelectedIndex);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error setting shutter state: " + x.Message);
            }
        }
    }
}
