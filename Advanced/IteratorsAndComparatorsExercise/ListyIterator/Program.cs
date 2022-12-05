using System;
using System.Collections.Generic;
using System.Linq;

namespace _ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1).ToList();
            
            ListyIterator<string> myList = new ListyIterator<string>(input);

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(myList.Move()); 
                        break;
                    case "HasNext":
                        Console.WriteLine(myList.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            myList.Print();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);                           
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            myList.PrintAll();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }                        
                        break;
                }

                command = Console.ReadLine();
            }

            
        }
    }
}
