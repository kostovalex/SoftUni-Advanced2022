using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceMidTermPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> location = new Dictionary<string, int>();
            
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            
            int smallerCount = whiteTiles.Count.CompareTo(greyTiles.Count); 
            
            while (whiteTiles.Count != 0 && greyTiles.Count != 0)
            {
                int currentWhite = whiteTiles.Pop();
                int currentGrey = greyTiles.Dequeue();

                if (currentGrey == currentWhite)
                {
                    int sumArea = currentWhite + currentGrey;
                    
                    switch (sumArea)
                    {
                        case 70:
                            if (!location.ContainsKey("Wall"))
                            {
                                location.Add("Wall", 0);
                            }
                            location["Wall"]++;
                            break;
                        case 60:
                            if (!location.ContainsKey("Countertop"))
                            {
                                location.Add("Countertop", 0);
                            }
                            location["Countertop"]++;
                            break;
                        case 50:
                            if (!location.ContainsKey("Oven"))
                            {
                                location.Add("Oven", 0);
                            }
                            location["Oven"]++;
                            break;
                        case 40:
                            if (!location.ContainsKey("Sink"))
                            {
                                location.Add("Sink", 0);
                            }
                            location["Sink"]++;
                            break;
                        default :
                            if (!location.ContainsKey("Floor"))
                            {
                                location.Add("Floor", 0);
                            }
                            location["Floor"]++;
                            break;
                    }

                }
                else if(currentGrey != currentWhite)
                {
                    currentWhite /= 2;
                    whiteTiles.Push(currentWhite);
                    greyTiles.Enqueue(currentGrey);
                }               
            }
           
            if (whiteTiles.Count!=0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", " , whiteTiles)}");
            }
            else
            {
                Console.WriteLine($"White tiles left: none");
            }
            if (greyTiles.Count != 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: none");
            }

            location = location.OrderByDescending(n => n.Value).ThenBy(n => n.Key).ToDictionary( x => x.Key, x => x.Value);

            foreach (var element in location)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }

        }
    }
}
