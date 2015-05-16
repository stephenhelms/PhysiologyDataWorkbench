using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.Utilities
{
    public partial class DataSetScatterPlotControl : UserControl, INotifyPropertyChanged
    {
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
                NotifyPropertyChanged("DataSet");
            }
        }

        public event EventHandler TableChanged;
        private string _Table;
        [Bindable(true)]
        public string Table
        {
            get { return _Table; }
            set
            {
                _Table = value;
                OnTableChanged(EventArgs.Empty);
                NotifyPropertyChanged("Table");
            }
        }

        public event EventHandler XColumnChanged;
        private string _XColumn;
        [Bindable(true)]
        public string XColumn
        {
            get { return _XColumn; }
            set
            {
                _XColumn = value;
                OnXColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("XColumn");
            }
        }

        

        public event EventHandler YColumnChanged;
        private string _YColumn;
        [Bindable(true)]
        public string YColumn
        {
            get { return _YColumn; }
            set
            {
                _YColumn = value;
                OnXColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("YColumn");
            }
        }

        public event EventHandler TagColumnChanged;
        private string _TagColumn;
        [Bindable(true)]
        public string TagColumn
        {
            get { return _TagColumn; }
            set
            {
                _TagColumn = value;
                OnXColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("TagColumn");
            }
        }

        public event EventHandler FilterChanged;
        private string _Filter;
        [Bindable(true)]
        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                OnFilterChanged(EventArgs.Empty);
                NotifyPropertyChanged("Filter");
            }
        }

        public event EventHandler TitleChanged;
        private string _Title;
        [Bindable(true)]
        [SettingsBindable(true)]
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnTitleChanged(EventArgs.Empty);
                NotifyPropertyChanged("Title");
            }
        }

        public event EventHandler GraphColorChanged;
        private Color _GraphColor = Color.LightGoldenrodYellow;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color GraphColor
        {
            get { return _GraphColor; }
            set {
                _GraphColor = value;
                if(GraphColorChanged != null)
                    try
                    {
                        GraphColorChanged(this, EventArgs.Empty);
                    }
                    catch (Exception x) { ; }
                NotifyPropertyChanged("GraphColor");
            }
        }

        public event EventHandler PointsColorChanged;
        private Color _PointsColor = Color.Crimson;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color PointsColor
        {
            get { return _PointsColor; }
            set {
                _PointsColor = value;
                if(PointsColorChanged != null)
                    try
                    {
                        PointsColorChanged(this, EventArgs.Empty);
                    }
                    catch (Exception x) { ; }
                NotifyPropertyChanged("PointsColor");
            }
        }

        private ZedGraph.LineItem _ScatterPlot;

        protected ZedGraph.LineItem ScatterPlot
        {
            get { return _ScatterPlot; }
            set
            {
                _ScatterPlot = value;
            }
        }

        public event EventHandler SymbolTypeChanged;
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
                if (SymbolTypeChanged != null)
                    try
                    {
                        SymbolTypeChanged(this, EventArgs.Empty);
                    }
                    catch (Exception x) { ; }
                NotifyPropertyChanged("SymbolType");
            }
        }

        private ZedGraph.DataSourcePointList _Points;
        protected ZedGraph.DataSourcePointList Points
        {
            get { return _Points; }
            set { _Points = value; }
        }

        public DataSetScatterPlotControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            RefreshGraph();
            base.OnLoad(e);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
                catch (Exception e) { ; }
        }

        #endregion

        protected virtual void OnTitleChanged(EventArgs e)
        {
            RefreshGraph();

            if (TitleChanged != null) TitleChanged(this, e);
        }

        protected virtual void OnXColumnChanged(EventArgs e)
        {
            RefreshGraph();

            if (XColumnChanged != null) XColumnChanged(this, e);
        }
        protected virtual void OnYColumnChanged(EventArgs e)
        {
            RefreshGraph();

            if (YColumnChanged != null) YColumnChanged(this, e);
        }
        protected virtual void OnTagColumnChanged(EventArgs e)
        {
            RefreshGraph();

            if (TagColumnChanged != null) TagColumnChanged(this, e);
        }

        protected virtual void OnFilterChanged(EventArgs e)
        {
            DataSetBindingSource.Filter = Filter;

            RefreshGraph();

            if (FilterChanged != null) FilterChanged(this, e);
        }

        protected virtual void OnTableChanged(EventArgs e)
        {
            try
            {
                DataSetBindingSource.DataMember = Table;
            }
            catch (Exception x) { ; }

            RefreshGraph();

            if (TableChanged != null) TableChanged(this, e);
        }

        protected virtual void OnDataSetChanged(EventArgs e)
        {
            if (DataSet != null) DataSetBindingSource.DataSource = DataSet;
            else DataSetBindingSource.DataSource = typeof(DataSet);

            OnTableChanged(e);

            RefreshGraph();

            if (DataSetChanged != null) DataSetChanged(this, e);
        }

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
            Points = null;
            ScatterPlot = null;
            GraphControl.GraphPane.CurveList.Clear();
        }
        protected virtual void ConfigureGraph()
        {
            GraphControl.GraphPane.Title.Text = Title;
            GraphControl.GraphPane.Title.FontSpec.Size = 30;
            GraphControl.GraphPane.Legend.IsVisible = false;
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
            if (Points == null) Points = new ZedGraph.DataSourcePointList();

            Points.DataSource = DataSetBindingSource;
            Points.XDataMember = XColumn;
            Points.YDataMember = YColumn;
            Points.TagDataMember = TagColumn;
        }
        protected virtual void ConfigureCurves()
        {
            if (ScatterPlot == null)
                ScatterPlot = GraphControl.GraphPane.AddCurve(
                    String.Format("{0} vs. {1}", YColumn, XColumn),
                    Points, PointsColor, SymbolType);
            else
            {
                ScatterPlot.Points = Points;
                ScatterPlot.Label.Text = String.Format("{0} vs. {1}", YColumn, XColumn);
                ScatterPlot.Color = PointsColor;
            }
            ScatterPlot.Symbol.Fill.IsVisible = true;
            ScatterPlot.Line.IsVisible = false;
            ScatterPlot.Symbol.IsAntiAlias = true;
        }
    }
}
