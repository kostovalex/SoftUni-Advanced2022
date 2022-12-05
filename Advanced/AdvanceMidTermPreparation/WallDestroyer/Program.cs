using System;
using System.Linq;
using System.Numerics;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            var startRow = 0;
            var startCol = 0;
            var holesCount = 1;
            bool vankoIsAlive = true;
            var steelRodsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End" && vankoIsAlive)
            {
                switch (command)
                {
                    case "right":
                        if (startCol + 1 >= n)
                        {
                            break;
                        }
                        else
                        {
                            matrix[startRow, startCol] = '*';

                            if (matrix[startRow, startCol + 1] == '-')
                            {
                                holesCount++;
                                startCol += 1;
                                matrix[startRow, startCol] = 'V';
                            }
                            else if (matrix[startRow, startCol + 1] == 'R')
                            {
                                steelRodsCount++;
                                matrix[startRow, startCol] = 'V';                                
                                Console.WriteLine("Vanko hit a rod!");
                            }
                            else if (matrix[startRow, startCol + 1] == 'C')
                            {
                                holesCount++;
                                matrix[startRow, startCol + 1] = 'E';
                                vankoIsAlive = false;
                            }
                            else if (matrix[startRow, startCol + 1] == '*')
                            {                               
                                startCol += 1;
                                Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                                matrix[startRow, startCol] = 'V';
                            }
                        }
                        break;
                    case "left":
                        if (startCol - 1 < 0)
                        {
                            break;
                        }
                        else
                        {
                            matrix[startRow, startCol] = '*';
 
                            if (matrix[startRow, startCol - 1] == '-')
                            {
                                holesCount++;
                                startCol -= 1;
                                matrix[startRow, startCol] = 'V';
                            }
                            else if (matrix[startRow, startCol - 1] == 'R')
                            {
                                steelRodsCount++;
                                matrix[startRow, startCol] = 'V';                                
                                Console.WriteLine("Vanko hit a rod!");
                            }
                            else if (matrix[startRow, startCol - 1] == 'C')
                            {
                                holesCount++;
                                matrix[startRow, startCol - 1] = 'E';
                                vankoIsAlive = false;
                            }
                            else if (matrix[startRow, startCol - 1] == '*')
                            {                                
                                startCol -= 1;
                                matrix[startRow, startCol] = 'V';
                                Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                            }
                        }
                        break;
                    case "down":
                        if (startRow + 1 >= n)
                        {
                            break;
                        }
                        else
                        {
                            matrix[startRow, startCol] = '*';                            

                            if (matrix[startRow + 1, startCol] == '-')
                            {
                                holesCount++;
                                startRow += 1;
                                matrix[startRow, startCol] = 'V';
                            }
                            else if (matrix[startRow + 1, startCol] == 'R')
                            {
                                steelRodsCount++;
                                matrix[startRow, startCol] = 'V';                                
                                Console.WriteLine("Vanko hit a rod!");
                            }
                            else if (matrix[startRow + 1, startCol] == 'C')
                            {
                                holesCount++;
                                matrix[startRow + 1, startCol] = 'E';
                                vankoIsAlive = false;
                            }
                            else if (matrix[startRow + 1, startCol] == '*')
                            {                               
                                startRow += 1;
                                matrix[startRow, startCol] = 'V';
                                Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                            }
                        }
                        break;
                    case "up":
                        if (startRow - 1 < 0)
                        {
                            break;
                        }
                        else
                        {
                            matrix[startRow, startCol] = '*';

                            if (matrix[startRow - 1, startCol] == '-')
                            {
                                holesCount++;
                                startRow -= 1;
                                matrix[startRow, startCol] = 'V';
                            }
                            else if (matrix[startRow - 1, startCol] == 'R')
                            {
                                steelRodsCount++;
                                matrix[startRow, startCol] = 'V';                                
                                Console.WriteLine("Vanko hit a rod!");
                            }
                            else if (matrix[startRow - 1, startCol] == 'C')
                            {
                                holesCount++;
                                matrix[startRow - 1, startCol] = 'E';
                                vankoIsAlive = false;
                            }
                            else if (matrix[startRow - 1, startCol] == '*')
                            {
                                startRow -= 1;
                                matrix[startRow, startCol] = 'V';
                                Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            if (vankoIsAlive)
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {steelRodsCount} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
