using System;
using System.Text;

using B_Tree;

public class Program
{
    public static void Main()
    {
        BTree<int> tree = new BTree<int>(5);
        tree.Add(1);
        tree.Add(2);
        tree.Add(3);
        tree.Add(4);
        tree.Add(5);
        tree.Add(6);
        Console.WriteLine(tree.Get(2));
        Console.WriteLine(tree);
        tree.Delete(2);
        Console.WriteLine(tree);
    }
}

