using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int[,] biggestSubMatrix = new int[2, 2];
            int biggestSum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = 0;

                    int topLeftElement = matrix[row, col];
                    int topRightElement = matrix[row, col + 1];
                    int bottomLeftElement = matrix[row + 1, col];
                    int bottomRightElement = matrix[row + 1, col + 1];

                    sum += topLeftElement + topRightElement + bottomLeftElement + bottomRightElement;

                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestSubMatrix = new[,] { { topLeftElement, topRightElement }, { bottomLeftElement, bottomRightElement } };
                    }
                }
            }

            for (int row = 0; row < biggestSubMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < biggestSubMatrix.GetLength(1); col++)
                {
                    Console.Write(biggestSubMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}