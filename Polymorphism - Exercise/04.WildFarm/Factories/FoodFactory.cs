using _04.WildFarm.Exceptions;
using _04.WildFarm.Factories.Contracts;
using _04.WildFarm.Models;
using _04.WildFarm.Models.Contracts;

namespace _04.WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            Food food;
            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidFoodTypeException();
            }

            return food;
        }
    }
}