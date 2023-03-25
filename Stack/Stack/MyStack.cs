using System;
using System.Linq;
using System.Text;

namespace Stack
{
    public class MyStack<T> where T : IComparable<T>
    {
        private protected int maxSize;
        private protected T[] stack;
        private int top;

        public MyStack(int size)
        {
            maxSize = size;
            stack = new T[maxSize];
            top = -1;
        }

        public MyStack() : this(10)
        {
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public int Length
        {
            get
            {
                return top + 1;
            }
        }

        public T Peek()
        {
            return stack[top];
        }

        public void Push(T x) 
        {

            if (top + 1 >= maxSize)
            {
                maxSize++;
                Array.Resize<T>(ref stack, maxSize);
            }

            top++;
            stack[top] = x;
        }

        public T Pop()
        {
            if (stack.Length == 0)
                throw new Exception("stack is empty!");

            return stack[top--];
        }

        public void Clear()
        {
            Array.Clear(stack, 0, stack.Length);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i <= top; i++)
                sb.Append($"{stack[i]} ");
            return sb.ToString();
        }

        public T TrueMax()
        {
            return stack.Max();
        }
    }
}
