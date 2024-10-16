using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class QuickPow : PowAlgorithm
    {
        public override int ExecuteAlgorithm(int[] vector)
        {
            int step = 0;
            int result;

            int n = p;
            int power = vector.Length;

            f = power % 2 == 1 ? n : 1;

            do
            {
                step++;
                power /= 2;
                n *= n;
                if (power % 2 == 1)
                {
                    f *= n;
                }

            } while (power != 0);

            result = f;
            return step;
        }
    }
}
