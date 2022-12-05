using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            List<string> list = new List<string>() { "poveche", "qm", "da", "nqma" };
            stack.AddRange(list);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
