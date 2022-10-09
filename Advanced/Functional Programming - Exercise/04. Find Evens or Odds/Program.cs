using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;
            
            int[] boundaries = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string evenOrOdd = Console.ReadLine();

            if (evenOrOdd=="even")
            {
                for (int i = boundaries[0]; i <= boundaries[1]; i++)
                {
                    if (isEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            else
            {
                for (int i = boundaries[0]; i <= boundaries[1]; i++)
                {
                    if (!isEven(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }

        }
    }
}
