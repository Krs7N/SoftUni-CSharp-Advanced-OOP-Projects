namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        public const double GingerbreadPrice = 4;

        public Gingerbread(string delicacyName) : base(delicacyName, GingerbreadPrice)
        {
        }
    }
}