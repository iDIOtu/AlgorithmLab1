using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class QuickPow1 : Algorithm
    {
        public override void ExecuteAlgorithm(ref int x, int n)
        {
            c = x;
            f = 1;
            k = n;

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

            x = f;
        }

    }
}
