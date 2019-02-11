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

        public MainWindow()
        {
            InitializeComponent();
            var test = new ModelView();
            test.BuildFunction();
            SeriesCollection = test.SeriesCollection;

            for (int i = 0; i < test.Points.Length - 1; i+=2)
            {
                textBlock.Inlines.Add("X: " + test.Points[i] + " | ");
                textBlock.Inlines.Add("Y: " + test.Points[i + 1]  + "\n");

            }
            Labels = test.Labels;
            DataContext = this;
        } 
    }
}
