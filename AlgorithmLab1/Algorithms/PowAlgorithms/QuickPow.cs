using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class QuickPow : PowAlgorithm
    {
        public override int ExecuteAlgorithm(int[] vector, int power)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                c = vector[i];
                k = power;

                f = k % 2 == 1 ? c : 1;

                do
                {
                    k /= 2;
                    c *= c;

                    if (k % 2 == 1)
                    {
                        f *= c;
                    }

                } while (k != 0);

                vector[i] = f;
            }
            return 0;
        }
    }
}
