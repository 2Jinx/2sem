using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Next { get; set; }

        public Elem(T info)
        {
            this.Info = info;
        }
    }

    internal class LinkedList<T>
    {
        private Elem<T> First { get; set; }

        public int Length
        {
            get
            {
                int k = 0;
                var el = First;
                while (el != null)
                {
                    k++;
                    el = el.Next;
                }
                return k;
            }
        }

        public void AddFirst(T info)
        {
            var el = new Elem<T>(info);
            el.Next = First;
            First = el;
        }

        public void AddLast(T info)
        {
            if (First == null)
            {
                AddFirst(info);
                return;
            }
            var el = First;
            while (el.Next != null)
            {
                el = el.Next;
            }
            el.Next = new Elem<T>(info);
        }

        public void DeleteFirst()
        {
            if (First == null)
                return;

            First = First.Next;
        }

        public void DeleteLast()
        {
            if (First == null)
                return;
            if (First.Next == null)
            {
                DeleteFirst();
                return;
            }
            var el = First;
            while (el.Next.Next != null)
                el = el.Next;

            el.Next = null;
        }

        public void DeleteElem(int k)
        {
            if (First == null)
                throw new ArgumentException("list is empty!");
            if (k == 0)
                First = First.Next;
            else
            {
                var prevElem = First;
                for (int i = 1; i < k; i++)
                {
                    prevElem = prevElem.Next;
                    if (prevElem == null)
                        throw new ArgumentException("");
                }
                if (prevElem.Next != null)
                    prevElem.Next = prevElem.Next.Next;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($" {el.Info.ToString()} ->");
                el = el.Next;
            }
            return sb.ToString();
        }


    }
}

