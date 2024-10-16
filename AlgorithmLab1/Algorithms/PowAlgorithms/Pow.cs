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
        public override int ExecuteAlgorithm(int[] vector)
        {
            int step = 0;
            int n = p;
            int power = vector.Length;

            int result = 1;
            
            f = 1;
            int k = 0;
            while (k < power)
            {
                step++;
                f *= n;
                k++;
            }

            result = f;
            
            return step;
        }
    }
}
