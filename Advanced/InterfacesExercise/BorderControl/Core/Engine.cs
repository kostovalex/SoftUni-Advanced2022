
namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using Interfaces;
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    using BorderControl.IO.Interfaces;

    internal class Engine : IEngine
    {
        public Engine(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; private set; }

        public IWriter Writer { get; private set; }

        public void Run()
        {
            Dictionary<string, IBuyer> capitalista = new Dictionary<string, IBuyer>();

            int count = int.Parse(this.Reader.Read());

            for (int i = 0; i < count; i++)
            {
                string[] input = this.Reader.Read().Split(' ');
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];

                    Citizen buerger = new Citizen(name, age, id, birthday);
                    capitalista.Add(name, buerger);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    Rebel vojvoda = new Rebel(name, age, group);
                    capitalista.Add(name, vojvoda);
                }
            }

            string guysWhoEat = this.Reader.Read();

            while (guysWhoEat != "End")
            {
                foreach (var item in capitalista)
                {
                    if (item.Key == guysWhoEat)
                    {
                        item.Value.BuyFood();
                    }
                }
               
                guysWhoEat = Console.ReadLine();
            }

            int totalFood = 0;
            foreach (var item in capitalista)
            {
                totalFood += item.Value.Food;
            }

            this.Writer.WriteLine(totalFood.ToString());
        }
    }
}
