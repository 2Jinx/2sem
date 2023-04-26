using System;
using Thread;
namespace Thread
{

    class Program
    {
        static void Main(string[] args)
        {
            int m = 5;
            int n = 5;
            MatrixMaxFormMins matrix = new MatrixMaxFormMins(n, m);
            
            matrix.GetMaxFromMins();
        }
    }

}