using System;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            string[,] matrix = new string[size, size];

            var trackedCar = matrix[0, 0];
            int kilometersPassed = 0;

            for (int row = 0; row < size; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string directions = Console.ReadLine();

            int currentRow = 0;
            int currentCol = 0;
            bool isTunnelExit = false;

            while (directions != "End")
            {
                switch (directions)
                {
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                }

                if (matrix[currentRow, currentCol] == ".")
                {
                    kilometersPassed += 10;
                }
                else if (matrix[currentRow, currentCol] == "T")
                {
                    matrix[currentRow, currentCol] = ".";
                    kilometersPassed += 30;

                    for (int curRow = 0; curRow < matrix.GetLength(0); curRow++)
                    {
                        for (int curCol = 0; curCol < matrix.GetLength(1); curCol++)
                        {
                            if (matrix[curRow, curCol] == "T")
                            {
                                matrix[curRow, curCol] = ".";
                                currentRow = curRow;
                                currentCol = curCol;

                                isTunnelExit = true;
                                break;
                            }
                        }

                        if (isTunnelExit)
                        {
                            break;
                        }
                    }
                }
                else if (matrix[currentRow, currentCol] == "F")
                {
                    kilometersPassed += 10;
                    matrix[currentRow, currentCol] = "C";
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    break;
                }


                directions = Console.ReadLine();
            }

            if (matrix[currentRow, currentCol] != "C")
            {
                matrix[currentRow, currentCol] = "C";
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometersPassed} km.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}