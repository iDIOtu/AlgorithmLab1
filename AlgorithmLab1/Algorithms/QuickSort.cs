using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class QuickSort : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            Sort(vector, 0, vector.Length - 1);
        }

        private int Partition(int[] array, int minIndex, int maxIndex)
        {
            int pivotIndex = minIndex - 1;

            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivotIndex++;
                    (array[pivotIndex], array[i]) = (array[i], array[pivotIndex]);
                }
            }

            pivotIndex++;
            (array[pivotIndex], array[maxIndex]) = (array[maxIndex], array[pivotIndex]);
            return pivotIndex;
        }

        private void Sort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                var pivotIndex = Partition(array, minIndex, maxIndex);
                Sort(array, minIndex, pivotIndex - 1);
                Sort(array, pivotIndex + 1, maxIndex);
            }
        }
    }
}
