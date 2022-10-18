using System;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            if (rowsAndCols <= 2)
            {
                Console.WriteLine(0);

                return;
            }

            int removedKnights = 0;

            while (true)
            {
                int mostAttackedByOneKnight = 0;
                int highestAttackerRow = 0;
                int highestAttackerCol = 0;

                for (int row = 0; row < rowsAndCols; row++)
                {
                    for (int col = 0; col < rowsAndCols; col++)
                    {
                        int currentAttacker = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if (IsCellValid(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (IsCellValid(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentAttacker++;
                            }

                            if (mostAttackedByOneKnight < currentAttacker)
                            {
                                mostAttackedByOneKnight = currentAttacker;
                                highestAttackerRow = row;
                                highestAttackerCol = col;
                            }
                        }

                    }
                }

                if (mostAttackedByOneKnight == 0)
                {
                    break;
                }

                matrix[highestAttackerRow, highestAttackerCol] = '0';
                removedKnights++;
            }

            Console.WriteLine(removedKnights);
        }

        static bool IsCellValid(int row, int col, char[,] matrix) =>
            row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}