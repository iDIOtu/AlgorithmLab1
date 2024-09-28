using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
// using LiveCharts;
// using LiveCharts.Defaults;
using System;
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
using LiveCharts.Wpf;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection.Emit;
using System.ComponentModel;
using LiveCharts.Configurations;


namespace AlgorithmLab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(GetInput.VectorInput(100));
        }


        private void Run_btn_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = "Click!";
        }
    }

// : INotifyPropertyChanged
    public class ViewModel 
    {
        public  ObservableCollection<ObservablePoint> _observableValues;

        public ViewModel() 
        {
            _observableValues = new ObservableCollection<ObservablePoint>
            {
                    new ObservablePoint(0, 4),
                    new ObservablePoint(4, 0),
                    new ObservablePoint(8, 4),
                    new ObservablePoint(12, 0),
                    new ObservablePoint(16, 4),
                    new ObservablePoint(20, 0),
            };
            Series = new ObservableCollection<ISeries>
            {
                    new LineSeries<ObservablePoint>
                    {
                        Values = _observableValues,
                        Fill = null
                    }
            };
        }

        public ObservableCollection<ISeries> Series { get; set; }


        private RelayCommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddItem);
                }

                return addCommand;
            }
        }

        private void AddItem()
        {
            _observableValues.Add(new ObservablePoint(5, 5));
        }



        private RelayCommand uITestCommand;
        public ICommand UITestCommand
        {
            get
            {
                if (uITestCommand == null)
                {
                    uITestCommand = new RelayCommand(UITest);
                }

                return uITestCommand;
            }
        }

        private void UITest()
        {
            _observableValues.Clear();
            ObservableCollection<ObservablePoint> newValues = new ObservableCollection<ObservablePoint>
            {
                    new ObservablePoint(0, 4),
                    new ObservablePoint(1, 3),
                    new ObservablePoint(3, 8),
                    new ObservablePoint(18, 6),
                    new ObservablePoint(20, 12)
            };

            // Да простит меня Бог Машин за столь ужасный костыль
            foreach (var value in newValues)
            {
                _observableValues.Add(value);
            }
        }





        private RelayCommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear);
                }

                return clearCommand;
            }
        }

        private void Clear()
        {
            _observableValues.Clear();
        }





    }

}

//public SeriesCollection SeriesCollection { get; set; }
//public string[] Labels { get; set; }
//public Func<double, string> YFormatter { get; set; }
//SeriesCollection = new SeriesCollection
//{
//    new LineSeries
//    {
//        Values = new ChartValues<ObservablePoint>
//        {
//            new ObservablePoint(0, 4),
//            new ObservablePoint(1, 3),
//            new ObservablePoint(3, 8),
//            new ObservablePoint(18, 6),
//            new ObservablePoint(20, 12)
//        }
//    }
//};
//YFormatter = value => value.ToString("C");
//DataContext = this;




//public class ViewModel : ObservableObject
//{
//    public ISeries[] SeriesCollection { get; set; } =
//    {
//            new LineSeries<ObservablePoint>
//            {
//                Values = new ObservablePoint[]
//                {
//                    new ObservablePoint(0, 4),
//                    new ObservablePoint(1, 3),
//                    new ObservablePoint(3, 8),
//                    new ObservablePoint(18, 6),
//                    new ObservablePoint(20, 12)
//                }
//            }
//        };

//}




//#region INotifyPropertyChangedImplementation

//public event PropertyChangedEventHandler PropertyChanged;

//protected virtual void OnPropertyChanged(string propertyName = null)
//{
//    //Raise PropertyChanged event
//    if (PropertyChanged != null)
//        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
//}

//#endregion