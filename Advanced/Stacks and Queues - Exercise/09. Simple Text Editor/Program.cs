using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string field = string.Empty;

            int opCount = int.Parse(Console.ReadLine());
            Stack<string> operations = new Stack<string>();
            
                
            for (int i = 0; i < opCount; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "1")
                {
                    field+=command[1];
                    operations.Push(String.Join(" ", command));

                }
                else if (command[0] == "2")
                {
                    int count = int.Parse(command[1]);
                    string deleted = field.Substring(field.Length - count);
                    field = field.Remove(field.Length-count);
                    operations.Push("2 " + deleted);
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);
                    char sign = field[index-1];
                    Console.WriteLine(sign);
                }
                else if (command[0] == "4")
                {
                    //undo 1 or 2
                    string[] oldCommand = operations.Pop().Split();
                    if (oldCommand[0] == "1")
                    {
                        field = field.Remove(field.Length - oldCommand[1].Length);
                    }
                    else
                    {
                        field += oldCommand[1];
                    }
                }
            }

        }
    }
}
