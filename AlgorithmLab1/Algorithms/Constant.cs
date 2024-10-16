using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class Constant : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            int factorial = 1;

            for (int i = 0; i < 100000; i++)
            {
                factorial = factorial * i;
            }
        }
    }
}
