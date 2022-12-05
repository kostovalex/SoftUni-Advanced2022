using System;

namespace GenericArrayCreator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] some = ArrayCreator.Create(100, 100);

            Console.WriteLine(string.Join(" ", some));
        }
    }
}
