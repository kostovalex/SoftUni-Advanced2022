namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar newCar = new FamilyCar(112, 1241.3);
            Vehicle veh = new Vehicle(2, 2.3);
            System.Console.WriteLine();

            Car car = new Car(1214, 12412.3);
            System.Console.WriteLine();

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(12, 21.2);
            SportCar sportCar = new SportCar(1214, 12412.3);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(1214, 12412.3);

        }
    }
}
