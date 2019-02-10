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
        public ChartValues<double> Points { get; set; }
        public RandomSeries var;
        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }
        public Func<double> XFormatter { get; set; }
        public string text { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var test = new ModelView();
            test.BuildFunction();
            SeriesCollection = test.SeriesCollection;
            Points = test.Points;
            //text = test.asd;
            text = "asd";
            //listView.Items.Insert(0, 0);
            //textBlock.Text = test.asd;
            for (int i = 0; i < test.asd.Length - 1; i++)
            {
                textBlock.Inlines.Add("X: " + test.asd[i] + " | ");
                textBlock.Inlines.Add("Y: " + test.asd[i + 1]  + "\n");

            }
            //XFormatter = val => 0.1;
            //YFormatter = test.YFormatter;
            Labels = test.Labels;
            DataContext = this;
        }
       
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }   
    }
}
