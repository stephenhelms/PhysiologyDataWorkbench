using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.Utilities
{
    public partial class DataSetGroupedScatterPlotControl : UserControl, INotifyPropertyChanged
    {
        private bool _IsDataOptionsPanelVisible = true;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(true)]
        public bool IsDataOptionsPanelVisible
        {
            get { return _IsDataOptionsPanelVisible; }
            set {
                _IsDataOptionsPanelVisible = value;
                UpdateControlSettings();
            }
        }
	

        public DataSetGroupedScatterPlotControl()
        {
            InitializeComponent();
        }

        protected virtual void UpdateControlSettings()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateControlSettings));
                return;
            }

            DataSettingsControlPanel.Visible = IsDataOptionsPanelVisible;
            XColumnComboBox.SelectedValue = XColumn;
            YColumnComboBox.SelectedValue = YColumn;
            GroupColumnComboBox.SelectedValue = GroupColumn;
            FilterTextBox.Text = Filter;
        }
        protected virtual void UpdateColumnComboBoxes()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(UpdateColumnComboBoxes));
                return;
            }

            if (DataSet != null && Table != null)
            {
                List<DataColumn> columns = new List<DataColumn>(DataSet.Tables[Table].Columns.Count);
                for(int i=0; i < DataSet.Tables[Table].Columns.Count; i++)
                    columns.Add(DataSet.Tables[Table].Columns[i]);
                XColumnComboBox.DataSource = new List<DataColumn>(columns);
                YColumnComboBox.DataSource = new List<DataColumn>(columns);
                GroupColumnComboBox.DataSource = new List<DataColumn>(columns);
            }
            else
            {
                XColumnComboBox.DataSource = null;
                YColumnComboBox.DataSource = null;
                GroupColumnComboBox.DataSource = null;
            }

            OnXColumnChanged(EventArgs.Empty);
            OnYColumnChanged(EventArgs.Empty);
            OnGroupColumnChanged(EventArgs.Empty);
        }

        #region Graph

        public event EventHandler DataSetChanged;
        private DataSet _DataSet;
        [Bindable(true)]
        public DataSet DataSet
        {
            get { return _DataSet; }
            set
            {
                _DataSet = value;
                OnDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnDataSetChanged(EventArgs e)
        {
            UpdateColumnComboBoxes();
            UpdateControlSettings();
            ResetGraph();

            if(DataSetChanged != null)
                try
                {
                    DataSetChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during DataSetChanged event.", x.Message);
                }
            NotifyPropertyChanged("DataSet");
        }

        public event EventHandler TableChanged;
        private string _Table;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string Table
        {
            get { return _Table; }
            set
            {
                _Table = value;
                OnTableChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnTableChanged(EventArgs e)
        {
            UpdateColumnComboBoxes();
            UpdateControlSettings();
            ResetGraph();

            if(TableChanged != null)
                try
                {
                    TableChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during TableChanged event.", x.Message);
                }
            NotifyPropertyChanged("Table");
        }

        public event EventHandler XColumnChanged;
        private string _XColumn;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string XColumn
        {
            get { return _XColumn; }
            set
            {
                _XColumn = value;
                OnXColumnChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnXColumnChanged(EventArgs e)
        {
            UpdateControlSettings();
            ResetGraph();

            if(XColumnChanged != null)
                try
                {
                    XColumnChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during XColumnChanged event.", x.Message);
                }
            NotifyPropertyChanged("XColumn");
        }

        public event EventHandler YColumnChanged;
        private string _YColumn;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string YColumn
        {
            get { return _YColumn; }
            set
            {
                _YColumn = value;
                OnYColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("YColumn");
            }
        }

        protected virtual void OnYColumnChanged(EventArgs e)
        {
            UpdateControlSettings();
            ResetGraph();

            if (YColumnChanged != null)
                try
                {
                    YColumnChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during YColumnChanged event.", x.Message);
                }
            NotifyPropertyChanged("YColumn");
        }

        public event EventHandler GroupColumnChanged;
        private string _GroupColumn;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string GroupColumn
        {
            get { return _GroupColumn; }
            set {
                _GroupColumn = value;
                OnGroupColumnChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnGroupColumnChanged(EventArgs e)
        {
            UpdateControlSettings();
            ResetGraph();

            if (GroupColumnChanged != null)
                try
                {
                    GroupColumnChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during GroupColumnChanged event.", x.Message);
                }
            NotifyPropertyChanged("GroupColumn");
        }
	

        public event EventHandler TagColumnChanged;
        private string _TagColumn;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string TagColumn
        {
            get { return _TagColumn; }
            set
            {
                _TagColumn = value;
                OnTagColumnChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnTagColumnChanged(EventArgs e)
        {
            UpdateControlSettings();
            ResetGraph();

            if (TagColumnChanged != null)
                try
                {
                    TagColumnChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during TagColumnChanged event.", x.Message);
                }
            NotifyPropertyChanged("TagColumn");
        }

        public event EventHandler FilterChanged;
        private string _Filter;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                OnFilterChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnFilterChanged(EventArgs e)
        {
            UpdateControlSettings();
            ResetGraph();

            if(FilterChanged != null)
                try
                {
                    FilterChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlotControl: Error during FilterChanged event.", x.Message);
                }
            NotifyPropertyChanged("Filter");
        }

        private string _Title;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
                ResetGraph();
            }
        }

        private Color _GraphColor = Color.LightGoldenrodYellow;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color GraphColor
        {
            get { return _GraphColor; }
            set
            {
                _GraphColor = value;
                NotifyPropertyChanged("GraphColor");
                //ResetGraph();
            }
        }

        private Color _PointsColor = Color.Crimson;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color PointsColor
        {
            get { return _PointsColor; }
            set
            {
                _PointsColor = value;
                NotifyPropertyChanged("PointsColor");
                ResetGraph();
            }
        }

        protected SortedList<object, ZedGraph.LineItem> ScatterPlots;

        private ZedGraph.SymbolType _SymbolType = ZedGraph.SymbolType.Circle;
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue(ZedGraph.SymbolType.Circle)]
        public ZedGraph.SymbolType SymbolType
        {
            get { return _SymbolType; }
            set
            {
                _SymbolType = value;
                NotifyPropertyChanged("SymbolType");
                ResetGraph();
            }
        }

        protected SortedList<object, ZedGraph.PointPairList> Points;

        public virtual void RefreshGraph()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(RefreshGraph));
                return;
            }

            ConfigureGraph();
            ConfigureAxes();
            ConfigurePlots();
            ConfigureCurves();

            try
            {
                GraphControl.AxisChange();
            }
            catch (Exception e) { ; }
            GraphControl.Invalidate();
        }

        protected virtual void ResetGraph()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ResetGraph));
                return;
            }

            Points = null;
            ScatterPlots = null;
            GraphControl.GraphPane.CurveList.Clear();
            RefreshGraph();
        }
        protected virtual void ConfigureGraph()
        {
            if(InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(ConfigureGraph));
                return;
            }

            GraphControl.GraphPane.Title.Text = Title;
            GraphControl.GraphPane.Title.FontSpec.Size = 30;
            GraphControl.GraphPane.Legend.IsVisible = true;
            GraphControl.GraphPane.Chart.Fill.Color = GraphColor;
            GraphControl.GraphPane.Chart.Fill.Type = ZedGraph.FillType.GradientByY;
            GraphControl.IsShowPointValues = true;
        }
        protected virtual void ConfigureAxes()
        {
            if (DataSet == null || Table == null || XColumn == null || YColumn == null
                || Table == "" || XColumn == "" || YColumn == "") return;

            GraphControl.GraphPane.XAxis.Type = DetermineAxisType(XColumn);
            if (GraphControl.GraphPane.XAxis.Type == ZedGraph.AxisType.Date)
                GraphControl.GraphPane.XAxis.Scale.Format = GetDateTimeFormat(XColumn);
            GraphControl.GraphPane.XAxis.Title.Text = DataSet.Tables[Table].Columns[XColumn].Caption ?? XColumn;
            GraphControl.GraphPane.XAxis.Title.FontSpec.Size = 20F;
            GraphControl.GraphPane.XAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.XAxis.Scale.MaxAuto = true;
            GraphControl.GraphPane.XAxis.Scale.FontSpec.Size = 20F;


            GraphControl.GraphPane.YAxis.Type = DetermineAxisType(YColumn);
            if (GraphControl.GraphPane.YAxis.Type == ZedGraph.AxisType.Date)
                GraphControl.GraphPane.YAxis.Scale.Format = GetDateTimeFormat(YColumn);
            GraphControl.GraphPane.YAxis.Title.Text = DataSet.Tables[Table].Columns[YColumn].Caption ?? YColumn;
            GraphControl.GraphPane.YAxis.Title.FontSpec.Size = 20F;
            GraphControl.GraphPane.YAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.YAxis.Scale.MaxAuto = true;
            GraphControl.GraphPane.YAxis.Scale.FontSpec.Size = 20F;
        }

        protected virtual string GetDateTimeFormat(string column)
        {
            if (DataSet == null || Table == null || Table == "" || column == null || column == "")
                return "d";

            if (DataSet.Tables[Table].Columns[column].DataType == typeof(DateTime))
                return "d";

            if (DataSet.Tables[Table].Columns[column].DataType == typeof(TimeSpan))
                return "hh:mm:ss";

            return "d";
        }

        protected virtual ZedGraph.AxisType DetermineAxisType(string column)
        {
            if (DataSet == null || Table == null || Table == "" || column == null || column == "")
                return ZedGraph.AxisType.Linear;

            if (DataSet.Tables[Table].Columns[column].DataType == typeof(DateTime))
                return ZedGraph.AxisType.Date;

            if (DataSet.Tables[Table].Columns[column].DataType == typeof(TimeSpan))
                return ZedGraph.AxisType.Linear;

            return ZedGraph.AxisType.Linear;
        }

        protected virtual void ConfigurePlots()
        {
            Points = new SortedList<object,ZedGraph.PointPairList>();

            if (DataSet != null && Table != null && GroupColumn != null)
            {
                try
                {
                    List<object> groupEntries = new List<object>();
                    DataRow[] rows = DataSet.Tables[Table].Select(Filter);
                    foreach (DataRow row in rows)
                        if (!groupEntries.Contains(row[GroupColumn]))
                            groupEntries.Add(row[GroupColumn]);

                    string userFilter = (Filter != null && Filter != "" && Filter != " ") ? "AND " + Filter : "";
                    foreach (object groupID in groupEntries)
                    {
                        DataRow[] groupRows = DataSet.Tables[Table].Select(
                            String.Format("{0} = '{1}' {2}", GroupColumn, groupID, userFilter));


                        Points.Add(groupID, new ZedGraph.PointPairList());
                        foreach (DataRow row in groupRows)
                        {
                            if (row[XColumn] != DBNull.Value && row[YColumn] != DBNull.Value)
                            {
                                double x = ConvertObjectToDouble(row[XColumn]);
                                double y = ConvertObjectToDouble(row[YColumn]);

                                ZedGraph.PointPair point = new ZedGraph.PointPair(x, y);
                                if (TagColumn != null) point.Tag = row[TagColumn];
                                Points[groupID].Add(point);
                            }
                        }
                    }
                }
                catch
                {
                    Points = null;
                }
            }
        }

        protected virtual double ConvertObjectToDouble(object o)
        {
            if (o is ValueType)
            {
                if (o is DateTime)
                {
                    return ((DateTime)o).ToOADate();
                }
                else if (o is TimeSpan)
                {
                    // TODO: Allow configuration of time span formatting
                    TimeSpan span = ((TimeSpan)o);
                    return span.TotalMinutes + ((double)span.Seconds) / 60;
                }
                else
                {
                    return Convert.ToDouble(o);
                }
            }
            else if (o is String)
            {
                throw new Exception("Invalid type.");
            }
            else
            {
                try
                {
                    return Convert.ToDouble(o);
                }
                catch (Exception x)
                {
                    throw new Exception("Invalid type.", x);
                }
            }
        }

        protected virtual void ConfigureCurves()
        {
            ScatterPlots = new SortedList<object,ZedGraph.LineItem>();

            if (Points == null) return;

            ZedGraph.ColorSymbolRotator rotator = new ZedGraph.ColorSymbolRotator();
            foreach(object groupID in Points.Keys)
            {
                ScatterPlots.Add(groupID, GraphControl.GraphPane.AddCurve(
                    groupID.ToString(),
                    Points[groupID], rotator.NextColor, rotator.NextSymbol));
                
                ScatterPlots[groupID].Symbol.Fill.IsVisible = true;
                ScatterPlots[groupID].Line.IsVisible = false;
                ScatterPlots[groupID].Symbol.IsAntiAlias = true;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("DataSetGroupedScatterPlot: Error during PropertyChanged event.", x.Message);
                }
        }

        #endregion

        private void OnSelectedXColumnChanged(object sender, EventArgs e)
        {
            XColumn = XColumnComboBox.SelectedValue.ToString();
        }

        private void OnSelectedYColumnChanged(object sender, EventArgs e)
        {
            YColumn = YColumnComboBox.SelectedValue.ToString();
        }

        private void OnSelectedGroupColumnChanged(object sender, EventArgs e)
        {
            GroupColumn = GroupColumnComboBox.SelectedValue.ToString();
        }

        private void OnFilterTextChanged(object sender, EventArgs e)
        {
            Filter = FilterTextBox.Text;
        }
    }
}
