using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> adder = n => n += 1;
            Func<int, int> multiplier = n => n *= 2;
            Func<int, int> subtractor = n=> n -= 1;
            Action<string> printer = n => Console.WriteLine(n);

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToList();
           
            string command = Console.ReadLine();

            while (command!="end")
            {
                if (command=="add")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = adder(numbers[i]);
                    }
                }
                else if (command =="multiply")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = multiplier(numbers[i]);
                    }
                }
                else if (command =="subtract")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = subtractor(numbers[i]);
                    }
                }
                else if (command == "print")
                {
                    printer(string.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
