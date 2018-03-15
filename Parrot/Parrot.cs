using System;

namespace parrot
{
    public class Parrot
    {
        readonly ParrotTypeEnum _type;
        readonly int _numberOfCoconuts;
        readonly double _voltage;
        readonly bool _isNailed;
        private readonly double _baseSpeed;
        private double _getLoadFactor = 9.0;
        private double _minimumBaseSpeedWithVoltage = 24.0;
        private readonly int _minimumSpeed = 0;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed, double baseSpeed = 12.0)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
            _baseSpeed = baseSpeed;
        }

        public double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return _baseSpeed;
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(_minimumSpeed, _baseSpeed - _getLoadFactor * _numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (_isNailed) ? _minimumSpeed : GetBaseSpeedForVoltage(_voltage);
            }

            throw new Exception("Should be unreachable");
        }

        private double GetBaseSpeedForVoltage(double voltage)
        {
            return Math.Min(_minimumBaseSpeedWithVoltage, voltage * _baseSpeed);
        }
    }
}
