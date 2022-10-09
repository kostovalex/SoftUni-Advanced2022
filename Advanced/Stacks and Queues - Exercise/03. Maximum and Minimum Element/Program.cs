using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queryN = int.Parse(Console.ReadLine());

            Stack<int> sequence = new Stack<int>();
            
            if (queryN>0&&queryN<=105)
            {
                for (int i = 0; i < queryN; i++)
                {
                    int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    
                    if (command[0] == 1)
                    {
                        int num = command[1];
                        if (num>0&&num<=109)
                        {
                            sequence.Push(num);
                        }  
                    }
                    
                    if (sequence.Count>0)
                    {
                        if (command[0] == 2)
                        {
                            sequence.Pop();
                        }
                        else if (command[0] == 3)
                        {
                            Console.WriteLine(sequence.Max());
                        }
                        else if (command[0] == 4)
                        {
                            Console.WriteLine(sequence.Min());
                        }
                    }                    
                }

                Console.WriteLine(String.Join(", ", sequence));
            }
            
        }
    }
}
