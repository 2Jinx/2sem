using System;
using System.Text;

namespace B_Tree
{
    public class BTreeNode<T> where T : IComparable<T>
    {
        public int MinDegree { get; private set; }
        public T[] Keys { get; private set; }
        public BTreeNode<T>[] Children { get; private set; }
        public int KeyCount { get; private set; }
        public bool IsLeaf { get; private set; }

        public BTreeNode(int minDegree, bool isLeaf)
        {
            MinDegree = minDegree;
            Keys = new T[2 * minDegree - 1];
            Children = new BTreeNode<T>[2 * minDegree];
            KeyCount = 0;
            IsLeaf = isLeaf;
        }

        public T Get(int index)
        {
            if (index >= 0 && index < KeyCount)
            {
                return Keys[index];
            }

            throw new IndexOutOfRangeException();
        }

        public void Add(T value)
        {
            if (KeyCount == Keys.Length)
            {
                BTreeNode<T> newNode = new BTreeNode<T>(MinDegree, IsLeaf);
                newNode.Children[0] = this;
                SplitChild(newNode, 0);

                int i = 0;
                if (value.CompareTo(Keys[0]) > 0)
                {
                    i++;
                }

                newNode.Children[i].InsertNonFull(value);
            }
            else
            {
                InsertNonFull(value);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            Traverse(builder);

            return builder.ToString();
        }

        private T GetPredecessorKey(int index)
        {
            BTreeNode<T> currentNode = Children[index];
            while (!currentNode.IsLeaf)
            {
                currentNode = currentNode.Children[currentNode.KeyCount];
            }
            return currentNode.Keys[currentNode.KeyCount - 1];
        }

        private T GetSuccessorKey(int index)
        {
            BTreeNode<T> currentNode = Children[index + 1];
            while (!currentNode.IsLeaf)
            {
                currentNode = currentNode.Children[0];
            }
            return currentNode.Keys[0];
        }

        private void MergeChildren(int index)
        {
            BTreeNode<T> leftChild = Children[index];
            BTreeNode<T> rightChild = Children[index + 1];

            leftChild.Keys[MinDegree - 1] = Keys[index];

            for (int i = 0; i < rightChild.KeyCount; i++)
            {
                leftChild.Keys[i + MinDegree] = rightChild.Keys[i];
            }

            if (!leftChild.IsLeaf)
            {
                for (int i = 0; i <= rightChild.KeyCount; i++)
                {
                    leftChild.Children[i + MinDegree] = rightChild.Children[i];
                }
            }

            for (int i = index + 1; i < KeyCount; i++)
            {
                Keys[i - 1] = Keys[i];
            }

            for (int i = index + 2; i <= KeyCount; i++)
            {
                Children[i - 1] = Children[i];
            }

            leftChild.KeyCount += rightChild.KeyCount + 1;
            KeyCount--;

            rightChild = null;
        }

        public void Delete(int index)
        {
            if (IsLeaf)
            {
                if (index >= 0 && index < KeyCount)
                {
                    for (int i = index; i < KeyCount - 1; i++)
                    {
                        Keys[i] = Keys[i + 1];
                    }

                    Keys[KeyCount - 1] = default(T);
                    KeyCount--;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                if (index >= 0 && index < KeyCount)
                {
                    bool isDeleted = false;
                    for (int i = 0; i < KeyCount; i++)
                    {
                        if (i == index)
                        {
                            BTreeNode<T> predecessorChild = Children[i];
                            BTreeNode<T> successorChild = Children[i + 1];

                            if (predecessorChild.KeyCount >= MinDegree)
                            {
                                T predecessorKey = GetPredecessorKey(i);
                                Keys[i] = predecessorKey;
                                predecessorChild.Delete(predecessorChild.KeyCount - 1);
                            }
                            else if (successorChild.KeyCount >= MinDegree)
                            {
                                T successorKey = GetSuccessorKey(i);
                                Keys[i] = successorKey;
                                successorChild.Delete(0);
                            }
                            else
                            {
                                MergeChildren(i);
                                Delete(index);
                            }

                            isDeleted = true;
                            break;
                        }
                        else if (index < KeyCount && Children[i].KeyCount >= MinDegree)
                        {
                            Children[i].Delete(index);
                            isDeleted = true;
                            break;
                        }
                    }

                    if (!isDeleted)
                    {
                        if (index == KeyCount)
                        {
                            Children[index - 1].Delete(index - 1);
                        }
                        else
                        {
                            Children[index].Delete(index);
                        }
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }


        private void Traverse(StringBuilder builder)
        {
            int i;
            for (i = 0; i < KeyCount; i++)
            {
                if (!IsLeaf)
                {
                    Children[i].Traverse(builder);
                }

                builder.Append(Keys[i]).Append(" ");
            }

            if (!IsLeaf)
            {
                Children[i].Traverse(builder);
            }
        }

        private void InsertNonFull(T value)
        {
            int i = KeyCount - 1;

            if (IsLeaf)
            {
                while (i >= 0 && value.CompareTo(Keys[i]) < 0)
                {
                    Keys[i + 1] = Keys[i];
                    i--;
                }

                Keys[i + 1] = value;
                KeyCount++;
            }
            else
            {
                while (i >= 0 && value.CompareTo(Keys[i]) < 0)
                {
                    i--;
                }

                i++;
                if (Children[i].KeyCount == 2 * MinDegree - 1)
                {
                    SplitChild(this, i);

                    if (value.CompareTo(Keys[i]) > 0)
                    {
                        i++;
                    }
                }

                Children[i].InsertNonFull(value);
            }
        }

        private void SplitChild(BTreeNode<T> parentNode, int childIndex)
        {
            BTreeNode<T> childNode = parentNode.Children[childIndex];
            BTreeNode<T> newNode = new BTreeNode<T>(MinDegree, childNode.IsLeaf);

            for (int j = 0; j < MinDegree - 1; j++)
            {
                newNode.Keys[j] = childNode.Keys[j + MinDegree];
            }

            if (!childNode.IsLeaf)
            {
                for (int j = 0; j < MinDegree; j++)
                {
                    newNode.Children[j] = childNode.Children[j + MinDegree];
                }
            }

            childNode.KeyCount = MinDegree - 1;

            for (int j = parentNode.KeyCount; j >= childIndex + 1; j--)
            {
                parentNode.Children[j + 1] = parentNode.Children[j];
            }

            parentNode.Children[childIndex + 1] = newNode;

            for (int j = parentNode.KeyCount - 1; j >= childIndex; j--)
            {
                parentNode.Keys[j + 1] = parentNode.Keys[j];
            }
            parentNode.Keys[childIndex] = childNode.Keys[MinDegree - 1];
            parentNode.KeyCount++;
            for (int j = childNode.KeyCount - 1; j >= MinDegree - 1; j--)
            {
                childNode.Keys[j] = default(T);
            }

            for (int j = childNode.KeyCount; j >= MinDegree; j--)
            {
                childNode.Children[j + 1] = null;
            }

            childNode.KeyCount = MinDegree - 1;
        }
    }

    public class BTree<T> where T : IComparable<T>
    {
        private BTreeNode<T> root; public int MinDegree { get; private set; }

        public BTree(int minDegree)
        {
            MinDegree = minDegree;
            root = new BTreeNode<T>(minDegree, true);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= root.KeyCount)
            {
                throw new IndexOutOfRangeException();
            }

            return GetElement(root, index);
        }

        public void Add(T value)
        {
            root.Add(value);
        }

        private T GetElement(BTreeNode<T> node, int index)
        {
            if (node.IsLeaf)
            {
                return node.Get(index);
            }

            int i = 0;
            while (i < node.KeyCount && index > node.Children[i].KeyCount)
            {
                index -= node.Children[i].KeyCount;
                i++;
            }

            return GetElement(node.Children[i], index);
        }

        public void Delete(int index)
        {
            root.Delete(index);
        }

        public override string ToString()
        {
            return root != null ? root.ToString() : string.Empty;
        }
    }
}

