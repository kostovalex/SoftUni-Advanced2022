using System;

namespace _02.GenericBoxOfInteger
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Items.Add(input);
            }

            Console.WriteLine(box);
        }
    }
}
