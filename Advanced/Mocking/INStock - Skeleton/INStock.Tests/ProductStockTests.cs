namespace INStock.Tests
{
    using INStock.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        Mock<IProductStock> mockedPs = new Mock<IProductStock>();
        Mock<IProduct> mockeProduct = new Mock<IProduct>();
        
        [Test]
        public void AddMethodTest()
        {
            var ps = mockedPs.Object;
            var product = mockeProduct.Object;

            ps.Add(product);

            Assert.That(ps.Count, Is.EqualTo(1));
        }
        

    }
}
