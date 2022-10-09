using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> VATrechner = d => d += d * 0.20;

            double[] array = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            foreach (var item in array)
            {
                Console.WriteLine($"{VATrechner(item):f2}");
            }
        }

    }
}
