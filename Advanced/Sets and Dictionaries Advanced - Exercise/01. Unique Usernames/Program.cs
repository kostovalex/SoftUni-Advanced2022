using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string username = Console.ReadLine();
                set.Add(username);
            }

            foreach (var username in set)
            {
                Console.WriteLine(username);
            }
        }
    }
}
