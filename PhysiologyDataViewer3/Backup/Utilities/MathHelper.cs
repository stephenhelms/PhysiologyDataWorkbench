using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.Utilities
{
    public static class MathHelper
    {
        public static double CalculateMean(double[] data)
        {
            double mean = 0;
            for (int i = 0; i < data.Length; i++)
                mean += data[i];
            return mean/((double) data.Length);
        }
        public static double CalculateMeanOverTimeRange(float[] time, double[] data, float t0, float t)
        {
            double mean = 0;
            int i0 = Array.BinarySearch<float>(time, t0);
            if (i0 < 0) i0 = -i0;
            int i1 = Array.BinarySearch<float>(time, t);
            if (i1 < 0) i1 = -i1;

            for (int i = i0; i < i1; i++)
                mean += data[i];

            return mean / ((double)(i1 - i0));
        }
        public static double CalculateStDev(double[] data)
        {
            double std = 0;

            double mean = CalculateMean(data);
            for (int i = 0; i < data.Length; i++)
                std += Math.Pow(data[i] - mean, 2);

            std = Math.Pow(std / ((double)(data.Length - 1)), 0.5);

            return std;
        }
        public static double CalculateStDevOverTimeRange(float[] time, double[] data, float t0, float t)
        {
            int i0 = Array.BinarySearch<float>(time, t0);
            if (i0 < 0) i0 = -i0;
            int i1 = Array.BinarySearch<float>(time, t);
            if (i1 < 0) i1 = -i1;

            double std = 0;

            double mean = CalculateMeanOverTimeRange(time, data, t0, t);
            for (int i = i0; i < i1; i++)
                std += Math.Pow(data[i] - mean, 2);

            std = Math.Pow(std / ((double)(i1 - i0 - 1)), 0.5);

            return std;
        }

        public static double CalculateMin(double[] data)
        {
            double min = data[0];
            foreach (double value in data)
                if (value < min) min = value;
            return min;
        }

        public static double CalculateMax(double[] data)
        {
            double max = data[0];
            foreach (double value in data)
                if (value > max) max = value;
            return max;
        }
    }
}
