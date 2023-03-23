using System;
using System.Text;

namespace List
{
    public class OrderedList<T> where T : IComparable
    {
        private class Elem<T>
        {
            public T Info { get; set; }
            public Elem<T> Next { get; set; }
            public Elem(T info)
            {
                this.Info = info;
            }
        }

        private Elem<T> First { get; set; }

        public void Add(T value)
        {
            var el = new Elem<T>(value);
            if (First == null)
                First = el;
            else
            {
                if (el.Info.CompareTo(First.Info) < 0)
                {
                    el.Next = First;
                    First = el;
                }
                else
                {
                    var al = new Elem<T>(value);
                    al = First;
                    while (al.Next != null && al.Next.Info.CompareTo(el.Info) < 0)
                    {
                        al = al.Next;
                    }
                    el.Next = al.Next;
                    al.Next = el;
                }
            }

        }
        public void Delete(T value)
        {
            bool fl = true;
            var el = First;
            var prev = el;
            if (First == null)
                throw new ArgumentException("list is empty !");
            while (el != null)
            {
                fl = false;
                if (el.Info.CompareTo(value) == 0)
                {
                    prev.Next = el.Next;
                    if (First.Info.CompareTo(value) == 0)
                    {
                        First = First.Next;
                    }
                    fl = true;
                    break;
                }
                else
                {
                    prev = el;
                    el = el.Next;
                }
            }
            if (!fl)
            {
                throw new ArgumentException("element doesn't exist !");
            }

        }

        public void Merge(OrderedList<T> list2)
        {
            Elem<T> current1 = First;
            Elem<T> current2 = list2.First;
            Elem<T> prev = null;
            while (current1 != null && current2 != null)
            {
                if (current2.Info.CompareTo(current1.Info) < 0)
                {
                    Elem<T> temp = current2;
                    current2 = current2.Next;
                    if (prev == null)
                    {
                        temp.Next = First;
                        First = temp;
                        prev = temp;
                    }
                    else
                    {
                        prev.Next = temp;
                        temp.Next = current1;
                        prev = temp;
                    }
                }
                else
                {
                    prev = current1;
                    current1 = current1.Next;
                }

            }
            if (current2 != null)
            {
                prev.Next = current2;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($"{el.Info?.ToString()} ->");
                el = el.Next;
            }
            return sb.ToString();
        }
    }
}


