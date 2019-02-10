using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class IntersectionPoints
    {
        public List<Tuple<double, double>> pointOfChartFirst = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> pointOfChart1 { get; set; }
        public List<Tuple<double, double>> pointOfChartSecond { get; set; }
        public GenerateChart GenerateChart;
        public int[] array = new int [20];
        static public int FindX(int x11, int y11, int x12, int y12, int x21, int y21, int x22, int y22)
        {
            int X = ((y21 - x21 * ((y22 - y21) / (x22 - x21))) -
                     (y11 - (x11 * (y12 - y11) / (x12 - x11)))) /
                    (((y12 - y11) / (x12 - x11)) - (y22 - y21) / (x22 - x21));

            return X;

        }
        static public int FindY(int x11, int y11, int x12, int y12, int x21, int y21, int x22, int y22, int X)
        {
            int Y = ((y12 - y11) / (x12 - x11)) * X + (y11 - x11 * (y12 - y11) / (x12 - x11));
            return Y;
        }

        static public bool transection(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            int v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            int v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            int v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            return ((v1 * v2 <= 0) && (v3 * v4 <= 0));
        }

        public int[] FindXFinal(List<Tuple<double, double>> first, List<Tuple<double, double>> second)
        {
            for (int i = 0; i < first.Count - 1; i++)
            {
                for (int j = 0, k = 0; j < second.Count - 1; j++)
                {
                    if (transection(
                        Convert.ToInt32(first[i].Item1),
                        Convert.ToInt32(first[i].Item2),
                        Convert.ToInt32(first[i + 1].Item1),
                        Convert.ToInt32(first[i + 1].Item2),
                        Convert.ToInt32(second[j].Item1), 
                        Convert.ToInt32(second[j].Item2),
                        Convert.ToInt32(second[j + 1].Item1),
                        Convert.ToInt32(second[j + 1].Item2)))
                    {
                        array[k] = FindX(
                            Convert.ToInt32(first[i].Item1),
                            Convert.ToInt32(first[i].Item2),
                            Convert.ToInt32(first[i + 1].Item1),
                            Convert.ToInt32(first[i + 1].Item2),
                            Convert.ToInt32(second[j].Item1),
                            Convert.ToInt32(second[j].Item2),
                            Convert.ToInt32(second[j + 1].Item1),
                            Convert.ToInt32(second[j + 1].Item2));
                        array[k + 1] = FindY(
                            Convert.ToInt32(first[i].Item1),
                            Convert.ToInt32(first[i].Item2),
                            Convert.ToInt32(first[i + 1].Item1),
                            Convert.ToInt32(first[i + 1].Item2),
                            Convert.ToInt32(second[j].Item1),
                            Convert.ToInt32(second[j].Item2),
                            Convert.ToInt32(second[j + 1].Item1),
                            Convert.ToInt32(second[j + 1].Item2),
                            array[j]);

                        k+=2;
                    }
                }
            }

            return array;
        }

    }
}
