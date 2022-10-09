using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            
            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList(); 
                periodicTable.UnionWith(input);
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
