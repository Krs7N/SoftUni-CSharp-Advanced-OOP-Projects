namespace _04.WildFarm.Models.Contracts
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        
        public abstract int Quantity { get; protected set; }
    }
}