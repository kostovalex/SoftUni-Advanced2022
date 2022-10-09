using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            int currSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                  
                }
            }


            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    currSum += matrix[row, col];
                }
                Console.WriteLine(currSum);
                currSum = 0;
            }
        }
    }
}
