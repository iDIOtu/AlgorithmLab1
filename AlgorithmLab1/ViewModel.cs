using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

using AlgorithmLab1_console_;
using AlgorithmLab1_console_.Algorithms;
using System;
using System.Collections.Generic;
using AlgorithmLab1_console_.Algorithms.PowAlgorithms;
using System.Windows.Data;
using System.Windows.Controls;

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
        public ObservableCollection<ObservablePoint> _observableValues; // тут лежат точки
        public ObservableCollection<ISeries> Series { get; set; } // это для графика

        public int PowerTextBox { get; set; } // Текстбокс, который управляет степенью степенных алгоритмов
        public int NTextBox { get; set; } // Текстбокс, который устанавливает n
        public int repeatTextBox { get; set; } // Текстбокс, который устанавливает количество повторений

        public string ConsoleTextBox { get; set; } // Текстбокс, который выполняет роль консоли

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
            PowerTextBox = 2;
            NTextBox = 200;
            repeatTextBox = 5;
            ConsoleTextBox = "";
        }

        // Эта функция трансформирует данные из массива в точки на графе, после чего передает их ему.
        // ИСПРАВИТЬ!
        public void UpdateData(double[,] newValues)
        {
            _observableValues.Clear();

            // Да простит меня Бог Машин за столь ужасный костыль
            for (int i = 0; i < newValues.GetLength(0); i++) 
            {
                _observableValues.Add(new ObservablePoint(newValues[i, 0], newValues[i, 1]));
            }
        }

        public void UpdateData(double[] newValues)
        {
            _observableValues.Clear();

            for (int i = 0; i < newValues.GetLength(0); i++)
            {
                _observableValues.Add(new ObservablePoint(i, newValues[i]));
            }
        }



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

        // Очищает график. Текст в текстбокс вставляется в MainWindow.xaml.cs
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
            ConsoleTextBox = "График очищен.";
        }




        //  -------------------  Обработчики команд из кнопок:   -------------------  //
        //  -------------------        Запуск алгоритмов         -------------------  //


        private RelayCommand run3Command;
        // Шаблон кнопки.
        // В функцию Run2() вставить вызов нужной функции, которая вернет double[,]
        // В конце передать double[,] в функцию UpdateData(double[,]);
        public ICommand Run3Command
        {
            get
            {
                if (run3Command == null)
                {
                    run3Command = new RelayCommand(Run2);
                }

                return run3Command;
            }
        }



        private void Run3()
        {
            //UpdateData(newValues);
        }

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
            ConsoleTextBox = "Я не завис. \n Думаю.";
            double[,] newValues = new double[50000, 2];

            for (int i = 0; i < 50000; i++)
            {
                newValues[i, 0] = i;
                newValues[i, 1] = i;
            }

            UpdateData(newValues);
            ConsoleTextBox = "Run1 выполнен.";
        }

        // ------------------------------------------------------------------- I  StoogeSort()
        private RelayCommand run2Command;
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
            ConsoleTextBox = "Я не завис. \n Думаю.";
            StoogeSort b = new StoogeSort();
            double[] time = Analyzer.Timing(NTextBox, 5, b);
            UpdateData(time);
            ConsoleTextBox = "StoogeSort выполнен и измерен.";
        }

        // ------------------------------------------------------------------- I  RunPow()
        private RelayCommand runPowCommand;
        public ICommand RunPowCommand
        {
            get
            {
                if (runPowCommand == null)
                {
                    runPowCommand = new RelayCommand(RunPow);
                }

                return runPowCommand;
            }
        }

        private void RunPow()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            Pow p = new Pow();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p, PowerTextBox);
            UpdateData(time);
            ConsoleTextBox = "Алгоритм возведения в степень выполнен и измерен.";
        }


        // ------------------------------------------------------------------- I  RunQuickPow
        private RelayCommand runQuickPowCommand;
        public ICommand RunQuickPowCommand
        {
            get
            {
                if (runQuickPowCommand == null)
                {
                    runQuickPowCommand = new RelayCommand(RunQuickPow);
                }

                return runQuickPowCommand;
            }
        }

        private void RunQuickPow()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            QuickPow p = new QuickPow();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p, PowerTextBox);
            UpdateData(time);
            ConsoleTextBox = "Алгоритм быстрого возведения в степень выполнен и измерен.";
        }

        // ------------------------------------------------------------------- I  RunQuick1Pow
        private RelayCommand runQuickPow1Command;

        public ICommand RunQuickPow1Command
        {
            get
            {
                if (runQuickPow1Command == null)
                {
                    runQuickPow1Command = new RelayCommand(RunQuickPow1);
                }

                return runQuickPow1Command;
            }
        }

        private void RunQuickPow1()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            QuickPow1 p = new QuickPow1();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p, PowerTextBox);
            UpdateData(time);
            ConsoleTextBox = "Алгоритм быстрого возведения в степень выполнен и измерен.";
        }

        // ------------------------------------------------------------------- I  RunRecPow
        private RelayCommand runRecPowCommand;

        public ICommand RunRecPowCommand
        {
            get
            {
                if (runRecPowCommand == null)
                {
                    runRecPowCommand = new RelayCommand(RunRecPow);
                }

                return runRecPowCommand;
            }
        }

        private void RunRecPow()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            RecPow p = new RecPow();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p, PowerTextBox);
            UpdateData(time);
            ConsoleTextBox = "Алгоритм возведения в степень выполнен и измерен.";
        }


        // ------------------------------------------------------------------- I  Алгоритмы, не связанные со степенью
        // ------------------------------------------------------------------- I  ~~~~~~~~~~~~~~~~~~~~
        // ------------------------------------------------------------------- I  RunConstant()
        private RelayCommand runConstantCommand;

        public ICommand RunConstantCommand
        {
            get
            {
                if (runConstantCommand == null)
                {
                    runConstantCommand = new RelayCommand(RunConstant);
                }

                return runConstantCommand;
            }
        }
        private void RunConstant()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            Constant c = new Constant();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, c);
            UpdateData(time);
            ConsoleTextBox = "Постоянство - признак константы.";
        }


        // ------------------------------------------------------------------- I  RunSum()
        private RelayCommand runSumCommand;

        public ICommand RunSumCommand
        {
            get
            {
                if (runSumCommand == null)
                {
                    runSumCommand = new RelayCommand(RunSum);
                }

                return runSumCommand;
            }
        }

        private void RunSum()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            Sum p = new Sum();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Сумма элементов";
        }

        // ------------------------------------------------------------------- I  RunMul()
        private RelayCommand runMulCommand;

        public ICommand RunMulCommand
        {
            get
            {
                if (runMulCommand == null)
                {
                    runMulCommand = new RelayCommand(RunMul);
                }

                return runMulCommand;
            }
        }

        private void RunMul()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            Multiply p = new Multiply();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Произведение элементов";
        }


        // ------------------------------------------------------------------- I  RunHorner()
        private RelayCommand runHornerCommand;

        public ICommand RunHornerCommand
        {
            get
            {
                if (runHornerCommand == null)
                {
                    runHornerCommand = new RelayCommand(RunHorner);
                }

                return runHornerCommand;
            }
        }

        private void RunHorner()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            Horner p = new Horner();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Горнер.";
        }


        // ------------------------------------------------------------------- I  RunBubble()
        private RelayCommand runBubbleCommand;

        public ICommand RunBubbleCommand
        {
            get
            {
                if (runBubbleCommand == null)
                {
                    runBubbleCommand = new RelayCommand(RunBubble);
                }

                return runBubbleCommand;
            }
        }

        private void RunBubble()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            BubbleSort p = new BubbleSort();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Пузырьком";
        }



        // ------------------------------------------------------------------- I  RunQuickSort()
        private RelayCommand runQuickCommand;

        public ICommand RunQuickCommand
        {
            get
            {
                if (runQuickCommand == null)
                {
                    runQuickCommand = new RelayCommand(RunQuickSort);
                }

                return runQuickCommand;
            }
        }

        private void RunQuickSort()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            QuickSort p = new QuickSort();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Быстрая сортировка";
        }


        // ------------------------------------------------------------------- I  RunTimSort()
        private RelayCommand runTimCommand;

        public ICommand RunTimCommand
        {
            get
            {
                if (runTimCommand == null)
                {
                    runTimCommand = new RelayCommand(RunTimSort);
                }

                return runTimCommand;
            }
        }

        private void RunTimSort()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            TimSort p = new TimSort();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Гибридный алгоритм сортировки";
        }




        // ------------------------------------------------------------------- II  RunMatrixMul()
        private RelayCommand runMatrixMulCommand;

        public ICommand RunMatrixMulCommand
        {
            get
            {
                if (runMatrixMulCommand == null)
                {
                    runMatrixMulCommand = new RelayCommand(RunMatrixMul);
                }

                return runMatrixMulCommand;
            }
        }

        private void RunMatrixMul()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            MatrixMultiplication p = new MatrixMultiplication();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Умножение матриц";
        }

        private RelayCommand runCycleCommand;

        public ICommand RunCycleCommand
        {
            get
            {
                if (runCycleCommand == null)
                {
                    runCycleCommand = new RelayCommand(RunCycle);
                }

                return runCycleCommand;
            }
        }

        private void RunCycle()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            CycleSort p = new CycleSort();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "";
        }

        private RelayCommand runSoRCommand;

        public ICommand RunSoRCommand
        {
            get
            {
                if (runSoRCommand == null)
                {
                    runSoRCommand = new RelayCommand(RunSoR);
                }

                return runSoRCommand;
            }
        }

        private void RunSoR()
        {
            ConsoleTextBox = "Я не завис. \n Думаю.";
            SumOfRows p = new SumOfRows();
            double[] time = Analyzer.Timing(NTextBox, repeatTextBox, p);
            UpdateData(time);
            ConsoleTextBox = "Сумма всех элементов строк двухмерного массива";
        }
    }
}
