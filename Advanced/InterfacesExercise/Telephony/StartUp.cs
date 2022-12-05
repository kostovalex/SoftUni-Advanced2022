using Telephony.Core;
using Telephony.IO;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
