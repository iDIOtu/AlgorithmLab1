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
                        k /= 2;
                    }
                    else
                    {
                        f *= c;
                        k--;
                    }
                }

                vector[i] = f;
            }
            return 0;
        }
    }
}
