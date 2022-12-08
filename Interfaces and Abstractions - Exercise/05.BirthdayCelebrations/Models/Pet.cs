namespace _05.BirthdayCelebrations.Models
{
    using Contracts;

    public class Pet : IPet
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }

        public string Birthdate { get; }
    }
}