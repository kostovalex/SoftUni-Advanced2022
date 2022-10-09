using System;
using System.Reflection;

namespace ImplementingStackAndQueue
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items { get; set; }

        private int Count { get; set; }
        private int this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }
            set
            {
                CheckIndex(index);
                items[index] = value;
            }
        }

        public int[] publicArray { 
            get 
            {
                int[] publicArray = new int[this.Count];

                for (int i = 0; i < this.Count; i++)
                {
                    publicArray[i] = this.items[i];
                }
                return publicArray;
            }
            set
            {
                int[] publicArray = new int[this.Count];

                for (int i = 0; i < this.Count; i++)
                {
                    publicArray[i] = this.items[i];
                }
                
            }
        }
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }
        
        private void CheckIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length*2];
            
            for (int i = 0; i < this.Count; i++)
            {
                copy[i]=this.items[i];
            }
            this.items = copy;  
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        
        
        
        
        public void Add(int element)
        {
            if (this.items.Length==this.Count)
            {
                this.Resize(); 
            }
            this.items[this.Count] = element;
            this.Count++;
        }
        
        public int RemoveAt(int index)
        {
            CheckIndex(index);
            
            int removedItem = this.items[index];

            this.items[index] = default(int);

            this.ShiftLeft(index);

            this.Count--;

            if (this.Count==this.items.Length/4)
            {
                this.Shrink();
            }
           
            return removedItem;
        }

        public void Insert(int index, int item)
        {
            CheckIndex(index);

            if (items.Length==this.Count)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            items[index] = default(int);
            items[index] = item;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element == this.items[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndex(firstIndex);
            CheckIndex(secondIndex);

            int temporaryStorage = default(int);
            temporaryStorage = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temporaryStorage;
        }

        public void Reverse() 
        {
            int[] copy = new int[this.items.Length];
            for (int i = 0; i < this.publicArray.Length; i++)
            {
                copy[i] = this.publicArray.Length - i;
                  
            }
            this.items = copy;
        }

        public override string ToString()
        {
            return string.Join(" ", this.publicArray); 
        }
    }
}
