namespace CommandPattern
{
    using System;
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public void IncreasePrice(decimal amount)
        {
            Price += amount;
            Console.WriteLine($"The price of the {Name} product has been increased by {amount} leva, and now is {Price}");
        }
        public void DecreasePrice(decimal amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price of the {Name} product has been decreased by {amount} leva, and now is {Price}");
            }
        }
        public override string ToString()
        {
            return $"Current price for the {Name} product is {Price} leva";
        }

    }
}
