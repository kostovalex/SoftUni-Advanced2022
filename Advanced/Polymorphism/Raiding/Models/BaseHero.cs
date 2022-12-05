namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        private string name;
        private int power;

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get => name; set => name = value; }
        public int Power { get => power; set => power = value; }

        public abstract string CastAbility();
        
    }
}
