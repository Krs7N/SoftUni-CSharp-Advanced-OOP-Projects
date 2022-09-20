using System;

namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                string text = Console.ReadLine();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = text[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}