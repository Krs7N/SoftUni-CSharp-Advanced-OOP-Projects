using System;
using System.Linq;

namespace _02._2X2SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            if (rows < 2 && cols < 2)
            {
                Console.WriteLine(0);
                return;
            }

            int squareMatrixCount = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char topLeftElement = matrix[row, col];
                    char topRightElement = matrix[row, col + 1];
                    char bottomLeftElement = matrix[row + 1, col];
                    char bottomRightElement = matrix[row + 1, col + 1];

                    if (topLeftElement == topRightElement 
                        && topLeftElement == bottomLeftElement
                        && topLeftElement == bottomRightElement)
                    {
                        squareMatrixCount++;
                    }
                }
            }

            Console.WriteLine(squareMatrixCount);
        }
    }
}