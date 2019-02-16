using System;
using System.Collections.Generic;

namespace Model
{
    public class IntersectionPoints
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Массив пересечений
        /// </summary>
        private readonly double[] _arrayIntersection = new double[20];

        /// <summary>
        ///     Список интервалов
        /// </summary>
        private readonly List<string> _interval = new List<string>();

        #endregion

        #endregion

        #region Properties

        private bool ChangeGraph { get; set; }
        private int Check { get; set; }

        #endregion

        #region Private methods

        /// <summary>
        ///     Функция для поиска точки пересечения (X)
        /// </summary>
        /// <param name="x11"></param>
        /// <param name="y11"></param>
        /// <param name="x12"></param>
        /// <param name="y12"></param>
        /// <param name="x21"></param>
        /// <param name="y21"></param>
        /// <param name="x22"></param>
        /// <param name="y22"></param>
        /// <returns></returns>
        private static double FindX(double x11, double y11, double x12, double y12,
            double x21,
            double y21, double x22, double y22)
        {
            var x = (y21 - x21 * ((y22 - y21) / (x22 - x21)) -
                     (y11 - x11 * (y12 - y11) / (x12 - x11))) /
                    ((y12 - y11) / (x12 - x11) - (y22 - y21) / (x22 - x21));

            return x;
        }

        /// <summary>
        ///     Функция для поиска точки пересечения (Y)
        /// </summary>
        /// <param name="x11"></param>
        /// <param name="y11"></param>
        /// <param name="x12"></param>
        /// <param name="y12"></param>
        /// <param name="x21"></param>
        /// <param name="y21"></param>
        /// <param name="x22"></param>
        /// <param name="y22"></param>
        /// <param name="X"></param>
        /// <returns></returns>
        private static double FindY(double x11, double y11, double x12, double y12,
            double x21,
            double y21, double x22, double y22, double X)
        {
            var Y = ((y21 - y22) * -X - (x21 * y22 - x22 * y21)) / (x22 - x21);
            return Y;
        }

        /// <summary>
        ///     Проверка - пересекаются ли графики
        /// </summary>
        /// <param name="ax1"></param>
        /// <param name="ay1"></param>
        /// <param name="ax2"></param>
        /// <param name="ay2"></param>
        /// <param name="bx1"></param>
        /// <param name="by1"></param>
        /// <param name="bx2"></param>
        /// <param name="by2"></param>
        /// <returns></returns>
        private static bool IsIntersection(double ax1, double ay1, double ax2, double ay2,
            double bx1, double by1, double bx2, double by2)
        {
            var v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            var v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            var v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            var v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            return v1 * v2 <= 0 && v3 * v4 <= 0;
        }

