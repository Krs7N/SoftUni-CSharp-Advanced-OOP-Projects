using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songsInQueue = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var songQueue = new Queue<string>(songsInQueue);

            while (songQueue.Any())
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Play":
                        songQueue.Dequeue();
                        break;
                    case "Add":
                        string songName = string.Join(' ', commands.Skip(1));
                        if (songQueue.Contains(songName))
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        else
                        {
                            songQueue.Enqueue(songName);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}