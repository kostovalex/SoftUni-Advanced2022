using System;

namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    result += CheckNumber(input[i]);                   
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {result}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {result}");
        }

        private static int CheckNumber(string input)
        {
            if (!int.TryParse(input, out int result))
            {
                if (!long.TryParse(input, out long longResult))
                {
                    throw new FormatException($"The element '{input}' is in wrong format!");
                }
                else
                {
                    throw new OverflowException($"The element '{input}' is out of range!");
                }
            }
            else
            {
                if (int.Parse(input) < int.MinValue || int.Parse(input) > int.MaxValue)
                {
                    throw new OverflowException($"The element '{input}' is out of range!");
                }               
            }      
            return result;
        }
    }
}
