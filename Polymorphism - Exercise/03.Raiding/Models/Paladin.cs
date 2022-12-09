namespace _03.Raiding.Models
{
    using Contracts;

    public class Paladin : BaseHero
    {
        public Paladin(string name)
        {
            this.Name = name;
            this.Power = 100;
        }

        public override string Name { get; }

        public override int Power { get; }

        public override string CastAbility() => $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
    }
}