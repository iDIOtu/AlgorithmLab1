using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class Sum : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            int sum = 0;

            for (int i = 0; i < vector.Length; i++)
            {
                sum += vector[i];
            }
        }
    }
}
