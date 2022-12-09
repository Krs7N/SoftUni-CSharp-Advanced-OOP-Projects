namespace _04.WildFarm.Factories.Contracts
{
    using Models.Contracts;

    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}