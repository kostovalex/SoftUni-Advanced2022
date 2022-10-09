using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = name => Console.WriteLine(name);
            
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printer(string.Join(Environment.NewLine, input));

        }
    }
}
