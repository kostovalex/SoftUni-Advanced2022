namespace BorderControl.IO
{
    using System;

    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
