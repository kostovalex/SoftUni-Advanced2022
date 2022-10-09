using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        internal class Person
        {

            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);

            Action<Person> printer = CreatePrinter(format);
            
            PrintFilteredPeople(people, filter, printer);

        }
        private static List<Person> ReadPeople()
        {

            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person() { Name = input[0], Age = int.Parse(input[1]) };

                people.Add(person);
            }

            return people;

        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                Func<Person, bool> filter = n => n.Age < ageThreshold;
                return filter;
            }
            else
            {
                Func<Person, bool> filter = n => n.Age >= ageThreshold;
                return filter;
            }
        }
        private static Action<Person> CreatePrinter(string[] format)
        {
            if (format.Length == 1)
            {
                if (format[0] == "name")
                {
                    Action<Person> printer = n => Console.WriteLine($"{n.Name}");
                    return printer;
                }
                else
                {
                    Action<Person> printer = n => Console.WriteLine($"{n.Age}");
                    return printer;
                }
            }
            else
            {
                Action<Person> printer = n => Console.WriteLine($"{n.Name} - {n.Age}");
                return printer;
            }
            }

            private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
            {
                people = people.Where(filter).ToList();

                foreach (var item in people)
                {
                    printer(item);
                }
            }



        }
    } 

