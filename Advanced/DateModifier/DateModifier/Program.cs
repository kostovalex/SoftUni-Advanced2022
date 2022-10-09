using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {

            string firstDateInString = Console.ReadLine();
            string secondDateInString = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.DifferenceCalculator(firstDateInString, secondDateInString));

        }
    }
}
