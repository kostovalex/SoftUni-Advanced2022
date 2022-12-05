using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            var dummy = new Dummy(100, 50);

            int dummyStartHealth = dummy.Health;

            dummy.TakeAttack(50);

            Assert.That(dummy.Health + 50, Is.EqualTo(dummyStartHealth));
        }

        [Test]
        public void DeadDummyShouldThrowAnExceptionIfAttacked()
        {
            var dummy = new Dummy(0, 50);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(50));
        }

        [Test]
        public void DeadDummyShouldGiveXP()
        {
            var dummy = new Dummy(0, 50);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(50));
        }
        
        [Test]
        public void AliveDummyShouldntGiveXp()
        {
            var dummy = new Dummy(50, 50);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());           
        }
    }
}