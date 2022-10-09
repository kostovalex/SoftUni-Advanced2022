using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> func = s => char.IsUpper(s[0]);

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(func).ToArray();

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }

        }
        
    }
}
