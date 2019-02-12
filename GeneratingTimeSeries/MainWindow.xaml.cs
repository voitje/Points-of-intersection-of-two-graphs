using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        //public SeriesCollection SeriesCollection = new SeriesCollection();
        public string[] Labels { get; set; }
        public string [] Number = new string[20];

        public ModelView test = new ModelView();

        public MainWindow()
        {
            InitializeComponent();
            CreateProgram();
            Labels = test.Labels;
            DataContext = this;
        }
        void CreateProgram()
        {
            buttonRandom.Click += ButtonClick;
            test.BuildFunction();
            SeriesCollection = test.SeriesCollection;

            test.CreateTextBlock(test, "Точки пересечения", textBlock);
            test.CreateTextBlock(test, "Интервал", textBlockInterval);

        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            test.Clear(this);
            textBlock.Text = "";
            textBlockInterval.Text = "";
            textBlock.Inlines.Clear();
            textBlockInterval.Inlines.Clear();
            SeriesCollection.Clear();
            CreateProgram();
        }
    }
}
