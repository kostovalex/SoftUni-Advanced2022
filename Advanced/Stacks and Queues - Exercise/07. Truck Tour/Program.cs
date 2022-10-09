using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            int gasInTank = 0;
           
            
            List<Pump> pumps = new List<Pump>();    
            
            Queue<int> queue = new Queue<int>();
            
            bool firstFound = false;


            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int gasoline = pumpInfo[0];
                int kmToNext = pumpInfo[1];

                Pump pump = new Pump() { Gas = gasoline, Distance = kmToNext, Index =i };
                pumps.Add(pump); 
            }


            for (int i = 0; i < pumps.Count; i++)
            {
                if (firstFound == false)
                {
                    if (pumps[i].Distance <= pumps[i].Gas)
                    {
                        queue.Enqueue(pumps[i].Index);
                        firstFound = true;
                        gasInTank = pumps[i].Gas - pumps[i].Distance;

                        for (int j = i + 1; j < pumpsCount; j++)
                        {
                            if (pumps[i].Distance <= pumps[i].Gas + gasInTank)
                            {
                                gasInTank += pumps[j].Gas - pumps[j].Distance;
                            }
                            else
                            {
                                firstFound = false;
                                queue.Dequeue();
                                gasInTank = 0;
                                break;
                            }
                        }
                    }
                    else
                    {
                        pumps.Add(pumps[i]);
                        pumps.RemoveAt(i);
                        i--;
                    }
                }
            }

            if (firstFound==true)
            {
                Console.WriteLine(queue.Dequeue());
            }

            

        }

    }
    class Pump
    {
        public int Gas { get; set; }
        public int Distance { get; set; }   

        public int Index { get; set; }
    }
}
