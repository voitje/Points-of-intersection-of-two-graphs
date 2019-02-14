using System;
using System.Collections.Generic;
using System.Windows.Controls;
using LiveCharts;
using Model;

namespace GeneratingTimeSeries.ViewModel
{
    public class ModelView
    {
        #region Fields

        #region Readonly fields

        private readonly IntersectionPoints
            _intersectionPoints = new IntersectionPoints();

        /// <summary>
        ///     Интвервал графиков
        /// </summary>
        private readonly double[] _interval = new double[20];

        /// <summary>
        ///     Точки пересечения
        /// </summary>
        private readonly string[] _points = new string[20];

        /// <summary>
        ///     Строки для TextBlock
        /// </summary>
        private readonly string[] _stringTextBlocks = new string[20];

        public readonly SeriesCollection SeriesCollection = new SeriesCollection();

        #endregion

        #region Private fields

        private List<Tuple<double, double>> _first = new List<Tuple<double, double>>();

        private double[] _pointsOfIntersection = new double[20];
        private RandomSeries _randomSeries;
        private List<Tuple<double, double>> _second = new List<Tuple<double, double>>();

        private List<string> _textBlocks = new List<string>();

        #endregion

        #endregion

        #region Properties

        public string[] Labels { get; set; }

        #endregion

        #region Public methods

        public void BuildFunction()
        {
            _randomSeries = new RandomSeries();

            SeriesCollection.AddRange(_randomSeries.BuidChart());

            _first = _randomSeries.PointOfChartFirst;
            _second = _randomSeries.PointOfChartSecond;

            _pointsOfIntersection = _intersectionPoints.FindXFinal(_first, _second);

            _textBlocks = _intersectionPoints.GetStringInterval(_first, _second);

            for (var i = 0; i < _pointsOfIntersection.Length; i++)
            {
                _points[i] = _pointsOfIntersection[i].ToString();
            }

            for (var i = 0; i < _pointsOfIntersection.Length; i++)
            {
                _stringTextBlocks[i] = _interval[i].ToString();
            }
        }

        public void CreateTextBlock(ModelView modelView, string textBlockName,
            TextBlock textBlock)
        {
            if (textBlockName == "Интервал")
            {
                for (var i = 0; i < _textBlocks.Count; i++)
                {
                    textBlock.Inlines.Add(_textBlocks[i]);
                }
            }
            else
            {
                textBlock.Inlines.Add("Точки пересечения графиков: \n");
                textBlock.Inlines.Add("X: 0 | Y: 0 \n");
                for (var i = 0; i < modelView._points.Length - 1; i += 2)
                {
                    if (modelView._points[i] != "0")
                    {
                        textBlock.Inlines.Add("X: " + modelView._points[i] + " | ");
                        textBlock.Inlines.Add("Y: " + modelView._points[i + 1] + "\n");
                    }
                }
            }
        }


        public void Clear()
        {
            _first.Clear();
            _second.Clear();
            Array.Clear(_pointsOfIntersection, 0, _pointsOfIntersection.Length);
            Array.Clear(_interval, 0, _interval.Length);
            SeriesCollection.Clear();
            _textBlocks.Clear();
            Array.Clear(_points, 0, _points.Length);
        }

        #endregion
    }
}