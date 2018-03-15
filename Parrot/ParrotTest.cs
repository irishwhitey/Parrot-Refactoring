
using NUnit.Framework;

namespace parrot
{
    [TestFixture]
    public class ParrotTest
    {
        private double _baseSpeed = 12.0;
        [Test]
        public void GetSpeedOfEuropeanParrot()
        {
            var expectedBaseSpeed = _baseSpeed;
            Parrot parrot = new Parrot(ParrotTypeEnum.EUROPEAN, 0, 0, false, _baseSpeed);
            Assert.AreEqual(expectedBaseSpeed, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            Parrot parrot = new Parrot(ParrotTypeEnum.AFRICAN, 1, 0, false, _baseSpeed);
            Assert.AreEqual(3.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            Parrot parrot = new Parrot(ParrotTypeEnum.AFRICAN, 2, 0, false, _baseSpeed);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var baseSpeed = 12.0;
            var expected = baseSpeed;
            Parrot parrot = new Parrot(ParrotTypeEnum.AFRICAN, 0, 0, false, baseSpeed);
            Assert.AreEqual(expected, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            Parrot parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 0, true, _baseSpeed);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            Parrot parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 1.5, false, _baseSpeed);
            Assert.AreEqual(18.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            Parrot parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, false, _baseSpeed);
            Assert.AreEqual(24.0, parrot.GetSpeed());
        }
    }
}
