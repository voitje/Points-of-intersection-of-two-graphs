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
        public double[] array = new double[20];
        public double[] interval = new double[20];
        public string[] intervals = new string[50];
        static public double FindX(double x11, double y11, double x12, double y12, double x21, 
            double y21, double x22, double y22)
        {
            double X = ((y21 - x21 * ((y22 - y21) / (x22 - x21))) -
                     (y11 - (x11 * (y12 - y11) / (x12 - x11)))) /
                    (((y12 - y11) / (x12 - x11)) - (y22 - y21) / (x22 - x21));
            return X;

        }
        static public double FindY(double x11, double y11, double x12, double y12, double x21,
            double y21, double x22, double y22, double X)
        {
            double Y = ((y21 - y22) * (-X) - (x21 * y22 - x22 * y21)) / (x22 - x21);
            return Y;
        }

        static public bool transection(double ax1, double ay1, double ax2, double ay2, 
            double bx1, double by1, double bx2, double by2)
        {
            double v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            double v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            double v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            double v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            return ((v1 * v2 <= 0) && (v3 * v4 <= 0));
        }

        public double[] FindXFinal(List<Tuple<double, double>> first, List<Tuple<double, double>> second)
        {
            double [] firstX = new double[7];
            double[] firstY = new double[7];
            double[] secondX = new double[7];
            double[] secondY = new double[7];
            for (int i = 0; i < first.Count; i++)
            {
                firstX[i] = first[i].Item1;
                firstY[i] = first[i].Item2;
                secondX[i] = second[i].Item1;
                secondY[i] = second[i].Item2;
            }
            for (int i = 0, k = 0; i < first.Count - 1; i++)
            {
                for (int j = 0; j < second.Count - 1; j++)
                {
                    if (transection(
                        firstX[i],
                        firstY[i],
                        firstX[i + 1],
                        firstY[i + 1],
                        secondX[j],
                        secondY[j],
                        secondX[j + 1],
                        secondY[j + 1]))
                    {
                        array[k] = FindX(
                            firstX[i],
                            firstY[i],
                            firstX[i + 1],
                            firstY[i + 1],
                            secondX[j],
                            secondY[j],
                            secondX[j + 1],
                            secondY[j + 1]);

                        array[k + 1] = FindY(
                            firstX[i],
                            firstY[i],
                            firstX[i + 1],
                            firstY[i + 1],
                            secondX[j],
                            secondY[j],
                            secondX[j + 1],
                            secondY[j + 1],
                            array[k]);
                        k+=2;
                    }
                }
            }
            
            //TODO: бефор фикс
            /*for (int i = 0, i1 = 1; i < first.Count - 1; i++, i1++)
            {
                for (int j = 0, k = 0; j < second.Count - 1; j++)
                {
                    if (transection(
                        first[i].Item1,
                        first[i].Item2,
                        first[i + 1].Item1,
                        first[i + 1].Item2,
                        second[j].Item1, 
                        second[j].Item2,
                        second[j + 1].Item1,
                        second[j + 1].Item2))
                    {
                        array[k] = FindX(
                            first[i].Item1,
                            first[i].Item2,
                            first[i + 1].Item1,
                            first[i + 1].Item2,
                            second[j].Item1,
                            second[j].Item2,
                            second[j + 1].Item1,
                            second[j + 1].Item2);
                        array[k + 1] = FindY(
                            first[i].Item1,
                            first[i].Item2,
                            first[i + 1].Item1,
                            first[i + 1].Item2,
                            second[j].Item1,
                            second[j].Item2,
                            second[j + 1].Item1,
                            second[j + 1].Item2,
                            array[k]);

                        k+=2;
                    }
                }
            }*/

            return array;
        }

        public double[] GetInterval(List<Tuple<double, double>> first,
            List<Tuple<double, double>> second)
        {
            double[] firstX = new double[7];
            double[] firstY = new double[7];
            double[] secondX = new double[7];
            double[] secondY = new double[7];
            for (int i = 0; i < first.Count; i++)
            {
                firstX[i] = first[i].Item1;
                firstY[i] = first[i].Item2;
                secondX[i] = second[i].Item1;
                secondY[i] = second[i].Item2;
            }

           
            
            //interval[0] = 0;
            for (int i = 1, j = 1, inter = 2; i < first.Count; i++)
            {
                if (firstY[i] > secondY[i])
                {
                    
                    while (firstY[i] > secondY[i])
                    {
                        i++;
                    }

                    intervals[j] = "1";
                    interval[j] = array[inter];
                    inter+=2;
                    j++;
                }
                if (firstY[i] < secondY[i])
                {
                    while (firstY[i] < secondY[i])
                    {
                        i++;
                    }

                    intervals[j] = "2";
                    interval[j] = array[inter];
                    inter+=2;
                    j++;
                }

            }
            //for (int i = 1, j = 1; i < first.Count; i++)
            //{
            /*if (firstY[i] > secondY[i])
            {
                interval[j] = firstX[i];
                while (firstY[i] > secondY[i])
                {
                    i++;
                }

                interval[j + 1] = firstX[i - 1];
                j += 2;
            }
            if (firstY[i] < secondY[i])
            {
                interval[j] = firstY[i];
                while (firstY[i] < secondY[i])
                {
                    i++;
                }

                interval[j + 1] = secondX[i - 1];
                j += 2;
            }
            */
            //}

            return interval;
        }

    }
}
