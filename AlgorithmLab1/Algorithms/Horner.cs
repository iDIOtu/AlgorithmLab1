using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class Horner : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            double component = vector[0];

            for (int i = 1; i < vector.Length; i++)
            {
                component = component * 1.5 + vector[i];
            }
        }
    }
}
