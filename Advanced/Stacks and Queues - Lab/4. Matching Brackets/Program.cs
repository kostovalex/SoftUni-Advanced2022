using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string array = Console.ReadLine();
            Stack<int> ints = new Stack<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '(')
                {
                    ints.Push(i);
                }
                else if (array[i] == ')')
                {
                    int startingIndex = ints.Pop();
                    int endIndx = i;
                    string expression = array.Substring(startingIndex, endIndx - startingIndex+1);
                    
                    Console.WriteLine(expression);
                }
            }

        }
    }
}
