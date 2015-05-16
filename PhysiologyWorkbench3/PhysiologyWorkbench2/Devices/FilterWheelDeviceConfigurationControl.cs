using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class FilterWheelDeviceConfigurationControl : UserControl
    {
        public event EventHandler FilterWheelChanged;
        private FilterWheelDevice _FilterWheel;

        public FilterWheelDevice FilterWheel
        {
            get { return _FilterWheel; }
            set {
                _FilterWheel = value;
                OnFilterWheelChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnFilterWheelChanged(EventArgs e)
        {
            UpdateFilterList();

            if(FilterWheelChanged != null)
                try
                {
                    FilterWheelChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("Error during FilterWheelChanged event.");
                }
        }
	

        public FilterWheelDeviceConfigurationControl(FilterWheelDevice device)
        {
            InitializeComponent();
            FilterWheel = device;
        }

        protected virtual void UpdateFilterList()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateFilterList));
                return;
            }

            FiltersListBox.Items.Clear();
            if (FilterWheel != null)
            {
                foreach (string filterName in FilterWheel.Filters.Keys)
                    FiltersListBox.Items.Add(filterName);
            }
        }

        protected virtual void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.AddFilter(FilterNameTextBox.Text, new FilterWheelState((int)WheelANumericControl.Value, (int)WheelBNumericControl.Value));
                UpdateFilterList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Could not add filter", x.Message);
            }
        }

        protected virtual void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                FilterWheel.RemoveFilter(FiltersListBox.SelectedItem.ToString());
                UpdateFilterList();
            }
            catch (Exception x)
            {
                MessageBox.Show("Could not remove filter", x.Message);
            }
        }

        protected virtual void FiltersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(FiltersListBox_SelectedIndexChanged), sender, e);
                return;
            }

            string name = "";
            int wheelAposition = 0;
            int wheelBposition = 0;

            if (FiltersListBox.SelectedItem != null)
            {
                name = FiltersListBox.SelectedItem.ToString();
                FilterWheelState state;
                if (FilterWheel.Filters.TryGetValue(name, out state))
                {
                    wheelAposition = state.WheelAPosition;
                    wheelBposition = state.WheelBPosition;
                }
            }

            FilterNameTextBox.Text = name;
            WheelANumericControl.Value = wheelAposition;
            WheelBNumericControl.Value = wheelBposition;
        }
    }
}
