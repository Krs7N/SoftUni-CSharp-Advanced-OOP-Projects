using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                {
                    switch (command[0])
                    {
                        case "Add":
                            matrix[row, col] += value;
                            break;
                        default:
                            matrix[row, col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}