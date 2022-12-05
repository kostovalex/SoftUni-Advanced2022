using System;

namespace _05.GenericCountMethodString
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.Items.Add(input);
            }

            string element = Console.ReadLine();

            Console.WriteLine(box.Comparer(element));
        }
    }
}
