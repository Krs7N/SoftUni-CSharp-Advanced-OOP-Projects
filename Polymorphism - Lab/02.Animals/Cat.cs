namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf() => $"I am {this.Name} and my favourite food is {this.FavouriteFood} MEEOW";
    }
}