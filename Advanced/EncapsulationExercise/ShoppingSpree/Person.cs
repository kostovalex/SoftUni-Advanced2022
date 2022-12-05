using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
        }

        public void Buy(Product product)
        {
            if (this.Money >= product.Price)
            {
                bagOfProducts.Add(product);
                this.Money -= product.Price;
                
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            if (bagOfProducts.Count>0)
            {
                return $"{this.Name} - {string.Join(", ", bagOfProducts)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }            
        }
    }
}
