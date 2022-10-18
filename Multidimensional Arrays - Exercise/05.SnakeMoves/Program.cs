using System;
using System.Linq;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string snakeWord = Console.ReadLine();

            char[,] matrix = new char[rows, cols];

            int curWordIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    curWordIndex = PrintRow(row, cols, snakeWord, matrix, curWordIndex);
                }
                else
                {
                    curWordIndex = PrintReversedRow(row, cols, snakeWord, matrix, curWordIndex);
                }
            }

            PrintMatrix(matrix);
        }

        static int PrintRow(int row, int cols, string snakeWord, char[,] matrix, int curWordIndex)
        {
            for (int col = 0; col < cols; col++)
            {
                if (curWordIndex == snakeWord.Length)
                {
                    curWordIndex = 0;
                }

                matrix[row, col] = snakeWord[curWordIndex++];
            }

            return curWordIndex;
        }

        static int PrintReversedRow(int row, int cols, string snakeWord, char[,] matrix, int curWordIndex)
        {
            for (int col = cols - 1; col >= 0; col--)
            {
                if (curWordIndex == snakeWord.Length)
                {
                    curWordIndex = 0;
                }

                matrix[row, col] = snakeWord[curWordIndex++];
            }

            return curWordIndex;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}