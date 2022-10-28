using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("Blader", 10);

            Console.WriteLine(bladeKnight);
        }
    }
}