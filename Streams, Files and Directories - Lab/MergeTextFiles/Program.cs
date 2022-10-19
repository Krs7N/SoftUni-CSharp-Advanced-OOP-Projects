using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"../../../input1.txt";
            var secondInputFilePath = @"../../../input2.txt";
            var outputFilePath = @"../../../output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var reader = new StreamReader(firstInputFilePath))
            {
                using (var secondReader = new StreamReader(secondInputFilePath))
                {
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        while (!reader.EndOfStream || !secondReader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string secondLine = secondReader.ReadLine();

                            if (line != null)
                            {
                                writer.WriteLine(line);
                            }

                            if (secondLine != null)
                            {
                                writer.WriteLine(secondLine);
                            }
                        }
                    }
                }
            }
        }
    }
}

