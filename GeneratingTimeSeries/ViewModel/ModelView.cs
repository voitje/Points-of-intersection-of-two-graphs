using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using Model;

namespace GeneratingTimeSeries.ViewModel
{
    public class ModelView
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<double> Points { get; set; }
        public RandomSeries randomSeries;
        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }
        public SeriesCollection SeriesCollectionX { get; set; }
        //public List<Tuple<double,double>> first { get; set; }
        //public List<Tuple<double,double>> second { get; set; }
        public List<Tuple<double, double>> first = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> second = new List<Tuple<double, double>>();
        public GenerateChart GenerateChart = new GenerateChart();
        public IntersectionPoints IntersectionPoints = new IntersectionPoints();
        public string[] asd = new string[20];
        public void BuildFunction()
        {
            //Points.Clear();
            //SeriesCollection.Clear();
            randomSeries = new RandomSeries();
            SeriesCollection = new SeriesCollection();
            Points = new ChartValues<double>();
            SeriesCollection.AddRange(randomSeries.BuidChart());
            //first = GenerateChart.pointOfChartFirst;
            first = randomSeries.pointOfChartFirst;
            //Points.AddRange(randomSeries.Points);
           // SeriesCollection.AddRange(randomSeries.BuidChart());
            //second = GenerateChart.pointOfChartSecond;
            second = randomSeries.pointOfChartSecond;
            int[] array = IntersectionPoints.FindXFinal(first, second);
            for (int i = 0; i < array.Length; i++)
            {
                asd[i] = array[i].ToString();
            }

            //Points.AddRange(randomSeries.Points);
            //Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        }
    }

}
