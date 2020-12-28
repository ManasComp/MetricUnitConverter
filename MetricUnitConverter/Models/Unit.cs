using System;

namespace MetricUnitConverter.Models
{
    public class Unit
    {
        public double ConvertionToBasicUnit { get; private set; }
        public string ShortName { get; private set; }
        public string LongName { get; private set; }

        public int Index { get; private set; }

        public Unit(string shortName, string longName, double convertionToBasicUnit, int index = 0)
        {
            ConvertionToBasicUnit = convertionToBasicUnit;
            ShortName = shortName ?? throw new ArgumentNullException(nameof(shortName));
            LongName = longName ?? throw new ArgumentNullException(nameof(longName));
            Index = index;
        }
    }
}