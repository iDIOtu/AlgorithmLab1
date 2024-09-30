using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_
{
    internal class Algorithm
    {
        protected int f;
        protected int k;
        protected int c;



        public virtual void ExecuteAlgorithm(int[] vector) { }
        public virtual void ExecuteAlgorithm(int[,] matrixA, int[,] matrixB) { }
        public virtual void ExecuteAlgorithm(ref int x, int n) { }
        public virtual void ExecuteAlgorithm(int[,] array) { } // SumOfPairs.cs
    }
}