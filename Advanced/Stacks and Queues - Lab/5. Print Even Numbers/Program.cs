using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfInts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ints = new Queue<int>();

            foreach (var item in arrayOfInts)
            {
                if (item%2==0)
                {
                    ints.Enqueue(item);
                }
            }
            Console.WriteLine(String.Join(", ", ints));
        }
    }
}
