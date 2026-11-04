using System;
using System.Text;
using System.Windows;

namespace Task3_WPF1D
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TxtN.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введіть коректне ціле додатне число n!", "Помилка вводу", MessageBoxButton.OK, MessageBoxImage.Warning);
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

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Початковий масив (індекс : значення):");
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append($"[{i}]: {arr[i]}   ");
            }
            sb.AppendLine("\n");

            int minIndex = 0;
            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex]) minIndex = i;
                if (arr[i] > arr[maxIndex]) maxIndex = i;
            }

            sb.AppendLine($"Мінімальний елемент: arr[{minIndex}] = {arr[minIndex]}");
            sb.AppendLine($"Максимальний елемент: arr[{maxIndex}] = {arr[maxIndex]}");
            sb.AppendLine(new string('-', 60));

            int startIndex = Math.Min(minIndex, maxIndex) + 1;
            int endIndex = Math.Max(minIndex, maxIndex) - 1;
            int countBetween = endIndex - startIndex + 1;

            if (countBetween <= 0)
            {
                sb.AppendLine("1. Між min та max немає жодного елемента.");
            }
            else
            {
                long indexProduct = 1;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    indexProduct *= i;
                }
                sb.AppendLine($"1. Добуток індексів між min та max (від {startIndex} до {endIndex}): {indexProduct}");
            }
            sb.Append("Масив після 1-ї дії: ");
            foreach (double elem in arr)
            {
                sb.Append(elem + "  ");
            }
            sb.AppendLine("\n" + new string('-', 60));

            if (countBetween > 1)
            {
                Array.Sort(arr, startIndex, countBetween);
                Array.Reverse(arr, startIndex, countBetween);
                sb.AppendLine("2. Елементи між min та max впорядковано за спаданням:");
            }
            else
            {
                sb.AppendLine("2. Сортування не потрібне (між min та max менше 2 елементів):");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append($"[{i}]: {arr[i]}   ");
            }
            sb.AppendLine();

            TxtOutput.Text = sb.ToString();
        }
    }
}