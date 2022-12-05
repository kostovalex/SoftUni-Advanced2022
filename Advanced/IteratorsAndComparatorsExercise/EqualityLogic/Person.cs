using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        { 
            Name = name;
            Age = age;           
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                return Age.CompareTo(other.Age);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            Person newPerson = (Person)obj;
            if(newPerson == null)
            {
                return false;
            }
            return newPerson.Name == Name && newPerson.Age == Age;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
    }
}
