using AlgorithmLab1;
using AlgorithmLab1_console_.Algorithms;
using AlgorithmLab1_console_.Algorithms.PowAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*ExchangeSort sort = new ExchangeSort();

            int[] vector = Generator.VectorInput(2000);
            sort.ExecuteAlgorithm(vector);

            Console.WriteLine(String.Join(" ", vector));*/

            /*Pow s = new Pow();

            int x = 2;
            int n = 10;

            s.ExecuteAlgorithm(ref x, n);

            Console.WriteLine(x);*/

            StoogeSort b = new StoogeSort();
            double[] time = Analyzer.Timing(200, 5, b);

            foreach (double t in time)
            {
               Console.WriteLine(t.ToString());
            }
        }
    }
}
