using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;//meat, veggies, cheese, or a sauce. 
        private double weight;
        private double calories;
        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
            CaloriesCalculator(Type);
        }

        private string Type
        {
            get => type;
            set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        private double Weight
        {
            get => weight;
            set
            {
                if (value<1||value>50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get =>  calories;
        }
        private void CaloriesCalculator(string type)
        {
            double modifier = 0;
            switch (type.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }
            double calorieSum = modifier * this.Weight * 2.00;
            this.calories = calorieSum;
        }
    }
}
