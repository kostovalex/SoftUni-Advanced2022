using System;

namespace _07.Tuple
{
    public class Startup
    {
        static void Main(string[] args)
        {
           
            string[] nameAdress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> nameAdressTuple = new Tuple<string, string>();
            nameAdressTuple.item1 = $"{nameAdress[0]} {nameAdress[1]}";
            nameAdressTuple.item2 = nameAdress[2];

            string[] nameBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> nameBeerTuple = new Tuple<string, int>();
            nameBeerTuple.item1 = nameBeer[0];
            nameBeerTuple.item2 = int.Parse(nameBeer[1]);

            string[] integerDouble = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> integerDoubleTuple = new Tuple<int, double>();
            integerDoubleTuple.item1 = int.Parse(integerDouble[0]);
            integerDoubleTuple.item2 = double.Parse(integerDouble[1]);



            Console.WriteLine(nameAdressTuple);
            Console.WriteLine(nameBeerTuple);
            Console.WriteLine(integerDoubleTuple);
        }
    }
}
