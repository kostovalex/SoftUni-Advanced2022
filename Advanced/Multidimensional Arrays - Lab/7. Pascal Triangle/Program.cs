using System;
using System.Numerics;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());

            long[][] pascal = new long[n][];

            long left = 0;
            long right = 0;


            for (int row  = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];
                
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    if (row - 1 < 0 || col - 1 < 0)
                    {
                        left = 0;
                    }
                    else
                    {
                        left = pascal[row - 1][col - 1];
                    }
                    
                    if (col + 1 == pascal[row].Length)
                    {
                        right = 0;
                    }
                    else
                    {
                        right = pascal[row-1][col];
                    }
                    
                    if (left == 0 && right == 0)
                    {
                        pascal[row][col] = left + right + 1;
                    }
                    else
                    {
                        pascal[row][col] = left + right;
                    }
                    
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
