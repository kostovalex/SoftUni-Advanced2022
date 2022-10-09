using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            int biggestSum = int.MinValue;
            //int[,] biggestSubMatrix = new int[2, 2];
            int minRow = int.MaxValue;
            int minCol = int.MaxValue;

            int currentSum = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];                   
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {                
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 1, col];
                    if (currentSum == biggestSum)
                    {
                        if (row <= minRow)
                        {
                            if (col<= minCol)
                            {
                                biggestSum = currentSum;
                                minCol = col;
                                minRow = row;
                            }
                        }
                    }
                    else if (currentSum>biggestSum)
                    {
                        biggestSum = currentSum;
                        minCol = col;
                        minRow = row;
                    }
                }
            }

            for (int row = minRow; row < minRow+2; row++)
            {
                for (int col = minCol; col < minCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestSum);
        }
    }
}
