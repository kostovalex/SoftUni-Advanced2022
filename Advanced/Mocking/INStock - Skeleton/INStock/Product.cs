using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label 
        { 
            get => label; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Label cannot be null!");
                }
                label = value;
            }
                 
        }
        public decimal Price 
        { 
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or null!");
                }
                price = value;
            }
        }
        public int Quantity 
        { 
            get => quantity;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Quantity cannot be negative number!");
                }
                quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
