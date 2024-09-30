using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;


/* ------------------------------------------------------------------------------------- /  
                      Это один из худших кодов, что я писал и видел.
                      Не стоит пытаться понять, нужно просто принять.
                      Если что-то не работает, пишите в тележку.
 / ------------------------------------------------------------------------------------- */


/* ------------------------------------------------------------------------------------- /  
                 ТУДУ: в метод Run1 на строке *** вставить вызов алгоритма №1. 
                   Он должен вернуть то, что сейчас находится в этом методе.
/ ------------------------------------------------------------------------------------- */


namespace AlgorithmLab1
{
    // : INotifyPropertyChanged
    public class ViewModel
    {
        public ObservableCollection<ObservablePoint> _observableValues;

        public ViewModel()
        {
            _observableValues = new ObservableCollection<ObservablePoint>
            {
                // Стандартные данные. Отображаются при загрузке.
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

        // Эта функция трансформирует данные из массива в точки на графе, после чего передает их ему.
        // ИСПРАВИТЬ!
        public void UpdateData(int[,] newValues)
        {
            _observableValues.Clear();

            // Да простит меня Бог Машин за столь ужасный костыль
            for (int i = 0; i < newValues.GetLength(0); i++) 
            {
                _observableValues.Add(new ObservablePoint(newValues[i, 0], newValues[i, 1]));
            }
        }

        public ObservableCollection<ISeries> Series { get; set; }

        //  -------------------  Обработчики команд из кнопок  -------------------  //
        private RelayCommand addCommand;
        // Команда для тестов, удалить к релизу
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


        // Команда для тестов, удалить к релизу. Генерирует простой график. Можно и оставить, в общем-то
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

        // Очищает граф. Текст в текстбокс вставляется в MainWindow.xaml.cs
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




        //  -------------------  Обработчики команд из кнопок:   -------------------  //
        //  -------------------        Запуск алгоритмов         -------------------  //


        private RelayCommand run1Command;
        // Кнопка Run TEST.
        // В функцию Run1() вставить вызов нужной функции, которая вернет int[,]
        // В конце передать int[,] в функцию UpdateData(int[,]);
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
            int[,] newValues = new int[10000, 2];

            for (int i = 0; i < 10000; i++)
            {
                newValues[i, 0] = i;
                newValues[i, 1] = i;
            }

            UpdateData(newValues);
        }

        private RelayCommand run2Command;
        // Шаблон кнопки.
        // В функцию Run2() вставить вызов нужной функции, которая вернет int[,]
        // В конце передать int[,] в функцию UpdateData(int[,]);
        public ICommand Run2Command
        {
            get
            {
                if (run2Command == null)
                {
                    run2Command = new RelayCommand(Run2);
                }

                return run2Command;
            }
        }
        private void Run2()
        {
            //UpdateData(newValues);
        }
    }
}
