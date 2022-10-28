using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Lizard lizard = new Lizard("lizard");

            Console.WriteLine(lizard.Name);
        }
    }
}