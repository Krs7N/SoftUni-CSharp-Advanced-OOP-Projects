namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        public const double LargeHibernation = 10.5;

        public Hibernation(string cocktailName, string size) : base(cocktailName, size, LargeHibernation)
        {
        }
    }
}