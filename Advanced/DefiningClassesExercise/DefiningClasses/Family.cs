using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
		private List<Person> people = new List<Person>();
	
		
		private List<Person> People
		{
			//get { return people; }
			set { people = value; }
		}

		public void AddMember(Person person)
		{
			
			people.Add(person);
		}

		public Person GetOldestMember()
		{
			Person oldestMember = people.OrderByDescending(p => p.Age).First();
			
			return oldestMember;
		}
	}
}
