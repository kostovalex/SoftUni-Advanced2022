using System;

namespace CustomStack
{
    public class CustomStack
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

        public CustomStack()
        {
            this.Count = 0;
            this.items = new int[InitialCapacity];
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

        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            int currentIndex = this.Count - 1;
            int poppedElement = this.items[currentIndex];

            this.items[currentIndex] = default(int);

            this.Count--;

            if (this.Count == this.items.Length / 4)
            {
                this.Shrink();
            }

            return poppedElement;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.items[this.Count - 1];
        }

        public void ForEach(Func<int, int> function)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = function(this.items[i]);
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
