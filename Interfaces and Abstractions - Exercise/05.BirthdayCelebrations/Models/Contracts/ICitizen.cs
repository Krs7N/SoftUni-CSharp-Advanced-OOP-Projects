namespace _05.BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen
    {
        string Name { get; }

        int Age { get; }

        string Id { get; }

        string Birthdate { get; }
    }
}