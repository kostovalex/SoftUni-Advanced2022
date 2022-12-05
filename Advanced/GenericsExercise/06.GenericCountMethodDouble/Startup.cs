using System;

namespace _06.GenericCountMethodDouble
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Items.Add(input);
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Comparer(element));
        }
    }
}
