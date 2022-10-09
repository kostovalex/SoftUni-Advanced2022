using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[row] = new int[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }

            //⦁	Add {row} {col} {value}
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0]!= "END")
            {
                if (command[0] == "Add")
                {
                    int dim1 = int.Parse(command[1]);
                    int dim2 = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (dim1 >= 0 && dim1 <= rowsCount - 1 && dim2 >= 0 && dim2 <= jaggedArray[dim1].Length - 1)
                    {
                        jaggedArray[dim1][dim2] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command[0] == "Subtract")
                {
                    int dim1 = int.Parse(command[1]);
                    int dim2 = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (dim1 >= 0 && dim1 <= rowsCount-1 && dim2 >= 0 && dim2 <= jaggedArray[dim1].Length - 1)
                    {
                        jaggedArray[dim1][dim2] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
