using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int carsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < carsCount; i++)
            {
                string[] carsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(carsInfo[0], double.Parse(carsInfo[1]), double.Parse(carsInfo[2]));

                cars.Add(carsInfo[0], car);
            }

            string[] driveCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (driveCommand[0]!= "End")
            {
                string carModel = driveCommand[1];
                int kmToDrive = int.Parse(driveCommand[2]);

                Car car = cars[carModel];
                
                car.Drive(kmToDrive);
                
                driveCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
    }
}
