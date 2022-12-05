namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");

            Assert.That(book.Author, Is.EqualTo("Ivan Vazov"));
            Assert.That(book.BookName, Is.EqualTo("Pod Igoto"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorThrowsExceptionIfBookNameIsNull(string name)
        {
            Assert.Throws<ArgumentException>(() => new Book(name, "Ivan Vazov"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorThrowsExceptionIfAuthorIsNull(string author)
        {
            Assert.Throws<ArgumentException>(() => new Book("Pod Igoto", author));
        }

        [Test]
        public void FindFootnoteShouldReturnNoteByGivenNumber()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");
            book.AddFootnote(1, "Some string");

            Assert.That(book.FindFootnote(1), Is.EqualTo("Footnote #1: Some string"));
        }

        [Test]
        public void FindFootnoteThrowsExceptionIfGivenNoteDoesntExist()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");
            book.AddFootnote(1, "Some string");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2));
        }

        [Test]
        public void AddFootnoteMethodShouldAddGivenNoteToTheDictionary()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");

            book.AddFootnote(1, "Some string");

            Assert.That(book.FindFootnote(1), Is.EqualTo("Footnote #1: Some string"));
        }
        [Test]
        public void AddFootnoteMethodThrowsExceptionIfNoteExists()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");

            book.AddFootnote(1, "Some string");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "Some other string"));
        }

        [Test]
        public void AlterFootnoteReplacesOldTextWithGivenTextInFootnote()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");

            book.AddFootnote(1, "Some string");

            book.AlterFootnote(1, "New string");

            Assert.That(book.FindFootnote(1), Is.EqualTo("Footnote #1: New string"));
        }

        [Test]
        public void AlterFootnoteThrowsExceptionIfGivenNoteDoesntExist()
        {
            var book = new Book("Pod Igoto", "Ivan Vazov");

            book.AddFootnote(1, "Some string");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2, "New string"));

        }
    }
}