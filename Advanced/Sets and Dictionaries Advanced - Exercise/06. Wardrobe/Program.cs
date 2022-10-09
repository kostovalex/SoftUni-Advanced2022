using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            string[] separators = new string[] { " -> ", "," };
            
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                
                for (int j = 1; j < input.Length; j++)
                {
                    string currentCloth = input[j];
                    
                    if (!wardrobe[color].ContainsKey(input[j]))
                    {
                        wardrobe[color].Add(currentCloth, 0);
                    }
                    wardrobe[color][currentCloth]++;
                }               
            }
            string[] search = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string wantedColor = search[0];
            string wantedCloth = search[1];

            foreach (var itemColor in wardrobe)
            {
                Console.WriteLine($"{itemColor.Key} clothes:");

                foreach (var item in itemColor.Value)
                {
                    string print = $"* {item.Key} - {item.Value}";

                    if (itemColor.Key==wantedColor&&item.Key == wantedCloth)
                    {
                        Console.WriteLine(print + " (found!)");
                    }
                    else
                    {
                        Console.WriteLine(print);
                    }
                    
                }
            }

        }
    }
}
