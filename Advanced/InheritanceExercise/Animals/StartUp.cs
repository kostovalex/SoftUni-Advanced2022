using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();  
            
            
            string animalType = Console.ReadLine();
            while (animalType != "Beast!")
            {
                try
                {
                    string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string gender = string.Empty;

                    if (info.Length > 2)
                    {
                        gender = info[2];
                    }

                    switch (animalType)
                    {
                        case "Cat":
                            Cat newCat = new Cat(name, age, gender);
                            animals.Add(newCat);
                            break;
                        case "Frog":
                            Frog newFrog = new Frog(name, age, gender);
                            animals.Add(newFrog);
                            break;
                        case "Dog":
                            Dog newDog = new Dog(name, age, gender);
                            animals.Add(newDog);
                            break;
                        case "Kitten":
                            Kitten newKitten = new Kitten(name, age);
                            animals.Add(newKitten);
                            break;
                        case "Tomcat":
                            Tomcat newTomcat = new Tomcat(name, age);
                            animals.Add(newTomcat);
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);                   
                }
                

                animalType = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }

        }
    }
}
