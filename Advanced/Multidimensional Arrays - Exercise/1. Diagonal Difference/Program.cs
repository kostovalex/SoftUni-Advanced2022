using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,]matrix = new int[n,n];
            int primarD = 0;
            int secondaryD = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int row = i;
                int col = i;

                primarD += matrix[row, col];               
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int row = i;
                int col = matrix.GetLength(1) - 1 - i;

                secondaryD += matrix[row, col];
            }

            int result = Math.Abs(primarD - secondaryD);

            Console.WriteLine(result);

        }
    }
}
