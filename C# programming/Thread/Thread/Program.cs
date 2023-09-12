using Threads;
namespace Threads
{
    class Program
    {
        static void Main()
        {
            try
            {
                MultiplicationTime();
                TreeSort();
                MaxInMins();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void MultiplicationTime()
        {
            File.Delete("log.txt");
            Console.ForegroundColor = ConsoleColor.Green;
            const int Z1 = 100;
            MatrixMultiplicationOnThreads m1 = new MatrixMultiplicationOnThreads(Z1, Z1, Z1, Z1);
            m1.WriteResultsInFileAsync("log.txt");
            Console.WriteLine("[■■                  ][10%]");
            const int Z2 = 200;
            MatrixMultiplicationOnThreads m2 = new MatrixMultiplicationOnThreads(Z2, Z2, Z2, Z2);
            m2.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■                ][20%]");
            const int Z3 = 300;
            MatrixMultiplicationOnThreads m3 = new MatrixMultiplicationOnThreads(Z3, Z3, Z3, Z3);
            m3.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■              ][30%]");
            const int Z4 = 400;
            MatrixMultiplicationOnThreads m4 = new MatrixMultiplicationOnThreads(Z4, Z4, Z4, Z4);
            m4.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■■■            ][40%]");
            const int Z5 = 500;
            MatrixMultiplicationOnThreads m5 = new MatrixMultiplicationOnThreads(Z5, Z5, Z5, Z5);
            m5.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■■■■■          ][50%]");
            const int Z6 = 600;
            MatrixMultiplicationOnThreads m6 = new MatrixMultiplicationOnThreads(Z6, Z6, Z6, Z6);
            m6.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■■■■■■■        ][60%]");
            const int Z7 = 700;
            MatrixMultiplicationOnThreads m7 = new MatrixMultiplicationOnThreads(Z7, Z7, Z7, Z7);
            m7.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■■■■■■■■■      ][70%]");
            const int Z8 = 800;
            MatrixMultiplicationOnThreads m8 = new MatrixMultiplicationOnThreads(Z8, Z8, Z8, Z8);
            m8.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■■■■■■■■■■■    ][80%]");
            const int Z9 = 900;
            MatrixMultiplicationOnThreads m9 = new MatrixMultiplicationOnThreads(Z9, Z9, Z9, Z9);
            m9.WriteResultsInFileAsync("log.txt");
            Console.Clear();
            Console.WriteLine("[■■■■■■■■■■■■■■■■■■  ][90%]");
            const int Z10 = 1000;
            MatrixMultiplicationOnThreads m10 = new MatrixMultiplicationOnThreads(Z10, Z10, Z10, Z10);
            m10.WriteResultsInFileAsync("log.txt");
            Console.WriteLine("[■■■■■■■■■■■■■■■■■■■■][100%]");
        }

        public static void TreeSort()
        {
            TreeSortOnThreads s = new TreeSortOnThreads();
            s.Main();
        }

        public static void MaxInMins()
        {
            MatrixMaxFromMins m = new MatrixMaxFromMins(6, 7);
            m.GetMaxFromMins();
        }
    }
    
}