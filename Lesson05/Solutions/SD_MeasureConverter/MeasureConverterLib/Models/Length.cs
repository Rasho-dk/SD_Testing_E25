using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureConverterLib.Models
{
    public class Length(double value, SystemOfUnits unit)
    {
        private const double CmPerInch = 2.54;
        private const double InchesPerCm = 1 / CmPerInch;

        private double Value { get; } = double.IsFinite(value) 
            ? double.Round(value, 2)
            : throw new ArgumentOutOfRangeException(nameof(value), "Value must be a finite number.");
        private SystemOfUnits Unit { get; } = unit is SystemOfUnits.Metric or SystemOfUnits.Imperial
            ? unit
            : throw new ArgumentException("Invalid unit specified.", nameof(unit));

        public double Convert()
        {
            return Unit switch
            {
                SystemOfUnits.Metric => Math.Abs(Math.Round(Value * InchesPerCm, 2)), // in -> cm
                SystemOfUnits.Imperial => Math.Abs(Math.Round(Value * CmPerInch, 2)), // cm -> in
                _ => throw new ArgumentException("Invalid target unit specified.", nameof(unit))
            };
        }

    }

}

public enum SystemOfUnits
{
    Metric,
    Imperial
}
