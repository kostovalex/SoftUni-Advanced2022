using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
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
        

        public int Comparer(T element)
        {
            List<T> result = new List<T>();
            
            foreach (var item in Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    result.Add(item);
                }
            }
            return result.Count;    
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
