using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using System.Threading;
using NationalInstruments.UI;

namespace RRLab.PhysiologyData.GUI
{
    public partial class NIRecordingDataGraphControl : UserControl, INotifyPropertyChanged
    {
        protected bool SuppressUpdates = false;

        public enum AxisLocation { Left, Right };
        public enum AxisMode { Auto, DynamicRange };

        public event EventHandler DefaultAxisLocationChanged;
        private AxisLocation _DefaultAxisLocation;
        [SettingsBindable(true)]
        [Bindable(true)]
        public AxisLocation DefaultAxisLocation
        {
            get { return _DefaultAxisLocation; }
            set {
                _DefaultAxisLocation = value;
                if (DefaultAxisLocationChanged != null) DefaultAxisLocationChanged(this, EventArgs.Empty);
                NotifyPropertyChanged("DefaultAxisLocation");
            }
        }

        public event EventHandler DefaultAxisModeChanged;
        private AxisMode _DefaultAxisMode;
        [SettingsBindable(true)]
        [Bindable(true)]
        public AxisMode DefaultAxisMode
        {
            get { return _DefaultAxisMode; }
            set {
                _DefaultAxisMode = value;
                if (DefaultAxisModeChanged != null) DefaultAxisModeChanged(this, EventArgs.Empty);
                NotifyPropertyChanged("DefaultAxisMode");
            }
        }

        public event EventHandler GraphBackColorChanged;
        private Color _GraphBackColor = Color.LightGoldenrodYellow;
        [Bindable(true)]
        [SettingsBindable(true)]
        public Color GraphBackColor
        {
            get { return _GraphBackColor; }
            set {
                _GraphBackColor = value;
                if (GraphBackColorChanged != null) GraphBackColorChanged(this, EventArgs.Empty);
                NotifyPropertyChanged("GraphBackColor");
            }
        }

        public event EventHandler IsAutoUpdateDisabledChanged;
        private bool _IsAutoUpdateDisabled = false;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(false)]
        public bool IsAutoUpdateDisabled
        {
            get { return _IsAutoUpdateDisabled; }
            set {
                _IsAutoUpdateDisabled = value;
                if (IsAutoUpdateDisabledChanged != null) IsAutoUpdateDisabledChanged(this, EventArgs.Empty);
            }
        }
	

