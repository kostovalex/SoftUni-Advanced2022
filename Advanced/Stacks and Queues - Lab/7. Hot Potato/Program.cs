using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int hotNumber = int.Parse(Console.ReadLine());

            int count = 1;

            while (children.Count != 1)
            {
                if (count == hotNumber)
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    count = 1;
                }
                else
                {
                    count++;
                    string passedPlayer = children.Dequeue();
                    children.Enqueue(passedPlayer);
                }
            }
            
            Console.WriteLine($"Last is {children.Peek()}");
        }
    }
}
