using System.Diagnostics;

internal class Program {
    static void Main() {
        DeleteFiles();
        GenerateFiles();
        ReadFile();
    }

    class Node {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value) {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    static int[] TreeSort(int[] array) {
        Node root = null;

        // Build binary search tree
        foreach (int value in array) {
            root = Insert(root, value);
        }

        // Traverse binary search tree in-order to get sorted array
        List<int> sortedList = new List<int>();
        InOrderTraversal(root, sortedList);

        return sortedList.ToArray();
    }

    static Node Insert(Node node, int value) {
        if (node == null) {
            return new Node(value);
        }

        if (value < node.Value) {
            node.Left = Insert(node.Left, value);
        } else {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    static void InOrderTraversal(Node node, List<int> list) {
        if (node == null) {
            return;
        }

        InOrderTraversal(node.Left, list);
        list.Add(node.Value);
        InOrderTraversal(node.Right, list);
    }

    static void PrintArray(int[] array) {
        foreach (int value in array) {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    static void GenerateFiles() {
        int pcount = 0;
        var r = new Random();
        for (int i = 1; i < 51; i++) {
            pcount += 10000;
            int[] ints = new int[pcount];
            using (var sw = new StreamWriter($@"files/{i}.txt", false)) {
                for (int j = 0; j < pcount; j++) {
                    ints[j] = r.Next(-10000, 10000);
                    sw.Write($"{ints[j]} ");
                }
            }
        }
    }

    static void ReadFile() {
        int qcount = 0;
        for (int q = 1; q < 51; q++) {
            qcount += 10000;
            int[] ints = new int[qcount];
            using (StreamReader sr = new StreamReader($@"files/{q}.txt")) {
                while (sr.Peek() != -1) {
                    string[] str = sr.ReadLine().Split(' ');
                    for (int i = 0; i < str.Length - 1; i++) {
                        ints[i] = int.Parse(str[i]);
                    }
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    TreeSort(ints);
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds);
                }
            }
        }
    }

    static void DeleteFiles() {
        DirectoryInfo dirInfo = new DirectoryInfo("files");

        foreach (FileInfo file in dirInfo.GetFiles()) {
            file.Delete();
        }
    }
}