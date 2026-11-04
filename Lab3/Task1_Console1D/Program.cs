using System;
using System.Text;

namespace Task1_Console1D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть кількість елементів масиву n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Помилка: введіть коректне натуральне число.");
                return;
            }

            double[] arr = new double[n];
            Random rnd = new Random();
            double minVal = -2.9;
            double maxVal = 60.3;

            for (int i = 0; i < arr.Length; i++)
            {
                double d = minVal + rnd.NextDouble() * (maxVal - minVal);
                arr[i] = Math.Round(d, 1);
            }
            Console.WriteLine("\nПочатковий масив:");
            foreach (double elem in arr)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();

            Console.WriteLine("Індекси елементів:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"[{i}]\t");
            }
            Console.WriteLine("\n");

            int minIndex = 0;
            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex]) minIndex = i;
                if (arr[i] > arr[maxIndex]) maxIndex = i;
            }

            Console.WriteLine($"Мінімальний елемент: arr[{minIndex}] = {arr[minIndex]}");
            Console.WriteLine($"Максимальний елемент: arr[{maxIndex}] = {arr[maxIndex]}");

            int startIndex = Math.Min(minIndex, maxIndex) + 1;
            int endIndex = Math.Max(minIndex, maxIndex) - 1;
            int countBetween = endIndex - startIndex + 1;

            if (countBetween <= 0)
            {
                Console.WriteLine("\n1. Між мінімальним і максимальним елементами немає інших елементів.");
            }
            else
            {
                long indexProduct = 1;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    indexProduct *= i;
                }
                Console.WriteLine($"\n1. Добуток індексів елементів між min та max (індекси від {startIndex} до {endIndex}): {indexProduct}");
            }
            Console.WriteLine("Масив після першої дії:");
            foreach (double elem in arr)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();

            if (countBetween > 1)
            {
                Array.Sort(arr, startIndex, countBetween);
                Array.Reverse(arr, startIndex, countBetween);
                Console.WriteLine("\n2. Елементи між min та max впорядковано за спаданням:");
            }
            else
            {
                Console.WriteLine("\n2. Недостатньо елементів між min та max для сортування. Масив без змін:");
            }

            foreach (double elem in arr)
            {
                Console.Write(elem + "\t");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}