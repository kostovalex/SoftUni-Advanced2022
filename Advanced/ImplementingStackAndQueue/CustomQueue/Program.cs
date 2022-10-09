using System;

namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue myQueue = new CustomQueue();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);
            myQueue.Enqueue(8);
            myQueue.Enqueue(9);
            Console.WriteLine(myQueue.ToString());
            Console.WriteLine();

            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();

            myQueue.ForEach(n => Console.WriteLine(n));

            Console.WriteLine();



        }
    }
}
