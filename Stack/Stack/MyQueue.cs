using System;
using System.Text;

namespace Stack
{
    public class MyQueue<T> where T : IComparable
    {
        private protected T[] queue;
        private protected int begin = 0;
        private protected int end = -1;
        private protected int maxL;

        public MyQueue(int maxLength)
        {
            maxL = maxLength;
            queue = new T[maxL];
        }

        public bool IsEmpty()
        {
            return begin > end;
        }

        public void Enqueue(T info) 
        {
            if (end + 1 >= maxL)
            {
                maxL++;
                Array.Resize<T>(ref queue, maxL);
            }
            queue[++end] = info;
        }

        public int Length
        {
            get
            {
                return end + 1;
            }
        }
        public T Dequeue() 
        {
            if (queue.Length == 0)
                throw new IndexOutOfRangeException("Queue is empty!");

            return queue[begin++];

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i <= end; i++)
                sb.Append($" {queue[i]} ");
            return sb.ToString();
        }
    }
}
