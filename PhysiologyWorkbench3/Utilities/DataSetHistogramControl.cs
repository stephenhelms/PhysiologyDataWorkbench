using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.Utilities
{
    public partial class DataSetHistogramControl : UserControl, INotifyPropertyChanged
    {
        public event EventHandler DataSetChanged;
        private DataSet _DataSet;
        [Bindable(true)]
        public DataSet DataSet
        {
            get { return _DataSet; }
            set {
                if (DataSet != null && Table != null && DataSet.Tables.Contains(Table)) DataSet.Tables[Table].ColumnChanged -= new DataColumnChangeEventHandler(OnDataTableColumnChanged);
                _DataSet = value;
                if (DataSet != null && Table != null && DataSet.Tables.Contains(Table)) DataSet.Tables[Table].ColumnChanged -= new DataColumnChangeEventHandler(OnDataTableColumnChanged);
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
            set {
                if (DataSet != null && Table != null && DataSet.Tables.Contains(Table)) DataSet.Tables[Table].ColumnChanged -= new DataColumnChangeEventHandler(OnDataTableColumnChanged);
                _Table = value;
                if (DataSet != null && Table != null && DataSet.Tables.Contains(Table)) DataSet.Tables[Table].ColumnChanged += new DataColumnChangeEventHandler(OnDataTableColumnChanged);
                OnTableChanged(EventArgs.Empty);
                NotifyPropertyChanged("Table");
            }
        }

        public event EventHandler ColumnChanged;
        private string _Column;
        [Bindable(true)]
        public string Column
        {
            get { return _Column; }
            set {
                _Column = value;
                OnColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("XColumn");
            }
        }

        public event EventHandler FilterChanged;
        private string _Filter;
        [Bindable(true)]
        public string Filter
        {
            get { return _Filter; }
            set {
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
            set {
                _Title = value;
                OnTitleChanged(EventArgs.Empty);
                NotifyPropertyChanged("Title");
            }
        }

        private Color _GraphColor = Color.LightGoldenrodYellow;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color GraphColor
        {
            get { return _GraphColor; }
            set { _GraphColor = value; }
        }

        private Color _BarColor = Color.Crimson;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color BarColor
        {
            get { return _BarColor; }
            set { _BarColor = value; }
        }

        private ZedGraph.BarItem _BarPlot;
        protected ZedGraph.BarItem BarPlot
        {
            get { return _BarPlot; }
            set { _BarPlot = value; }
        }
	

        public DataSetHistogramControl()
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
            if(PropertyChanged != null)
                try {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                } catch(Exception e) { ; }
        }

        #endregion

        protected virtual void OnTitleChanged(EventArgs e)
        {
            RefreshGraph();

            if (TitleChanged != null) TitleChanged(this, e);
        }

        protected virtual void OnColumnChanged(EventArgs e)
        {
            CalculateHistogram();

            if (ColumnChanged != null) ColumnChanged(this, e);
        }

        protected virtual void OnFilterChanged(EventArgs e)
        {
            CalculateHistogram();

            if (FilterChanged != null) FilterChanged(this, e);
        }

        protected virtual void OnTableChanged(EventArgs e)
        {
            CalculateHistogram();

            if (TableChanged != null) TableChanged(this, e);
        }

        protected virtual void OnDataSetChanged(EventArgs e)
        {
            CalculateHistogram();

            if (DataSetChanged != null) DataSetChanged(this, e);
        }

        public virtual void RefreshGraph()
        {
            if (InvokeRequired)
            {
                Invoke(new System.Threading.ThreadStart(RefreshGraph));
                return;
            }

            if (_HistogramData == null) CalculateHistogram();

            ConfigureGraph();
            ConfigureAxes();
            ConfigurePlots();
            ConfigureCurves();

            if (HistogramData.Count != 0)
                try
                {
                    GraphControl.AxisChange();
                }
                catch (Exception e) { ; }
            GraphControl.Invalidate();
        }

        protected virtual void ResetGraph()
        {
            GraphControl.GraphPane.CurveList.Clear();
        }
        protected virtual void ConfigureGraph()
        {
            GraphControl.GraphPane.Title.Text = Title;
            GraphControl.GraphPane.Title.FontSpec.Size = 30;
            GraphControl.GraphPane.Legend.IsVisible = false;
            GraphControl.GraphPane.Chart.Fill.Color = GraphColor;
            GraphControl.GraphPane.Chart.Fill.Type = ZedGraph.FillType.GradientByY;
        }
        protected virtual void ConfigureAxes()
        {
            if (DataSet == null || Table == null || Column == null || Table == "" || Column == "") return;

            if (CategorizeByDate)
            {
                GraphControl.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;
            }
            else
            {
                GraphControl.GraphPane.XAxis.Type = ZedGraph.AxisType.Linear;
                GraphControl.GraphPane.XAxis.Scale.FormatAuto = true;
            }

            GraphControl.GraphPane.XAxis.Title.Text = DataSet.Tables[Table].Columns[Column].Caption ?? Column;
            GraphControl.GraphPane.XAxis.Title.FontSpec.Size = 20F;
            GraphControl.GraphPane.XAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.XAxis.Scale.MaxAuto = true;
            GraphControl.GraphPane.XAxis.Scale.FontSpec.Size = 20F;

            GraphControl.GraphPane.YAxis.Title.Text = "Number";
            GraphControl.GraphPane.YAxis.Title.FontSpec.Size = 20F;
            GraphControl.GraphPane.YAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.YAxis.Scale.MaxAuto = true;
            GraphControl.GraphPane.YAxis.Scale.FontSpec.Size = 20F;
            GraphControl.GraphPane.YAxis.Scale.Format = "N0";
        }

        private ZedGraph.IPointList _Points;
        protected ZedGraph.IPointList Points
        {
            get { return _Points; }
            set { _Points = value; }
        }

        protected virtual void ConfigurePlots()
        {
            double[] x = new double[HistogramData.Keys.Count];
            double[] y = new double[HistogramData.Keys.Count];
            for (int i = 0; i < HistogramData.Keys.Count; i++)
            {
                x[i] = _HistogramData.Keys[i];
                y[i] = (double) _HistogramData.Values[i];
            }
            Points = new ZedGraph.PointPairList(x, y);
        }
        protected virtual void ConfigureCurves()
        {
            if (BarPlot == null)
                BarPlot = GraphControl.GraphPane.AddBar(Column, Points, BarColor);
            else
            {
                BarPlot.Points = Points;
                BarPlot.Label.Text = Column;
                BarPlot.Color = BarColor;
            }
        }

        private SortedList<double, int> _HistogramData = new SortedList<double,int>();
        public IDictionary<double, int> HistogramData
        {
            get { return _HistogramData; }
        }

        protected bool CategorizeByDate
        {
            get
            {
                if (DataSet != null && Table != null && Column != null && Table != "" && Column != "")
                    return DataSet.Tables[Table].Columns[Column].DataType == typeof(DateTime);
                else return false;
            }
        }

        protected virtual void CalculateHistogram()
        {
            if (DataSet == null || Table == null || Column == null)
            {
                _HistogramData = new SortedList<double, int>();
                RefreshGraph();
                return;
            }

            if (CategorizeByDate)
            {
                CalculateHistogramByDateTime();
                return;
            }


            _HistogramData = new SortedList<double, int>();

            DataRow[] rows = DataSet.Tables[Table].Select(Filter);
            List<double> values = new List<double>(rows.Length);
            foreach (DataRow row in rows)
                if (!row.IsNull(Column))
                    if (row[Column] is TimeSpan)
                        values.Add(((TimeSpan)row[Column]).TotalMinutes);
                    else values.Add(Convert.ToDouble(row[Column]));
            values.TrimExcess();
            values.Sort();

            double min = values[0];
            double max = values[values.Count-1];
            int nBins = Convert.ToInt32(Math.Sqrt(values.Count));
            double binWidth = Math.Abs(max - min) / ((double)nBins);
            for (double i = min; i < max + binWidth; i += binWidth)
                _HistogramData.Add(i, 0);

            for (int i = 0; i < values.Count; i++)
            {
                int bin = Convert.ToInt32((values[i] - min) / binWidth);
                _HistogramData[_HistogramData.Keys[bin]]++;
            }

            RefreshGraph();
        }
        protected virtual void CalculateHistogramByDateTime()
        {
            _HistogramData = new SortedList<double, int>();

            DataRow[] rows = DataSet.Tables[Table].Select(Filter);
            List<DateTime> values = new List<DateTime>(rows.Length);
            foreach (DataRow row in rows)
                if (!row.IsNull(Column))
                    values.Add((DateTime)row[Column]);
            values.TrimExcess();
            values.Sort();

            DateTime min = values[0];
            DateTime max = values[values.Count - 1];
            TimeSpan span = max - min;

            int nBins = Convert.ToInt32(Math.Sqrt(values.Count));
            int nExtraBins_Dates = Convert.ToInt32(Math.Abs(nBins - span.TotalDays));
            int nExtraBins_Hours = Convert.ToInt32(Math.Abs(nBins - span.TotalHours));
            int nExtraBins_Minutes = Convert.ToInt32(Math.Abs(nBins - span.TotalMinutes));
            bool useDates =  nExtraBins_Dates < nExtraBins_Hours && nExtraBins_Dates < nExtraBins_Minutes;
            bool useHours = nExtraBins_Hours < nExtraBins_Dates && nExtraBins_Hours < nExtraBins_Minutes;

            for (ZedGraph.XDate i = min.ToOADate(); i < max.ToOADate();)
            {
                DateTime dateTime = DateTime.FromOADate(i);
                ZedGraph.XDate x;
                if (useDates) x = new ZedGraph.XDate(dateTime.Year, dateTime.Month, dateTime.Day);
                else if (useHours) x = new ZedGraph.XDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);
                else x = new ZedGraph.XDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);

                _HistogramData.Add(x, 0);
                if (useDates) i.AddDays(1);
                else if (useHours) i.AddHours(1);
                else i.AddMinutes(1);
            }

            if (useDates) GraphControl.GraphPane.XAxis.Scale.Format = "d";
            else if (useHours) GraphControl.GraphPane.XAxis.Scale.Format = "g";
            else GraphControl.GraphPane.XAxis.Scale.Format = "g";

            for (int i = 0; i < values.Count; i++)
            {
                DateTime dateTime = (DateTime) rows[i][Column];
                _HistogramData[new ZedGraph.XDate(dateTime.Year, dateTime.Month, dateTime.Day)]++;
            }

            RefreshGraph();
        }

        protected virtual void OnDataTableColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == Column) CalculateHistogram();
        }
    }
}
