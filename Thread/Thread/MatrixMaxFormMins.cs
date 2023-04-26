using System;
using Thread;
namespace Thread
{
    /// <summary>
    /// Нахождение максимума среди минимумов по строкам 
    /// </summary>
    public class MatrixMaxFormMins
    {
        readonly int M;
        readonly int N;
        protected int[,] matrix;
        protected int[] mins;

        public MatrixMaxFormMins(int n, int m)
        {
            this.M = m;
            this.N = n;
            this.matrix = new int[N, M];
            this.mins = new int[N];
        }

        private void GenerateAndFillMatrix()
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    matrix[i, j] = r.Next(-10, 10);
        }

        private void PrintMatrix()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Вывод матрицы, минимумов матрицы по строкам и максимума из них
        /// </summary>
        public void GetMaxFromMins()
        {
            GenerateAndFillMatrix();
            PrintMatrix();
            Console.WriteLine();
            GetMinOnTasks();
            Console.WriteLine();
            int max = int.MinValue;
            for (int i = 0; i < N; i++)
                if (max < mins[i])
                    max = mins[i];

            Console.WriteLine($"Максимум из минимумов строк равен -> {max}");
        }

        private void GetMinOnTasks()
        {
            for (int i = 0; i < N; i++)
            {
                int row = i; // создаем копию переменной i для использования внутри лямбда-выражения
                Task.Run(() =>
                {
                    int min = matrix[row, 0];
                    for (int j = 1; j < M; j++)
                    {
                        if (matrix[row, j] < min)
                        {
                            min = matrix[row, j];
                        }
                    }
                    Console.WriteLine($"Минимум в строке {row + 1}: {min}");
                    mins[row] = min;
                });
            }

            Console.ReadKey();
        }

    }
}


