using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class QuickPow1 : PowAlgorithm
    {
        public override int ExecuteAlgorithm(int[] vector, int power)
        {
            int step = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                c = vector[i];
                f = 1;
                k = power;

                while (k != 0)
                {
                    if (k % 2 == 0)
                    {
                        c *= c;
                        step++;
                        k /= 2;
                        step++;
                    }
                    else
                    {
                        f *= c;
                        step++;
                        k--;
                        step++;
                    }
                }

                vector[i] = f;
            }
            return step;
        }
    }
}
