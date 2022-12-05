namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_INCREMENT = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, FUEL_INCREMENT)
        {
        }
    }
}
