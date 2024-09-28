using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class QuickPow : Algorithm
    {
        public override void ExecuteAlgorithm(ref int x, int n)
        {
            c = x;
            k = n;

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

            x = f;
        }
    }
}
