namespace INStock.Tests
{
    using Microsoft.VisualBasic;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ProductConstructorTest()
        {
            var product = new Product("Milk", 2.50m,200);

            Assert.That(product.Quantity, Is.EqualTo(200));
            Assert.That(product.Label, Is.EqualTo("Milk"));
            Assert.That(product.Price, Is.EqualTo(2.50m));
        }
        
        
        
        [Test]
        public void ProductsConstructorShouldThrowExceptionIfInvalidQuantityIsGiven()
        {
            Assert.Throws<ArgumentException>(() => new Product("Milk", 2.50m, -200));
        }

        [Test]
        public void ProductsConstructorShouldThrowExceptionIfInvalidLabelIsGiven()
        {
            Assert.Throws<ArgumentException>(() => new Product("", 2.50m, 200));
        }

        [Test]
        public void ProductsConstructorShouldThrowExceptionIfInvalidPriceIsGiven()
        {
            Assert.Throws<ArgumentException>(() => new Product("Milk", 0, 200));
        }
    }
}