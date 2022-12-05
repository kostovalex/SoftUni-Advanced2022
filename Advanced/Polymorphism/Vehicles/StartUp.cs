namespace Vehicles
{
    using System;
    using Vehicles.Core;
    using Vehicles.IO;
    using Vehicles.IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter consoleWriter = new ConsoleWriter();
            IReader consoleReader = new ConsoleReader();

            Engine engine = new Engine(consoleReader, consoleWriter);
            engine.Run();
        }
    }
}
