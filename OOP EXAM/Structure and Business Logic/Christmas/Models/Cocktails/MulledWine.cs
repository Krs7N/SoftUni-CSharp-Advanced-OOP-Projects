namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        public const double PriceForLargeMulledWine = 13.5;

        public MulledWine(string cocktailName, string size) : base(cocktailName, size, PriceForLargeMulledWine)
        {
        }
    }
}