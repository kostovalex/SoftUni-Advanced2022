
namespace Raiding.Factories
{
    using Raiding.Models;
    using Raiding.Exceptions;
    public class Factory : IFactory
    {
        public Factory()
        {

        }

        public IHero CreateHero(string name, string type)
        {
            IHero hero;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidTypeException("Invalid hero!");
            }
            return hero;
        }
    }
}
