using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, Dictionary<string, double>> shopsInSofia = new SortedDictionary<string, Dictionary<string, double>>();
            
            while (input[0]!= "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopsInSofia.ContainsKey(shop))
                {
                    shopsInSofia.Add(shop, new Dictionary<string, double>());
                }
                shopsInSofia[shop].Add(product, price);
                
                
                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
           
            foreach (var shop in shopsInSofia)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }       

        }
    }
}
