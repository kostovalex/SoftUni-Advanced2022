using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> intBox = new Box<int>();

            intBox.Add(1);
            intBox.Add(2);
            intBox.Add(3);
            intBox.Add(4);
            Console.WriteLine(intBox.Remove());

            Box<string> stringBox = new Box<string>();
            stringBox.Add("Zemi");
            stringBox.Add("Tova");
            Console.WriteLine(stringBox.Remove());

            Console.WriteLine(string.Join(" ", intBox.internalArray));

            Console.WriteLine();

            Console.WriteLine(string.Join(" ", stringBox.internalArray));
        }
    }
}
