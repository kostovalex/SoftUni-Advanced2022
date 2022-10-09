using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);         
            HashSet<string> carsInTheLot = new HashSet<string>();

            while (input[0]!="END")
            {
                string direction = input[0];    
                string plateNumber = input[1];

                if (direction=="IN")
                {
                    carsInTheLot.Add(plateNumber);
                }
                else if (direction == "OUT")
                {
                    carsInTheLot.Remove(plateNumber);
                }
                
                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (carsInTheLot.Count>0)
            {
                foreach (var car in carsInTheLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
