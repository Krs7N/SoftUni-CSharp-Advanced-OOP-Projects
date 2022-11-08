namespace _03.ShoppingSpree.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                money = value;
            }
        }

        public void ReduceMoney(int cost) => Money -= cost;

        public void AddProduct(Product product) => products.Add(product);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Name} - ")
                .AppendLine(products.Count == 0 ? "Nothing bought" : string.Join(", ", products));

            return sb.ToString().Trim();
        }
    }
}