using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            
            int[,] matrix = new int[size, size];
            int sumOfPrimar = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0, col = 0; row < matrix.GetLength(0); row++, col++)
            {                
                sumOfPrimar += matrix[row, col];
            }

            Console.WriteLine(sumOfPrimar);

        }
    }
}
