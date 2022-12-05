using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string GENDER = "female";
        public Kitten(string name, int age) : base(name, age, GENDER)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
