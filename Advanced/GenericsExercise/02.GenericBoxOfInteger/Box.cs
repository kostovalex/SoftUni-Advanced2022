using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public List<T> Items { get; set; }

        public Box()
        {
            this.Items = new List<T>();
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
