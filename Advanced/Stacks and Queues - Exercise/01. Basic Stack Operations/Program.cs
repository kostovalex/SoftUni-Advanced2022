using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int numbersToPop = parameters[1];
            int numberToFind = parameters[2];

            for (int i = 0; i < numbersToPop; i++)
            {
                if (numbers.Count>0)
                {
                    numbers.Pop();
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (numbers.Contains(numberToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}
