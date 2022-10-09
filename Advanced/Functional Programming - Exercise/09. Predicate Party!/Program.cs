using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Party!")
            {

                if (command[0] == "Double")
                {
                    if (command[1] == "StartsWith")
                    {
                        string sub = command[2];
                        
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].Contains(sub))
                            {
                                guests.Insert(i+1, guests[i]);
                                i++;
                            }
                        }

                    }
                    else if (command[1] == "EndsWith")
                    {
                        string sub = command[2];
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].Contains(sub))
                            {
                                guests.Insert(i+1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else if (command[1] == "Length")
                    {
                        int length = int.Parse(command[2]);
                        Predicate<int> lengthChecker = l => l == length;

                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (lengthChecker(guests[i].Length))
                            {
                                guests.Insert(i, guests[i]);
                                i++;
                            }
                        }

                    }
                }
                else if (command[0] == "Remove")
                {
                    if (command[1] == "StartsWith")
                    {
                        string sub = command[2];

                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].Contains(sub))
                            {
                                guests.Remove(guests[i]);
                                i--;
                            }
                        }

                    }
                    else if (command[1] == "EndsWith")
                    {
                        string sub = command[2];
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].Contains(sub))
                            {
                                guests.Remove(guests[i]);
                                i--;
                            }
                        }
                    }
                    else if (command[1] == "Length")
                    {
                        int length = int.Parse(command[2]);
                        Predicate<int> lengthChecker = l => l == length;

                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (lengthChecker(guests[i].Length))
                            {
                                guests.Remove(guests[i]);
                                i--;
                            }
                        }

                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
