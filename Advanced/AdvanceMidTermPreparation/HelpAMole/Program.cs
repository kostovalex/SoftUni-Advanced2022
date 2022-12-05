using System;

namespace HelpAMole
{
    public class Mole
    {
        public Mole(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Points { get; set; }

        public void CheckIndexAndMove(string direction, int fieldSize)
        {
            switch (direction)
            {
                case "right":
                    if (Col + 1 >= fieldSize) { Console.WriteLine("Don't try to escape the playing field!"); }
                    else { Col += 1; }
                    break;
                case "left":
                    if (Col - 1 < 0) { Console.WriteLine("Don't try to escape the playing field!"); }
                    else { Col -= 1; }
                    break;
                case "down":
                    if (Row + 1 >= fieldSize) { Console.WriteLine("Don't try to escape the playing field!"); }
                    else { Row += 1; }
                    break;
                case "up":
                    if (Row - 1 < 0) { Console.WriteLine("Don't try to escape the playing field!"); }
                    else { Row -= 1; }
                    break;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            
            char[,] field = new char[fieldSize, fieldSize];
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                string line = Console.ReadLine();
                
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = line[col];
                    if (line[col] == 'M')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Mole mole = new Mole(startRow,startCol);

            string command = Console.ReadLine();

            while (command != "End" && mole.Points < 25)
            {
                switch (command)
                {
                    case "left":
                        field[mole.Row, mole.Col] = '-';
                        mole.CheckIndexAndMove("left", fieldSize);
                        break;
                    case "right":
                        field[mole.Row, mole.Col] = '-';
                        mole.CheckIndexAndMove("right", fieldSize);
                        break;
                    case "up":
                        field[mole.Row, mole.Col] = '-';
                        mole.CheckIndexAndMove("up", fieldSize);
                        break;
                    case "down":
                        field[mole.Row, mole.Col] = '-';
                        mole.CheckIndexAndMove("down", fieldSize);
                        break;
                }

                if (field[mole.Row, mole.Col] == 'S')
                {
                    field[mole.Row, mole.Col] = '-';
                    
                    for (int row = 0; row < fieldSize; row++)
                    {                       
                        for (int col = 0; col < fieldSize; col++)
                        {                           
                            if (field[row,col] == 'S')
                            {
                                mole.Row = row;
                                mole.Col = col;
                                mole.Points -= 3;
                            }
                        }
                    }
                }
                else if (char.IsDigit(field[mole.Row, mole.Col]))
                {
                    
                    int currentPoints = int.Parse(field[mole.Row, mole.Col].ToString());
                    mole.Points += currentPoints;         
                    //check later
                }

                field[mole.Row, mole.Col] = 'M';


                command = Console.ReadLine();
            }

            if (mole.Points>=25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {mole.Points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {mole.Points} points.");
            }

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}
