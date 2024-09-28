using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
// using LiveCharts;
// using LiveCharts.Defaults;
using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;


/* ------------------------------------------------------------------------------------- /  
                      Это один из худших кодов, что я писал и видел.
                      Не стоит пытаться понять, нужно просто принять.
                      Если что-то не работает, пишите в тележку.
 / ------------------------------------------------------------------------------------- */


/* ------------------------------------------------------------------------------------- /  
                 ТУДУ: в метод Run1 на строке 170 вставить вызов алгоритма №1. 
                   Он должен вернуть то, что сейчас находится в этом методе.
/ ------------------------------------------------------------------------------------- */

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

        public void UpdateData(ObservableCollection<ObservablePoint> newValues)
        {
            _observableValues.Clear();
            

            // Да простит меня Бог Машин за столь ужасный костыль
            foreach (var value in newValues)
            {
                _observableValues.Add(value);
            }
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

        private RelayCommand run1Command;

        public ICommand Run1Command
        {
            get
            {
                if (run1Command == null)
                {
                    run1Command = new RelayCommand(Run1);
                }

                return run1Command;
            }
        }

        private void Run1()
        {
            ObservableCollection<ObservablePoint> newValues = new ObservableCollection<ObservablePoint>
            {
                    new ObservablePoint(0, 4),
                    new ObservablePoint(1, 3),
                    new ObservablePoint(3, 8),
                    new ObservablePoint(18, 6),
                    new ObservablePoint(20, 12)
            };

            UpdateData(newValues);
        }
    }
}