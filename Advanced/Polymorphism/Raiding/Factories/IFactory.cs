
namespace Raiding.Factories
{
    using Raiding.Models;
    public interface IFactory
    {
        IHero CreateHero(string name, string type);
    }
}
