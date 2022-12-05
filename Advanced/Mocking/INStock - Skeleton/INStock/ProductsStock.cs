using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;
        public ProductStock()
        {
            products = new List<IProduct>();
        }
        public List<IProduct> Product { get { return products; } }
        public int Count => products.Count;
        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public void Add(IProduct product)
        {
            if (!products.Any(p => p.Label == product.Label))
            {
                products.Add(product);
            }
        }

        public bool Contains(IProduct product)
        {
            if (products.Any(p => p.Label == product.Label))
            {
                if (products.Where(p => p.Label == product.Label).First().Quantity > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("There is no such Index in the collection!");
            }
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
            => products.Where(p => p.Price == price).ToList();



        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
            => products.Where(p => p.Quantity == quantity).ToList();

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
            => products.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p.Price).ToList();

        public IProduct FindByLabel(string label)
        {
            if (!products.Any(p => p.Label == label))
            {
                throw new ArgumentException("Product with this label doesn't exist!");
            }
            return products.Where(p => p.Label == label).First();
        }

        public IProduct FindMostExpensiveProduct()
            => products.OrderByDescending(p => p.Price).First();

        public IEnumerator<IProduct> GetEnumerator()
        {
            products = products.Where(p => p.Quantity != 0).ToList();
            for (int i = 0; i < this.Count; i++)
            {
                yield return products[i];
            }
        }

        public bool Remove(IProduct product)
        {
            if (!products.Any(p => p.Label == product.Label))
            {
                throw new ArgumentException("Product doesn't exist!");
            }
            products.Remove(product);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
