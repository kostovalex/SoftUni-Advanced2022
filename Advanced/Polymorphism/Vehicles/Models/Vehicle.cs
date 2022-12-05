namespace Vehicles.Models
{
    using System;
    using Vehicles.Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private double fuelIncrement;
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double fuelIncrement)
        {
            FuelConsumption = fuelConsumption + fuelIncrement;
            TankCapacity = tankCapacity;
            this.fuelIncrement = fuelIncrement;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (fuelQuantity > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get => fuelConsumption; private set => fuelConsumption = value; }

        public double TankCapacity { get => tankCapacity; private set => tankCapacity = value; }

        public virtual double FuelIncrement { get => fuelIncrement; }

        public virtual string Drive(double distance)
        {
            if (this.FuelConsumption * distance > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= distance * this.FuelConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public string Drive(double distance, string condition)
        {
            if (this.FuelConsumption * distance > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= distance * this.FuelConsumption - this.FuelIncrement;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double quantity)
        {

            if (quantity + fuelQuantity > tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }
            else if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            
            this.FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
