using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            Lake myLake = new Lake(input);

            Console.WriteLine(string.Join(", ", myLake));
        }
    }
}
