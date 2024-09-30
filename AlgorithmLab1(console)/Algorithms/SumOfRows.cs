using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class SumOfRows : Algorithm
    {
        public override void ExecuteAlgorithm(int[,] array)
        {
            int[] result = { };
            for (int i = 0; i < array.GetLength(0); i++)// Row
            {
                for (int j = 0; j < array.GetLength(1); j++) // Column
                {
                    result[i] = array[i, j] + result[i];
                }
            }
        }
    }
}
