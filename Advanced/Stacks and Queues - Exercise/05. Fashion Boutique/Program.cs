using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());

            int currentRack = 0;
            int racksCount = 1;

            while (clothes.Count>0)
            {
                int currentPiece = clothes.Pop();
                if (rackCapacity>=currentPiece+currentRack)
                {
                    currentRack += currentPiece;
                }
                else
                {
                    racksCount++;
                    currentRack = currentPiece;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
