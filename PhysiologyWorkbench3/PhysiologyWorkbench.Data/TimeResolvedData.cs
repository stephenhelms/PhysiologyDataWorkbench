using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.PhysiologyWorkbench.Data
{
    public static class TimeResolvedDataUtility
    {
        public static double[] ConvertDataToArray(TimeResolvedDataPoint[] points)
        {
            double[] data = new double[points.Length];
            for (int i = 0; i < points.Length; i++)
                data[i] = points[i].Data;
            return data;
        }
        public static float[] ConvertTimeToArray(TimeResolvedDataPoint[] points)
        {
            float[] time = new float[points.Length];
            for (int i = 0; i < points.Length; i++)
                time[i] = points[i].Time;
            return time;
        }
    }

    public class TimeResolvedData
    {
        public TimeResolvedDataPoint[] DataPoints;
        public string Units;

        public float[] Time
        {
            get { return TimeResolvedDataUtility.ConvertTimeToArray(DataPoints); }
            set {
                if(DataPoints.Length != value.Length) throw new ArgumentException("New data must be same length as old data.");
                for (int i = 0; i < DataPoints.Length; i++)
                    this[i] = new TimeResolvedDataPoint(value[i], this[i].Data);
            }
        }
        public double[] Values
        {
            get { return TimeResolvedDataUtility.ConvertDataToArray(DataPoints); }
            set {
                if(DataPoints.Length != value.Length) throw new ArgumentException("New data must be same length as old data.");
                for(int i=0; i < DataPoints.Length; i++)
                    this[i] = new TimeResolvedDataPoint(this[i].Time, value[i]);
            }
        }

        public TimeResolvedData()
        {
            DataPoints = null;
            Units = "Unknown";
        }
        public TimeResolvedData(TimeResolvedDataPoint[] data)
        {
            DataPoints = data;
            Units = "Unknown";
        }
        public TimeResolvedData(TimeResolvedDataPoint[] data, string units)
        {
            DataPoints = data;
            Units = units;
        }
        public TimeResolvedData(float[] time, double[] values) : this(time, values, "Unknown")
        {
        }
        public TimeResolvedData(float[] time, double[] values, string units)
        {
            if (time.Length != values.Length) throw new ArgumentException("Time and values must be of same length.");

            Units = units;
            DataPoints = new TimeResolvedDataPoint[time.Length];

            for (int i = 0; i < time.Length; i++)
                DataPoints[i] = new TimeResolvedDataPoint(time[i], values[i]);
        }

        public TimeResolvedDataPoint this[int i]
        {
            get { return DataPoints[i]; }
            set { DataPoints[i] = value; }
        }
    }

    public struct TimeResolvedDataPoint : IComparable<TimeResolvedDataPoint>, IEquatable<TimeResolvedDataPoint>
    {
        public float Time;
        public double Data;

        public TimeResolvedDataPoint(float time, double data) {
            Time = time;
            Data = data;
        }

        #region IComparable<TimeResolvedDataPoint> Members

        public int CompareTo(TimeResolvedDataPoint other)
        {
            return Convert.ToInt32(Time - other.Time);
        }

        #endregion

        #region IEquatable<TimeResolvedDataPoint> Members

        public bool Equals(TimeResolvedDataPoint other)
        {
            return Time == other.Time && Data == other.Data;
        }

        #endregion
    }
}
