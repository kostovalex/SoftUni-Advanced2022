namespace Vehicles.Models
{
    public interface IVehicle
    {
        double FuelIncrement { get; }
        double TankCapacity { get; }
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        public string Drive(double distance);
        public string Drive(double distance, string condition);
        public void Refuel(double quantity);
    }
}
