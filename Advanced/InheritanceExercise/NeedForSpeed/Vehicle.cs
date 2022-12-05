﻿

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        private const double DefaultFuelConsumption = 1.25;
        
        public virtual double FuelConsumption { get { return DefaultFuelConsumption; } }
        
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double usedFuel = kilometers * FuelConsumption;
            
            if (usedFuel <= Fuel)
            {
                Fuel -= usedFuel;
            }
        }
    }
}
