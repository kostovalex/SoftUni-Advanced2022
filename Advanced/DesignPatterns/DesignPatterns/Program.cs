using System;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            var db = SingletonDataContainer.Instance;
            var db1 = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Moscow"));
            Console.WriteLine(db1.GetPopulation("Sofia"));
            Console.WriteLine(db2.GetPopulation("Berlin"));
        }
    }
}
