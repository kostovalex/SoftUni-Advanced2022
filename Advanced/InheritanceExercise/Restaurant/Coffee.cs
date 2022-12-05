
namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;
        private const double CoffeeMilliliters = 50;
        public Coffee(string name, double caff) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = caff;
        }
        public double Caffeine  { get; set; }
    }
}
