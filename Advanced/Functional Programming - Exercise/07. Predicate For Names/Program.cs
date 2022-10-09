using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int desiredLength = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            Predicate<string> checker = n=> n.Length<= desiredLength;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(name=>checker(name))));
        }
    }
}
