using Microsoft.VisualBasic;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode Previous { get; set; }
            public ListNode(int value)
            {
                this.Value = value;
            }

        }
        private ListNode Head;
        private ListNode Tail;

        public int Count { get; private set; }


        public void AddFirst(int value)
        {
            if (this.Count == 0)
            {
                this.Head = new ListNode(value);
                this.Tail = this.Head;
            }
            else
            {
                ListNode newHead = new ListNode(value);
                newHead.Next = this.Head;
                this.Head.Previous = newHead;
                this.Head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int value)
        {
            if (this.Count == 0)
            {
                this.Head = new ListNode(value);
                this.Tail = this.Head;
            }
            else
            {
                ListNode newTail = new ListNode(value);
                this.Tail.Next = newTail;
                newTail.Previous = this.Tail;
                this.Tail = newTail;
            }
            this.Count++;
        }

        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else
            {
                int removedItem = this.Head.Value;

                if ((this.Count == 1))
                {
                    this.Head = null;
                    this.Tail = null;
                }
                else
                {
                    this.Head = this.Head.Next;
                    this.Head.Previous = null;
                }

                this.Count--;
                return removedItem;
            }

        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else
            {
                int removedItem = this.Tail.Value;

                if (this.Count == 1)
                {
                    this.Tail = null;
                    this.Head = null;
                }
                else
                {
                    this.Tail = this.Tail.Previous;
                    this.Tail.Next = null;
                }

                this.Count--;
                return removedItem;
            }

        }

        public void ForEach(Action<int> action)
        {
            ListNode currentNode = this.Head;
            while (currentNode!= null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    
        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            int arrayCounter = 0;
           
            ListNode currentNode = this.Head;
            while (arrayCounter < this.Count)
            {
                array[arrayCounter] = currentNode.Value;
                currentNode = currentNode.Next;
                arrayCounter++; 
            }

            return array;
        }
    
    }
}