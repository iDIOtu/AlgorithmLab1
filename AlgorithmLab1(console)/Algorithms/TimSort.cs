using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class TimSort : Algorithm
    {
        public override void ExecuteAlgorithm(int[] vector)
        {
            int n = vector.Length;

            // Сортируем каждый подмассив
            for (int start = 0; start < n; start += Run)
            {
                int end = Math.Min(start + Run - 1, n - 1);
                InsertionSort(vector, start, end);
            }

            // Объединяем отсортированные подмассивы
            for (int size = Run; size < n; size *= 2)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right)
                        Merge(vector, left, mid, right);
                }
            }
        }

        private const int Run = 32;

        // Сортировка вставками
        private void InsertionSort(int[] vector, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = vector[i];
                int j = i - 1;

                while (j >= left && vector[j] > key)
                {
                    vector[j + 1] = vector[j];
                    j--;
                }

                vector[j + 1] = key;
            }
        }

        // Слияние двух подмассивов
        private void Merge(int[] arr, int left, int mid, int right)
        {
            int len1 = mid - left + 1;
            int len2 = right - mid;

            int[] leftArray = new int[len1];
            int[] rightArray = new int[len2];

            Array.Copy(arr, left, leftArray, 0, len1);
            Array.Copy(arr, mid + 1, rightArray, 0, len2);

            int i = 0, j = 0;
            int k = left;

            while (i < len1 && j < len2)
            {
                if (leftArray[i] <= rightArray[j])
                    arr[k++] = leftArray[i++];
                else
                    arr[k++] = rightArray[j++];
            }

            while (i < len1)
                arr[k++] = leftArray[i++];

            while (j < len2)
                arr[k++] = rightArray[j++];
        }
    }
}
