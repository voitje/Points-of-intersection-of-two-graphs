using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autofac;
using GeneratingTimeSeries.ViewModel;
using LiveCharts;
using Model;

namespace GeneratingTimeSeries
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }
        public string [] Number = new string[20];

        public MainWindow()
        {
            InitializeComponent();
            //buttonRandom.Click += Button_Click;
            var test = new ModelView();
            test.BuildFunction();
            SeriesCollection = test.SeriesCollection;
            textBlock.Inlines.Add("Точки пересечения графиков: \n");
            textBlock.Inlines.Add("X: 0 | Y: 0 \n");
            for (int i = 0; i < test.Points.Length - 1; i+=2)
            {
                if (test.Points[i] != "0")
                {
                    textBlock.Inlines.Add("X: " + test.Points[i] + " | ");
                    textBlock.Inlines.Add("Y: " + test.Points[i + 1] + "\n");
                }

            }

            for (int i = 0; i < test.Interval.Length; i++)
            {
                if (test.Number[i] == "1")
                {
                    textBlockInterval.Inlines.Add("\nСиний график: \n");
                    textBlockInterval.Inlines.Add(test.Interval[i - 1] + " ; " + test.Interval[i] + " ");
                }
                if (test.Number[i] == "2")
                {
                    textBlockInterval.Inlines.Add("\nКрасный график: \n");
                    textBlockInterval.Inlines.Add(test.Interval[i - 1] + " ; " + test.Interval[i] + " ");
                }
            }
            /*(void Button_Click(object sender, RoutedEventArgs e) //Event which will be triggerd on click of ya button 
            {
                
                textBlock.Text = String.Empty;
                textBlockInterval.Text = String.Empty;
                SeriesCollection.Clear();
                var test1 = new ModelView();
                test1.Clear();
                test1.BuildFunction();
                SeriesCollection = test1.SeriesCollection;
                textBlock.Inlines.Add("Точки пересечения графиков: \n");
                textBlock.Inlines.Add("X: 0 | Y: 0 \n");
                for (int i = 0; i < test1.Points.Length - 1; i += 2)
                {
                    if (test1.Points[i] != "0")
                    {
                        textBlock.Inlines.Add("X: " + test1.Points[i] + " | ");
                        textBlock.Inlines.Add("Y: " + test1.Points[i + 1] + "\n");
                    }

                }

                for (int i = 0; i < test1.Interval.Length; i++)
                {
                    if (test1.Number[i] == "1")
                    {
                        textBlockInterval.Inlines.Add("\nСиний график: \n");
                        textBlockInterval.Inlines.Add(test1.Interval[i - 1] + " ; " + test1.Interval[i] + " ");
                    }
                    if (test1.Number[i] == "2")
                    {
                        textBlockInterval.Inlines.Add("\nКрасный график: \n");
                        textBlockInterval.Inlines.Add(test1.Interval[i - 1] + " ; " + test1.Interval[i] + " ");
                    }
                }
            }*/
            Labels = test.Labels;
            DataContext = this;
        } 
    }
}
