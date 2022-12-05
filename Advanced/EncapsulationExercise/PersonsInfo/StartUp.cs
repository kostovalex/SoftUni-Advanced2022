using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("CSKA");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] personInfo = Console.ReadLine().Split(" ");

                    string firstName = personInfo[0];
                    string lastName = personInfo[1];
                    int age = int.Parse(personInfo[2]);
                    decimal salary = decimal.Parse(personInfo[3]);

                    Person person = new Person(firstName, lastName, age, salary); 
                    team.AddPlayer(person);
                   
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"First team has {team.ReserveTeam.Count} players.");
        }
    }
}
