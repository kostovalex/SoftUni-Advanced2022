using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            while (input[0] != "END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int indexToCompare = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[indexToCompare];

            int equals = 0;
            int differs = 0;
            
            foreach (Person person in people)
            {
                if (person.CompareTo(personToCompare)!=0)
                {
                    differs++;
                }
                else
                {
                    equals++;
                }
            }

            if (equals<=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {differs} {people.Count}");
            }
        }
    }
}
