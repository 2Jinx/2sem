using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    public class ListEnumerator : IEnumerator<int>
    {

        List<int> lst;
        int cur;

        public ListEnumerator(List<int> lst)
        {
            this.lst = lst;
            cur = -1;
        }


        public int Current
        {
            get
            {
                return lst[cur];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            cur++;
            return cur < lst.Count;
        }

        public void Reset()
        {
            cur = -1;
        }
    }



    public class ListEnum : IEnumerable<int>
    {

        List<int> lst;


        public ListEnum(List<int> lst)
        {
            this.lst = lst;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new ListEnumerator(lst);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}



