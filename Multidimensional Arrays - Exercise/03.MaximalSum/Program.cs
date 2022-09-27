using System;
using System.Linq;

namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int[,] subMatrix = new int[3, 3];
            int bestSum = int.MinValue;
            int curSum;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int topLeftElement = matrix[row, col];
                    int topCenterElement = matrix[row, col + 1];
                    int topRightElement = matrix[row, col + 2];
                    int centerLeftElement = matrix[row + 1, col];
                    int centerCenterElement = matrix[row + 1, col + 1];
                    int centerRightElement = matrix[row + 1, col + 2];
                    int bottomLeftElement = matrix[row + 2, col];
                    int bottomCenterElement = matrix[row + 2, col + 1];
                    int bottomRightElement = matrix[row + 2, col + 2];

                    curSum = topLeftElement + topCenterElement + topRightElement + centerCenterElement +
                             centerLeftElement + centerRightElement + bottomRightElement + bottomLeftElement +
                             bottomCenterElement;

                    if (curSum > bestSum)
                    {
                        bestSum = curSum;
                        subMatrix = new[,]
                        {
                            { topLeftElement, topCenterElement, topRightElement },
                            { centerLeftElement, centerCenterElement, centerRightElement },
                            { bottomLeftElement, bottomCenterElement, bottomRightElement }
                        };
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");
            for (int row = 0; row < subMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < subMatrix.GetLength(1); col++)
                {
                    Console.Write(subMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}