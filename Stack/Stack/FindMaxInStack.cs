using System;
using System.Text;

namespace Stack
{
    internal class FindMaxInStack
    {
        private protected int[] stack;
        private protected int maxSize;
        private protected int top;
        MyStack<int> max = new MyStack<int>();

        public FindMaxInStack(int size)
        {
            maxSize = size;
            stack = new int[maxSize];
            top = -1;
            max.Push(int.MinValue);
        }

        public FindMaxInStack() : this(10) { }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void Push(int item)
        {
            if (top + 1 >= maxSize)
            {
                maxSize++;
                Array.Resize(ref stack, maxSize);
            }

            stack[++top] = item;
            max.Push(Math.Max(max.Peek(), item));
        }
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("stack is empty!");
            }
            max.Pop();
            return stack[top--];
        }

        public int Peek()
        {
            return stack[top];
        }

        public int GetMax()
        {
            return max.Peek();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i <= top; i++)
            {
                sb.Append($"{stack[i]} ");
            }
            return sb.ToString();
        }
    }
}

