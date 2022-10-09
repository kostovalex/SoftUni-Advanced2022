using System;

namespace CustomStack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack myStack = new CustomStack();

            myStack.Push(21);
            myStack.Push(24);
            myStack.Push(26);
            myStack.Push(27);

            
            myStack.ForEach(n => Console.WriteLine(n));

        }
    }
}
