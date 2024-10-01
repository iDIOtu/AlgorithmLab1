using System;

namespace AlgorithmLab1
{
    internal class Generator
    {
        static Random random = new Random();

        public static int[] VectorInput(int n)     
        {
            int[] vector = new int[n];

            for (int i = 0; i < n; i++)
            {
                vector[i] = random.Next(10000);
            }

            return vector;
        }

        public static int[,] MatrixInput(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next();
                }
            }

            return matrix;
        }
    }
}