using System;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            long[][] pascal = new long[inputNumber][];

            for (int row = 0; row < inputNumber; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                { 
                    long curValue = 0;

                    if (row == 0)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }

                    if (col > 0 && row > 0)
                    {
                        curValue += pascal[row - 1][col - 1];
                    }

                    if (pascal[row].Length - 1 > col)
                    {
                        curValue += pascal[row - 1][col];
                    }

                    pascal[row][col] = curValue;
                }
            }

            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}