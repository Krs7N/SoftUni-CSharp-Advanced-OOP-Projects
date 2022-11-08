namespace _03.ShoppingSpree.Models
{
    using System;

    public class Product
    {
        private string name;

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
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

        public int Cost { get; set; }

        public override string ToString() => Name;
        
    }
}
