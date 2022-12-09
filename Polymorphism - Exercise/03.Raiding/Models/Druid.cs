namespace _03.Raiding.Models
{
    using Contracts;

    public class Druid : BaseHero
    {
        public Druid(string name)
        {
            this.Name = name;
            this.Power = 80;
        }

        public override string Name { get; }

        public override int Power { get; }

        public override string CastAbility() => $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
    }
}