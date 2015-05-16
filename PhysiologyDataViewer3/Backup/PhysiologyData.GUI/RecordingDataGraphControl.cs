using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;
using System.Threading;

namespace RRLab.PhysiologyData.GUI
{
    public partial class RecordingDataGraphControl : UserControl, INotifyPropertyChanged
    {
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
	
	

        public event EventHandler IsDarkRoomStyleChanged;
        private bool _IsDarkRoomStyle = false;
        [SettingsBindable(true)]
        [Bindable(true)]
        [DefaultValue(false)]
        public bool IsDarkRoomStyle
        {
            get { return _IsDarkRoomStyle; }
            set {
                _IsDarkRoomStyle = value;
                OnIsDarkRoomStyleChanged(EventArgs.Empty);
                NotifyPropertyChanged("IsDarkRoomStyle");
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
                _DataSet = value;
                OnDataSetChanged(EventArgs.Empty);
                NotifyPropertyChanged("DataSet");
            }
        }

        public event EventHandler CurrentRecordingIDChanged;
        private long _CurrentRecordingID;
        [Bindable(true)]
        public long CurrentRecordingID
        {
            get { return _CurrentRecordingID; }
            set
            {
                _CurrentRecordingID = value;
                OnCurrentRecordingIDChanged(EventArgs.Empty);
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

        public PhysiologyDataSet.RecordingsRow CurrentRecordingsRow
        {
            get
            {
                if (DataSet == null) return null;
                try
                {
                    return ((DataRowView)RecordingBindingSource.Current).Row as PhysiologyDataSet.RecordingsRow;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        private SortedList<string, string> _AxesTitles = new SortedList<string, string>();
        protected IDictionary<string, string> AxesTitles
        {
            get { return _AxesTitles; }
        }

        private SortedList<string, ZedGraph.FilteredPointList> _Plots = new SortedList<string, ZedGraph.FilteredPointList>();
        protected IDictionary<string, ZedGraph.FilteredPointList> Plots
        {
            get { return _Plots; }
        }

        private SortedList<string, ZedGraph.LineItem> _Curves = new SortedList<string, ZedGraph.LineItem>();
        protected IDictionary<string, ZedGraph.LineItem> Curves
        {
            get { return _Curves; }
        }

        private SortedList<string, ZedGraph.Axis> _Axes = new SortedList<string, ZedGraph.Axis>();
        protected IDictionary<string, ZedGraph.Axis> Axes
        {
            get { return _Axes; }
        }

        public RecordingDataGraphControl()
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



        protected virtual void OnCurrentRecordingIDChanged(EventArgs e)
        {
            if (RecordingBindingSource.DataSource != null)
                try
                {
                    RecordingBindingSource.Position = RecordingBindingSource.Find("RecordingID", CurrentRecordingID);
                    RecordingBindingSource.ResetBindings(false);
                    RecordingBindingSource.ResetCurrentItem();
                    RecordingDataBindingSource.ResetBindings(false);
                }
                catch (Exception x) { ; }

            OnCurrentRecordingChanged(this, e);

            if (CurrentRecordingIDChanged != null) CurrentRecordingIDChanged(this, EventArgs.Empty);
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

            ResetGraph();

            if (AxesModesChanged != null)
                try {
                    AxesModesChanged(this, e);
                } catch(Exception x) { ; }
        }

        protected virtual void OnIsDarkRoomStyleChanged(EventArgs e)
        {
            if (IsDarkRoomStyleChanged != null)
                try
                {
                    IsDarkRoomStyleChanged(this, e);
                }
                catch (Exception x) { ; }
        }
        protected virtual void OnIsTitleVisibleChanged(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<EventArgs>(OnIsTitleVisibleChanged), e);
                return;
            }

            RecordingDataGraph.GraphPane.Title.IsVisible = IsTitleVisible;
            RecordingDataGraph.Invalidate();

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

            RecordingDataGraph.GraphPane.Legend.IsVisible = IsLegendVisible;
            RecordingDataGraph.Invalidate();

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
            if (DataSet != null) RecordingBindingSource.DataSource = DataSet;
            else RecordingBindingSource.DataSource = typeof(PhysiologyDataSet);

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

        protected virtual void OnUseDarkRoomStyleChecked(object sender, EventArgs e)
        {
            IsDarkRoomStyle = DarkRoomCheckBox.Checked;
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
                if (CurrentRecordingsRow != null)
                {
                    List<string> channels = new List<string>(CurrentRecordingsRow.GetDataNames());

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
                    if (CurrentRecordingsRow.DoesMetaDataExist("DataToShow"))
                        dataToShowMetaData = new List<string>(CurrentRecordingsRow.GetMetaData("DataToShow").Split(','));
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
            if(CurrentRecordingsRow == null) return null;

            // Format: DataName,DataName2, DataName3, etc.
            if(CurrentRecordingsRow.DoesMetaDataExist("DataToShow")) {
                string dataToShowList = CurrentRecordingsRow.GetMetaData("DataToShow");
                string[] dataToShow = dataToShowList.Split(',');
                List<string> output = new List<string>();
                foreach (string dataName in dataToShow)
                    output.Add(dataName.Trim());
                return output;
            } else return null;
        }
        protected virtual IDictionary<string, AxisMode> GetAxesModesFromMetaData()
        {
            if (CurrentRecordingsRow == null) return null;

            if(CurrentRecordingsRow.DoesMetaDataExist("AxesModes")) {
                // Format: DataName=AxisMode,DataName2=AxisMode
                string axesModesList = CurrentRecordingsRow.GetMetaData("AxesModes");
                string[] axesModeAssignments =axesModesList.Split(',');

                SortedList<string, AxisMode> axesModes = new SortedList<string, AxisMode>();
                foreach(string assignment in axesModeAssignments) {
                    string[] split = assignment.Split('=');
                    if(split.Length != 2) continue; // Invalid format
                    
                    AxisMode mode = AxisMode.Auto; // Default
                    if(split[1].Trim() == "DynamicRange") mode = AxisMode.DynamicRange;
                    
                    axesModes.Add(split[0].Trim(), mode);
                }

                return axesModes;
            } else return null;
        }
        protected virtual IDictionary<string, AxisLocation> GetAxesLocationsFromMetaData()
        {
            if (CurrentRecordingsRow == null) return null;

            if (CurrentRecordingsRow.DoesMetaDataExist("AxesLocations"))
            {
                // Format: DataName=AxisLocation,DataName2=AxisLocation
                string axesLocationsList = CurrentRecordingsRow.GetMetaData("AxesLocations");
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

            if (Curves.ContainsKey(dataName))
            {
                Curves[dataName].IsVisible = isVisible;
                Curves[dataName].Label.IsVisible = isVisible;
            }
            if (Axes.ContainsKey(dataName))
                Axes[dataName].IsVisible = isVisible;

            RecordingDataGraph.Invalidate();

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

            if (IsDarkRoomStyle)
            {
                RecordingDataGraph.GraphPane.Fill.Color = Color.Black;
                RecordingDataGraph.GraphPane.Title.FontSpec.FontColor = Color.White;
                RecordingDataGraph.GraphPane.Border.Color = Color.White;
                RecordingDataGraph.GraphPane.Legend.FontSpec.FontColor = Color.White;
                RecordingDataGraph.GraphPane.Chart.Border.Color = Color.White;
                RecordingDataGraph.GraphPane.Chart.Fill.Color = Color.Black;
                RecordingDataGraph.GraphPane.Chart.Fill.Type = ZedGraph.FillType.Solid;
                RecordingDataGraph.ForeColor = Color.White;
                RecordingDataGraph.BackColor = Color.Black;
            }
            else
            {
                RecordingDataGraph.GraphPane.Chart.Fill.Color = GraphBackColor;
                RecordingDataGraph.GraphPane.Chart.Fill.Type = ZedGraph.FillType.GradientByX;
            }
        }

        protected virtual void ConfigureAxes()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(ConfigureAxes));
                return;
            }

            RecordingDataGraph.GraphPane.XAxis.Title.Text = "Time (ms)";
            RecordingDataGraph.GraphPane.XAxis.Scale.MinGrace = 0;
            RecordingDataGraph.GraphPane.XAxis.Scale.MinAuto = true;
            RecordingDataGraph.GraphPane.XAxis.Scale.MaxGrace = 0;
            RecordingDataGraph.GraphPane.XAxis.Scale.MaxAuto = true;

            if (IsDarkRoomStyle)
            {
                RecordingDataGraph.GraphPane.XAxis.Color = Color.White;
                RecordingDataGraph.GraphPane.XAxis.MinorTic.Color = Color.White;
                RecordingDataGraph.GraphPane.XAxis.MajorTic.Color = Color.White;
                RecordingDataGraph.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
                RecordingDataGraph.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            }

            RecordingDataGraph.GraphPane.YAxisList.Clear();
            RecordingDataGraph.GraphPane.Y2AxisList.Clear();
            foreach (string dataName in DataNames)
            {
                string axisTitle = GetAxisTitle(dataName);

                ZedGraph.Axis yaxis = null;

                if (AxesLocations[dataName] == AxisLocation.Left)
                {
                    if (RecordingDataGraph.GraphPane.YAxisList.IndexOf(axisTitle) < 0)
                        RecordingDataGraph.GraphPane.YAxisList.Add(axisTitle);
                    yaxis = RecordingDataGraph.GraphPane.YAxisList[axisTitle];
                }
                else
                {
                    if (RecordingDataGraph.GraphPane.Y2AxisList.IndexOf(axisTitle) < 0)
                        RecordingDataGraph.GraphPane.Y2AxisList.Add(axisTitle);
                    yaxis = RecordingDataGraph.GraphPane.Y2AxisList[axisTitle];
                }

                // Store axis
                if (!_Axes.ContainsKey(dataName))
                    _Axes.Add(dataName, yaxis);
                else _Axes[dataName] = yaxis;

                // Set visibility
                yaxis.IsVisible = ShownDataList.Contains(dataName);

                // Dark room sstyle
                if (IsDarkRoomStyle)
                {
                    yaxis.Color = Color.White;
                    yaxis.MinorTic.Color = Color.White;
                    yaxis.MajorTic.Color = Color.White;
                    yaxis.Title.FontSpec.FontColor = Color.White;
                    yaxis.Scale.FontSpec.FontColor = Color.White;
                }

                if (AxesModes[dataName] == AxisMode.Auto)
                {
                    //yaxis.Scale.MinAuto = true;
                    //yaxis.Scale.MinGrace = 0.1;
                    //yaxis.Scale.MaxAuto = true;
                    //yaxis.Scale.MaxGrace = 0.1;
                    Range dataRange = FindRange(dataName);
                    yaxis.Scale.Min = dataRange.Min;
                    yaxis.Scale.Max = dataRange.Max;
                }
                else
                {
                    try
                    {
                        double min;
                        double max;

                        if (dataName == "Current")
                        {
                            double gain = 1000 / Double.Parse(CurrentRecordingsRow.GetEquipmentSetting("AmplifierGain")); // gain is in pA/V
                            min = -10 * gain;
                            max = 10 * gain;
                        }
                        else
                        {
                            min = Double.Parse(CurrentRecordingsRow.GetEquipmentSetting("DynamicRange-Min:" + dataName));
                            max = Double.Parse(CurrentRecordingsRow.GetEquipmentSetting("DynamicRange-Max:" + dataName));
                        }

                        yaxis.Scale.MinAuto = false;
                        yaxis.Scale.Min = min;
                        yaxis.Scale.MaxAuto = false;
                        yaxis.Scale.Max = max;
                    }
                    catch (Exception x)
                    {
                        //yaxis.Scale.MinAuto = true;
                        //yaxis.Scale.MinGrace = 0;
                        //yaxis.Scale.MaxAuto = true;
                        //yaxis.Scale.MaxGrace = 0;
                        Range dataRange = FindRange(dataName);
                        yaxis.Scale.Min = dataRange.Min;
                        yaxis.Scale.Max = dataRange.Max;
                    }
                }
            }

            if (RecordingDataGraph.GraphPane.YAxisList.Count == 0)
                RecordingDataGraph.GraphPane.YAxisList.Add("");

            RecordingDataGraph.Invalidate();
        }

        protected virtual string GetAxisTitle(string dataName)
        {
            string title = dataName;

            if (!_AxesTitles.ContainsKey(dataName)) _AxesTitles.Add(dataName, title);
            else _AxesTitles[dataName] = title;

            return title;
        }

        protected virtual void UpdatePlots()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(UpdatePlots));
                return;
            }

            DateTime start = DateTime.Now;
            foreach (string dataName in DataNames)
            {
                TimeResolvedData data = CurrentRecordingsRow.GetData(dataName);
                ZedGraph.FilteredPointList points = new ZedGraph.FilteredPointList(Array.ConvertAll<float,double>(data.Time, new Converter<float,double>(delegate(float value) {
                    return (double) value; })), data.Values);

                // If this plot has already been made, skip it
                if (!_Plots.ContainsKey(dataName))
                {
                    _Plots.Add(dataName, points);
                    //ZedGraph.DataSourcePointList points = new ZedGraph.DataSourcePointList();
                    //_Plots.Add(dataName, points);

                    //BindingSource bs = new BindingSource(RecordingBindingSource, "FK_Recordings_Recording_Data");
                    //bs.Filter = "DataName = '" + dataName + "'";
                    //points.DataSource = bs;
                    //points.XDataMember = "Time";
                    //points.YDataMember = "Value";
                }
                else _Plots[dataName] = points;
            }
            TimeSpan span = DateTime.Now - start;
            Console.WriteLine("Plots took " + span.ToString());
        }

