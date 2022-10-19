namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (var reader = new StreamReader(inputFilePath))
            {
                int row = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    char[] charsToReplace = { '-', ',', '.', '!', '?' };

                    if (row % 2 == 0)
                    {
                        foreach (var ch in charsToReplace)
                        {
                            if (line.Contains(ch))
                            {
                                line = line.Replace(ch, '@');
                            }
                        }

                        string[] reversedLine =
                            line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

                        line = string.Join(' ', reversedLine);

                        sb.AppendLine(line);
                    }

                    row++;
                }
            }

            return sb.ToString().Trim();
        }
    }
}