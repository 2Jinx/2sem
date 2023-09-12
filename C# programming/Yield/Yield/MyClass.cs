using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class MyClass : IEnumerator<string>
    {
        private string[] words;
        private int top = -1;

        public MyClass(string[] w)
        {
            this.words = w;
        }

        public string Current
        {
            get
            {
                return words[top];
            }
        }

        public bool MoveNext()
        {
            top++;
            return top < words.Length;
        }
        public void Reset()
        {
            top = -1;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}