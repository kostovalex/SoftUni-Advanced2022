using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = name => Console.WriteLine($"Sir {name}");
             
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                printer(item);
            }
        }
    }
}
