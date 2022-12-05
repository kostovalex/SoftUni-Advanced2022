
namespace Raiding
{
    using System;
    using Core;
    using Core.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
