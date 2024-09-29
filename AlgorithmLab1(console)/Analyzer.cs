using AlgorithmLab1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_
{
    internal class Analyzer
    {
        public static double[] Timing(int n, int repeats, Algorithm algorithm)
        {
            double[,] allTests = new double[repeats, n];
            Stopwatch sw = new Stopwatch();

            for (int precision = 0; precision < repeats; precision++)
                for (int dataSize = 0; dataSize < n; dataSize++)
                {
                    int[] data = Generator.VectorInput(n);

                    sw.Start();
                    algorithm.ExecuteAlgorithm(data);
                    sw.Stop();

                    allTests[precision, dataSize] = sw.ElapsedTicks / 10000000.0d;

                    sw.Reset();

                }

            double[] timeApprox = new double[n];

            for (int dataSize = 0; dataSize < n; dataSize++)
            {
                for (int j = 0; j < repeats; j++)
                    timeApprox[dataSize] += allTests[j, dataSize];

                timeApprox[dataSize] /= repeats;
            }

            return timeApprox;
        }
    }
}
