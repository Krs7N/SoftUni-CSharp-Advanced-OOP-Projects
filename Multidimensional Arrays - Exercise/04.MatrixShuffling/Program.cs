using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "END")
            {
                if (IsValidCommand(rows, cols, commands))
                {
                    string tempValue = matrix[int.Parse(commands[1]), int.Parse(commands[2])];
                    matrix[int.Parse(commands[1]), int.Parse(commands[2])] = matrix[int.Parse(commands[3]), int.Parse(commands[4])];
                    matrix[int.Parse(commands[3]), int.Parse(commands[4])] = tempValue;

                    PrintMatrix(rows, cols, matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static bool IsValidCommand(int rows, int cols, string[] commands)
        {
            return commands.Length == 5
                                && commands[0] == "swap"
                                && int.Parse(commands[1]) >= 0 && int.Parse(commands[1]) < rows
                                && int.Parse(commands[2]) >= 0 && int.Parse(commands[2]) < cols
                                && int.Parse(commands[3]) >= 0 && int.Parse(commands[3]) < rows
                                && int.Parse(commands[4]) >= 0 && int.Parse(commands[4]) < cols;
        }

        static void PrintMatrix(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}