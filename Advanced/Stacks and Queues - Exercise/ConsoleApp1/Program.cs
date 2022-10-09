using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (stack.Count>0)
                {
                    if (input[i] == ')')
                    {
                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                    }
                    else if (input[i] == ']')
                    {
                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                    }
                    else if (input[i] == '}')
                    {
                        if (stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(input[i]);
                    }
                }
                else
                {
                    stack.Push(input[i]);
                }
            }

            if (stack.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            

        }
    }
}