        public event EventHandler IsTitleVisibleChanged;
        private bool _IsTitleVisible = true;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(true)]
        public bool IsTitleVisible
        {
            get { return _IsTitleVisible; }
            set {
                _IsTitleVisible = value;
                OnIsTitleVisibleChanged(EventArgs.Empty);
                NotifyPropertyChanged("IsTitleVisible");
            }
        }

        public event EventHandler IsLegendVisibleChanged;
        private bool _IsLegendVisible = true;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(true)]
        public bool IsLegendVisible
        {
            get { return _IsLegendVisible; }
            set {
                _IsLegendVisible = value;
                OnIsLegendVisibleChanged(EventArgs.Empty);
                NotifyPropertyChanged("IsLegendVisible");
            }
        }

        public event EventHandler DataSetChanged;
        private PhysiologyDataSet _DataSet;
        [Bindable(true)]
        public PhysiologyDataSet DataSet
        {
            get { return _DataSet; }
            set {
                if (DataSet == value) return;
                _DataSet = value;
                OnDataSetChanged(EventArgs.Empty);
                NotifyPropertyChanged("DataSet");
            }
        }	

        public event EventHandler ShownDataListChanged;
        public ICollection<string> ShownDataList
        {
            get
            {
                List<string> shownData = new List<string>(AvailableDataCheckedListBox.CheckedItems.Count);
                foreach (object o in AvailableDataCheckedListBox.CheckedItems)
                    shownData.Add(o.ToString());
                return shownData;
            }
        }

        public event EventHandler AxesLocationsChanged;
        private SortedList<string, AxisLocation> _AxesLocations = new SortedList<string,AxisLocation>();
        public IDictionary<string, AxisLocation> AxesLocations
        {
            get
            {
                return _AxesLocations;
            }
        }

        public event EventHandler AxesModesChanged;
        private SortedList<string, AxisMode> _AxesModes = new SortedList<string, AxisMode>();
        public IDictionary<string, AxisMode> AxesModes
        {
            get
            {
                return _AxesModes;
            }
        }

        public event EventHandler IsSidebarVisibleChanged;
        private bool _IsSidebarVisible = true;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(true)]
        public bool IsSidebarVisible
        {
            get { return _IsSidebarVisible; }
            set {
                _IsSidebarVisible = value;
                OnIsSidebarVisibleChanged(EventArgs.Empty);
                NotifyPropertyChanged("IsSidebarVisible");
            }
        }

        public event EventHandler RecordingChanged;
        private PhysiologyDataSet.RecordingsRow _Recording;
        [Bindable(true)]
        public PhysiologyDataSet.RecordingsRow Recording
        {
            get
            {
                return _Recording;
            }
            set
            {
                if (Recording == value) return;
                _Recording = value;
                OnRecordingChanged(EventArgs.Empty);
            }
        }

        private SortedList<string, string> _AxesTitles = new SortedList<string, string>();
        protected IDictionary<string, string> AxesTitles
        {
            get { return _AxesTitles; }
        }

        private SortedList<string, ScatterPlot> _Plots = new SortedList<string, ScatterPlot>();
        protected IDictionary<string, ScatterPlot> Plots
        {
            get { return _Plots; }
        }

        private SortedList<string, YAxis> _Axes = new SortedList<string, YAxis>();
        protected IDictionary<string, YAxis> Axes
        {
            get { return _Axes; }
        }

        public NIRecordingDataGraphControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ResetGraph();
        }

        protected virtual void SetAxisLocation(string dataName, AxisLocation location)
        {
            if (_AxesLocations.ContainsKey(dataName))
                _AxesLocations[dataName] = location;
            else _AxesLocations.Add(dataName, location);

            OnAxesLocationsChanged(EventArgs.Empty);
        }

        protected virtual void OnAxesLocationsChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnAxesLocationsChanged), e);
                return;
            }

            if(AxesLocationsChanged != null)
                try
                {
                    AxesLocationsChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        protected virtual void OnRecordingChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnRecordingChanged), e);
                return;
            }

            if (RecordingBindingSource.DataSource != null)
                try
                {
                    if (Recording == null || DataSet == null)
                    {
                        Enabled = false;
                        RecordingBindingSource.Position = -1;
                    }
                    else
                    {
                        int position = RecordingBindingSource.Find("RecordingID", Recording.RecordingID);
                        System.Diagnostics.Debug.Assert(position >= 0, "NIRecordingDataGraphControl: Recording not found.");
                        RecordingBindingSource.Position = position;
                        Enabled = true;
                    }
                    ResetGraph();
                }
                catch (Exception x) { ; }
            else
            {
                Enabled = false;
                ResetGraph();
            }

            if (RecordingChanged != null)
                try
                {
                    RecordingChanged(this, e);
                }
                catch(Exception x)
                {
                    System.Diagnostics.Debug.Fail("NIRecordingDataGraphControl: Error during RecordingChanged event.", x.Message);
                }
        }


        protected virtual void SetAxisMode(string dataName, AxisMode mode)
        {
            if (_AxesModes.ContainsKey(dataName) && _AxesModes[dataName] != mode)
            {
                _AxesModes[dataName] = mode;
                OnAxesModesChanged(EventArgs.Empty);
            }
            else
            {
                _AxesModes.Add(dataName, mode);
                OnAxesModesChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnAxesModesChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnAxesModesChanged), e);
                return;
            }

            if(!SuppressUpdates) ResetGraph();

            if (AxesModesChanged != null)
                try {
                    AxesModesChanged(this, e);
                } catch(Exception x) { ; }
        }

        
        protected virtual void OnIsTitleVisibleChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnIsTitleVisibleChanged), e);
                return;
            }



            if (IsTitleVisibleChanged != null)
                try
                {
                    IsTitleVisibleChanged(this, e);
                }
                catch (Exception x) { ; }
        }
        protected virtual void OnIsLegendVisibleChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnIsLegendVisibleChanged), e);
                return;
            }

            Legend.Visible = IsLegendVisible;

            if (IsLegendVisibleChanged != null)
                try
                {
                    IsLegendVisibleChanged(this, e);
                }
                catch (Exception x) { ; }
        }
        protected virtual void OnDataSetChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnDataSetChanged), e);
                return;
            }

            if (AreUpdatesSuspended) return;
            if (DataSet != null)
            {
                RecordingBindingSource.DataSource = DataSet;
                RecordingBindingSource.DataMember = "Recordings";
            }
            else
            {
                RecordingBindingSource.DataSource = typeof(PhysiologyDataSet);
                RecordingBindingSource.DataMember = "Recordings";
            }
            OnRecordingChanged(EventArgs.Empty);

            if (DataSetChanged != null)
                try
                {
                    DataSetChanged(this, EventArgs.Empty);
                }
                catch (Exception x) { ; }
        }

        protected virtual void OnShowTitleChecked(object sender, EventArgs e)
        {
            IsTitleVisible = ShowTitleCheckBox.Checked;
        }

        protected virtual void OnShowLegendChecked(object sender, EventArgs e)
        {
            IsLegendVisible = ShowLegendCheckBox.Checked;
        }

        protected virtual void OnIsSidebarVisibleChanged(EventArgs e)
        {
            if (InvokeRequired) {
                Invoke(new Action<EventArgs>(OnIsSidebarVisibleChanged), e);
                return;
            }

            // Hide the panel
            HideablePanel.Visible = IsSidebarVisible;
            // Update the button label
            if (IsSidebarVisible)
                ToggleHiddenButton.Text = "Hide >>>";
            else ToggleHiddenButton.Text = "<<<";

            if(IsSidebarVisibleChanged != null)
                try
                {
                    IsSidebarVisibleChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        protected virtual void UpdateAvailableDataList()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(UpdateAvailableDataList));
                return;
            }

            System.Diagnostics.Debug.WriteLine("NIRecordingDataGraphControl: Updating available data list.");

            // Figure out the items that are not checked, since the default is to be checked
            List<string> notChecked = new List<string>(AvailableDataCheckedListBox.Items.Count);
            foreach (string s in AvailableDataCheckedListBox.Items)
                if (!AvailableDataCheckedListBox.CheckedItems.Contains(s))
                    notChecked.Add(s);

            // Clear the list
            AvailableDataCheckedListBox.Items.Clear();
            
            // Load the new data
            if (DataSet != null)
            {
                if (Recording != null)
                {
                    List<string> channels = new List<string>(Recording.GetDataNames());

                    foreach (string channel in channels)
                    {
                        IDictionary<string, AxisMode> axisModeMetaData = GetAxesModesFromMetaData();
                        IDictionary<string, AxisLocation> axisLocationMetaData = GetAxesLocationsFromMetaData();

                        if (!AxesLocations.ContainsKey(channel))
                        {
                            if (axisModeMetaData != null && axisModeMetaData.ContainsKey(channel))
                                SetAxisLocation(channel, axisLocationMetaData[channel]);
                            else SetAxisLocation(channel, DefaultAxisLocation);
                        }
                        if (!AxesModes.ContainsKey(channel))
                        {
                            if (axisLocationMetaData != null && axisLocationMetaData.ContainsKey(channel))
                                SetAxisMode(channel, axisModeMetaData[channel]);
                            else SetAxisMode(channel, DefaultAxisMode);
                        }
                    }

                    // Set shown items
                    _DataNames.Clear();
                    _DataNames.AddRange(channels.ToArray());
                    OnDataNamesChanged(EventArgs.Empty);

                    List<string> dataToShowMetaData = new List<string>();
                    lock (DataSet)
                    {
                        if (Recording.DoesMetaDataExist("DataToShow"))
                            dataToShowMetaData = new List<string>(Recording.GetMetaData("DataToShow").Split(','));
                    }
                    for (int i = 0; i < dataToShowMetaData.Count; i++)
                        dataToShowMetaData[i] = dataToShowMetaData[i].Trim();
                    if (dataToShowMetaData.Count == 0)
                        dataToShowMetaData.AddRange(DataNames);

                    AvailableDataCheckedListBox.Items.Clear();
                    foreach (string dataName in DataNames)
                        AvailableDataCheckedListBox.Items.Add(dataName, (!notChecked.Contains(dataName) && dataToShowMetaData.Contains(dataName)));
                }
            }

            OnShownDataListChanged(EventArgs.Empty); // Since the available data changed, update the list
        }

        private List<string> _DataNames = new List<string>();
        public IList<string> DataNames
        {
            get { return _DataNames; }
        }

        protected virtual IList<string> GetDataToShowFromMetaData()
        {
            if(Recording == null) return null;

            lock (DataSet)
            {
                // Format: DataName,DataName2, DataName3, etc.
                if (Recording.DoesMetaDataExist("DataToShow"))
                {
                    string dataToShowList = Recording.GetMetaData("DataToShow");
                    string[] dataToShow = dataToShowList.Split(',');
                    List<string> output = new List<string>();
                    foreach (string dataName in dataToShow)
                        output.Add(dataName.Trim());
                    return output;
                }
                else return null;
            }
        }
        protected virtual IDictionary<string, AxisMode> GetAxesModesFromMetaData()
        {
            if (Recording == null) return null;

            lock (DataSet)
            {
                if (Recording.DoesMetaDataExist("AxesModes"))
                {
                    // Format: DataName=AxisMode,DataName2=AxisMode
                    string axesModesList = Recording.GetMetaData("AxesModes");
                    string[] axesModeAssignments = axesModesList.Split(',');

                    SortedList<string, AxisMode> axesModes = new SortedList<string, AxisMode>();
                    foreach (string assignment in axesModeAssignments)
                    {
                        string[] split = assignment.Split('=');
                        if (split.Length != 2) continue; // Invalid format

                        AxisMode mode = AxisMode.Auto; // Default
                        if (split[1].Trim() == "DynamicRange") mode = AxisMode.DynamicRange;

                        axesModes.Add(split[0].Trim(), mode);
                    }

                    return axesModes;
                }
                else return null;
            }
        }
        protected virtual IDictionary<string, AxisLocation> GetAxesLocationsFromMetaData()
        {
            if (Recording == null) return null;

            lock (DataSet)
            {
                if (Recording.DoesMetaDataExist("AxesLocations"))
                {
                    // Format: DataName=AxisLocation,DataName2=AxisLocation
                    string axesLocationsList = Recording.GetMetaData("AxesLocations");
                    string[] axesLocationAssignments = axesLocationsList.Split(',');

                    SortedList<string, AxisLocation> axesLocations = new SortedList<string, AxisLocation>();
                    foreach (string assignment in axesLocationAssignments)
                    {
                        string[] split = assignment.Split('=');
                        if (split.Length != 2) continue; // Invalid format

                        AxisLocation location = AxisLocation.Left; // Default
                        if (split[1].Trim() == "Right") location = AxisLocation.Right;

                        axesLocations.Add(split[0].Trim(), location);
                    }

                    return axesLocations;
                }
                else return null;
            }
        }

        protected virtual void OnAvailableDataItemChecked(object sender, ItemCheckEventArgs e)
        {
            SetDataVisible(AvailableDataCheckedListBox.Items[e.Index].ToString(), e.NewValue == CheckState.Checked);
        }

        public virtual void SetDataVisible(string dataName, bool isVisible)
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(delegate()
                {
                    SetDataVisible(dataName, isVisible);
                }));
                return;
            }

            if (Plots.ContainsKey(dataName))
            {
                Plots[dataName].Visible = isVisible;
            }
            if (Axes.ContainsKey(dataName))
                Axes[dataName].Visible = isVisible;

            Graph.Invalidate();

            //if (AvailableDataCheckedListBox.GetItemChecked(AvailableDataCheckedListBox.Items.IndexOf(dataName))
            //    != isVisible)
            //    AvailableDataCheckedListBox.SetItemChecked(AvailableDataCheckedListBox.Items.IndexOf(dataName), isVisible);
        }

        protected virtual void OnShownDataListChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnShownDataListChanged), e);
                return;
            }

            //try
            //{
            //    ConfigureAxes();
            //    UpdatePlots();
            //    UpdateCurves();
            //    try
            //    {
            //        RecordingDataGraph.AxisChange();
            //    }
            //    catch (Exception x) { ; }
            //    RecordingDataGraph.Invalidate();
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show("Error updating graph: " + x.Message);
            //}

            if(ShownDataListChanged != null)
                try
                {
                    ShownDataListChanged(this, e);
                }
                catch (Exception x) { ; }
        }

        public virtual void ConfigureGraph()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(ConfigureGraph));
                return;
            }

            
        }

        protected virtual void ConfigureAxes()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(ConfigureAxes));
                return;
            }

            System.Diagnostics.Debug.WriteLine("NIRecordingDataGraphControl: Configuring axes.");

            Action<string> configureAxisAction = new Action<string>(ConfigureAxis);
            foreach (string dataName in DataNames)
            {
                string axisTitle = GetAxisTitle(dataName);

                YAxis yaxis = null;

                
                if (Axes.ContainsKey(dataName)) yaxis = Axes[dataName];
                else
                {
                    Axes.Add(dataName, new YAxis());
                    yaxis = Axes[dataName];
                    Graph.YAxes.Add(yaxis);
                }

                yaxis.Caption = GetAxisTitle(dataName);

                // Set visibility
                yaxis.Visible = ShownDataList.Contains(dataName);

                if (AxesLocations[dataName] == AxisLocation.Right)
                {
                    yaxis.Position = YAxisPosition.Right;
                    yaxis.CaptionPosition = YAxisPosition.Right;
                }

                configureAxisAction.BeginInvoke(dataName, null, null);
            }
        }

        protected virtual void ConfigureAxis(string dataName)
        {
            YAxis yaxis = Axes[dataName];

            if (AxesModes[dataName] == AxisMode.Auto)
            {
                SetGraphAxisModeRange(yaxis, NationalInstruments.UI.AxisMode.AutoScaleLoose, yaxis.Range);
            }
            else
            {
                try
                {
                    double min;
                    double max;

                    lock (DataSet)
                    {
                        if (dataName == "Current")
                        {
                            double gain = 1000 / Double.Parse(Recording.GetEquipmentSetting("AmplifierGain")); // gain is in pA/V
                            min = -10 * gain;
                            max = 10 * gain;
                        }
                        else
                        {
                            min = Double.Parse(Recording.GetEquipmentSetting("DynamicRange-Min:" + dataName));
                            max = Double.Parse(Recording.GetEquipmentSetting("DynamicRange-Max:" + dataName));
                        }
                    }

                    SetGraphAxisModeRange(yaxis, NationalInstruments.UI.AxisMode.Fixed, new NationalInstruments.UI.Range(min, max));
                }
                catch (Exception x)
                {
                    SetGraphAxisModeRange(yaxis, NationalInstruments.UI.AxisMode.AutoScaleLoose, yaxis.Range);
                }
            }
        }

        protected delegate void SetGraphAxisModeRangeDelegate(YAxis axis, NationalInstruments.UI.AxisMode mode, Range range);

        protected virtual void SetGraphAxisModeRange(YAxis axis, NationalInstruments.UI.AxisMode mode, Range range)
        {
            if (InvokeRequired)
            {
                Invoke(new SetGraphAxisModeRangeDelegate(SetGraphAxisModeRange), axis, mode, range);
                return;
            }

            if(axis.Mode != mode) axis.Mode = mode;
            if(axis.Range != range) axis.Range = range;
        }

        protected virtual string GetAxisTitle(string dataName)
        {
            string title = dataName;

            if (!_AxesTitles.ContainsKey(dataName)) _AxesTitles.Add(dataName, title);

            return title;
        }

        protected virtual void UpdatePlots()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(UpdatePlots));
                return;
            }
            
            System.Diagnostics.Debug.WriteLine("NIRecordingDataGraphControl: Updating plots.");

            Action<string> preparePlotAction = new Action<string>(PreparePlot);
            foreach (string dataName in DataNames)
            {
                IAsyncResult ar = preparePlotAction.BeginInvoke(dataName, null, null);
            }
        }
        protected virtual void PreparePlot(string dataName)
        {
            ScatterPlot plot;

            // If this plot has already been made, skip it
            if (!_Plots.ContainsKey(dataName))
            {
                plot = new ScatterPlot();
                plot.XAxis = TimeAxis;
                plot.YAxis = Axes[dataName];
                plot.LineColor = GetNextColor();
                _Plots.Add(dataName, plot);
                AddPlotToGraph(dataName);
            }
            else plot = _Plots[dataName];

            plot.Visible = Axes[dataName].Visible;

            TimeResolvedData data;
            lock (DataSet)
            {
                data = Recording.GetData(dataName);
            }

            PlotData(dataName, Array.ConvertAll<float, double>(data.Time, new Converter<float, double>(delegate(float value)
                {
                    return (double)value;
                })), data.Values);
        }

        protected delegate void PlotDataDelegate(string dataName, double[] time, double[] values);

        protected virtual void PlotData(string dataName, double[] time, double[] values)
        {
            if (InvokeRequired)
            {
                Invoke(new PlotDataDelegate(PlotData), dataName, time, values);
                return;
            }

            Plots[dataName].PlotXY(time, values);
        }

        protected virtual void AddPlotToGraph(string dataName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddPlotToGraph), dataName);
                return;
            }

            ScatterPlot plot = Plots[dataName];
                
            Graph.Plots.Add(plot);
            Legend.Items.Add(new LegendItem(plot, dataName));
        }

        public virtual void ResetGraph()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResetGraph));
                return;
            }

            DateTime start = DateTime.Now;

            SuppressUpdates = true;

            Graph.SuspendLayout();

            ResetColorCounter();
            _Axes.Clear();
            _AxesTitles.Clear();
            _Plots.Clear();
            Legend.Items.Clear();

            Graph.Plots.Clear();
            Graph.YAxes.Clear();

            if (DataSet == null || Recording == null) return;

            try
            {
                UpdateAvailableDataList();

                ConfigureGraph();

                DateTime start2 = DateTime.Now;
                ConfigureAxes();
                System.Diagnostics.Debug.WriteLine(String.Format(
                    "NIRecordingGraphControl: Configuring axes took {0}.", DateTime.Now - start2));

                start2 = DateTime.Now;
                UpdatePlots(); System.Diagnostics.Debug.WriteLine(String.Format(
                    "NIRecordingGraphControl: Updating plots took {0}.", DateTime.Now - start2));
            }
            catch (Exception x)
            {
                MessageBox.Show("Error updating graph: " + x.Message);
            }

            Graph.ResumeLayout();

            SuppressUpdates = false;

            TimeSpan executionTime = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("NIRecordingDataGraph: Graph update took " + executionTime.ToString());
        }

        public virtual void RefreshGraphData()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(RefreshGraphData));
                return;
            }

            if (DataSet == null || Recording == null)
            {
                ResetGraph();
                return;
            }

            DateTime start = DateTime.Now;

            SuppressUpdates = true;

            Graph.SuspendLayout();

            ResetColorCounter();

            try
            {
                UpdateAvailableDataList();

                ConfigureGraph();

                DateTime start2 = DateTime.Now;
                ConfigureAxes();
                System.Diagnostics.Debug.WriteLine(String.Format(
                    "NIRecordingGraphControl: Configuring axes took {0}.", DateTime.Now - start2));

                start2 = DateTime.Now;
                UpdatePlots(); System.Diagnostics.Debug.WriteLine(String.Format(
                    "NIRecordingGraphControl: Updating plots took {0}.", DateTime.Now - start2));
            }
            catch (Exception x)
            {
                MessageBox.Show("Error updating graph: " + x.Message);
            }

            Graph.ResumeLayout();

            SuppressUpdates = false;

            TimeSpan executionTime = DateTime.Now - start;
            System.Diagnostics.Debug.WriteLine("NIRecordingDataGraph: Graph refresh took " + executionTime.ToString());
        }

        private bool _PreviousIsAutoUpdateDisabled;
        public virtual void SuspendBinding()
        {
            RecordingBindingSource.SuspendBinding();
            RecordingDataBindingSource.SuspendBinding();
            _PreviousIsAutoUpdateDisabled = IsAutoUpdateDisabled;
            IsAutoUpdateDisabled = true;
        }
        public virtual void ResumeBinding()
        {
            RecordingBindingSource.ResumeBinding();
            RecordingBindingSource.ResetBindings(false);
            RecordingDataBindingSource.ResumeBinding();
            RecordingDataBindingSource.ResetBindings(false);
            IsAutoUpdateDisabled = _PreviousIsAutoUpdateDisabled;
        }

        private List<Color> _Colors = new List<Color>(new Color[] {
            Color.Yellow, Color.Pink, Color.Cyan, Color.Lime, Color.White
        });
        private int _ColorsIndex = 0;
        protected virtual Color GetNextColor()
        {

            if (_ColorsIndex >= _Colors.Count) ResetColorCounter();

            return _Colors[_ColorsIndex++];
        }
        protected virtual void ResetColorCounter()
        {
            _ColorsIndex = 0;
        }

        protected virtual void OnToggleHiddenClicked(object sender, EventArgs e)
        {
            IsSidebarVisible = !IsSidebarVisible;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
                catch (Exception e) { ; }
        }

        #endregion

        protected virtual void OnCurrentRecordingChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnCurrentRecordingChanged), sender, e);
                return;
            }

            if (!IsAutoUpdateDisabled) ResetGraph();
        }

        protected virtual void OnDataNamesChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnDataNamesChanged), e);
                return;
            }

            AxisComboBox.Items.Clear();
            AxisComboBox.Items.AddRange(_DataNames.ToArray());
            if(AxisComboBox.Items.Count != 0) AxisComboBox.SelectedIndex = 0;
        }

        protected virtual void OnSelectedAxisChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(OnSelectedAxisChanged), sender, e);
                return;
            }

            if (!AxesLocations.ContainsKey(AxisComboBox.Text) ||
                AxesLocations[AxisComboBox.Text] == AxisLocation.Left)
                AxisPlacementComboBox.SelectedItem = "Left";
            else AxisPlacementComboBox.SelectedItem = "Right";

            if (!AxesModes.ContainsKey(AxisComboBox.Text) ||
                AxesModes[AxisComboBox.Text] == AxisMode.Auto)
                AxisModeComboBox.SelectedItem = "Auto";
            else AxisModeComboBox.SelectedItem = "Dynamic Range";
        }

        protected virtual void OnSelectedPlacementChanged(object sender, EventArgs e)
        {
            if(InvokeRequired) {
                Invoke(new EventHandler(OnSelectedPlacementChanged),sender,e);
                return;
            }

            if (!DataNames.Contains(AxisComboBox.Text)) return;

            if (!AxesLocations.ContainsKey(AxisComboBox.Text))
                AxesLocations.Add(AxisComboBox.Text, AxisLocation.Left);
            
            if (AxisPlacementComboBox.Text == "Left")
                AxesLocations[AxisComboBox.Text] = AxisLocation.Left;
            else AxesLocations[AxisComboBox.Text] = AxisLocation.Right;

            if (!SuppressUpdates)
            {
                ResetGraph();
                Graph.Invalidate();
            }
        }

        private void OnSelectedModeChanged(object sender, EventArgs e)
        {
            if(InvokeRequired) {
                Invoke(new EventHandler(OnSelectedModeChanged),sender,e);
                return;
            }

            if (!DataNames.Contains(AxisComboBox.Text)) return;

            if (!AxesModes.ContainsKey(AxisComboBox.Text))
                AxesModes.Add(AxisComboBox.Text, AxisMode.Auto);
            
            if (AxisModeComboBox.Text == "Data")
                AxesModes[AxisComboBox.Text] = AxisMode.Auto;
            else AxesModes[AxisComboBox.Text] = AxisMode.DynamicRange;

            if(!SuppressUpdates) ResetGraph();
        }

        protected virtual void OnRecordingDataChanged(object sender, ListChangedEventArgs e)
        {
            if (DataSet == null) return;

            if (!IsAutoUpdateDisabled)
            {
                ResetGraph();
            }
        }

        private bool _AreUpdatesSuspended = false;
        protected bool AreUpdatesSuspended
        {
            get
            {
                return _AreUpdatesSuspended;
            }
            set
            {
                _AreUpdatesSuspended = value;
            }
        }

        public void SuspendUpdates()
        {
            AreUpdatesSuspended = true;
            RecordingBindingSource.SuspendBinding();
            RecordingDataBindingSource.SuspendBinding();
        }
        public void ResumeUpdates()
        {
            AreUpdatesSuspended = false;
            RecordingBindingSource.ResumeBinding();
            RecordingDataBindingSource.ResumeBinding();
            ResetGraph();
        }

        protected Range FindRange(string dataName)
        {
            List<double> values = new List<double>();

            PhysiologyDataSet.Recordings_DataRow[] rows = DataSet.Recordings_Data.Select(
                String.Format("RecordingID = {0} AND DataName = '{1}'", Recording.RecordingID, dataName),
                "Value") as PhysiologyDataSet.Recordings_DataRow[];

            if (rows == null || rows.Length == 0) return new Range(0, 1);
            else return new Range(rows[0].Value, rows[rows.Length-1].Value);
        }

        public event EventHandler AntialiasCurvesChanged;
        private bool _AntialiasCurves = false;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(false)]
        public bool AntialiasCurves
        {
            get { return _AntialiasCurves; }
            set {
                _AntialiasCurves = value;
                if(AntialiasCurvesChanged != null)
                    try
                    {
                        AntialiasCurvesChanged(this, EventArgs.Empty);
                    }
                    catch (Exception x) { ; }
                NotifyPropertyChanged("AntialiasCurves");
                ResetGraph();
            }
        }
    }
}
