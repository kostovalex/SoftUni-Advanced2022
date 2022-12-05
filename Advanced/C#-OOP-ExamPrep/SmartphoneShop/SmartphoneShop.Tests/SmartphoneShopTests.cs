using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ShopConstructorAndCapacityTest()
        {
            var shop = new Shop(10);

            Assert.That(shop.Capacity, Is.EqualTo(10));
        }
        
        [TestCase(-1)]
        [TestCase(-100)]
        public void ConstructorShouldThrowExceptionIfCapacityIsInvalid(int value)
        {
            Assert.Throws<ArgumentException>(() => new Shop(value));
        }

        [Test]
        public void AddMethodAndCountTest()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var huawei = new Smartphone("Huawei", 100);
            var shop = new Shop(5);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);
            shop.Add(huawei);

            Assert.That(shop.Count, Is.EqualTo(4));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfModelExists()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var huawei = new Smartphone("Huawei", 100);
            var shop = new Shop(10);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);
            shop.Add(huawei);

            Assert.Throws<InvalidOperationException>(() => shop.Add(huawei));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfShopIsFull()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var huawei = new Smartphone("Huawei", 100);
            var shop = new Shop(4);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);
            shop.Add(huawei);

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("LG", 100)));
        }

        [Test]
        public void RemoveMethodShouldRemoveGivenModel()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var huawei = new Smartphone("Huawei", 100);
            var shop = new Shop(4);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);
            shop.Add(huawei);

            shop.Remove("Nokia");

            Assert.That(shop.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfGivenModelDoesntExist()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var shop = new Shop(4);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Huawei"));
        }

        [Test]
        public void TestPhoneShouldReduceBatteryChargeWithBatteryUsage()
        {
            var nokia = new Smartphone("Nokia", 100);
            var shop = new Shop(4);

            shop.Add(nokia);

            shop.TestPhone("Nokia", 49);

            Assert.That(51, Is.EqualTo(nokia.CurrentBateryCharge));
        }
        [Test]
        public void TestPhoneThrowsExceptionIfModelDoesntExist()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var shop = new Shop(4);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Huawei", 50));
        }

        [Test]
        public void TestPhoneThrowsExceptionIfBatteryUsageIsBiggerThanCharge()
        {
            var nokia = new Smartphone("Nokia", 50);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var shop = new Shop(4);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 100));
        }
        [Test]
        public void ChargePhoneThrowsExceptionIfModelDoesntExist()
        {
            var nokia = new Smartphone("Nokia", 100);
            var samsung = new Smartphone("Samsung", 100);
            var xiaomi = new Smartphone("Xiaomi", 100);
            var shop = new Shop(4);

            shop.Add(nokia);
            shop.Add(samsung);
            shop.Add(xiaomi);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Huawei"));
        }

        [Test]
        public void ChargePhoneShouldRestoreCurrentChargeToMaximumBatteryCharge()
        {
            var xiaomi = new Smartphone("Xiaomi", 100);
            var shop = new Shop(4);

            shop.Add(xiaomi);

            shop.TestPhone("Xiaomi", 49);
            shop.ChargePhone("Xiaomi");

            Assert.AreEqual(xiaomi.MaximumBatteryCharge, xiaomi.CurrentBateryCharge);
        }

    }
}