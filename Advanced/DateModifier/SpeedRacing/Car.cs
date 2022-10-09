using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
            this.TravelledDistance = 0;
        }
        
        public string Model { get; set; } //unique
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(int kmToDrive)
        {
            
            double consumption = this.FuelConsumptionPerKilometer;

            if ((kmToDrive*consumption) <= this.FuelAmount)
            {
                this.FuelAmount -= (kmToDrive * consumption);
                this.TravelledDistance += kmToDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
