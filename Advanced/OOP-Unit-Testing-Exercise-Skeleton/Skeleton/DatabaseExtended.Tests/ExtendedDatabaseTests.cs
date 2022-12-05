namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void PersonConstructorTest()
        {
            long id = 9223372036854775807;
            string username = "Pesho";

            Person newPerson = new Person(id, username);

            Assert.That(newPerson.Id, Is.EqualTo(id));
            Assert.That(newPerson.UserName, Is.EqualTo(username));

        }

        [Test]
        public void DatabaseConstructorAndCountTest()
        {
            Person[] people = new Person[] {new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
                new Person(9223372036854775513, "person5"),
                new Person(9223372036854775512, "person6"),
                new Person(9223372036854775511, "person7"),
                new Person(9223372036854775509, "person8"),
                new Person(9223372036854775508, "person9"),
                new Person(9223372036854775507, "person10"),
                new Person(9223372036854775506, "person11"),
                new Person(9223372036854775505, "person12"),
                new Person(9223372036854775504, "person13"),
                new Person(9223372036854775503, "person14"),
                new Person(9223372036854775502, "person15"),
                new Person(9223372036854775501, "person16") };

            Database database = new Database(people);

            Assert.That(database.Count, Is.EqualTo(people.Length));
        }
        

        [Test]
        public void AddRangeThrowExceptionIfInputIsBiggerThan16()
        {
            Person[] people = new Person[]
            {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
                new Person(9223372036854775513, "person5"),
                new Person(9223372036854775512, "person6"),
                new Person(9223372036854775511, "person7"),
                new Person(9223372036854775509, "person8"),
                new Person(9223372036854775508, "person9"),
                new Person(9223372036854775507, "person10"),
                new Person(9223372036854775506, "person11"),
                new Person(9223372036854775505, "person12"),
                new Person(9223372036854775504, "person13"),
                new Person(9223372036854775503, "person14"),
                new Person(9223372036854775502, "person15"),
                new Person(9223372036854775501, "person16"),
                new Person(9223372036854775241, "person17") };
            
            Assert.Throws<ArgumentException>(() => new Database(people));
        }
        [Test]
        public void AddRangeShouldWorkWithEmptyArray()
        {
            Person[] people = new Person[0];

            Database database = new Database(people);

            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfPersonsIDExists()
        {
            Person[] people = new Person[]
           {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
           };

            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(9223372036854775515, "person5")));

        }
        [Test]
        public void AddMethodShouldThrowAnExceptionIfPersonsUsernameExists()
        {
            Person[] people = new Person[]
           {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4")
           };
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(9223372036854775516, "person4")));
        }
        [Test]
        public void RemoveShouldThrowAnExceptionIfDatabaseIsEmpty()
        {
            Person[] people = new Person[0];

            Database database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveMethodShouldEraseLastPerson()
        {
            Person[] people = new Person[]
          {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
          };
            var database = new Database(people);

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(people.Length - 1));
        }
        [Test]
        public void FindByUsernameShouldReturnThePersonWithSameUsername()
        {
            Person[] people = new Person[]
         {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
         };
            var database = new Database(people);

            var neededUser = new Person(9223372036854775514, "person3");
            Assert.That(neededUser.UserName, Is.EqualTo(database.FindByUsername("person3").UserName));
        }
        [Test]
        public void FindByUsernameShouldThrowAnExceptionIfUsernameDoesntExist()
        {
            Person[] people = new Person[]
            {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
            };
            var database = new Database(people);
            
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("person5"));
        }
        [Test]
        public void FindByUsernameShouldThrowAnExceptionIfUsernameIsNull()
        {
            Person[] people = new Person[]
            {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
            };
            var database = new Database(people);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""));
        }
        [Test]
        public void FindByIDShouldReturnThePersonWithSameID()
        {
            Person[] people = new Person[]
         {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
         };
            
            var database = new Database(people);
           
            var neededUser = new Person(9223372036854775514, "person3");
            
            Assert.That(neededUser.Id, Is.EqualTo(database.FindById(9223372036854775514).Id));
        }
        
        [Test]
        public void FindByIdShouldThrowAnExceptionIfIdDoesntExist()
        {
            Person[] people = new Person[]
            {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
            };
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.FindById(1223372036854775515));
        }
        [Test]
        public void FindByIdShouldThrowAnExceptionIfIdIsInvalid()
        {
            Person[] people = new Person[]
            {
                new Person(9223372036854775807, "person1"),
                new Person(9223372036854775516, "person2"),
                new Person(9223372036854775514, "person3"),
                new Person(9223372036854775515, "person4"),
            };
            var database = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-121));
        }
    }
}
