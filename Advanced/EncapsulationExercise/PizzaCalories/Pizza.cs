using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private double totalCalories;
        public Pizza(string name)
        {
            this.Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public int ToppingsCount
        {
            get { return toppings.Count; }
        }
        public Dough Dough
        {
            get => dough;
            set { dough = value; }
        }
        public double TotalCalories
        {
            get { return totalCalories; }
            private set
            {
                totalCalories = value;
            }
        }
        private void CaloriesCalculator()
        {
            if (ToppingsCount>0)
            {
                double totalCalories = 0;

                totalCalories += this.dough.Calories;
                foreach (var item in toppings)
                {
                    totalCalories += item.Calories;
                }

                this.TotalCalories = totalCalories;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (ToppingsCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
            CaloriesCalculator();
        }
    }
}
