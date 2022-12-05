using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType; 
        private string bakingTechnique;
        private double weight; 
        private double calories; 
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Weight = weight;
            CaloriesCalculator();
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() == "white"|| value.ToLower() == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set 
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy"|| value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                
            }
        }
        private double Weight
        {
            get { return weight; }
            set
            {
                if (value<1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                } 
                weight = value; }
        }
        public double Calories { get => calories; }
        private void CaloriesCalculator()
        {
            double flourModifier = 0;
            double techModifier = 0;
            switch (FlourType)
            {
                case "white":
                    flourModifier = 1.5;
                    break;
                case "wholegrain":
                    flourModifier = 1.0;
                    break;
            }
            switch (BakingTechnique)
            {
                case"crispy":
                    techModifier = 0.9;
                    break;
                case "chewy":
                    techModifier = 1.1;
                    break;
                case "homemade":
                    techModifier = 1.0;
                    break;
            }
            double caloriesSum = (2 * this.Weight) * flourModifier * techModifier;
            this.calories = caloriesSum;
        }



    }
}
