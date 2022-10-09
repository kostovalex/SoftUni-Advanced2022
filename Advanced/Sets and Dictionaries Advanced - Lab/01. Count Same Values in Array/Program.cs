using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> numberOccurence = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!numberOccurence.ContainsKey(input[i]))
                {
                    numberOccurence.Add(input[i], 0);
                }
                numberOccurence[input[i]]++;
            }

            foreach (var number in numberOccurence)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            } 
        }
    }
}
