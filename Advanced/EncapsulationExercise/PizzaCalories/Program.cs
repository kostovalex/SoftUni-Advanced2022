using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
                string[] pizzaInfo = Console.ReadLine().Split(" ");
                string[] info = Console.ReadLine().Split(" ");
                
                Pizza pizza = new Pizza(pizzaInfo[1]);
                Dough dough = new Dough(info[1], info[2], double.Parse(info[3]));
                pizza.Dough = dough;

                string[] toppingInfo = Console.ReadLine().Split(" ");

                while (toppingInfo[0] != "END")
                {
                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);

                    toppingInfo = Console.ReadLine().Split(" ");
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
              
            }
			catch (Exception ae)
			{
                Console.WriteLine(ae.Message);
			}

        }
    }
}
