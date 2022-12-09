namespace _03.Raiding.Models
{
    using Contracts;

    public class Warrior : BaseHero
    {
        public Warrior(string name)
        {
            this.Name = name;
            this.Power = 100;
        }

        public override string Name { get; }

        public override int Power { get; }

        public override string CastAbility() => $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
    }
}