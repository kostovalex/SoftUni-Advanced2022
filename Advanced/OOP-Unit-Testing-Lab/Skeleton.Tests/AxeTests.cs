using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void DurabilityShouldDecreaseAfterAttack()
        {
            var axe = new Axe(100, 50);
            var dummy = new Dummy(200, 100);

            var durabilityBefore = axe.DurabilityPoints;
            
            axe.Attack(dummy);
            
            var durabilityAfter = axe.DurabilityPoints;
            
            Assert.AreEqual(durabilityAfter + 1, durabilityBefore);
        }

        [Test]
        public void AttackWithBrokenWeaponShouldThrowAnException()
        {
            var axe = new Axe(100, -10);
            var dummy = new Dummy(200, 100);

            Assert.Throws<InvalidOperationException>(()=> axe.Attack(dummy));
        }
    }
}