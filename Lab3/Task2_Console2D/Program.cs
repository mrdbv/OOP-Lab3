using System;
using System.Text;

namespace Task2_Console2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть кількість рядків матриці n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            Console.Write("Введіть кількість стовпців матриці m: ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0) return;

            double[,] matrix = new double[n, m];
            Random rnd = new Random();
            double minVal = -15.62;
            double maxVal = 53.36;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    double d = minVal + rnd.NextDouble() * (maxVal - minVal);
                    matrix[i, j] = Math.Round(d, 2);
                }
            }

            Console.WriteLine("\nПочаткова матриця:");
            PrintMatrix(matrix);

            int rowsWithoutPositives = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int posCount = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        posCount++;
                    }
                }
                if (posCount == 0)
                {
                    rowsWithoutPositives++;
                }
            }

            Console.WriteLine($"\n1. Кількість рядків, які не містять жодного додатного елемента: {rowsWithoutPositives}");
            Console.WriteLine("Матриця після першої дії:");
            PrintMatrix(matrix);

            double[] colSums = new double[m];
            for (int j = 0; j < m; j++)
            {
                double sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += Math.Abs(matrix[i, j]); 
                    }
                }
                colSums[j] = Math.Round(sum, 2);
            }

            Console.WriteLine("\nСуми модулів додатних елементів по стовпцях (до перестановки):");
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{colSums[j],8}\t");
            }
            Console.WriteLine();

            for (int pass = 0; pass < m - 1; pass++)
            {
                for (int j = 0; j < m - 1 - pass; j++)
                {
                    if (colSums[j] < colSums[j + 1])
                    {
                        double tempSum = colSums[j];
                        colSums[j] = colSums[j + 1];
                        colSums[j + 1] = tempSum;

                        for (int i = 0; i < n; i++)
                        {
                            double tempElem = matrix[i, j];
                            matrix[i, j] = matrix[i, j + 1];
                            matrix[i, j + 1] = tempElem;
                        }
                    }
                }
            }

            Console.WriteLine("\n2. Матриця після перестановки стовпців за спаданням сум додатних елементів:");
            PrintMatrix(matrix);

            Console.WriteLine("Суми стовпців після перестановки:");
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{colSums[j],8}\t");
            }
            Console.WriteLine();

            Console.ReadKey();
        }

        static void PrintMatrix(double[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write($"{mat[i, j],8}\t");
                }
                Console.WriteLine();
            }
        }
    }
}