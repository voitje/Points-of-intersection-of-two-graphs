using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using Model;

namespace GeneratingTimeSeries.ViewModel
{
    public class ModelView
    {
        public SeriesCollection SeriesCollection = new SeriesCollection();
        public RandomSeries randomSeries;
        public string[] Labels { get; set; }
        public List<Tuple<double, double>> first = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> second = new List<Tuple<double, double>>();
        public IntersectionPoints IntersectionPoints = new IntersectionPoints();
        private readonly string[] Points = new string[20];
        private readonly string[] Interval = new string[20];
        private string[] Number = new string[20];
        private double[] arrayXY = new double[20];
        private double[] interval = new double[20];
        public void BuildFunction()
        {
            randomSeries = new RandomSeries();

            SeriesCollection.AddRange(randomSeries.BuidChart());

            first = randomSeries.pointOfChartFirst;
            second = randomSeries.pointOfChartSecond;

            arrayXY = IntersectionPoints.FindXFinal(first, second);
            interval = IntersectionPoints.GetInterval(first, second);

            for (int i = 0; i < arrayXY.Length; i++)
            {
                Points[i] = arrayXY[i].ToString();
            }

            Number = IntersectionPoints.intervals;
            for (int i = 0; i < arrayXY.Length; i++)
            {
                Interval[i] = interval[i].ToString();
            }
        }

        public void CreateTextBlock(ModelView modelView, string textBlockName, TextBlock textBlock)
        {
            if (textBlockName == "Интервал")
            {
                for (int i = 0; i < modelView.Interval.Length; i++)
                {
                    if (modelView.Number[i] == "1")
                    {
                        textBlock.Inlines.Add("\nСиний график: \n");
                        textBlock.Inlines.Add(
                            modelView.Interval[i - 1] + " ; " + modelView.Interval[i] + " ");
                    }

                    if (modelView.Number[i] == "2")
                    {
                        textBlock.Inlines.Add("\nКрасный график: \n");
                        textBlock.Inlines.Add(
                            modelView.Interval[i - 1] + " ; " + modelView.Interval[i] + " ");
                    }
                }
            }
            else
            {
                textBlock.Inlines.Add("Точки пересечения графиков: \n");
                textBlock.Inlines.Add("X: 0 | Y: 0 \n");
                for (int i = 0; i < modelView.Points.Length - 1; i += 2)
                {
                    if (modelView.Points[i] != "0")
                    {
                        textBlock.Inlines.Add("X: " + modelView.Points[i] + " | ");
                        textBlock.Inlines.Add("Y: " + modelView.Points[i + 1] + "\n");
                    }
                }
            }
        }


        public void Clear(MainWindow mainWindow)
        {
            first.Clear(); 
            second.Clear();
            Array.Clear(arrayXY, 0, arrayXY.Length);
            Array.Clear(interval, 0, interval.Length);
            SeriesCollection.Clear();
            Array.Clear(Points, 0, Points.Length);
            Array.Clear(Interval, 0, Interval.Length);
            Array.Clear(Number, 0, Number.Length);
        }

    }

}
