using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                
                if (!map.ContainsKey(continent))
                {
                    map.Add(continent,new Dictionary<string, List<string>>());

                }
                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }
                map[continent][country].Add(city);
            }
            //Africa:
            //Nigeria->Abuja
           
            foreach (var continent in map)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"    {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
