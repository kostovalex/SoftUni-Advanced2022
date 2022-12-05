namespace Raiding.Models
{
    public interface IHero
    {
        string Name { get; }
        public int Power { get; }
        string CastAbility();
    }
}
