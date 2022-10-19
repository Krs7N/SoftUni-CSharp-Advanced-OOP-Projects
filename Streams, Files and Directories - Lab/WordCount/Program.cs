using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"../../../words.txt";
            string textPath = @"../../../text.txt";
            string outputPath = @"../../../output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var countByWords = new Dictionary<string, int>();

            string[] inputWords = File.ReadAllText(wordsFilePath).Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var inputWord in inputWords)
            {
                countByWords.Add(inputWord, 0);
            }

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                Regex regex = new Regex("[a-z]+");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().ToLower();

                    MatchCollection matches = regex.Matches(line);

                    foreach (Match match in matches)
                    {
                        if (countByWords.ContainsKey(match.Value))
                        {
                            countByWords[match.Value]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var countByWord in countByWords)
                {
                    writer.WriteLine($"{countByWord.Key} - {countByWord.Value}");
                }
            }
        }
    }
}

