using _04.WildFarm.Models.Contracts;

namespace _04.WildFarm.Factories.Contracts
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string[] cmdArgs);
    }
}