using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class ArOper
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }
        public int Mult(int a, int b)
        {
            return a * b;
        }
        public int Div(int a, int b)
        {
            return a / b;
        }

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void Hello1()
        {
            Console.WriteLine("Hello 1");
        }
        public void Hello2()
        {
            Console.WriteLine("Hello 2");
        }
    }
}