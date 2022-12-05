using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
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

            int[] swapCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
