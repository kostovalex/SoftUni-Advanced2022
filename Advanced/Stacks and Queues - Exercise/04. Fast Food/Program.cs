using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            
            Console.WriteLine(queue.Max());

            while (true)
            {                
                if (queue.Count>0)
                {
                    int currentOrder = queue.Peek();
                    if (currentOrder <= foodQuantity)
                    {
                        foodQuantity -= currentOrder;
                        queue.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Orders complete");
                    return;
                }   
                
            }
        }
    }
}
