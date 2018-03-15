
using NUnit.Framework;

namespace parrot
{
    [TestFixture]
    public class ParrotTest
    {

        private Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed)
        {
            return Parrot.Create( type, numberOfCoconuts, voltage, isNailed, baseSpeed);
        }

        private double _baseSpeed = 12.0;
        [Test]
        public void GetSpeedOfEuropeanParrot()
        {
            var expectedBaseSpeed = _baseSpeed;
            var numberOfCoconuts = 0;
            var voltage = 0;
            var isNailed = false;
            Parrot parrot = Create(ParrotTypeEnum.EUROPEAN, numberOfCoconuts, voltage, isNailed, _baseSpeed);
            Assert.AreEqual(expectedBaseSpeed, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            Parrot parrot = Create(ParrotTypeEnum.AFRICAN, 1, 0, false, _baseSpeed);
            Assert.AreEqual(3.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            Parrot parrot = Create(ParrotTypeEnum.AFRICAN, 2, 0, false, _baseSpeed);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var baseSpeed = 12.0;
            var expected = baseSpeed;
            Parrot parrot = Create(ParrotTypeEnum.AFRICAN, 0, 0, false, baseSpeed);
            Assert.AreEqual(expected, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            Parrot parrot = Create(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 0, true, _baseSpeed);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var voltage = 1.5;
            Parrot parrot = Create(ParrotTypeEnum.NORWEGIAN_BLUE, 0, voltage, false, _baseSpeed);
            Assert.AreEqual(_baseSpeed * voltage, parrot.GetSpeed());
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            Parrot parrot = Create(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, false, _baseSpeed);
            Assert.AreEqual(24.0, parrot.GetSpeed());
        }
    }
}
