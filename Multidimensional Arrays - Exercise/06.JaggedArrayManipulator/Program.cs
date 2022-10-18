using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                jaggedArray[row] = rowData;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                switch (commands[0])
                {
                    case "Add":
                        Add(int.Parse(commands[1]), int.Parse(commands[2]), int.Parse(commands[3]), jaggedArray);
                        break;
                    case "Subtract":
                        Subtract(int.Parse(commands[1]), int.Parse(commands[2]), int.Parse(commands[3]), jaggedArray);
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            PrintMatrix(jaggedArray);
        }

        static void Add(int row, int col, int value, double[][] jaggedArray)
        {
            if (row >= 0 && row < jaggedArray.Length
                && col >= 0 && col < jaggedArray[row].Length)
            {
                jaggedArray[row][col] += value;
            }
        }

        static void Subtract(int row, int col, int value, double[][] jaggedArray)
        {
            if (row >= 0 && row < jaggedArray.Length
                && col >= 0 && col < jaggedArray[row].Length)
            {
                jaggedArray[row][col] -= value;
            }
        }

        static void PrintMatrix(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].GetLength(0); col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}