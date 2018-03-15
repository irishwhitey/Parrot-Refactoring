using System;

namespace parrot
{
    public class Parrot
    {
        protected readonly int _numberOfCoconuts;
        protected readonly double _voltage;
        protected readonly bool _isNailed;
        protected readonly double _baseSpeed;
        protected double _getLoadFactor = 9.0;
        protected double _minimumBaseSpeedWithVoltage = 24.0;
        protected readonly int _minimumSpeed = 0;

        public Parrot(int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed)
        {
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
            _baseSpeed = baseSpeed;
        }

        public virtual double GetSpeed()
        {
            throw new Exception("Should be unreachable");
        }

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot(numberOfCoconuts, voltage, isNailed, baseSpeed);
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(numberOfCoconuts, voltage, isNailed, baseSpeed);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorweigenBlue(numberOfCoconuts, voltage, isNailed, baseSpeed);
            }
            return new Parrot(numberOfCoconuts, voltage, isNailed, baseSpeed);
        }
    }

    public class EuropeanParrot :Parrot
    {
        public EuropeanParrot(int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed) 
            : base(numberOfCoconuts, voltage, isNailed, baseSpeed)
        {
        }

        public override double GetSpeed()
        {
            return _baseSpeed;
        }
    }

    public class AfricanParrot : Parrot
    {
        public AfricanParrot(int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed) : base(numberOfCoconuts, voltage, isNailed, baseSpeed)
        {
        }


        public override double GetSpeed()
        {
            return Math.Max(_minimumSpeed, _baseSpeed - _getLoadFactor * _numberOfCoconuts);
        }
        
    }

    public class NorweigenBlue :Parrot
    {
        public NorweigenBlue(int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed) : base(numberOfCoconuts, voltage, isNailed, baseSpeed)
        {
        }

        public override double GetSpeed()
        {
            return (_isNailed) ? _minimumSpeed : GetBaseSpeedForVoltage(_voltage);
        }

        private double GetBaseSpeedForVoltage(double voltage)
        {
            return Math.Min(_minimumBaseSpeedWithVoltage, voltage * _baseSpeed);
        }

    }
}
