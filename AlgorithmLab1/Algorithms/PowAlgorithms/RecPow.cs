using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class RecPow : PowAlgorithm
    {
        int step = 0;
        public override int ExecuteAlgorithm(int[] vector, int n)
        {
            int power = vector.Length;

            k = Pow(n, power);

            return step;
        }
        private int Pow(int x, int n)
        {
            step++;
            f = 0;
            if (n == 0)
            {
                f = 1;
            }
            else
            {
                f = Pow(x, n / 2);
                f = n % 2 == 1 ? f * f * x : f * f;
            }

            return f;
        }
    }
}
