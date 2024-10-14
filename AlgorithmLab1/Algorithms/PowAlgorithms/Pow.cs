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
            int step = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                f = 1;
                k = 0;
                while (k < power)
                {

                    f *= vector[i];
                    step++;
                    k++;
                    step++;
                }

                vector[i] = f;
            }
            return step;
        }
    }
}
