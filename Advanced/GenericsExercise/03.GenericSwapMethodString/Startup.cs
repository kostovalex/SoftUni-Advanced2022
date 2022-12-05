using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    internal class Startup
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

            int[] swapCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
