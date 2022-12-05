using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
                List<Person> people = new List<Person>();
                List<Product> productsList = new List<Product>();

                string[] persons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < persons.Length; i++)
                {
                    string[] personInfo = persons[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }

                for (int i = 0; i < products.Length; i++)
                {
                    string[] productsInfo = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = productsInfo[0];
                    decimal price = decimal.Parse(productsInfo[1]);

                    Product product = new Product(name, price);
                    productsList.Add(product);
                }

                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                while (command[0] != "END")
                {
                    string personsName = command[0];
                    string productName = command[1];

                    Person person = people.FirstOrDefault(p => p.Name == personsName);
                    Product product = productsList.FirstOrDefault(prod => prod.Name == productName);

                    person.Buy(product);

                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }

                foreach (var item in people)
                {
                    Console.WriteLine(item);
                }
            }
			catch (ArgumentException ae)
			{
                Console.WriteLine(ae.Message);
                return;
			}
        }
    }
}
