namespace _04.WildFarm.Models
{
    using Contracts;

    public class Meat : Food
    {
        public Meat(int quantity) : base(quantity)
        {
        }

        public override int Quantity { get; protected set; }

    }
}