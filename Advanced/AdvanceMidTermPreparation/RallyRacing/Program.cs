using System;
using System.Linq;

namespace RallyRacing
{
    public class RaceCar
    {
        public int Row = 0;
        public int Col = 0;
        public int KmPassed = 0;

        public void Move(string direction)
        {
            switch (direction)
            {
                case "right":
                     Col += 1; 
                    break;
                case "left":                    
                     Col -= 1;
                    break;
                case "down":
                     Row += 1; 
                    break;
                case "up":
                     Row -= 1;
                    break;
            }
        }
    }
    
    
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();

            char[,] route = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                
                for (int col = 0; col < n; col++)
                {
                    route[row, col] = line[col];
                }
            }
            
            RaceCar car = new RaceCar();
            bool finished = false;

            string directions = Console.ReadLine();
            while (directions != "End")
            {
                route[car.Row, car.Col] = '.';
                car.Move(directions);
                

                if (route[car.Row, car.Col] == 'T')
                {
                    route[car.Row, car.Col] = '.';
                    
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (route[row, col] == 'T' )
                            {
                                car.Row = row;
                                car.Col = col;
                                car.KmPassed += 30;
                            }                           
                        }
                    }
                    
                    route[car.Row, car.Col] = 'C';
                }
                else if (route[car.Row, car.Col] == 'F')
                {                    
                    finished = true;
                    route[car.Row, car.Col] = 'C';
                    car.KmPassed += 10;
                    break;
                }
                else
                {
                    route[car.Row, car.Col] = 'C';
                    car.KmPassed += 10;
                }
    
                directions = Console.ReadLine();
            }

            if (finished==false)
            {
                route[car.Row, car.Col] = 'C';
                Console.WriteLine($"Racing car {carNumber} DNF.");

            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
            }
            
            Console.WriteLine($"Distance covered {car.KmPassed} km.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(route[row,col]);
                }
                Console.WriteLine();
            }

        }       
    }
}
