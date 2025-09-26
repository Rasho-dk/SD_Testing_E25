using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureConverterLib.Models
{
    public class Weight(double value, SystemOfUnits unit)
    {
        // kg & lb conversion factor

        private const double KgPerLb = 0.45359237; 

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
                SystemOfUnits.Metric => Math.Abs(Math.Round(Value * KgPerLb, 2)), // lb -> kg
                SystemOfUnits.Imperial => Math.Abs(Math.Round(Value / KgPerLb, 2)), // kg -> lb
                _ => throw new ArgumentException("Invalid target unit specified.", nameof(unit))
            };
        }

    }
}

