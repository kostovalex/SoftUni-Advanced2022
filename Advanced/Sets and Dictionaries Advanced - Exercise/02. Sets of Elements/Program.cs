using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setLengths = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>(setLengths[0]);
            HashSet<int> secondSet = new HashSet<int>(setLengths[1]);

            for (int i = 0; i < setLengths[0]; i++)
            {
                int input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }
            
            for (int i = 0; i < setLengths[1]; i++)
            {
                int input = int.Parse(Console.ReadLine());
                secondSet.Add(input);
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ",firstSet));

        }
    }
}
