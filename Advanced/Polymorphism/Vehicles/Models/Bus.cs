namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_INCREMENT = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, FUEL_INCREMENT)
        {
        }

        

    }
}
