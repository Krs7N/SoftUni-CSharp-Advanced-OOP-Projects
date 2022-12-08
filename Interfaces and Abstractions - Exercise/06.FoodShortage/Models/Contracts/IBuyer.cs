namespace _06.FoodShortage.Models.Contracts
{
    public interface IBuyer
    {
        void BuyFood();

        int Food { get; }
    }
}