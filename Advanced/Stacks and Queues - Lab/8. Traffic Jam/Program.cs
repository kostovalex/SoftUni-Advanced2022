using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsPerLight = int.Parse(Console.ReadLine());
            Queue<string> carsWaiting = new Queue<string>();
            int carsPassed = 0;
            
            string command = Console.ReadLine();           
            
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsPerLight; i++)
                    {
                        if (carsWaiting.Count > 0)
                        {
                            Console.WriteLine($"{carsWaiting.Dequeue()} passed!");
                            carsPassed++;
                        }
                    }
                }
                else
                {
                   carsWaiting.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
