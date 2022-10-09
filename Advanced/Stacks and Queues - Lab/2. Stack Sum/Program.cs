using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse)); 

            string[] command = Console.ReadLine().ToLower().Split();

            while (command[0]!= "end")
            {
                if (command[0]=="add")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command[0] == "remove")
                {
                    int count = int.Parse(command[1]);
                    if (count<=stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower().Split();
            }
            
            int sum = 0;
            while (stack.Count>0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
