using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            Queue<char> queue = new Queue<char>(Console.ReadLine());
           

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row%2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                
            }
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }


        }
    }
}
