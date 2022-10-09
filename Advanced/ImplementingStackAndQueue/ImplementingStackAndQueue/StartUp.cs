using System;

namespace ImplementingStackAndQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList();

            myList.Add(1);
            myList.Add(2);
            myList.Add(7);

            myList.Insert(2, 5);
            myList.Insert(3, 6);
            myList.Insert(2, 3);
            myList.Insert(3, 4);


            myList.Reverse();
            
            Console.WriteLine(myList.ToString());




            

            

        }
    }
}
