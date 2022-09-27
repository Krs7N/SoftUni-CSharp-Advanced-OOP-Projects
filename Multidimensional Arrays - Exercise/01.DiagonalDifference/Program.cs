using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            //for (int i = 0, j = size - 1; i < size; i++, j--)
            //{
            //    primaryDiagonalSum += matrix[i, i];
            //    secondaryDiagonalSum += matrix[i, j];
            //}

            for (int i = 0; i < size; i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }

            int row = 0;

            for (int i = size - 1; i >= 0; i--)
            {
                secondaryDiagonalSum += matrix[row, i];
                row++;
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
