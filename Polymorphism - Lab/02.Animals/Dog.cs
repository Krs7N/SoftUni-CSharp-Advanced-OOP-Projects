namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf() => $"I am {this.Name} and my favourite food is {this.FavouriteFood} DJAAF";
    }
}