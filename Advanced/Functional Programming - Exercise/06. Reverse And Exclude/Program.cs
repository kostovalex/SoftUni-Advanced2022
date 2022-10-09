using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<int> collection = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            
            Func<List<int>, List<int>> listReversing = ListReverser(collection);
            
            Predicate<int> isDivisable = n=> n%divider != 0;
            
            Console.WriteLine(string.Join(" ", listReversing(collection).Where(n=>isDivisable(n))));

        }

        public static Func<List<int>, List<int>> ListReverser(List<int> collection)
        {
            
            List<int> reversedList = new List<int>();

            for (int i = collection.Count-1; i >=0; i--)
            {
                reversedList.Add(collection[i]);
            }

            return collection => collection = reversedList;
            
        }
    }
}
