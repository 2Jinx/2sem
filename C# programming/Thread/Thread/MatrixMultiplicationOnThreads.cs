using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;

namespace Threads
{
    public class MatrixMultiplicationOnThreads
    {
        readonly int N;
        readonly int M;
        protected int[,] A;

        readonly int K;
        readonly int Z;
        protected int[,] B;

        protected int[,] C;

        protected long[] ParallelTime = new long[5];
        protected long[] TaskTime = new long[5];
        protected long[] ThreadTime = new long[5];

        public MatrixMultiplicationOnThreads(int n, int m, int k, int z)
        {
            if (m != k)
                throw new ArgumentException("Матрицы невозможно умножить!");
            else
            {
                N = n;
                M = m;
                K = k;
                Z = z;

                A = new int[N, M];
                B = new int[K, Z];
                C = new int[N, Z];

                GenerateAndFillMatrix(A);
                GenerateAndFillMatrix(B);
            }
        }

        public MatrixMultiplicationOnThreads(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                throw new ArgumentException("Матрицы невозможно умножить!");
            else
            {
                A = a;
                B = b;
                C = new int[A.GetLength(0),B.GetLength(1)];
            }
        }

        /// <summary>
        /// Умножение матрицы на другую без использования потоков
        /// </summary>
        public long SimpleMatrixMuiltiplication()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < Z; j++)
                {
                    C[i, j] = 0;
                    for (int z = 0; z < K; z++)
                    {
                        C[i, j] += A[i, z] * B[z, j];
                    }
                }
            }
            //Console.WriteLine("Исходные матрицы: \n");
            //PrintMatrix(A);
            //Console.WriteLine();
            //PrintMatrix(B);
            //Console.WriteLine();
            //Console.WriteLine("Результат: \n");
            //PrintMatrix(C);
            //Console.WriteLine();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Умножение матрицы на другую с использованием Task
        /// </summary>
        public long MatrixMultiplicationOnTasks(int numTasks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int rowsPerTask = C.GetLength(0) / numTasks;

            Task[] tasks = new Task[numTasks];
            for (int i = 0; i < numTasks; i++)
            {
                int startRow = i * rowsPerTask;
                int endRow = (i == numTasks - 1) ? C.GetLength(0) : (i + 1) * rowsPerTask;

                tasks[i] = Task.Run(() =>
                {
                    for (int j = startRow; j < endRow; j++)
                    {
                        for (int k = 0; k < C.GetLength(1); k++)
                        {
                            for (int l = 0; l < B.GetLength(0); l++)
                            {
                                C[j, k] += A[j, l] * B[l, k];
                            }
                        }
                    }
                });
            }

            Task.WaitAll(tasks);

            //Console.WriteLine();
            //PrintMatrix(C);
            //Console.WriteLine();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long MatrixMultiplicationWithParallelFor(int numThreads)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = numThreads;

            Parallel.For(0, C.GetLength(0), options, i =>
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            });
            //Console.WriteLine();
            //PrintMatrix(C);
            //Console.WriteLine();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long MatrixMultiplicationWithThreads(int numThreads)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int rowsPerThread = C.GetLength(0) / numThreads;

            Thread[] threads = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                int startRow = i * rowsPerThread;
                int endRow = (i == numThreads - 1) ? C.GetLength(0) : (i + 1) * rowsPerThread;

                threads[i] = new Thread(() =>
                {
                    for (int j = startRow; j < endRow; j++)
                    {
                        for (int k = 0; k < C.GetLength(1); k++)
                        {
                            for (int l = 0; l < B.GetLength(0); l++)
                            {
                                C[j, k] += A[j, l] * C[l, k];
                            }
                        }
                    }
                });

                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            //Console.WriteLine();
            //PrintMatrix(C);
            //Console.WriteLine();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public void ShowResultsInConsole()
        { 
            int k = 2;
            int m;
            for (int i = 0; i < TaskTime.Length; i++)
            {
                m = (int)Math.Pow(k, i);
                TaskTime[i] = MatrixMultiplicationOnTasks(m);
                ThreadTime[i] = MatrixMultiplicationWithThreads(m);
                ParallelTime[i] = MatrixMultiplicationWithParallelFor(m);
            }
            Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
            Console.WriteLine("\t |    Размеры матриц   \t|\t    Количество      \t|\t       Потраченное       \t|");
            Console.WriteLine($"\t |      [{N}][{M}]\t|\t     потоков        \t|\t          время          \t|");
            Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
            Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
            Console.WriteLine($"\t |     Default    \t|\t      ----          \t|\t           {SimpleMatrixMuiltiplication()}     \t\t|");
            Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
            Console.WriteLine("\t ------------------------------------------------------------------------------------------------");

            for (int i = 0; i < TaskTime.Length; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                    Console.Write("\t |      Tasks      ");
                    Console.Write($"\t|\t       {Math.Pow(k, i)}             \t|\t           {TaskTime[i]}              \t|\n");
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                }
                else
                {
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                    Console.Write($"\t |                 \t|\t       {Math.Pow(k, i)}             \t|\t           {TaskTime[i]}              \t|\n");
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                }
                
                if (i != TaskTime.Length - 1)
                {
                    Console.WriteLine("\t |\t\t\t-------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
                }
            }

            for (int i = 0; i < ParallelTime.Length; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                    Console.Write("\t |     Parallel.For");
                    Console.Write($"\t|\t       {Math.Pow(k, i)}             \t|\t           {ParallelTime[i]}              \t|\n");
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                }
                else
                {
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                    Console.Write($"\t |                 \t|\t       {Math.Pow(k, i)}             \t|\t           {ParallelTime[i]}              \t|\n");
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                }

                if (i != TaskTime.Length - 1)
                {
                    Console.WriteLine("\t |\t\t\t-------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
                }
            }

            for (int i = 0; i < ThreadTime.Length; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                    Console.Write("\t |     Thread    ");
                    Console.Write($"\t|\t       {Math.Pow(k, i)}             \t|\t           {ThreadTime[i]}              \t|\n");
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                }
                else
                {
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                    Console.Write($"\t |                 \t|\t       {Math.Pow(k, i)}             \t|\t           {ThreadTime[i]}              \t|\n");
                    Console.WriteLine("\t |                 \t|\t                       \t|\t                         \t|");
                }

                if (i != TaskTime.Length - 1)
                {
                    Console.WriteLine("\t |\t\t\t-------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\t ------------------------------------------------------------------------------------------------");
                }
            }
        }

        public async Task WriteResultsInFileAsync(string filename)
        {
            int k = 2;
            int m;
            for (int i = 0; i < TaskTime.Length; i++)
            {
                m = (int)Math.Pow(k, i);
                TaskTime[i] = MatrixMultiplicationOnTasks(m);
                ThreadTime[i] = MatrixMultiplicationWithThreads(m);
                ParallelTime[i] = MatrixMultiplicationWithParallelFor(m);
            }
            string text;
            text = "\t ------------------------------------------------------------------------------------------------\n"+
            "\t |                 \t|\t                       \t|\t                         \t|\n"+
            "\t |    Размеры матриц   \t|\t    Количество      \t|\t       Потраченное       \t|\n"+
            $"\t |      [{N}][{M}]\t|\t     потоков        \t|\t          время          \t|\n"+
            "\t |                 \t|\t                       \t|\t                         \t|\n"+
            "\t ------------------------------------------------------------------------------------------------\n"+
            "\t |                 \t|\t                       \t|\t                         \t|\n"+
            $"\t |     Default    \t|\t      ----          \t|\t           {SimpleMatrixMuiltiplication()}     \t\t|\n"+
            "\t |                 \t|\t                       \t|\t                         \t|\n"+
            "\t ------------------------------------------------------------------------------------------------\n";

            for (int i = 0; i < TaskTime.Length; i++)
            {
                if (i == 2)
                {
                    text += "\t |                 \t|\t                       \t|\t                         \t|\n"+
                    "\t |      Tasks      "+
                    $"\t|\t       {Math.Pow(k, i)}             \t|\t           {TaskTime[i]}              \t|\n"+
                    "\t |                 \t|\t                       \t|\t                         \t|\n";
                }
                else
                {
                    text += "\t |                 \t|\t                       \t|\t                         \t|\n"+
                    $"\t |                 \t|\t       {Math.Pow(k, i)}             \t|\t           {TaskTime[i]}              \t|\n"+
                    "\t |                 \t|\t                       \t|\t                         \t|\n";
                }

                if (i != TaskTime.Length - 1)
                {
                    text += "\t |\t\t\t-------------------------------------------------------------------------\n";
                }
                else
                {
                    text += "\t ------------------------------------------------------------------------------------------------\n";
                }
            }

            for (int i = 0; i < ParallelTime.Length; i++)
            {
                if (i == 2)
                {
                    text += "\t |                 \t|\t                       \t|\t                         \t|\n"+
                    "\t |     Parallel.For"+
                    $"\t|\t       {Math.Pow(k, i)}             \t|\t           {ParallelTime[i]}              \t|\n"+
                    "\t |                 \t|\t                       \t|\t                         \t|\n";
                }
                else
                {
                    text += "\t |                 \t|\t                       \t|\t                         \t|\n"+
                    $"\t |                 \t|\t       {Math.Pow(k, i)}             \t|\t           {ParallelTime[i]}              \t|\n"+
                    "\t |                 \t|\t                       \t|\t                         \t|\n";
                }

                if (i != TaskTime.Length - 1)
                {
                    text += "\t |\t\t\t-------------------------------------------------------------------------\n";
                }
                else
                {
                    text += "\t ------------------------------------------------------------------------------------------------\n";
                }
            }

            for (int i = 0; i < ThreadTime.Length; i++)
            {
                if (i == 2)
                {
                    text += "\t |                 \t|\t                       \t|\t                         \t|\n"+
                    "\t |     Thread    "+
                    $"\t|\t       {Math.Pow(k, i)}             \t|\t           {ThreadTime[i]}              \t|\n"+
                    "\t |                 \t|\t                       \t|\t                         \t|\n";
                }
                else
                {
                    text += "\t |                 \t|\t                       \t|\t                         \t|\n"+
                    $"\t |                 \t|\t       {Math.Pow(k, i)}             \t|\t           {ThreadTime[i]}              \t|\n"+
                    "\t |                 \t|\t                       \t|\t                         \t|\n";
                }

                if (i != TaskTime.Length - 1)
                {
                    text += "\t |\t\t\t-------------------------------------------------------------------------\n";
                }
                else
                {
                    text += "\t ------------------------------------------------------------------------------------------------\n";
                }
            }
            using (var sw = new StreamWriter(@"log.txt", false))
            {
                sw.WriteLine(text);
            }
        }

        /// <summary>
        /// Заполнение матрицы рандомными значениями
        /// </summary>
        private void GenerateAndFillMatrix(int[,] matrix)
        {
            Random r = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = r.Next(-10, 10);
        }

        /// <summary>
        /// Вывод матрицы
        /// </summary>
        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"\t{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}

