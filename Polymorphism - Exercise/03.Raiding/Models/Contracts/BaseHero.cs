namespace _03.Raiding.Models.Contracts
{
    public abstract class BaseHero
    {
        public abstract string Name { get; }

        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}