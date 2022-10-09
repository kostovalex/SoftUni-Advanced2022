using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playlist = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (playlist.Count > 0)
            {
                List<string> command = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

                if (command[0] == "Play")
                {
                    playlist.Dequeue();
                }
                
                else if (command[0] == "Add")
                {
                    command.RemoveAt(0);
                    string songName = String.Join(" ", command);

                    if (!playlist.Contains(songName))
                    {
                        playlist.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                
                else if (command[0]=="Show")
                {
                    Console.WriteLine(String.Join(", ",playlist));
                }
            }
            
            Console.WriteLine("No more songs!");
        }
    }
}
