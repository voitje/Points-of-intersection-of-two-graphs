using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Model
{
    public class GenerateChart
    {
        public ChartValues<double> Points { get; set; }
        double[] arraySeries = new double[30];
        double[] array = new double[20];
        double[] arraySeries1 = new double[30];
        double[] array1 = new double[20];
        public List<Tuple<double, double>> pointOfChartFirst = new List<Tuple<double, double>>();
        public List<Tuple<double, double>> pointOfChartSecond = new List<Tuple<double, double>>();
        public int countChart = 0;
        public IntersectionPoints IntersectionPoints;
        public LineSeries GenerateSeries(string axis)
        {
            IntersectionPoints = new IntersectionPoints();
            Random randomSeries = new Random();
            ChartValues<double> series = new ChartValues<double>(new double[20]);
            ChartValues<ObservablePoint> series1 = new ChartValues<ObservablePoint>();
            /*double[] arraySeries = new double[30];
            double[] array = new double[20];*/
            if (axis == "1")
            {
                /*for (int i = 0; i < 5; i++)
                {
                    double randomValue = randomSeries.Next(1, 20);
                    if (!array.Contains(randomValue))
                    {
                        array[i] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    double randomValue = randomSeries.Next(1, 20);
                    if (!arraySeries.Contains(randomValue))
                    {
                        //series.Add(randomValue);
                        int index = Convert.ToInt32(array[i]);
                        arraySeries[index] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }*/

                arraySeries[2] = 2;
                arraySeries[16] = 16;
                for (int i = 0; i < 20; i++)
                {
                    if (arraySeries[i] != 0)
                    {
                        series1.Add(new ObservablePoint(i, arraySeries[i]));
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    pointOfChartFirst.Add(new Tuple<double, double>(series1[i].X, series1[i].Y));
                }

            }
            if (axis == "2")
            {
                series1.Clear();
                /*for (int i = 0; i < 5; i++)
                {
                    double randomValue = randomSeries.Next(1, 20);
                    if (!array1.Contains(randomValue))
                    {
                        array1[i] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    double randomValue = randomSeries.Next(1, 20);
                    if (!arraySeries1.Contains(randomValue))
                    {
                        //series.Add(randomValue);
                        int index = Convert.ToInt32(array1[i]);
                        arraySeries1[index] = randomValue;
                    }
                    else
                    {
                        i--;
                    }
                }*/
                arraySeries1[2] = 16;
                arraySeries1[16] = 2;
                for (int i = 0; i < 20; i++)
                {
                    if (arraySeries1[i] != 0)
                    {
                        series1.Add(new ObservablePoint(i, arraySeries1[i]));
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    pointOfChartSecond.Add(new Tuple<double, double>(series1[i].X, series1[i].Y));
                }

                
                /*for (int i = 0; i < 20; i++)
                {
                    if (arraySeries1[i] != 0)
                    {
                        series1.Add(new ObservablePoint(i, arraySeries1[i]));
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    pointOfChartSecond.Add(new Tuple<double, double>(series1[i].X, series1[i].Y));
                }*/

            }


            Points = series;
            var testSeries = new LineSeries
            {
                Title = "Test",
                Values = series1
            };

            countChart++;
            //IntersectionPoints.pointOfChartFirst = new List<Tuple<double, double>>();
            
            /*if (countChart == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    pointOfChartFirst.Add(new Tuple<double, double>(series1[i].X, series1[i].Y));
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    pointOfChartSecond.Add(new Tuple<double, double>(series1[i].X, series1[i].Y));
                }
            }*/

            
            return testSeries;
        }
    }
}

