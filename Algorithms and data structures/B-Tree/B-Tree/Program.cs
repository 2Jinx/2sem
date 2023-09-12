using System;
using System.Diagnostics;
using System.Text;

using B_Tree;

public class Program
{
    public static void Main()
    {
        try
        {
            GetTime();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void GetTime()
    {
        BTree<int> tree = new BTree<int>(10000);
        Random r = new Random();
        Stopwatch watch = new Stopwatch();
        int k = 0;
        Console.WriteLine("Время добавления элементов в структуру\n");
        for (int i = 0; i < 10000; i++)
        {
            watch.Start();
            tree.Add(r.Next(-100, 100));
            Console.Write($"{watch.ElapsedMilliseconds} ");
        }
        watch.Stop();
        watch.Reset();
        Console.WriteLine("\nВремя удаления элементов из структуры\n");
        for (int i = 0; i < 1000; i++)
        {
            watch.Start();
            tree.Delete(k);
            Console.Write($"{watch.ElapsedMilliseconds} ");
            k += 5;
        }
        watch.Stop();
        watch.Reset();
        k = 0;
        Console.WriteLine("\nВремя получения элементов из структуры\n");
        for (int i = 0; i < 100; i++)
        {
            watch.Start();
            tree.Get(k);
            Console.Write($"{watch.ElapsedMilliseconds} ");
            k += 10;
        }
    }
}