        /*public double[] GetInterval(List<Tuple<double, double>> first,
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

            for (int i = 1, j = 1, inter = 2; i < first.Count; i++)
            {
                if (firstY[i] > secondY[i])
                {
                    
                    while (firstY[i] > secondY[i])
                    {
                        i++;
                    }

                    intervals[j] = "1";
                    interval[j] = arrayIntersection[inter];
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
                    interval[j] = arrayIntersection[inter];
                    inter+=2;
                    j++;
                }

            }
         
            return interval;
        }
        */
        /*public static double lagrange1(double x, double[] xd, double[] yd)
        {
            if (xd.Length != yd.Length)
            {
                throw new ArgumentException(
                    "Arrays must be of equal length."); //$NON-NLS-1$
            }

            double sum = 0;
            for (int i = 0, n = xd.Length; i < n; i++)
            {
                if (x - xd[i] == 0)
                {
                    return yd[i];
                }

                var product = yd[i];
                for (var j = 0; j < n; j++)
                {
                    if (i == j || xd[i] - xd[j] == 0)
                    {
                        continue;
                    }

                    product *= (x - xd[i]) / (xd[i] - xd[j]);
                }

                sum += product;
            }

            return sum;
        }

        public static double lagrange3(double x, double[] xd, double[] yd)
        {
            //ВТОРОЙ СПОСОБ
            double mult;
            double sum = 0;
            for (var i = 0; i <= xd.Length - 1; i++)
            {
                mult = 1;
                for (var j = 0; j <= xd.Length - 1; j++)
                {
                    if (j != i)
                    {
                        mult *= (x - xd[j]) / (xd[i] - xd[j]);
                    }
                }

                sum += mult * yd[i];
            }

            return sum;
        }
        */
        /// <summary>
        ///     Интерполяция Лагранжа
        /// </summary>
        /// <param name="x"></param>
        /// <param name="xd"></param>
        /// <param name="yd"></param>
        /// <returns></returns>
        private static double Lagrange(double x, double[] xd, double[] yd)
        {
            /*double result = 0; // Initialize result 

            for (int i = 0; i < xd.Length; i++)
            {
                // Compute individual terms of above formula 
                double term = yd[i];
                for (int j = 0; j < xd.Length; j++)
                {
                    if (j != i)
                        term = term * (x - xd[i]) / (xd[i] - xd[j]);
                }

                // Add current term to result 
                result += term;
            }

            return result;*/
            double sum = 0;
            var factor = new double [29];
            for (var i = 0; i < xd.Length; i++)
            {
                factor[i] = 1.0;
                for (var j = 0; j < xd.Length; j++)
                {
                    if (i != j)
                    {
                        factor[i] = factor[i] * (x - xd[j]) / (xd[i] - xd[j]);
                    }
                }
            }

            for (var i = 0; i < xd.Length; i++)
            {
                sum = sum + factor[i] * yd[i];
            }

            return sum;
        }

