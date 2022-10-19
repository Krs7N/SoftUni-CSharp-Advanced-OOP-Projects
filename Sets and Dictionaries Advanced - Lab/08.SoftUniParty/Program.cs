using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var VIPs = new HashSet<string>();
            var regulars = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    VIPs.Add(command);
                }
                else
                {
                    regulars.Add(command);
                }

                command = Console.ReadLine();
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (VIPs.Contains(command))
                {
                    VIPs.Remove(command);
                }
                else
                {
                    regulars.Remove(command);
                }
            }

            Console.WriteLine(VIPs.Count + regulars.Count);

            if (VIPs.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, VIPs));
            }

            if (regulars.Count > 0)
            {

                Console.WriteLine(string.Join(Environment.NewLine, regulars));
            }
        }
    }
}