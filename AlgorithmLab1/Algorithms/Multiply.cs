using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class Multiply : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            long multiplier = 1;

            for (int i = 0; i < vector.Length; i++)
            {
                multiplier *= vector[i];
            }
        }
    }
}
