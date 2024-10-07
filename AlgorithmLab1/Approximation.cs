using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AlgorithmLab1
{
    internal class Approximation
    {
        public static double[] GetPolApproximation(int start, int step, double[] yTimes)
        {
            double[] nTimes = new double[yTimes.Length];

            for (int i = 0; i < yTimes.Length; i++)
                nTimes[i] = start + i * step;
            
            double[] coeffiecents = Fit.Polynomial(nTimes, yTimes, 3);

            for (int i = 0 ; i < nTimes.Length; i++)
            {
                nTimes[i] = coeffiecents[0] + coeffiecents[1] * nTimes[i] + coeffiecents[2]
                   * nTimes[i] * nTimes[i] + coeffiecents[3] * nTimes[i] * nTimes[i] * nTimes[i];

            }

            return nTimes;
        }
    }
}
