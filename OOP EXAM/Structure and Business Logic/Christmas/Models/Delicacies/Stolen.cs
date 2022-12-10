namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        public const double StolenPrice = 3.5;
        public Stolen(string delicacyName) : base(delicacyName, StolenPrice)
        {
        }
    }
}