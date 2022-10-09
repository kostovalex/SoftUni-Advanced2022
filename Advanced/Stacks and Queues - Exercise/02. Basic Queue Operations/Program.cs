using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int numsToDequeue = parameters[1];
            int numToFind = parameters[2];

            if (numsToDequeue<= queue.Count)
            {
                for (int i = 0; i < numsToDequeue; i++)
                {
                    queue.Dequeue();
                }
            }
            
            if (queue.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (queue.Contains(numToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
