using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<int,int> numbersOccurence = new Dictionary<int,int>();
            
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                
                if (!numbersOccurence.ContainsKey(input))
                {
                    numbersOccurence.Add(input, 0);
                }
                numbersOccurence[input]++;
            }

            

            Console.WriteLine(numbersOccurence.Single(n => n.Value % 2 == 0).Key);
        }
    }
}
