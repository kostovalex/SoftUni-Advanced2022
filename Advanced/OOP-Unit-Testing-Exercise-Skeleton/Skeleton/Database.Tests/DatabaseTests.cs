namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void DatabaseConstructorAndCountTest(int[] array)
        {
            var database = new Database(array);

            Assert.That(database.Count, Is.EqualTo(array.Length));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void DatabaseCapacityShouldBeLimitedTo16(int[] array)
        {
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldThrowAnExceptionIfDatabaseIsFull(int[] array)
        {
            var database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(12));
        }

        [Test]
        public void RemoveShouldRemoveLastElement()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] modifiedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            
            var database = new Database(array);
            
            database.Remove();
            database.Remove();

            CollectionAssert.AreEqual(database.Fetch(), modifiedArray);
    
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenInvokedOnEmptyDatabase()
        {
            int[] array = new int[0];
            var database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnTheElementsOfTheArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var database = new Database(array);

            CollectionAssert.AreEqual(array, database.Fetch());
        }

    }
}
