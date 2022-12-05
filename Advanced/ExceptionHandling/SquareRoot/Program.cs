namespace SquareRoot
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            try
            {
                double result = SquareRootCalculator(number);
                Console.WriteLine(result);
            }
            catch (ArgumentException ae )
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }


        }

        public static double SquareRootCalculator(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            return Math.Sqrt(number);
        }
    }
}
