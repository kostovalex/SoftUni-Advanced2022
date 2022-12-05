namespace Facade
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("Mazda6")
                    .WithColor("Red")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Hiroshima")
                    .AtAdress("Somewhere in Japan")
                .Build();

            Console.WriteLine(car);
                
            
        }
    }
}
