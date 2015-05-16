using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RRLab.PhysiologyWorkbench.Data;

namespace RRLab.PhysiologyDataWorkshop.Experiments.MacroscopicBump
{
    public partial class MacroscopicBumpViewerControl : UserControl, INotifyPropertyChanged
    {
        public event EventHandler PhysiologyDataSetChanged;
        private PhysiologyDataSet _PhysiologyDataSet;
        [Bindable(true)]
        public PhysiologyDataSet PhysiologyDataSet
        {
            get { return _PhysiologyDataSet; }
            set {
                _PhysiologyDataSet = value;
                OnPhysiologyDataSetChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnPhysiologyDataSetChanged(EventArgs e)
        {
            ResetGraph();

            if(PhysiologyDataSetChanged != null)
                try
                {
                    PhysiologyDataSetChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("MacroscopicBumpViewerControl: Error during PhysiologyDataSetChanged event.", x.Message);
                }
        }

        public event EventHandler MacroscopicBumpChanged;
        private MacroscopicRecordingsDataSet.MacroscopicRecordingsRow _MacroscopicBump;
        [Bindable(true)]
        public MacroscopicRecordingsDataSet.MacroscopicRecordingsRow MacroscopicBump
        {
            get { return _MacroscopicBump; }
            set {
                _MacroscopicBump = value;
                OnMacroscopicBumpChanged(EventArgs.Empty);
            }
        }

        protected virtual void OnMacroscopicBumpChanged(EventArgs e)
        {
            ResetGraph();

            if(MacroscopicBumpChanged != null)
                try
                {
                    MacroscopicBumpChanged(this, e);
                }
                catch (Exception x)
                {
                    System.Diagnostics.Debug.Fail("MacroscopicBumpViewerControl: Error during MacroscopicBumpChanged event.", x.Message);
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

        private Color _LineColor = Color.Blue;
        [SettingsBindable(true)]
        [Bindable(true)]
        public Color LineColor
        {
            get { return _LineColor; }
            set {
                _LineColor = value;
                NotifyPropertyChanged("LineColor");
            }
        }
	

        private ZedGraph.LineItem _CurrentScatterPlot;

        protected ZedGraph.LineItem CurrentScatterPlot
        {
            get { return _CurrentScatterPlot; }
            set
            {
                _CurrentScatterPlot = value;
            }
        }

        private ZedGraph.LineItem _FitScatterPlot;

        protected ZedGraph.LineItem FitScatterPlot
        {
            get { return _FitScatterPlot; }
            set { _FitScatterPlot = value; }
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

        private ZedGraph.FilteredPointList _CurrentPoints;
        protected ZedGraph.FilteredPointList CurrentPoints
        {
            get { return _CurrentPoints; }
            set { _CurrentPoints = value; }
        }

        private ZedGraph.PointPairList _FitPoints;

        protected ZedGraph.PointPairList FitPoints
        {
            get { return _FitPoints; }
            set { _FitPoints = value; }
        }
	

        public MacroscopicBumpViewerControl()
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
            CurrentPoints = null;
            FitPoints = null;
            CurrentScatterPlot = null;
            FitScatterPlot = null;
            GraphControl.GraphPane.CurveList.Clear();

            RefreshGraph();
        }
        protected virtual void ConfigureGraph()
        {
            if (MacroscopicBump != null)
                GraphControl.GraphPane.Title.Text = String.Format("Recording {0}\n{1}\nAnalyzed: {2}", MacroscopicBump.RecordingID, MacroscopicBump.Genotype, MacroscopicBump.AnalysisDate);
            else GraphControl.GraphPane.Title.Text = "No Bump Selected";
            //GraphControl.GraphPane.Title.FontSpec.Size = 30;
            GraphControl.GraphPane.Legend.IsVisible = false;
            GraphControl.GraphPane.Chart.Fill.Color = GraphColor;
            GraphControl.GraphPane.Chart.Fill.Type = ZedGraph.FillType.GradientByY;
            
        }
        protected virtual void ConfigureAxes()
        {
            GraphControl.GraphPane.XAxis.Title.Text = "Time (ms)";
            //GraphControl.GraphPane.XAxis.Title.FontSpec.Size = 20F;
            GraphControl.GraphPane.XAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.XAxis.Scale.MaxAuto = true;
            //GraphControl.GraphPane.XAxis.Scale.FontSpec.Size = 20F;


            GraphControl.GraphPane.YAxis.Title.Text = "Current (pA)";
            //GraphControl.GraphPane.YAxis.Title.FontSpec.Size = 20F;
            GraphControl.GraphPane.YAxis.Scale.MinAuto = true;
            GraphControl.GraphPane.YAxis.Scale.MaxAuto = true;
            //GraphControl.GraphPane.YAxis.Scale.FontSpec.Size = 20F;
        }

        protected virtual void ConfigurePlots()
        {
            if (PhysiologyDataSet == null || MacroscopicBump == null) return;

            TimeResolvedData currentData = PhysiologyDataSet.Recordings.FindByRecordingID(
                MacroscopicBump.RecordingID).GetData("Current");
            CurrentPoints = new ZedGraph.FilteredPointList(Array.ConvertAll<float,double>(currentData.Time, new Converter<float,double>(delegate(float value)
            { return (double) value; })), currentData.Values);

            FitPoints = new ZedGraph.PointPairList();
            if (!MacroscopicBump.IsLatencyTimeNull())
            {
                FitPoints.Add(MacroscopicBump.LatencyTime, Array.Find<TimeResolvedDataPoint>(currentData.DataPoints, new Predicate<TimeResolvedDataPoint>(
                    delegate(TimeResolvedDataPoint point)
                    {
                        return point.Time >= MacroscopicBump.LatencyTime;
                    })).Data, "Latency Time");
                if (!MacroscopicBump.IsSlowActivationTimeNull())
                    // Half-rise time is t_lat + t_slowact
                    FitPoints.Add(MacroscopicBump.LatencyTime + MacroscopicBump.SlowActivationTime, Array.Find<TimeResolvedDataPoint>(currentData.DataPoints, new Predicate<TimeResolvedDataPoint>(
                        delegate(TimeResolvedDataPoint point)
                        {
                            return point.Time >= MacroscopicBump.LatencyTime + MacroscopicBump.SlowActivationTime;
                        })).Data, "Half-Activation Time");
            }
            if (!MacroscopicBump.IsTimeOfPeakNull())
            {
                FitPoints.Add(MacroscopicBump.TimeOfPeak, Array.Find<TimeResolvedDataPoint>(currentData.DataPoints, new Predicate<TimeResolvedDataPoint>(
                    delegate(TimeResolvedDataPoint point)
                    {
                        return point.Time >= MacroscopicBump.TimeOfPeak;
                    })).Data, "Time of Peak");
                if (!MacroscopicBump.IsFastInactivationTimeNull())
                {
                    // Half-inact. time is t_peak + t_fastinac
                    FitPoints.Add(MacroscopicBump.TimeOfPeak + MacroscopicBump.FastInactivationTime, Array.Find<TimeResolvedDataPoint>(currentData.DataPoints, new Predicate<TimeResolvedDataPoint>(
                        delegate(TimeResolvedDataPoint point)
                        {
                            return point.Time >= MacroscopicBump.TimeOfPeak + MacroscopicBump.FastInactivationTime;
                        })).Data, "Half-Inactivation Time");
                    if(!MacroscopicBump.IsSlowActivationTimeNull())
                        // Finished time is t_peak + t_fastinact + t_slowinac
                        FitPoints.Add(MacroscopicBump.TimeOfPeak + MacroscopicBump.FastInactivationTime + MacroscopicBump.SlowInactivationTime, Array.Find<TimeResolvedDataPoint>(currentData.DataPoints, new Predicate<TimeResolvedDataPoint>(
                        delegate(TimeResolvedDataPoint point)
                        {
                            return point.Time >= MacroscopicBump.TimeOfPeak + MacroscopicBump.FastInactivationTime + MacroscopicBump.SlowInactivationTime;
                        })).Data, "Finished Time");
                }
            }
        }
        protected virtual void ConfigureCurves()
        {
            if (FitPoints != null)
            {

                if (FitScatterPlot == null)
                    FitScatterPlot = GraphControl.GraphPane.AddCurve("Bump Fit", FitPoints, PointsColor, SymbolType);
                else
                {
                    FitScatterPlot.Points = FitPoints;
                    FitScatterPlot.Label.Text = "Bump Fit";
                    FitScatterPlot.Color = PointsColor;
                }
                FitScatterPlot.Symbol.Fill.IsVisible = true;
                FitScatterPlot.Line.IsVisible = false;
                FitScatterPlot.Symbol.IsAntiAlias = true;
                FitScatterPlot.Symbol.Size = 10;
            }

            if (CurrentPoints == null) return;

            if (CurrentScatterPlot == null)
                CurrentScatterPlot = GraphControl.GraphPane.AddCurve("Current", CurrentPoints, PointsColor, ZedGraph.SymbolType.None);
            else
            {
                CurrentScatterPlot.Points = CurrentPoints;
                CurrentScatterPlot.Label.Text = "Current";
                CurrentScatterPlot.Color = LineColor;
            }
            CurrentScatterPlot.Symbol.Fill.IsVisible = false;
            CurrentScatterPlot.Line.IsVisible = true;
            CurrentScatterPlot.Symbol.IsAntiAlias = true;
        }
    }
}
