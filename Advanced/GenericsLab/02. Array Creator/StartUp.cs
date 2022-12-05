using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] stringCreator = ArrayCreator<string>.Create(10, "hello");
            int[] ints = ArrayCreator<int>.Create(100, 100);

            Console.WriteLine(string.Join(", ", ints));
            Console.WriteLine(string.Join(" ", stringCreator)); 
        }
    }
}
