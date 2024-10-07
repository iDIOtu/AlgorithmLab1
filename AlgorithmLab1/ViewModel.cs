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
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

/* ------------------------------------------------------------------------------------- /  
                      Это один из худших кодов, что я писал и видел.
                      Не стоит пытаться понять, нужно просто принять.
                      Если что-то не работает, пишите в тележку.
 / ------------------------------------------------------------------------------------- */

namespace AlgorithmLab1
{
    // : INotifyPropertyChanged
    public class ViewModel
    {
        public ObservableCollection<ObservablePoint> _observableValues; // тут лежат точки функции
        public ObservableCollection<ObservablePoint> _approximationValues; // тут лежат точки аппроксимации

        public ObservableCollection<ISeries> Series { get; set; } // это для графика

        public int PowerTextBox { get; set; } // Текстбокс, который управляет степенью степенных алгоритмов
        public int NTextBox { get; set; } // Текстбокс, который устанавливает n
        public int RepeatTextBox { get; set; } // Текстбокс, который устанавливает количество повторений
        public int StartTextBox { get; set; } // Текстбокс, который задает начальный объем данных
        public int StepTextBox { get; set; } // Текстбокс, который задает шаг

        public ViewModel()
        {
            _observableValues = new ObservableCollection<ObservablePoint>
            {
                // Стандартные данные функции. Отображаются при загрузке.
                    new ObservablePoint(0, 4),
                    new ObservablePoint(4, 0),
                    new ObservablePoint(8, 4),
                    new ObservablePoint(12, 0),
            };
            _approximationValues = new ObservableCollection<ObservablePoint>
            {
                // Стандартные аппроксимации. Отображаются при загрузке.
                    new ObservablePoint(0, 0),
                    new ObservablePoint(4, 4),
                    new ObservablePoint(8, 0),
                    new ObservablePoint(12, 4),
            };
            Series = new ObservableCollection<ISeries>
            {
                    new LineSeries<ObservablePoint>
                    {
                        Values = _observableValues,
                        Fill = new SolidColorPaint(SKColors.LightBlue),
                        GeometrySize = 2
                    },
                    new LineSeries<ObservablePoint>
                    {
                        Values = _approximationValues,
                        Stroke = new SolidColorPaint(SKColors.Yellow, 4),
                        Fill = null,
                        GeometryStroke = new SolidColorPaint(SKColors.Yellow, 4),
                        GeometryFill = new SolidColorPaint(SKColors.White, 4),                       
                        GeometrySize = 2,
                        
                    }
            };


            PowerTextBox = 2;
            NTextBox = 200;
            RepeatTextBox = 5;
            StartTextBox = 1;
            StepTextBox = 10; 
        }

        public Axis[] YAxis { get; set; } =
        {
            new Axis
            {
                Name = "Время выполнения, мс",
            }
        };
        public Axis[] XAxis { get; set; } =
{
            new Axis
            {
                Name = "Количество данных, n",
            }
        };


        // Эта функция трансформирует данные из массива в точки на графе, после чего передает их ему.
        // ИСПРАВИТЬ!
        public void UpdateData(double[,] newValues)
        {
            _observableValues.Clear();
            _approximationValues.Clear();

            // Да простит меня Бог Машин за столь ужасный костыль
            for (int i = 0; i < newValues.GetLength(0); i++) 
            {
                _observableValues.Add(new ObservablePoint(newValues[i, 0], newValues[i, 1]));
            }
        }

        public void UpdateData(double[] newValues)
        {
            _observableValues.Clear();
            _approximationValues.Clear();

            for (int i = 0; i < newValues.GetLength(0); i++)
            {
                _observableValues.Add(new ObservablePoint(i, newValues[i]));
            }
        }

        public void UpdateData(double[] newValues, int start, int step)
        {
            _observableValues.Clear();
            _approximationValues.Clear();
 
            for (int i = 0; i < newValues.GetLength(0); i++)
            {
                _observableValues.Add(new ObservablePoint(start, newValues[i]));
                start += step;
            }
        }
        public void UpdateApproximation(double[] newValues, int start, int step)
        {
            _observableValues.Clear();
            _approximationValues.Clear();

            for (int i = 0; i < newValues.GetLength(0); i++)
            {
                _observableValues.Add(new ObservablePoint(start, newValues[i]));
                start += step;
            }
        }



        //  -------------------  Обработчики команд из кнопок  -------------------  //

        // Очищает график. 
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
            _approximationValues.Clear();
        }




        //  -------------------  Обработчики команд из кнопок:   -------------------  //
        //  -------------------        Запуск алгоритмов         -------------------  //

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
            Pow p = new Pow();
            double[] time = Analyzer.Timing(NTextBox, RepeatTextBox, p, PowerTextBox);
            UpdateData(time);
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
            QuickPow p = new QuickPow();
            double[] time = Analyzer.Timing(NTextBox, RepeatTextBox, p, PowerTextBox);
            UpdateData(time);
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
            QuickPow1 p = new QuickPow1();
            double[] time = Analyzer.Timing(NTextBox, RepeatTextBox, p, PowerTextBox);
            UpdateData(time);
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
            RecPow p = new RecPow();
            double[] time = Analyzer.Timing(NTextBox, RepeatTextBox, p, PowerTextBox);
            UpdateData(time);
        }


        // ------------------------------------------------------------------- I  Алгоритмы, не связанные со степенью
        // ------------------------------------------------------------------- I  ~~~~~~~~~~~~~~~~~~~~
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
            StoogeSort b = new StoogeSort();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, b);
            UpdateData(time);
        }



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
            Constant c = new Constant();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, c);
            UpdateData(time);
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
            Sum p = new Sum();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
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
            Multiply p = new Multiply();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
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
            Horner p = new Horner();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
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
            BubbleSort p = new BubbleSort();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
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
            QuickSort p = new QuickSort();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
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
            TimSort p = new TimSort();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
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
            MatrixMultiplication p = new MatrixMultiplication();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
        }


        // ------------------------------------------------------------------- II  RunCycle()
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
            CycleSort p = new CycleSort();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time);
        }

        // ------------------------------------------------------------------- II  RunSoR()
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
            SumOfRows p = new SumOfRows();
            double[] time = Analyzer.Timing(NTextBox, StartTextBox, StepTextBox, RepeatTextBox, p);
            UpdateData(time, StartTextBox, StepTextBox);
            //UpdateApproximation(Analyzer.Approximation(time), StartTextBox, StepTextBox);
        }
    }
}
