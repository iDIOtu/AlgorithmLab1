using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class Pow : Algorithm
    {
        public override void ExecuteAlgorithm(ref int x, int n)
        {
            f = 1;
            k = 0;

            while (k < n)
            {
                f *= x;
                k++;
            }

            x = f;
        }
    }
}
