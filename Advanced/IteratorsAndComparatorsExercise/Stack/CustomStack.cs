using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index = 0;

        public CustomStack()
        {
            items = new List<T>();
        }

        public void Push(List<T> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                this.items.Add(items[i]);
                this.index++;
            }
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            
            T element = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            index--;
            return element;
        }

        public void EndCommand()
        {
            items.Reverse();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
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
