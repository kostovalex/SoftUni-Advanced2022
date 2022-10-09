using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(200);
            doublyLinkedList.AddLast(300);
            doublyLinkedList.AddFirst(100);
            doublyLinkedList.AddLast(400);


            doublyLinkedList.ForEach(n => Console.WriteLine(n));
            Console.WriteLine();

            Console.WriteLine(string.Join (" ", doublyLinkedList.ToArray()));
            Console.WriteLine();
            Console.WriteLine(doublyLinkedList.RemoveLast());

            Console.WriteLine();
            Console.WriteLine(string.Join(" ", doublyLinkedList.ToArray()));
        }
    }
}
