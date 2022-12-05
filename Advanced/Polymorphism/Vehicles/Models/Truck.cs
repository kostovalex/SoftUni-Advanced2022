using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_INCREMENT = 1.4;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, FUEL_INCREMENT)
        {
        }

        public override void Refuel(double quantity)
        {
            if (quantity + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }
            else if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.FuelQuantity += quantity*0.95;
            
        }

    }
}
