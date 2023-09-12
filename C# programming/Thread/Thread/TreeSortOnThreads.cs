using System;
using Threads;
using System.Diagnostics;

namespace Threads
{
    internal class TreeSortOnThreads
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

            public Node()
            {

            }
        }

        private static Node root;

        public static int[] SimpleTreeSort(int[] array)
        {
            Node root = null;

            foreach (int value in array)
            {
                root = Insert(root, value);
            }

            List<int> sortedList = new List<int>();
            InOrderTraversal(root, sortedList);

            return sortedList.ToArray();
        }

        public static Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        private static void InOrderTraversal(Node node, List<int> list)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left, list);
            list.Add(node.Value);
            InOrderTraversal(node.Right, list);
        }

        public static void Add(int value)
        {
            if (root == null)
            {
                root = new Node { Value = value };
            }
            else
            {
                AddRecursive(root, value);
            }
        }

        private static void AddRecursive(Node node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node { Value = value };
                }
                else
                {
                    AddRecursive(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node { Value = value };
                }
                else
                {
                    AddRecursive(node.Right, value);
                }
            }
        }

        public static int[] TreeSortOnThread(int[] array)
        {
            int[] sortedArray = new int[CountNodes(root)];
            int index = 0;

            Task traverseTask = Task.Run(() =>
            {
                TraverseInOrder(root, (value) =>
                {
                    sortedArray[index++] = value;
                });
            });

            traverseTask.Wait();

            return sortedArray;
        }

        private static int CountNodes(Node node)
        {
            if (node == null)
                return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }

        private static void TraverseInOrder(Node node, Action<int> action)
        {
            if (node == null)
            {
                return;
            }

            TraverseInOrder(node.Left, action);
            action(node.Value);
            TraverseInOrder(node.Right, action);
        }

        public static void PrintArray(int[] array)
        {
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        public static void GenerateFiles()
        {
            int pcount = 0;
            var r = new Random();
            for (int i = 1; i < 51; i++)
            {
                pcount += 10000;
                int[] ints = new int[pcount];
                using (var sw = new StreamWriter($@"files/{i}.txt", false))
                {
                    for (int j = 0; j < pcount; j++)
                    {
                        ints[j] = r.Next(-10000, 10000);
                        sw.Write($"{ints[j]} ");
                    }
                }
            }
        }

        public static void ReadFile()
        {
            int qcount = 0;
            for (int q = 1; q < 51; q++)
            {
                qcount += 10000;
                int[] ints = new int[qcount];
                using (StreamReader sr = new StreamReader($@"files/{q}.txt"))
                {
                    while (sr.Peek() != -1)
                    {
                        string[] str = sr.ReadLine().Split(' ');
                        for (int i = 0; i < str.Length - 1; i++)
                        {
                            ints[i] = int.Parse(str[i]);
                            Add(int.Parse(str[i]));
                        }

                        Stopwatch watch = new Stopwatch();
                        watch.Start();
                        SimpleTreeSort(ints);
                        watch.Stop();
                        Console.Write($"\t  {watch.ElapsedMilliseconds}");

                        Stopwatch watch1 = new Stopwatch();
                        watch1.Start();
                        TreeSortOnThread(ints);
                        watch1.Stop();
                        Console.Write($"  \t//\t{watch1.ElapsedMilliseconds}");
                        root = null;
                        Console.Write($"  \t//\t{qcount}\n");
                    }
                }
            }
        }

        public static void DeleteFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("files");

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        public void Main()
        {
            Console.WriteLine("       Default  //   OnTasks    //   Array size");
            DeleteFiles();
            GenerateFiles();
            ReadFile();
        }
    }
}

