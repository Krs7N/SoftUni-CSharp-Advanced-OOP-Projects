using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"../../../input.txt";
            string outputFilePath = @"../../../output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader streamReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int row = 0;
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                        if (row % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        row++;
                    }
                }
            }
        }
    }
}

