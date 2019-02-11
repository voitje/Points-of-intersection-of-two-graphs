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
        public RandomSeries randomSeries;
        public string[] Labels { get; set; }
        public List<Tuple<double, double>> first = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> second = new List<Tuple<double, double>>();
        public IntersectionPoints IntersectionPoints = new IntersectionPoints();
        public string[] Points = new string[20];
        public void BuildFunction()
        {
            randomSeries = new RandomSeries();
            SeriesCollection = new SeriesCollection();

            SeriesCollection.AddRange(randomSeries.BuidChart());

            first = randomSeries.pointOfChartFirst;

            second = randomSeries.pointOfChartSecond;
            double[] array = IntersectionPoints.FindXFinal(first, second);

            for (int i = 0; i < array.Length; i++)
            {
                    Points[i] = array[i].ToString();
            }


        }
    }

}
