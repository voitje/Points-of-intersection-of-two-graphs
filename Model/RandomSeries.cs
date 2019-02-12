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

        public List<Tuple<double, double>> pointOfChartFirst = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> pointOfChartSecond = new List<Tuple<double, double>>();

        public SeriesCollection BuidChart()
        {
   
            var generateChart = new GenerateChart();
            var firstChart = generateChart.GenerateSeries("1");
            var secondChart = generateChart.GenerateSeries("2");
            
            pointOfChartFirst = generateChart.pointOfChartFirst;
            pointOfChartSecond = generateChart.pointOfChartSecond;
            Series = new SeriesCollection 
            {
                firstChart
            };
            Series.Add(secondChart);
            return Series;
        }

    }
}
