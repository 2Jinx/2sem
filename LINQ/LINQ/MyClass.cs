using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class MyClass
    {
        public delegate int MyDeleg(int k, int l);

        public int size;
        public int[] mas;

        public MyClass(int n)
        {
            Random r = new Random();
            size = n;
            mas = new int[size];
            for (int i = 0; i < size; i++)
            {
                mas[i] = r.Next(-100, 100);
            }
        }


        public int SomeMethod(Func<int, int, int> deleg)
        {
            if (size == 1)
                return mas[0];
            int res = mas[0];

            for (int i = 1; i < size; i++)
                res = deleg(res, mas[i]);

            return res;

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (int i in mas)
            {
                sb.Append($"{i} ");
            }
            return sb.ToString();
        }
    }
}