﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {

                Name = name;
                Age = age;
                Gender = gender;
            
        }

        public string Name 
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))  throw new ArgumentException("Invalid input!");
                
                name = value;   
            }
        }
        public int Age 
        {
            get { return age; }
            set
            {
                if (value <= 0 ) throw new ArgumentException("Invalid input!");

                age = value;
            } 
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid input!");

                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Noise!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().Trim();
        }
    }
}
