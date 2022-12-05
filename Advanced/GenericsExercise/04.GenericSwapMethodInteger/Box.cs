using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public List<T> Items { get; set; }

        public Box()
        {
            this.Items = new List<T>();
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = Items[firstIndex];
            Items[firstIndex] = Items[secondIndex];
            Items[secondIndex] = temp;
        }
        
        public override string ToString()
        {
            StringBuilder newSb = new StringBuilder();
            foreach (var item in Items)
            {
                newSb.AppendLine($"{typeof(T)}: {item}");                
            }
            newSb.ToString().TrimEnd();
            return newSb.ToString();
        }
    }
}
