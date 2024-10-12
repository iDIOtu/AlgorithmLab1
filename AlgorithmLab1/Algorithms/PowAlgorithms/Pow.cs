using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms.PowAlgorithms
{
    internal class Pow : PowAlgorithm
    {
        public override int ExecuteAlgorithm(int[] vector, int power)
        { 
            int steps = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                f = 1;
                k = 0;
                while (k < power)
                {
                    steps++;
                    f *= vector[i];
                    k++;
                }

                vector[i] = f;
            }
            return steps;
        }
    }
}
