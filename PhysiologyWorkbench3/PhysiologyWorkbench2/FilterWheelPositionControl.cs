using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.PhysiologyWorkbench.Devices
{
    public partial class FilterWheelPositionControl : UserControl
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
                if (FilterWheel != null) FilterWheel.ShutterStateChanged -= new EventHandler(OnFilterWheelStateChanged);
                _FilterWheel = value;
                if (FilterWheel != null) FilterWheel.ShutterStateChanged += new EventHandler(OnFilterWheelStateChanged);
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
                int index = _Wheels.FindIndex(delegate(char c)
                {
                    return c == value;
                });
                if ((index >= 0) && (index < WheelsBox.Items.Count))
                    WheelsBox.SelectedIndex = index;
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

        public FilterWheelPositionControl()
        {
            InitializeComponent();
        }
        public FilterWheelPositionControl(FilterWheel filterWheel)
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
                this.Enabled = true;
                _Wheels.AddRange(filterWheel.GetAvailableWheels());
                foreach (char wheelLetter in _Wheels)
                {
                    WheelsBox.Items.Add("Wheel " + wheelLetter);
                }
                WheelsBox.SelectedIndex = 0;
                if (FilterWheel is SerialPortFilterWheel) TakeControlButton.Enabled = true;
                else TakeControlButton.Enabled = false;
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

            ShutterStateComboBox.DataSource = Enum.GetValues(typeof(FilterWheelShutterStatus));

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

            switch (Char.ToUpper(CurrentWheel))
            {
                case 'A':
                    ShutterStateComboBox.SelectedItem = FilterWheel.ShutterAStatus;
                    break;
                case 'B':
                    ShutterStateComboBox.SelectedItem = FilterWheel.ShutterBStatus;
                    break;
                default:
                    ShutterStateComboBox.SelectedItem = null;
                    break;
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

            
        }

        protected virtual void OnSetFilterClicked(object sender, EventArgs e)
        {
            if (FilterWheel == null) return;
            try
            {
                FilterWheel.SetFilterWheelPosition(CurrentWheel, CurrentPosition, FilterWheel.DefaultSpeed);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error while setting filter wheel position: " + x.Message);
            }
        }

        protected virtual void OnTakeControlClicked(object sender, EventArgs e)
        {
            if (FilterWheel == null || !(FilterWheel is SerialPortFilterWheel)) return;
            try {
                ((SerialPortFilterWheel)FilterWheel).ForceComputerControl();
            }
            catch(Exception x)
            {
                MessageBox.Show("Error taking control of filter wheel: " + x.Message);
            }
        }

        private void OnSetShutterClicked(object sender, EventArgs e)
        {
            try
            {
                FilterWheelShutterStatus state = (FilterWheelShutterStatus)ShutterStateComboBox.SelectedValue;
                if (FilterWheel != null)
                    FilterWheel.SetShutterState(CurrentWheel, state);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error setting shutter state: " + x.Message);
            }
        }

        protected virtual void OnFilterWheelStateChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnFilterWheelStateChanged), sender, e);
                return;
            }
            LoadFilterWheelSettings(FilterWheel);
        }
    }
}
