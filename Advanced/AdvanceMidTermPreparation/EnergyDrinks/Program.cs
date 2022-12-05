using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> mgOfCaff = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> drinksCount = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int maxCaff = 0;

            while (mgOfCaff.Count != 0 && drinksCount.Count != 0)
            {
                int currentCaff = mgOfCaff.Pop();
                int currentDrink = drinksCount.Dequeue();
                int currentResult = currentCaff * currentDrink;

                if (maxCaff + currentResult <= 300)
                {
                    maxCaff += currentResult;
                }
                else
                {
                    drinksCount.Enqueue(currentDrink);
                    if (maxCaff - 30 > 0)
                    {
                        maxCaff -= 30;
                    }
                    else
                    {
                        maxCaff = 0;
                    }
                }
            }

            if (drinksCount.Count != 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", " , drinksCount)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {maxCaff} mg caffeine.");
        }
    }
}
