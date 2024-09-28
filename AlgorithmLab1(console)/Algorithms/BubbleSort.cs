using AlgorithmLab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class BubbleSort : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[i] > vector[j])
                    {
                        (vector[i], vector[j]) = (vector[j], vector[i]);
                    }
                }
            }
        }
    }
}
