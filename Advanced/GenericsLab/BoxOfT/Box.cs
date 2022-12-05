using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> internalArray;
        public int Count { get { return internalArray.Count; } }
        public Box()
        {
            this.internalArray = new List<T>();
        }


        public void Add(T element)
        {
            this.internalArray.Add(element);
        }
        
        public T Remove()
        {
            if (internalArray.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T element = this.internalArray[this.Count-1];
            
            this.internalArray.RemoveAt(this.Count-1);
            
            return element;
            
        }
    }
}
