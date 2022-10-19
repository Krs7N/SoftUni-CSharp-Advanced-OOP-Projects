using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothesCountByTypesByColors = new Dictionary<string, Dictionary<string, int>>();

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string[] clothesData = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                if (!clothesCountByTypesByColors.ContainsKey(clothesData[0]))
                {
                    clothesCountByTypesByColors.Add(clothesData[0], new Dictionary<string, int>());
                }

                for (int j = 1; j < clothesData.Length; j++)
                {
                    if (!clothesCountByTypesByColors[clothesData[0]].ContainsKey(clothesData[j]))
                    {
                        clothesCountByTypesByColors[clothesData[0]].Add(clothesData[j], 0);
                    }

                    clothesCountByTypesByColors[clothesData[0]][clothesData[j]]++;
                }
            }

            string[] clothToLookFor = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var clothesCountByTypeByColor in clothesCountByTypesByColors)
            {
                Console.WriteLine($"{clothesCountByTypeByColor.Key} clothes:");

                foreach (var clothCount in clothesCountByTypeByColor.Value)
                {
                    if (clothesCountByTypeByColor.Key == clothToLookFor[0] && clothCount.Key == clothToLookFor[1])
                    {
                        Console.WriteLine($"* {clothCount.Key} - {clothCount.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothCount.Key} - {clothCount.Value}");
                    }
                }
            }
        }
    }
}