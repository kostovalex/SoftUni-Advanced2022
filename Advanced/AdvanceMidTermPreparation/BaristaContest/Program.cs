using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuants = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milkQuants = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> bevarages = new Dictionary<string, int>();

            while (coffeeQuants.Count != 0 && milkQuants.Count  != 0)
            {
                int currentMilk = milkQuants.Pop();
                int currentCoffee = coffeeQuants.Dequeue();

                int currentQuant = currentCoffee + currentMilk;          

                switch (currentQuant)
                {
                    case 200:
                        if (!bevarages.ContainsKey("Latte"))
                        {
                            bevarages.Add("Latte", 0);
                        }
                        bevarages["Latte"]++;
                        break;
                    case 150:
                        if (!bevarages.ContainsKey("Americano"))
                        {
                            bevarages.Add("Americano", 0);
                        }
                        bevarages["Americano"]++;
                        break;
                    case 100:
                        if (!bevarages.ContainsKey("Capuccino"))
                        {
                            bevarages.Add("Capuccino", 0);
                        }
                        bevarages["Capuccino"]++;
                        break;
                    case 75:
                        if (!bevarages.ContainsKey("Espresso"))
                        {
                            bevarages.Add("Espresso", 0);
                        }
                        bevarages["Espresso"]++;
                        break;
                    case 50:
                        if (!bevarages.ContainsKey("Cortado"))
                        {
                            bevarages.Add("Cortado", 0);
                        }
                        bevarages["Cortado"]++;
                        break;
                    default:
                        currentMilk -= 5;
                        milkQuants.Push(currentMilk);
                        break;
                }
            }


            if (coffeeQuants.Count == 0 && milkQuants.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQuants.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuants)}");
            }
            
            if (milkQuants.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: { string.Join(", ", milkQuants)}");
            }

            bevarages = bevarages.OrderBy(b => b.Value).ThenByDescending(b => b.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in bevarages)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