        public virtual void ResetGraph()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResetGraph));
                return;
            }

            ResetColorCounter();
            _AxesTitles.Clear();
            _Curves.Clear();
            _Plots.Clear();

            RecordingDataGraph.GraphPane.CurveList.Clear();
            RecordingDataGraph.GraphPane.YAxisList.Clear();
            RecordingDataGraph.GraphPane.YAxisList.Add("");
            RecordingDataGraph.GraphPane.Y2AxisList.Clear();

            if (DataSet == null) return;

                try
                {
                    UpdateAvailableDataList();
                    ConfigureGraph();
                    ConfigureAxes();
                    UpdatePlots();
                    UpdateCurves();
                    try
                    {
                        RecordingDataGraph.AxisChange();
                    }
                    catch (Exception x) { ; }
                    RecordingDataGraph.Invalidate();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error updating graph: " + x.Message);
                }
        }

        public virtual void RefreshGraphData()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(RefreshGraphData));
                return;
            }

            _Plots.Clear();
            _Curves.Clear();
            RecordingDataGraph.GraphPane.CurveList.Clear();

            UpdatePlots();
            UpdateCurves();
            try
            {
                RecordingDataGraph.AxisChange();
            }
            catch { ; }
            Invalidate();
        }

        protected virtual void UpdateCurves()
        {
            foreach (string dataName in DataNames)
            {
                ZedGraph.LineItem curve;

                if (!_Curves.ContainsKey(dataName))
                {
                    curve = RecordingDataGraph.GraphPane.AddCurve(dataName, Plots[dataName], GetNextColor(), ZedGraph.SymbolType.None);
                    _Curves.Add(dataName, curve);
                }
                else curve = _Curves[dataName];

                curve.Line.Width = 1.5F;
                curve.Line.IsAntiAlias = AntialiasCurves;

                curve.IsVisible = ShownDataList.Contains(dataName);
                curve.Label.IsVisible = ShownDataList.Contains(dataName);

                if (AxesLocations.ContainsKey(dataName) && AxesLocations[dataName] == AxisLocation.Right)
                {
                    curve.IsY2Axis = true;
                    curve.YAxisIndex = GetYAxisIndex(dataName, true);
                }
                else
                {
                    curve.IsY2Axis = false;
                    curve.YAxisIndex = GetYAxisIndex(dataName, false);
                }
            }
        }

        private List<Color> _Colors = new List<Color>(new Color[] {
            Color.Blue, Color.Red, Color.Green, Color.Brown, Color.Crimson });
        private List<Color> _DarkRoomColors = new List<Color>(new Color[] {
            Color.Yellow, Color.Pink, Color.Cyan, Color.Lime, Color.White
        });
        private int _ColorsIndex = 0;
        protected virtual Color GetNextColor()
        {
            List<Color> Colors;
            if (IsDarkRoomStyle) Colors = _DarkRoomColors;
            else Colors = _Colors;

            if (_ColorsIndex >= Colors.Count) ResetColorCounter();

            return Colors[_ColorsIndex++];
        }
        protected virtual void ResetColorCounter()
        {
            _ColorsIndex = 0;
        }

        protected virtual int GetYAxisIndex(string dataName, bool isY2)
        {
            if(isY2)
                return RecordingDataGraph.GraphPane.Y2AxisList.IndexOf(AxesTitles[dataName]);
            else return RecordingDataGraph.GraphPane.YAxisList.IndexOf(AxesTitles[dataName]);
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

            if (IsAutoUpdateDisabled) return;

            if (CurrentRecordingsRow != null)
            {
                RecordingDataGraph.GraphPane.Title.Text = CurrentRecordingsRow.Title;
                Enabled = true;
            }
            else
            {
                RecordingDataGraph.GraphPane.Title.Text = "No Recording Selected";
                Enabled = false;
            }

            ResetGraph();
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

            ResetGraph();
            RecordingDataGraph.Invalidate();
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

            ConfigureAxes();
            UpdatePlots();
            UpdateCurves();
            RecordingDataGraph.Invalidate();
        }

        protected virtual void OnRecordingDataChanged(object sender, ListChangedEventArgs e)
        {
            if (DataSet == null) return;

            if (!IsAutoUpdateDisabled && !AreUpdatesSuspended)
            {
                RefreshGraphData();
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
            OnCurrentRecordingIDChanged(EventArgs.Empty);
            ResetGraph();
        }

        protected Range FindRange(string dataName)
        {
            List<double> values = new List<double>();

            PhysiologyDataSet.Recordings_DataRow[] rows = DataSet.Recordings_Data.Select(
                String.Format("RecordingID = {0} AND DataName = '{1}'", CurrentRecordingID, dataName),
                "Value") as PhysiologyDataSet.Recordings_DataRow[];

            if (rows == null || rows.Length == 0) return new Range(0, 1);
            else return new Range(rows[0].Value, rows[rows.Length-1].Value);
        }

        protected struct Range
        {
            public double Min;
            public double Max;

            public Range(double min, double max)
            {
                Min = min;
                Max = max;
            }
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
	

        protected virtual void OnAntialiasCurvesChecked(object sender, EventArgs e)
        {
            AntialiasCurves = AntialiasCheckBox.Checked;
        }
    }
}
