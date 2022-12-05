using System;
using System.Threading;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName
        {
            get => firstName;

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.FIRST_NAME_CANNOT_BE_SHORTER_THAN);
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.LAST_NAME_CANNOT_BE_SHORTER_THAN);
                }
                lastName = value;
            }
        }
        public int Age
        {
            get => age;
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.AGE_CANNOT_BE_ZERO);
                }
                age = value;
            }
        }
        public decimal Salary
        {
            get => salary;
            private set 
            {
                //if (value < 650)
                //{
                //    throw new ArgumentException(ExceptionMessages.INVALID_SALARY);
                //}
                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += Salary * (percentage / 2) / 100;
            }
            else
            {
                this.Salary += Salary * percentage / 100;
            }
        }
        public override string ToString() => $"{FirstName} {LastName} recieves {Salary:f2} leva.";

    }
}
