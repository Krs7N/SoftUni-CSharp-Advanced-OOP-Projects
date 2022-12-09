namespace _03.Raiding.Models
{
    using Contracts;

    public class Rogue : BaseHero
    {
        public Rogue(string name)
        {
            this.Name = name;
            this.Power = 80;
        }

        public override string Name { get; }

        public override int Power { get; }

        public override string CastAbility() => $"{nameof(Rogue)} - {this.Name} hit for {this.Power} damage";
    }
}