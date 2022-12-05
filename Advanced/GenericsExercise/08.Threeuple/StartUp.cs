using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAdressTown = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string, string> nameAdressTuple = new Tuple<string, string, string>();
            nameAdressTuple.item1 = $"{nameAdressTown[0]} {nameAdressTown[1]}";
            nameAdressTuple.item2 = nameAdressTown[2];
            if (nameAdressTown[3] == "New")
            {
                nameAdressTuple.item3 = nameAdressTown[3] + " York";
            }
            else
            {
                nameAdressTuple.item3 = nameAdressTown[3];
            }
            

            string[] nameBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int, bool> nameBeerTuple = new Tuple<string, int, bool>();
            nameBeerTuple.item1 = nameBeer[0];
            nameBeerTuple.item2 = int.Parse(nameBeer[1]);
            if (nameBeer[2] == "drunk")
            {
                nameBeerTuple.item3 = true;
            }
            else
            {
                nameBeerTuple.item3 = false;
            }

            string[] nameBank = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, double, string> integerDoubleTuple = new Tuple<string, double, string>();
            integerDoubleTuple.item1 = nameBank[0];
            integerDoubleTuple.item2 = double.Parse(nameBank[1]);
            integerDoubleTuple.item3 = nameBank[2];

            Console.WriteLine(nameAdressTuple);
            Console.WriteLine(nameBeerTuple);
            Console.WriteLine(integerDoubleTuple);

        }
    }
}
