using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class QuickPow1 : PowAlgorithm
    {
        public override int ExecuteAlgorithm(int[] vector, int p)
        {
            int step = 0;
            double result = 1;
            int n = p; // Основание степени
            int power = vector.Length;

            while (power != 0)
            {
                step++;

                if (power % 2 == 0)
                {
                    n *= n;
                    power /= 2;
                }
                else 
                {
                    result *= n;
                    power--;
                }
            }
            return step;
        }
    }
}
