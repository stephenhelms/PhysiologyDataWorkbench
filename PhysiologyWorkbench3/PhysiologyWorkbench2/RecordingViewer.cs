using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.UI.WindowsForms;
using NationalInstruments.UI;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyWorkbench
{
    public partial class RecordingViewer : UserControl
    {
        public event EventHandler RecordingChanged;

        private Recording _Recording;
        public Recording Recording
        {
            get { return _Recording; }
            set {
                //if (Recording != null) Recording.Updated -= new EventHandler(OnRecordingUpdated);
                _Recording = value;
                
                if (Recording != null) RecordingBindingSource.DataSource = Recording;
                else RecordingBindingSource.DataSource = typeof(Recording);

                //if (Recording != null) Recording.Updated += new EventHandler(OnRecordingUpdated);
                if (!Disposing)
                {
                    UpdateRecordingView();
                    if (RecordingChanged != null) RecordingChanged(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler IsLegendVisibleChanged;
        private bool _IsLegendVisible = true;
        [DefaultValue(true)]
        public bool IsLegendVisible
        {
            get { return _IsLegendVisible; }
            set
            {
                _IsLegendVisible = value;
                UpdateViewStyle();
                if (IsLegendVisibleChanged != null) IsLegendVisibleChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler IsTitleVisibleChanged;
        private bool _IsTitleVisible = true;
        [DefaultValue(true)]
        public bool IsTitleVisible
        {
            get { return _IsTitleVisible; }
            set
            {
                _IsTitleVisible = value;
                UpdateViewStyle();
                if (IsTitleVisibleChanged != null) IsTitleVisibleChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler IsSidebarHiddenChanged;
        private bool _IsSidebarHidden = false;
        [DefaultValue(false)]
        public bool IsSidebarHidden {
            get {
                return _IsSidebarHidden;
            }
            set {
                _IsSidebarHidden = value;
                UpdateViewStyle();
                if (IsSidebarHiddenChanged != null) IsSidebarHiddenChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler VoltageAxisScalingChanged;
        private AutoAxisMode _VoltageAxisScaling = AutoAxisMode.DynamicRange;
        public AutoAxisMode VoltageAxisScaling
        {
            get { return _VoltageAxisScaling; }
            set
            {
                bool needsUpdate = (_VoltageAxisScaling != value);
                _VoltageAxisScaling = value;
                if(needsUpdate) UpdateVoltageAxisScaling();
                if (VoltageAxisScalingChanged != null) VoltageAxisScalingChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CurrentAxisScalingChanged;
        private AutoAxisMode _CurrentAxisScaling = AutoAxisMode.DynamicRange;
        public AutoAxisMode CurrentAxisScaling
        {
            get { return _CurrentAxisScaling; }
            set
            {
                bool needsUpdate = (_CurrentAxisScaling != value);
                _CurrentAxisScaling = value;
                if(needsUpdate) UpdateCurrentAxisScaling();
                if (CurrentAxisScalingChanged != null) CurrentAxisScalingChanged(this, EventArgs.Empty);
            }
        }
        public Range VoltageAxisRange
        {
            get { return VoltageAxis.Range; }
            set {
                VoltageAxis.Range = value;
            }
        }
        public Range CurrentAxisRange
        {
            get { return CurrentAxis.Range; }
            set
            {
                CurrentAxis.Range = value;
            }
        }


        public event EventHandler CurrentMinDaqVoltageChanged;
        private double _CurrentMinDaqVoltage = -10;

        public double CurrentMinDaqVoltage
        {
            get { return _CurrentMinDaqVoltage; }
            set {
                _CurrentMinDaqVoltage = value;
                if (InvokeRequired)
                    Invoke(new System.Threading.ThreadStart(delegate()
                    {
                        CurrentAxisRange = new Range(CurrentMinDaqVoltage, CurrentAxisRange.Maximum);
                    }));
                if (CurrentMinDaqVoltageChanged != null) CurrentMinDaqVoltageChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CurrentMaxDaqVoltageChanged;

        private double _CurrentMaxDaqVoltage = 10;

        public double CurrentMaxDaqVoltage
        {
            get { return _CurrentMaxDaqVoltage; }
            set {
                _CurrentMaxDaqVoltage = value;
                if (InvokeRequired)
                    Invoke(new System.Threading.ThreadStart(delegate()
                    {
                        CurrentAxisRange = new Range(CurrentAxisRange.Minimum, CurrentMaxDaqVoltage);
                    }));
                if (CurrentMaxDaqVoltageChanged != null) CurrentMaxDaqVoltageChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler VoltageMinDaqVoltageChanged;

        private double _VoltageMinDaqVoltage = -10;

        public double VoltageMinDaqVoltage
        {
            get { return _VoltageMinDaqVoltage; }
            set {
                _VoltageMinDaqVoltage = value;
                if (InvokeRequired)
                    Invoke(new System.Threading.ThreadStart(delegate()
                    {
                        VoltageAxisRange = new Range(VoltageMinDaqVoltage, VoltageAxisRange.Maximum);
                    }));
                if (VoltageMinDaqVoltageChanged != null) VoltageMinDaqVoltageChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler VoltageMaxDaqVoltageChanged;
        private double _VoltageMaxDaqVoltage = 10;

        public double VoltageMaxDaqVoltage
        {
            get { return _VoltageMaxDaqVoltage; }
            set {
                _VoltageMaxDaqVoltage = value;
                if(InvokeRequired)
                    Invoke(new System.Threading.ThreadStart(delegate() {
                        VoltageAxisRange = new Range(VoltageAxisRange.Minimum, VoltageMaxDaqVoltage);
                    }));
                if (VoltageMaxDaqVoltageChanged != null) VoltageMaxDaqVoltageChanged(this, EventArgs.Empty);
            }
        }
	
	


        private SortedList<string, ScatterPlot> _Plots = new SortedList<string, ScatterPlot>();
        protected IDictionary<string, ScatterPlot> Plots
        {
            get { return _Plots; }
            set { _Plots = new SortedList<string,ScatterPlot>(value); }
        }

        public RecordingViewer()
        {
            InitializeComponent();
            RecordingViewerBindingSource.DataSource = this;
            RegisterEventListeners();
        }

        protected virtual void RegisterEventListeners()
        {
            CurrentAxis.RangeChanged += new EventHandler(OnCurrentAxisRangeChanged);
            VoltageAxis.RangeChanged += new EventHandler(OnVoltageAxisRangeChanged);
        }

        protected virtual void UpdateRecordingView()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateRecordingView));
                return;
            }
            if (Recording == null)
            {
                Enabled = false;
                return;
            }

            Enabled = true;
            Title.Text = Recording.Title;
            UpdateAvailableDataListBox();
            DetermineDataToShow();
            CreatePlots();
            UpdateGraph();
            UpdateCurrentAxisScaling();
            UpdateVoltageAxisScaling();
            UpdateAmplifierData();
        }

        private void OnHideButtonClicked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnHideButtonClicked), sender, e);
                return;
            }
            IsSidebarHidden = !IsSidebarHidden;
        }
        private void OnRecordingUpdated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnRecordingUpdated), sender, e);
                return;
            }
            UpdateRecordingView();
        }

        protected virtual void UpdateAvailableDataListBox()
        {
            ChannelsCheckListBox.Items.Clear();

            if (Recording == null) return;

            foreach (string s in Recording.Data.Keys)
            {
                ChannelsCheckListBox.Items.Add(s, true);
            }
        }

        protected virtual void DetermineDataToShow()
        {
            if (Recording != null && Recording.MetaData.ContainsKey("DataToShow"))
            {
                List<string> dataToShow = new List<string>(Recording.MetaData["DataToShow"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                for (int i = 0; i < ChannelsCheckListBox.Items.Count; i++)
                    ChannelsCheckListBox.SetItemChecked(i, dataToShow.Contains(ChannelsCheckListBox.Items[i].ToString()));
            }
        }

        protected virtual void UpdateGraph()
        {
            Graph.Plots.Clear();
            List<ScatterPlot> plotsToShow = new List<ScatterPlot>(Plots.Values);
            Graph.Plots.AddRange(plotsToShow.ToArray());
        }

        protected virtual void CreatePlots()
        {
            CurrentLineColorIndex = 0;
            Plots.Clear();
            Legend.Items.Clear();
            foreach (object o in ChannelsCheckListBox.CheckedItems)
            {
                string key = o.ToString();
                YAxis yaxis = VoltageAxis;
                if (ShowOnCurrentAxis(key)) yaxis = CurrentAxis;
                ScatterPlot plot = new ScatterPlot(TimeAxis, yaxis);
                if (Recording != null)
                {
                    TimeResolvedData points = Recording.Data[key];
                    plot.PlotXY(Array.ConvertAll<float,double>(points.Time,
                        new Converter<float,double>(delegate(float input) { return (double) input; }))
                        ,points.Values);
                }
                plot.LineColor = NextLineColor();
                Plots.Add(key, plot);
                Legend.Items.Add(new LegendItem(Plots[key], key));
            }
        }

        protected virtual void UpdatePlotsData()
        {
            foreach (object o in ChannelsCheckListBox.CheckedItems)
            {
                string key = o.ToString();
                Plots[key].ClearData();
                if (Recording != null)
                {
                    TimeResolvedData points = Recording.Data[key];
                    Plots[key].PlotXY(Array.ConvertAll<float,double>(points.Time,new Converter<float,double>(delegate(float target) { return (double) target; })),
                        points.Values);
                }
            }
        }

        protected int CurrentLineColorIndex = 0;
        protected Color[] LineColors = new Color[] { Color.Yellow, Color.White, Color.Pink, Color.LawnGreen };
        protected virtual Color NextLineColor()
        {
            if (CurrentLineColorIndex >= LineColors.Length) CurrentLineColorIndex = 0;
            return LineColors[CurrentLineColorIndex++];
        }

        protected virtual bool ShowOnCurrentAxis(string key)
        {
            if (key == "Current") return true;
            else return false;
        }

        protected virtual void UpdateAmplifierData()
        {
            // Update the amplifer settings boxes
            if (Recording.EquipmentSettings.ContainsKey("AmplifierCapacitanceCorrection"))
                this.CapacTextbox.Text = Recording.EquipmentSettings["AmplifierCapacitanceCorrection"];
            else
                this.CapacTextbox.Text = "";
            if (Recording.EquipmentSettings.ContainsKey("AmplifierGain"))
                this.GainTextbox.Text = Recording.EquipmentSettings["AmplifierGain"];
            else
                this.GainTextbox.Text = "";
        }

        public virtual void Clear()
        {
            foreach (ScatterPlot p in Plots.Values) p.ClearData();
            ChannelsCheckListBox.Items.Clear();
        }

        
        protected virtual void OnCurrentAxisRangeChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCurrentAxisRangeChanged), sender, e);
                return;
            }
            CurrentMinTextBox.Text = CurrentAxis.Range.Minimum.ToString();
            CurrentMaxTextBox.Text = CurrentAxis.Range.Maximum.ToString();
        }
        protected virtual void OnVoltageAxisRangeChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnVoltageAxisRangeChanged), sender, e);
                return;
            }
            VoltageMinTextBox.Text = VoltageAxis.Range.Minimum.ToString();
            VoltageMaxTextBox.Text = VoltageAxis.Range.Maximum.ToString();
        }

        protected virtual void SetCurrentAxisFixed()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetCurrentAxisFixed));
                return;
            }

            if (CurrentAxisModeComboBox.SelectedIndex != (int)AutoAxisMode.Fixed) CurrentAxisModeComboBox.SelectedIndex = (int)AutoAxisMode.Fixed;
            CurrentMinTextBox.ReadOnly = false;
            CurrentMinTextBox.Enabled = true;
            CurrentMaxTextBox.ReadOnly = false;
            CurrentMaxTextBox.Enabled = true;
            if(CurrentAxis.Mode != AxisMode.Fixed) CurrentAxis.Mode = AxisMode.Fixed;
            try
            {
                double minCurrent, maxCurrent;
                if (CurrentMinTextBox.Text == "") minCurrent = -1;
                else minCurrent = Double.Parse(CurrentMinTextBox.Text);
                if (CurrentMaxTextBox.Text == "") maxCurrent = 1;
                else maxCurrent = Double.Parse(CurrentMaxTextBox.Text);
                CurrentAxis.Range = new Range(minCurrent, maxCurrent);
            }
            catch (Exception x)
            {
                ;
            }
        }
        protected virtual void SetCurrentAxisData()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetCurrentAxisData));
                return;
            }

            if (CurrentAxisModeComboBox.SelectedIndex != (int)AutoAxisMode.Data) CurrentAxisModeComboBox.SelectedIndex = (int)AutoAxisMode.Data;
            CurrentMinTextBox.ReadOnly = true;
            CurrentMinTextBox.Enabled = false;
            CurrentMaxTextBox.ReadOnly = true;
            CurrentMaxTextBox.Enabled = false;
            if (CurrentAxis.Mode != AxisMode.AutoScaleLoose) CurrentAxis.Mode = AxisMode.AutoScaleLoose;
        }
        protected virtual void SetCurrentAxisDynamicRange()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetCurrentAxisDynamicRange));
                return;
            }

            // If the dynamic range information is not available, use autoscaling
            if ((Recording == null) || (Recording.EquipmentSettings.ContainsKey("AmplifierGain")))
            {
                CurrentAxisScaling = AutoAxisMode.Data;
                return;
            }

            try {
                if (CurrentAxisModeComboBox.SelectedIndex != (int)AutoAxisMode.DynamicRange) CurrentAxisModeComboBox.SelectedIndex = (int)AutoAxisMode.DynamicRange;
                CurrentMinTextBox.ReadOnly = true;
                CurrentMinTextBox.Enabled = false;
                CurrentMaxTextBox.ReadOnly = true;
                CurrentMaxTextBox.Enabled = false;
                if (CurrentAxis.Mode != AxisMode.Fixed) CurrentAxis.Mode = AxisMode.Fixed;
                double gain = 1000/Double.Parse(Recording.EquipmentSettings["AmplifierGain"]); // gain is in pA/V
                double min = CurrentMinDaqVoltage*gain;
                double max = CurrentMaxDaqVoltage*gain;
                CurrentAxis.Range = new Range(min, max);
            } catch(Exception e) {
                CurrentAxisScaling = AutoAxisMode.Data; // If a problem happens, autoscale the data
            }
        }

        protected virtual void SetVoltageAxisFixed()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetVoltageAxisFixed));
                return;
            }

            if (VoltageAxisModeComboBox.SelectedIndex != (int)AutoAxisMode.Fixed) VoltageAxisModeComboBox.SelectedIndex = (int)AutoAxisMode.Fixed;
            VoltageMinTextBox.ReadOnly = false;
            VoltageMinTextBox.Enabled = true;
            VoltageMaxTextBox.ReadOnly = false;
            VoltageMaxTextBox.Enabled = true;
            if (VoltageAxis.Mode != AxisMode.Fixed) VoltageAxis.Mode = AxisMode.Fixed;
            try
            {
                double minVoltage = Double.Parse(VoltageMinTextBox.Text);
                double maxVoltage = Double.Parse(VoltageMaxTextBox.Text);
                VoltageAxis.Range = new Range(minVoltage, maxVoltage);
            }
            catch (Exception x)
            {
                ;
            }
        }
        protected virtual void SetVoltageAxisData()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetVoltageAxisData));
                return;
            }

            if (VoltageAxisModeComboBox.SelectedIndex != (int)AutoAxisMode.Data) VoltageAxisModeComboBox.SelectedIndex = (int)AutoAxisMode.Data;
            VoltageMinTextBox.ReadOnly = true;
            VoltageMinTextBox.Enabled = false;
            VoltageMaxTextBox.ReadOnly = true;
            VoltageMaxTextBox.Enabled = false;
            if (VoltageAxis.Mode != AxisMode.AutoScaleLoose) VoltageAxis.Mode = AxisMode.AutoScaleLoose;
        }
        protected virtual void SetVoltageAxisDynamicRange()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(SetVoltageAxisDynamicRange));
                return;
            }

            if (VoltageAxisModeComboBox.SelectedIndex != (int)AutoAxisMode.DynamicRange) VoltageAxisModeComboBox.SelectedIndex = (int)AutoAxisMode.DynamicRange;
            VoltageMinTextBox.ReadOnly = true;
            VoltageMinTextBox.Enabled = false;
            VoltageMaxTextBox.ReadOnly = true;
            VoltageMaxTextBox.Enabled = false;
            if (VoltageAxis.Mode != AxisMode.Fixed) VoltageAxis.Mode = AxisMode.Fixed;
            VoltageAxis.Range = new Range(VoltageMinDaqVoltage, VoltageMaxDaqVoltage);
        }

        protected virtual void UpdateViewStyle()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateViewStyle));
                return;
            }

            Title.Visible = IsTitleVisible;
            Legend.Visible = IsLegendVisible;
            if (!IsSidebarHidden)
            {
                HideButton.Text = "Hide >>>";
                HideablePanel.Visible = true;
                SidebarPanel.MinimumSize = new Size(180, 0);
            }
            else
            {
                HideButton.Text = "<<<";
                HideablePanel.Visible = false;
                SidebarPanel.MinimumSize = new Size(50, 0);
            }
        }

        protected virtual void UpdateCurrentAxisScaling()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateCurrentAxisScaling));
                return;
            }
            switch (CurrentAxisScaling)
            {
                case AutoAxisMode.Fixed:
                    SetCurrentAxisFixed();
                    break;
                case AutoAxisMode.Data:
                    SetCurrentAxisData();
                    break;
                case AutoAxisMode.DynamicRange:
                    SetCurrentAxisDynamicRange();
                    break;
            }
        }
        protected virtual void UpdateVoltageAxisScaling()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateVoltageAxisScaling));
                return;
            }
            switch (VoltageAxisScaling)
            {
                case AutoAxisMode.Fixed:
                    SetVoltageAxisFixed();
                    break;
                case AutoAxisMode.Data:
                    SetVoltageAxisData();
                    break;
                case AutoAxisMode.DynamicRange:
                    SetVoltageAxisDynamicRange();
                    break;
            }
        }

        private void OnCurrentRecordingChanged(object sender, EventArgs e)
        {
            UpdateRecordingView();
        }

        private void OnCurrentAxisModeComboBoxSelectionChanged(object sender, EventArgs e)
        {
            CurrentAxisScaling = (AutoAxisMode)CurrentAxisModeComboBox.SelectedIndex;
        }

        private void OnVoltageAxisModeComboBoxSelectionChanged(object sender, EventArgs e)
        {
            VoltageAxisScaling = (AutoAxisMode)VoltageAxisModeComboBox.SelectedIndex;
        }

        protected virtual void OnCheckedChannelsChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCheckedChannelsChanged), sender, e);
                return;
            }

            CreatePlots();
            UpdateGraph();
            // if(Recording != null) Recording.SetMetaData("DataToShow",...);
        }

        private void OnShowTitleClicked(object sender, EventArgs e)
        {
            Invoke(new System.Threading.ThreadStart(delegate()
            {
                this.IsTitleVisible = ShowTitleMenuItem.Checked;
            }));
        }

        private void OnShowLegendClicked(object sender, EventArgs e)
        {
            Invoke(new System.Threading.ThreadStart(delegate()
            {
                this.IsLegendVisible = ShowLegendMenuItem.Checked;
            }));
        }
    }

    public enum AutoAxisMode { Fixed, Data, DynamicRange };
}
