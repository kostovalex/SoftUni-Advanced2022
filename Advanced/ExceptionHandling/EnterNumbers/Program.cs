using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();
            string number = "1";
            
            while (ints.Count < 10)
            {
                try
                {
                    ints.Add(ReadNumber(number));
                    number = ints.Last().ToString();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ", ints));


        }

        public static int ReadNumber(string number)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                throw new ArgumentException("Invalid Number!");
            }
            if (int.Parse(input) <= int.Parse(number) || int.Parse(input) >= 100)
            {
                throw new ArgumentException($"Your number is not in range {int.Parse(number)} - 100!");
            }
            
            number = input;
            return int.Parse(number);
        }
    }
}
