using System;
using System.Text;

namespace List
{
    internal class CircularLinkedList<T> where T : IComparable
    {
        public class Node<T>
        {
            public T Info;
            public Node<T> Next;
            public Node<T> Prev;

            public Node(T info)
            {
                this.Info = info;
            }
        }

        public Node<T> Head;

        public void AddFirst(T info)
        {
            Node<T> newNode = new Node<T>(info);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                newNode.Next = Head;
                newNode.Prev = Head.Prev;
                Head.Prev.Next = newNode;
                Head.Prev = newNode;
                Head = newNode;
            }
        }

        public void AddLast(T info)
        {
            Node<T> newNode = new Node<T>(info);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                newNode.Prev = Head.Prev;
                newNode.Next = Head;
                Head.Prev.Next = newNode;
                Head.Prev = newNode;

            }
        }

        public T GetElement(int index)
        {
            Node<T> currentNode = Head;
            for (int i = 0; i < index; i++)
            {
                //if (currentNode == null)
                //    throw new ArgumentOutOfRangeException();
                currentNode = currentNode.Next;
            }
            return currentNode.Info;
        }

        public bool Contains(int k)
        {
            Node<T> currentNode = Head;
            do
            {
                if (currentNode.Info.CompareTo(k) == 0)
                    return true;
                currentNode = currentNode.Next;
            } while (currentNode != Head);
            return false;
        }

        public void ShiftRight(int k)
        {
            if (this.Head != null)
            {
                while (k != 0)
                {
                    Head = Head.Prev;
                    k--;
                }
            }
        }

        public void ShiftLeft(int k)
        {
            if (this.Head != null)
            {
                while (k != 0)
                {
                    Head = Head.Next;
                    k--;
                }
            }
        }

        public T[] ToArray()
        {
            List<T> list = new List<T>();
            Node<T> currentNode = Head;
            do
            {
                list.Add(currentNode.Info);
                currentNode = currentNode.Next;
            } while (currentNode != Head);
            return list.ToArray();
        }

        public override string ToString()
        {
            return string.Join(" -> ", ToArray());
        }
    }
}