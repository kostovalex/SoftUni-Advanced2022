using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            
            int carsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < carsCount; i++)
            {
                string[] carsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carsInput[0];
                
                int engineSpeed = int.Parse(carsInput[1]);
                int enginePower = int.Parse(carsInput[2]);
                Engine engine = new Engine(engineSpeed, enginePower); 
                
                int cargoWeight = int.Parse(carsInput[3]);
                string cargoType = carsInput[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(carsInput[5]), int.Parse(carsInput[6])),
                    new Tire(double.Parse(carsInput[7]), int.Parse(carsInput[8])),
                    new Tire(double.Parse(carsInput[9]), int.Parse(carsInput[10])),
                    new Tire(double.Parse(carsInput[11]), int.Parse(carsInput[12]))
                };

                Car car = new Car(model,engine, cargo, tires);

                cars.Add(car);
            }
            
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                cars = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
