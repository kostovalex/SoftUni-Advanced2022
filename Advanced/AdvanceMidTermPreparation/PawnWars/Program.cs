using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PawnWars
{
    public class BlackPawn
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public BlackPawn(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void Move(char[,] board)
        {
            board[Row, Col] = '-';
            Row -= 1;
            board[Row, Col] = 'b';
        }
    }
    public class WhitePawn
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public WhitePawn(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void Move(char[,] board)
        {
            board[Row, Col] = '-';
            Row += 1;
            board[Row, Col] = 'w';

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int startBlackRow = 0;
            int startBlackCol = 0;
            
            int startWhiteRow = 0;
            int startWhiteCol = 0;
            
            for (int row = 7; row >= 0; row--)
            {
                string line = Console.ReadLine();
                
                for (int col = 0; col <= 7; col++)
                {
                    board[row, col] = line[col];
                    if (line[col] == 'b')
                    {
                        startBlackRow = row;
                        startBlackCol = col;
                    }
                    else if (line[col] == 'w')
                    {
                        startWhiteRow = row;
                        startWhiteCol = col;
                    }
                }
            }

            BlackPawn black = new BlackPawn(startBlackRow, startBlackCol);
            WhitePawn white = new WhitePawn(startWhiteRow, startWhiteCol);
            
            while (true)
            {
                if (black.Row == white.Row + 1 && black.Col == white.Col - 1 ||
                    black.Row == white.Row + 1 && black.Col == white.Col + 1)
                {
                    string coordinates = $"{char.ConvertFromUtf32(black.Col + 97)}{black.Row +1}";
                    Console.WriteLine($"Game over! White capture on { coordinates}.");
                    break;
                }
                white.Move(board);
                if (white.Row == 7)
                {
                    string coordinates = $"{char.ConvertFromUtf32(white.Col+97)}8";                   
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                    break;
                }

                if (white.Row == black.Row - 1 && white.Col == black.Col - 1 ||
                    white.Row == black.Row - 1 && white.Col == black.Col + 1)
                {
                    string coordinates = $"{char.ConvertFromUtf32(white.Col + 97)}{white.Row + 1}";
                    Console.WriteLine($"Game over! Black capture on {coordinates}.");
                    break;
                }
                black.Move(board);
                if (black.Row == 0)
                {
                    string coordinates = $"{char.ConvertFromUtf32(black.Col + 97)}1";
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                    break;
                }


            }
            
        }
        
    }
}
