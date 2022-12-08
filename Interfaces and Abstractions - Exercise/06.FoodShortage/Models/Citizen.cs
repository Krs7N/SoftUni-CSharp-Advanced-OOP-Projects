namespace _06.FoodShortage.Models
{
    using Contracts;

    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public string Birthdate { get; }

        public int Food { get; private set; }

        public void BuyFood() => Food += 10;
    }
}