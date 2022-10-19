using System;
using System.IO;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = File.ReadAllLines(inputFilePath);

            int lineCount = 1;


            foreach (var line in lines)
            {
                int letters = 0;
                int punctuationMarks = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsLetter(line[i]))
                    {
                        letters++;
                    }

                    if (char.IsPunctuation(line[i]))
                    {
                        punctuationMarks++;
                    }

                }

                sb.AppendLine($"Line {lineCount++}: {line} ({letters})({punctuationMarks})");
            }

            File.WriteAllText(outputFilePath, sb.ToString().Trim());
        }
    }
}