using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index = 0;
        public ListyIterator(List<T> items)
        {
            this.items = items;
        }

        public bool Move()
        {           
            if (this.index < items.Count - 1)
            {
                index++;
                return true;
            }
            else { return false; }  
        }
        public bool HasNext()
        {
            if (this.index == items.Count - 1)
            {
                return false;
            }
            else { return true; }
            
        }
        public void Print()
        {
            if (items.Count==0)
            {
                throw new InvalidOperationException("Ivalid Operation!");
            }
            else
            {
                Console.WriteLine(items[index]);
            }
        }

        public void PrintAll()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Ivalid Operation!");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                
                foreach (var item in items)
                {
                   sb.Append($"{item} "); 
                }

                sb.ToString().TrimEnd();
                Console.WriteLine(sb);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    
}
