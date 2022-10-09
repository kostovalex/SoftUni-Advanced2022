 using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                double[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArray[row] = new double[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }

            for (int row = 0; row < rowCount - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] = 2 * jaggedArray[row][col];
                        jaggedArray[row + 1][col] = 2 * jaggedArray[row + 1][col];
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] = jaggedArray[row][col] / 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] = jaggedArray[row + 1][col] / 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                int rowCommand = int.Parse(command[1]);
                int colCommand = int.Parse(command[2]);
                double value = int.Parse(command[3]);

                if (command[0] == "Add" && rowCommand >= 0 && rowCommand < rowCount - 1
                    && colCommand >= 0 && colCommand < jaggedArray[rowCommand].Length - 1)
                {
                    jaggedArray[rowCommand][colCommand] += value;

                }
                else if (command[0] == "Subtract" && rowCommand >= 0 && rowCommand < rowCount - 1
                    && colCommand >= 0 && colCommand <= jaggedArray[rowCommand].Length - 1)
                {
                    jaggedArray[rowCommand][colCommand] -= value;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
