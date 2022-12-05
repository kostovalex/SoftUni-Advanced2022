using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    internal class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, decimal price) : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var item in gifts)
            {
                totalPrice += item.CalculateTotalPrice();
            }

            return totalPrice;
        }
        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }


        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