        /// <summary>
        /// Функция для поиска ближайщего элемента к центру пересечений
        /// </summary>
        /// <param name="array">Массив по X</param>
        /// <param name="middlePointOfArray">Средняя точка между двумя пересечениями</param>
        /// <returns></returns>
        private static int GetIndexArray(double[] array, double middlePointOfArray)
        {
            double temp = 0, t = double.MaxValue;

            for (var i = 0; i < array.Length; i++)
            {
                var a = Math.Abs(array[i] - middlePointOfArray);

                if (a < t)
                {
                    temp = array[i];
                    t = a;
                }
            }

            var otvet = Array.IndexOf(array, temp);
            if (temp > middlePointOfArray)
            {
                return otvet - 1;
            }

            return otvet;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Функция для нахождения точки пересечения
        /// </summary>
        /// <param name="first">Набор точек первого графика</param>
        /// <param name="second">Набор точек второго графика</param>
        /// <returns></returns>
        public double[] FindXFinal(List<Tuple<double, double>> first,
            List<Tuple<double, double>> second)
        {
            var firstX = new double[7];
            var firstY = new double[7];
            var secondX = new double[7];
            var secondY = new double[7];
            for (var i = 0; i < first.Count; i++)
            {
                firstX[i] = first[i].Item1;
                firstY[i] = first[i].Item2;
                secondX[i] = second[i].Item1;
                secondY[i] = second[i].Item2;
            }

            for (int i = 0, k = 0; i < first.Count - 1; i++)
            {
                for (var j = 0; j < second.Count - 1; j++)
                {
                    if (IsIntersection(
                        firstX[i],
                        firstY[i],
                        firstX[i + 1],
                        firstY[i + 1],
                        secondX[j],
                        secondY[j],
                        secondX[j + 1],
                        secondY[j + 1]))
                    {
                        _arrayIntersection[k] = FindX(
                            firstX[i],
                            firstY[i],
                            firstX[i + 1],
                            firstY[i + 1],
                            secondX[j],
                            secondY[j],
                            secondX[j + 1],
                            secondY[j + 1]);

                        if (k == 2)
                        {
                            Check = i;
                        }

                        _arrayIntersection[k + 1] = FindY(
                            firstX[i],
                            firstY[i],
                            firstX[i + 1],
                            firstY[i + 1],
                            secondX[j],
                            secondY[j],
                            secondX[j + 1],
                            secondY[j + 1],
                            _arrayIntersection[k]);

                        k += 2;
                    }
                }
            }

            return _arrayIntersection;
        }


        //TODO: В разроботке!
        public List<string> GetStringInterval(List<Tuple<double, double>> first,
            List<Tuple<double, double>> second)
        {
            var firstX = new double[first.Count];
            var firstY = new double[first.Count];
            var secondX = new double[first.Count];
            var secondY = new double[first.Count];
            for (var i = 0; i < first.Count; i++)
            {
                firstX[i] = first[i].Item1;
                firstY[i] = first[i].Item2;
                secondX[i] = second[i].Item1;
                secondY[i] = second[i].Item2;
            }

            var middlePoint = (_arrayIntersection[0] + _arrayIntersection[2]) / 2;
            double ansLagrangeFirst;
            double ansLagrangeSecond;
            var indexFirst = GetIndexArray(firstX, middlePoint);
            var indexSecond = GetIndexArray(secondX, middlePoint);

            double[] xfirst = {firstX[indexFirst], firstX[indexFirst + 1]};
            double[] yfirst = {firstY[indexFirst], firstY[indexFirst + 1]};

            double[] xsecond = {secondX[indexSecond], secondX[indexFirst + 1]};
            double[] ysecond = {secondY[indexSecond], secondY[indexSecond + 1]};

            ansLagrangeFirst = Lagrange(middlePoint, xfirst, yfirst);
            ansLagrangeSecond = Lagrange(middlePoint, xsecond, ysecond);


            if (ansLagrangeFirst > ansLagrangeSecond)
            {
                ChangeGraph = false;
            }
            else
            {
                ChangeGraph = true;
            }

            if (ChangeGraph == false)
            {
                _interval.Add($"Синий больше с:" + _arrayIntersection[0] + " до: " +
                              _arrayIntersection[2] +
                              "\n");

                if (_arrayIntersection[2] == 20)
                {
                    return _interval;
                }

                for (int i = 2, j = 0; i < _arrayIntersection.Length - 2; i += 2, j++)
                {
                    if (_arrayIntersection[i] == 20 && _arrayIntersection[i + 2] == 0)
                    {
                        return _interval;
                    }

                    if (j % 2 == 0)
                    {
                        _interval.Add($"Красный больше с:" + _arrayIntersection[i] +
                                      " до: " +
                                      _arrayIntersection[i + 2] +
                                      "\n");
                    }
                    else
                    {
                        _interval.Add($"Синий больше с:" + _arrayIntersection[i] +
                                      " до: " +
                                      _arrayIntersection[i + 2] +
                                      "\n");
                    }
                }
            }
            else
            {
                _interval.Add($"Красный больше с:" + _arrayIntersection[0] + " до: " +
                              _arrayIntersection[2] +
                              "\n");

                if (_arrayIntersection[2] == 20)
                {
                    return _interval;
                }

                for (int i = 2, j = 0; i < _arrayIntersection.Length - 2; i += 2, j++)
                {
                    if (_arrayIntersection[i] == 20 && _arrayIntersection[i + 2] == 0)
                    {
                        return _interval;
                    }

                    if (j % 2 == 0)
                    {
                        _interval.Add($"Синий больше с:" + _arrayIntersection[i] +
                                      " до: " +
                                      _arrayIntersection[i + 2] +
                                      "\n");
                    }
                    else
                    {
                        _interval.Add($"Красный больше с:" + _arrayIntersection[i] +
                                      " до: " +
                                      _arrayIntersection[i + 2] +
                                      "\n");
                    }
                }
            }


            return _interval;
        }

        #endregion
    }
}