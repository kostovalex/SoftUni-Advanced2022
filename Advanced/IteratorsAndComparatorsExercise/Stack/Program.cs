using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();
            
            List<string> input = Console.ReadLine().Split(" ").ToList();

            while (input[0]!= "END")         
            {
                switch (input[0])
                {
                    case "Push":
                        string items = string.Join(" ",input.Skip(1));
                        List<string> elements = items.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);                           
                        }
                        
                        break;
                }
                input = Console.ReadLine().Split(" ").ToList();
            }
            
            stack.EndCommand();
            

        }
    }
} 
