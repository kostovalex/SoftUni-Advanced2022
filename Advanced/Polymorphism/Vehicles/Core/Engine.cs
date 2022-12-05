using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Vehicles.Core.Interfaces;
using Vehicles.Exceptions;
using Vehicles.IO.Interfaces;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    string[] vehicleInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    vehicles.Add(CreateVehicle(vehicleInfo));
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }

            int n = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] commands = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = commands[0];
                    string vehicle = commands[1];
                    double value = double.Parse(commands[2]);


                    if (command == "Drive")
                    {
                        this.writer.WriteLine(vehicles.FirstOrDefault(v => v.GetType().Name == vehicle).Drive(value));
                    }
                    else if (commands[0] == "DriveEmpty")
                    {
                        this.writer.WriteLine(vehicles.FirstOrDefault(v => v.GetType().Name == vehicle).Drive(value, "Empty"));
                    }
                    else if (commands[0] == "Refuel")
                    {
                        vehicles.FirstOrDefault(v => v.GetType().Name == vehicle).Refuel(value);
                    }
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                
            }

            foreach (var item in vehicles)
            {
                this.writer.WriteLine(item.ToString());
            }
        }

        private IVehicle CreateVehicle(string[] vehicleInfo)
        {
            string vehicleType = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            switch (vehicleType)
            {
                case "Car":
                    IVehicle car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                    return car;
                case "Truck":
                    IVehicle truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                    return truck;
                case "Bus":
                    IVehicle bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                    return bus;
                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }

        }
    }
}
