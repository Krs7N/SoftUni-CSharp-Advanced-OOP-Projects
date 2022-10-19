using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var priceByProductsByShops = new Dictionary<string, Dictionary<string, double>>();

            string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (tokens[0] != "Revision")
            {
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!priceByProductsByShops.ContainsKey(shop))
                {
                    priceByProductsByShops.Add(shop, new Dictionary<string, double>());
                }

                priceByProductsByShops[shop].Add(product, price);

                tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            priceByProductsByShops = priceByProductsByShops.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var priceByProductsByShop in priceByProductsByShops)
            {
                Console.WriteLine($"{priceByProductsByShop.Key}->");

                foreach (var priceByProduct in priceByProductsByShop.Value)
                {
                    Console.WriteLine($"Product: {priceByProduct.Key}, Price: {priceByProduct.Value}");
                }
            }
        }
    }
}