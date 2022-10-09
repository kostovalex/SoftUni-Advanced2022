using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

    }
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.cubicCapacity = cubicCapacity;
        }
        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

    }
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            :this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption= fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity,fuelConsumption)
        {
            
            this.Engine = engine;
            this.Tires = tires;
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public Tire[] Tires
        {     
            get { return tires; }
            set { tires = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (distance * (this.FuelConsumption/100.00)) >= 0)
            {
                this.FuelQuantity -= (distance * (this.FuelConsumption/100.00));
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity}");
            

            return sb.ToString();
        }

    }
    
    public class StartUp
    {
        static void Main(string[] args)
        {   
            List<Tire[]> tiresSortiment = new List<Tire[]>();

            string[] newTiresInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            while (newTiresInfo[0] != "No"&& newTiresInfo[1] != "more"&& newTiresInfo[2] != "tires")
            {
                Tire[] tires = new Tire[4];
                int counter = 0;
                
                for (int i = 0; i < newTiresInfo.Length-1; i+=2)
                {
                    int year = int.Parse(newTiresInfo[i]);
                    double pressure = double.Parse(newTiresInfo[i+1]);

                    Tire tire = new Tire(year, pressure);

                    tires[counter] = tire;
                    counter++;
                }

               tiresSortiment.Add(tires);

               newTiresInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            List<Engine> engines = new List<Engine>();
            
            string[] newEnginesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (newEnginesInfo[0] != "Engines" && newEnginesInfo[1] != "done")
            {
                int horsePower = int.Parse(newEnginesInfo[0]);
                double cubicCapacity = double.Parse(newEnginesInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);

                newEnginesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Car> cars = new List<Car>();

            string[] finalStep = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (finalStep[0]!= "Show"&& finalStep[1] != "special")
            {
                string make = finalStep[0];
                string model = finalStep[1];
                int year = int.Parse(finalStep[2]);
                double fuelQuantity = double.Parse(finalStep[3]);
                double fuelConsumption = double.Parse(finalStep[4]);
                int engineIndex = int.Parse(finalStep[5]);
                int tiresIndex = int.Parse(finalStep[6]);

                Engine engine = engines[engineIndex];

                Tire[] tiresPick = tiresSortiment[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity,fuelConsumption,engine,tiresPick);

                cars.Add(car);

                finalStep = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            cars = cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330&&c.Tires.Sum(t=>t.Pressure)>9&& c.Tires.Sum(t => t.Pressure)<10).ToList();

            foreach (Car auto in cars)
            {
                auto.Drive(20);
                Console.WriteLine(auto.WhoAmI());
            }
           
        }

    }
}

