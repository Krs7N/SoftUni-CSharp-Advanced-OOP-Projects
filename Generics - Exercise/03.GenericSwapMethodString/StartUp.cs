﻿using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int countOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBoxes; i++)
            {
                string input = Console.ReadLine();

                box.Sentences.Add(input);
            }

            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            box.Swap(indexes[0], indexes[1]);

            Console.WriteLine(box);
        }
    }
}