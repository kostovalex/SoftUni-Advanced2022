using System;


namespace CustomQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private int count;
        private int[] items { get; set; }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }
        public CustomQueue()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0; 
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
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

        private void ShiftLeft()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
                
            }
            this.items[this.Count - 1] = default(int);
        }

        public void Enqueue(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = element;
            this.Count++;
        }

        public int Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            int dequeuedElement = this.items[0];
            this.items[0] = default(int);
           
            this.ShiftLeft();

            this.Count--;

            if (this.Count == this.items.Length/4)
            {
                this.Shrink();
            }

            return dequeuedElement;
        }
        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.items[0];
        }

        public void Clear()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
           
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = default(int);
            }
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        public override string ToString()
        {
            return string.Join(" ", this.items);
        }
    }
}
