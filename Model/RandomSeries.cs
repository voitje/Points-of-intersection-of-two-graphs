using System;
using System.Collections.Generic;
using LiveCharts;

namespace Model
{
    public class RandomSeries
    {
        #region Fields

        #region Ordinary fields

        public List<Tuple<double, double>> PointOfChartFirst =
            new List<Tuple<double, double>>();

        public List<Tuple<double, double>> PointOfChartSecond =
            new List<Tuple<double, double>>();

        #endregion

        #endregion

        #region Properties

        private SeriesCollection Series { get; set; }

        #endregion

        #region Public methods

        public SeriesCollection BuidChart()
        {
            var generateChart = new GenerateChart();
            var firstChart = generateChart.GenerateSeries("1");
            var secondChart = generateChart.GenerateSeries("2");

            PointOfChartFirst = generateChart.PointOfChartFirst;
            PointOfChartSecond = generateChart.PointOfChartSecond;
            Series = new SeriesCollection
            {
                firstChart
            };

            Series.Add(secondChart);
            return Series;
        }

        #endregion
    }
}