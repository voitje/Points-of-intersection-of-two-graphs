using System.Windows;
using GeneratingTimeSeries.ViewModel;
using LiveCharts;

namespace GeneratingTimeSeries
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        #region Readonly fields

        private readonly ModelView _modelView = new ModelView();

        #endregion

        #endregion

        #region Properties

        public SeriesCollection SeriesCollection { get; set; }

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            CreateProgram();
            DataContext = this;
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Функция передачи данных для отображения данных в программе
        /// </summary>
        private void CreateProgram()
        {
            _modelView.BuildFunction();
            SeriesCollection = _modelView.SeriesCollection;

            _modelView.CreateTextBlock(_modelView, "Точки пересечения", textBlock);
            _modelView.CreateTextBlock(_modelView, "Интервал", textBlockInterval);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            _modelView.Clear();
            textBlock.Text = "";
            textBlockInterval.Text = "";
            SeriesCollection.Clear();
            CreateProgram();
        }

        #endregion
    }
}