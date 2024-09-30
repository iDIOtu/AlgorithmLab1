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
        }

        // Ищешь граф? Он в файле ViewModel. Тут его нет, уходи.
        private void Run_btn1_Click(object sender, RoutedEventArgs e)
        {
            txtBox1.Text = "Wait a minute... Test is running.";
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            txtBox1.Text = "The graph is cleared.";
        }
    }
}