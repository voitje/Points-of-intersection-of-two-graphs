using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;


namespace Model
{
    public class RandomSeries
    {
        public SeriesCollection Series { get; private set; }

        public SeriesCollection SeriesX { get; private set; }
        public List<Tuple<double, double>> pointOfChartFirst = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> pointOfChartSecond = new List<Tuple<double, double>>();

        public ChartValues<double> Points { get; private set; }
        double[] arraySeries = new double[30];
        double[] array = new double[20];
        public SeriesCollection BuidChart()
        {
            Random randomSeries = new Random();
            var generateChart = new GenerateChart();
            var asd = generateChart.GenerateSeries("1");
            var asd2 = generateChart.GenerateSeries("2");
            
            pointOfChartFirst = generateChart.pointOfChartFirst;
            pointOfChartSecond = generateChart.pointOfChartSecond;
            Series = new SeriesCollection 
            {
                asd
            };
            Series.Add(asd2);
            Points = generateChart.Points;
            return Series;
        }

    }
}
