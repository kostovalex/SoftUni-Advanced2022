using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;
            Stack<char> stack = new Stack<char>();

            foreach (char character in input)
            {
                stack.Push(character);
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            

            Console.WriteLine(result);
        }
    }
}
