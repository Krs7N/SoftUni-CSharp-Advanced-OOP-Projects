using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            int sum = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
