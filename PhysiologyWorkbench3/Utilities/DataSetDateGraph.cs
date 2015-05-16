using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RRLab.Utilities
{
    public partial class DataSetDateGraph : UserControl, INotifyPropertyChanged
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

        public event EventHandler ColumnChanged;
        private string _Column;
        [Bindable(true)]
        public string Column
        {
            get { return _Column; }
            set
            {
                _Column = value;
                OnColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("XColumn");
            }
        }

        public event EventHandler DateTimeColumnChanged;
        private string _DateTimeColumn;
        [Bindable(true)]
        public string DateTimeColumn
        {
            get { return _DateTimeColumn; }
            set
            {
                _DateTimeColumn = value;
                OnDateTimeColumnChanged(EventArgs.Empty);
                NotifyPropertyChanged("DateTimeColumn");
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
                OnTagColumnChanged(EventArgs.Empty);
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
        private string _Title = "DataSetDateGraph";
        [Bindable(true)]
        [SettingsBindable(true)]
        [DefaultValue("DataSetDateGraph")]
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

        public DataSetDateGraph()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
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

        protected virtual void OnColumnChanged(EventArgs e)
        {
            ResetGraph();

            if (ColumnChanged != null) ColumnChanged(this, e);
        }

        protected virtual void OnFilterChanged(EventArgs e)
        {
            DataBindingSource.Filter = Filter;

            ResetGraph();

            if (FilterChanged != null) FilterChanged(this, e);
        }

        protected virtual void OnTableChanged(EventArgs e)
        {
            ResetGraph();

            if (TableChanged != null) TableChanged(this, e);
        }

        protected virtual void OnDataSetChanged(EventArgs e)
        {
            if (DataSet != null) DataBindingSource.DataSource = DataSet;
            else DataBindingSource.DataSource = typeof(DataSet);

            ResetGraph();

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
            GraphControl.GraphPane.CurveList.Clear();
        }
        protected virtual void ConfigureGraph()
        {
            GraphControl.GraphPane.Title.Text = Title;
            GraphControl.GraphPane.Chart.Fill.Color = GraphColor;
            GraphControl.GraphPane.Chart.Fill.Type = ZedGraph.FillType.GradientByY;
        }
        protected virtual void ConfigureAxes()
        {
            GraphControl.GraphPane.XAxis.Title.Text = DateTimeColumn;
            GraphControl.GraphPane.XAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.XAxis.Scale.MaxAuto = true;
            GraphControl.GraphPane.YAxis.Title.Text = Column;
            GraphControl.GraphPane.YAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.YAxis.Scale.MaxAuto = true;
        }

        private ZedGraph.IPointList _Points;
        protected ZedGraph.IPointList Points
        {
            get { return _Points; }
            set { _Points = value; }
        }

        protected virtual void ConfigurePlots()
        {
            ZedGraph.DataSourcePointList points = new ZedGraph.DataSourcePointList();
            points.DataSource = DataBindingSource;
            points.XDataMember = DateTimeColumn;
            points.YDataMember = Column;
            points.TagDataMember = TagColumn;

            Points = points;
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

        protected virtual void OnDateTimeColumnChanged(EventArgs e)
        {
            ResetGraph();

            if (DateTimeColumnChanged != null)
                try
                {
                    DateTimeColumnChanged(this, e);
                }
                catch (Exception x) { ; }
        }
        protected virtual void OnTagColumnChanged(EventArgs e)
        {
            ResetGraph();

            if (TagColumnChanged != null)
                try
                {
                    TagColumnChanged(this, e);
                }
                catch (Exception x) { ; }
        }
    }
}
