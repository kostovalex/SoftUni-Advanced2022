using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    internal class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");
            return this.price;
        }
    }
}
