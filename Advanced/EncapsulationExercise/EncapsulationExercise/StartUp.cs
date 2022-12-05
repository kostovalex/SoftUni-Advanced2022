using System;

namespace EncapsulationExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			try
			{
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box newBox = new Box(length, width, height);

                Console.WriteLine(newBox);
            }
			catch (ArgumentException ae)
			{
                Console.WriteLine(ae.Message);				
			}
        }
    }
}
