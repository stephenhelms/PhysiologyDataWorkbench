using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class FilterWheelConfigurationControl : UserControl
    {
        private List<char> _Wheels = new List<char>(3);

        private FilterWheel _FilterWheel;
        public FilterWheel FilterWheel
        {
            get
            {
                return _FilterWheel;
            }
            set
            {
                _FilterWheel = value;
                LoadFilterWheelSettings(_FilterWheel);
            }
        }

        public char CurrentWheel
        {
            get
            {
                return _Wheels[WheelsBox.SelectedIndex];
            }
            set
            {
                WheelsBox.SelectedIndex = _Wheels.FindIndex(delegate(char c)
                {
                    return c == value;
                });
            }
        }
        public int CurrentPosition
        {
            get
            {
                return FiltersBox.SelectedIndex;
            }
            set
            {
                FiltersBox.SelectedIndex = value;
            }
        }

        public FilterWheelConfigurationControl()
        {
            InitializeComponent();
        }
        public FilterWheelConfigurationControl(FilterWheel filterWheel)
        {
            InitializeComponent();
            FilterWheel = filterWheel;
        }

        protected virtual void LoadFilterWheelSettings(FilterWheel filterWheel)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() { LoadFilterWheelSettings(filterWheel); }));
                return;
            }

            WheelsBox.Items.Clear();
            _Wheels.Clear();

            if (filterWheel == null)
            {
                this.Enabled = false;
            }
            else
            {
                _Wheels.AddRange(filterWheel.GetAvailableWheels());
                foreach (char wheelLetter in _Wheels)
                {
                    WheelsBox.Items.Add("Wheel " + wheelLetter);
                }
                WheelsBox.SelectedIndex = 0;
            }
        }
        protected virtual void LoadFilterDescriptions(FilterWheel filterWheel, char wheel)
        {
            if (filterWheel == null) return;
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() { LoadFilterDescriptions(filterWheel, wheel); }));
                return;
            }

            FiltersBox.Enabled = true;

            FiltersBox.Items.Clear();
            for (int i = 0; i < FilterWheel.NumberOfFilters; i++)
            {
                string name = i.ToString();
                string description = FilterWheel.GetFilterDescription(CurrentWheel, i);
                if (description != null)
                    name += " " + description;
                FiltersBox.Items.Add(name);
            }
        }

        protected virtual void OnSelectedWheelChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedWheelChanged),sender,e);
                return;
            }

            
            if (WheelsBox.SelectedIndex != -1)
            {
                LoadFilterDescriptions(FilterWheel, CurrentWheel);
            }
            else
            {
                FiltersBox.Items.Clear();
                FiltersBox.Enabled = false;
            }
        }

        protected virtual void OnSelectedFilterChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedFilterChanged), sender, e);
                return;
            }

            if (FiltersBox.SelectedIndex == -1)
            {
                FilterDescriptionBox.Clear();
            }
            else
            {
                FilterDescriptionBox.Text = FilterWheel.GetFilterDescription(CurrentWheel, CurrentPosition);
            }
            UpdateButton.Enabled = false;
        }

        protected virtual void OnDescriptionTextChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnDescriptionTextChanged), sender, e);
                return;
            }

            UpdateButton.Enabled = true;
        }

        protected virtual void OnFiltersBoxEnabledChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnFiltersBoxEnabledChanged), sender, e);
                return;
            }

            if (!FiltersBox.Enabled)
            {
                FilterDescriptionBox.Enabled = false;
                UpdateButton.Enabled = false;
            }
        }

        protected virtual void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnUpdateButtonClicked), sender, e);
                return;
            }

            try
            {
                FilterWheel.SetFilterDescription(CurrentWheel, CurrentPosition, FilterDescriptionBox.Text);
                UpdateButton.Enabled = false;
                LoadFilterDescriptions(FilterWheel, CurrentWheel);
            }
            catch (Exception x)
            {
                MessageBox.Show("Filter description not accepted: " + x.Message);
            }
        }

    }
}
