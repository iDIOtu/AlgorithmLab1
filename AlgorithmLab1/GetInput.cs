using System;

namespace AlgorithmLab1
{
    internal class GetInput
    {
        static Random random = new Random();
        public static int[] VectorInput(int n)
        {
            int[] vector = new int[n];

            for (int i = 0; i < n; i++)
            {
                vector[i] = random.Next();
            }

            return vector;
        }
    }
}