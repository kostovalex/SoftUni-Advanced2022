using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> range = new List<int>();            
            for (int i = 1; i <= endOfRange; i++)
            {
                range.Add(i);
            }

            Func<List<int>, List<int>> checker = DividerChecker(range, dividers);

            Console.WriteLine(string.Join(" ", checker(range)));
        }

        private static Func<List<int>, List<int>> DividerChecker(List<int> range, List<int> dividers)
        {
            
            List<int> divisable = new List<int>();
  
            for (int i = 0; i < range.Count; i++)
            {
                bool isDivisable = true;
                
                for (int j = 0; j < dividers.Count; j++)
                {
                    if (range[i] % dividers[j]!=0)
                    {
                        isDivisable = false;
                    }
                }
                
                if (isDivisable)
                {
                    divisable.Add(range[i]);
                }
            }

            return range => range = divisable;
        }
    }
}
