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
        //public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection = new SeriesCollection();
        public RandomSeries randomSeries;
        public string[] Labels { get; set; }
        public List<Tuple<double, double>> first = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> second = new List<Tuple<double, double>>();
        public IntersectionPoints IntersectionPoints = new IntersectionPoints();
        public string[] Points = new string[20];
        public string[] Interval = new string[20];
        public string[] Number = new string[20];
        public void BuildFunction()
        {
            randomSeries = new RandomSeries();
            //SeriesCollection = new SeriesCollection();

            SeriesCollection.AddRange(randomSeries.BuidChart());

            first = randomSeries.pointOfChartFirst;

            second = randomSeries.pointOfChartSecond;
            double[] array = IntersectionPoints.FindXFinal(first, second);
            double[] interval = IntersectionPoints.GetInterval(first, second);

            for (int i = 0; i < array.Length; i++)
            {
                Points[i] = array[i].ToString();
            }

            Number = IntersectionPoints.intervals;
            for (int i = 0; i < array.Length; i++)
            {
                Interval[i] = interval[i].ToString();
            }
        }

        public void CreateTextBlock(ModelView test, string textBlockName, TextBlock textBlock)
        {
            if (textBlockName == "Интервал")
            {
                for (int i = 0; i < test.Interval.Length; i++)
                {
                    if (test.Number[i] == "1")
                    {
                        textBlock.Inlines.Add("\nСиний график: \n");
                        textBlock.Inlines.Add(
                            test.Interval[i - 1] + " ; " + test.Interval[i] + " ");
                    }

                    if (test.Number[i] == "2")
                    {
                        textBlock.Inlines.Add("\nКрасный график: \n");
                        textBlock.Inlines.Add(
                            test.Interval[i - 1] + " ; " + test.Interval[i] + " ");
                    }
                }
            }
            else
            {
                textBlock.Inlines.Add("Точки пересечения графиков: \n");
                textBlock.Inlines.Add("X: 0 | Y: 0 \n");
                for (int i = 0; i < test.Points.Length - 1; i += 2)
                {
                    if (test.Points[i] != "0")
                    {
                        textBlock.Inlines.Add("X: " + test.Points[i] + " | ");
                        textBlock.Inlines.Add("Y: " + test.Points[i + 1] + "\n");
                    }

                }
            }
        }


        public void Clear(MainWindow mainWindow)
        {
            first.Clear(); 
            second.Clear();
            SeriesCollection.Clear();
            Array.Clear(Points, 0, Points.Length);
            //Array.Clear(Points, 0, Points.Length);
            Array.Clear(Interval, 0, Interval.Length);
            mainWindow.textBlock.Text = String.Empty;
            mainWindow.textBlockInterval.Text = String.Empty;
            mainWindow.textBlock.Inlines.Clear();
            mainWindow.textBlockInterval.Inlines.Clear();

        }

    }

}
