using System;
using System.Collections.Generic;
using System.Linq;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Model
{
    public class GenerateChart
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        /// Рандомные точки по X
        /// </summary>
        private readonly double[] _randomPointsX = new double[20];

        /// <summary>
        /// Рандомные точки по Y
        /// </summary>
        private readonly double[] _randomPointsY = new double[5];

        /// <summary>
        /// Набор точек первого для первого графика
        /// </summary>
        public readonly List<Tuple<double, double>> PointOfChartFirst =
            new List<Tuple<double, double>>();

        /// <summary>
        /// Набор точек для второго графика
        /// </summary>
        public readonly List<Tuple<double, double>> PointOfChartSecond =
            new List<Tuple<double, double>>();

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        /// Функция для создания рандомных точек для графиков
        /// </summary>
        /// <param name="numberOfChart">Номер графика</param>
        /// <returns></returns>
        public LineSeries GenerateSeries(string numberOfChart)
        {
            //IntersectionPoints = new IntersectionPoints();
            var randomSeries = new Random();

            var chartValues = new ChartValues<ObservablePoint>();

            if (numberOfChart == "1")
            {
                for (var i = 0; i < 5; i++)
                {
                    var randomValue = Convert.ToDouble(randomSeries.Next(200)) / 10;
                    if (!_randomPointsX.Contains(randomValue))
                    {
                        _randomPointsX[i] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }

                for (var i = 0; i < 5; i++)
                {
                    var randomValue = Convert.ToDouble(randomSeries.Next(200)) / 10;
                    if (!_randomPointsY.Contains(randomValue))
                    {
                        _randomPointsY[i] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }

                Array.Sort(_randomPointsY);

                chartValues.Add(new ObservablePoint(0, 0));
                for (var i = 0; i < 5; i++)
                {
                    chartValues.Add(new ObservablePoint(_randomPointsY[i],
                        _randomPointsX[i]));
                }

                chartValues.Add(new ObservablePoint(20, 20));
                for (var i = 0; i < 7; i++)
                {
                    PointOfChartFirst.Add(
                        new Tuple<double, double>(chartValues[i].X, chartValues[i].Y));
                }
            }

            if (numberOfChart == "2")
            {
                chartValues.Clear();

                for (var i = 0; i < 5; i++)
                {
                    var randomValue = Convert.ToDouble(randomSeries.Next(200)) / 10;
                    if (!_randomPointsX.Contains(randomValue))
                    {
                        _randomPointsX[i] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }

                for (var i = 0; i < 5; i++)
                {
                    var randomValue = Convert.ToDouble(randomSeries.Next(200)) / 10;

                    _randomPointsY[i] = randomValue;
                }

                Array.Sort(_randomPointsY);
                chartValues.Add(new ObservablePoint(0, 0));
                for (var i = 0; i < 5; i++)
                {
                    chartValues.Add(new ObservablePoint(_randomPointsY[i],
                        _randomPointsX[i]));
                }

                chartValues.Add(new ObservablePoint(20, 20));
                for (var i = 0; i < 7; i++)
                {
                    PointOfChartSecond.Add(
                        new Tuple<double, double>(chartValues[i].X, chartValues[i].Y));
                }
            }


            var testSeries = new LineSeries
            {
                Values = chartValues
            };

            return testSeries;
        }

        #endregion
    }
}