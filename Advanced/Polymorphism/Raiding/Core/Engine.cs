namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Factories;
    using Exceptions;
    using Interfaces;

    public class Engine : IEngine
    {
        public void Run()
        {
            IFactory factory = new Factory();
            List<IHero> raid = new List<IHero>();

            int count = int.Parse(Console.ReadLine());


            while (raid.Count < count)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();
                    raid.Add(factory.CreateHero(name, type));
                }
                catch (InvalidTypeException ite)
                {
                    Console.WriteLine(ite.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;

            foreach (var hero in raid)
            {
                Console.WriteLine(hero.CastAbility());
                raidPower += hero.Power;
            }

            if (raidPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
