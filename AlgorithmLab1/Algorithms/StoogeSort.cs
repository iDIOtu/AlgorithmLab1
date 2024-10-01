using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class StoogeSort : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            Stooge(vector, 0, vector.Length - 1);
        }

        public static int[] Stooge(int[] vector, int start, int end)
        {
            if (vector[start] > vector[end])
            {
                (vector[start], vector[end]) = (vector[end], vector[start]);
            }

            if (end - start > 1)
            {
                var len = (end - start + 1) / 3;

                Stooge(vector, start, end - len);
                Stooge(vector, start + len, end);
                Stooge(vector, start, end - len);
            }

            return vector;
        }
    }
}
