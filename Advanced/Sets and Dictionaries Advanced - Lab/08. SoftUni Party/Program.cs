using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> vipList = new HashSet<string>();

            while (command!="END" && command!= "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    vipList.Add(command);
                }
                else
                {
                    guestList.Add(command);
                }
               
                               
                command = Console.ReadLine();
            }

            if (command == "PARTY")
            {
                string arrived = Console.ReadLine();

                while (arrived != "END")
                {
                    if (char.IsDigit(arrived[0]))
                    {
                        vipList.Remove(arrived);
                    }
                    else
                    {
                        guestList.Remove(arrived);
                    }
                    arrived = Console.ReadLine();
                }
            }

            Console.WriteLine(guestList.Count + vipList.Count);

            if (vipList.Count>0)
            {
                foreach (var guest in vipList)
                {
                    Console.WriteLine(guest);
                }
            }
            if (guestList.Count>0)
            {
                foreach (var guest in guestList)
                {
                    Console.WriteLine(guest);
                }
            }
            



        }
    }
}
