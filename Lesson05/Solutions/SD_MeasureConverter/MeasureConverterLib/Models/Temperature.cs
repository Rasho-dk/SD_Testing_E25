namespace MeasureConverterLib.Models
{
    public class Temperature(double value, TemperatureUnit fromUnit)
    {
        private double Value { get; } = double.IsFinite(value)
            ? double.Round(value, 2)
            : throw new ArgumentOutOfRangeException(nameof(value), "Value must be a finite number.");
        private TemperatureUnit FromUnit { get; } = fromUnit is TemperatureUnit.Celsius or TemperatureUnit.Fahrenheit or TemperatureUnit.Kelvin
            ? fromUnit
            : throw new ArgumentException("Invalid unit specified.", nameof(fromUnit));
        public double Convert(TemperatureUnit toUnit)
        {
            if (!Enum.IsDefined(typeof(TemperatureUnit), toUnit))
            {
                throw new ArgumentOutOfRangeException(nameof(toUnit), toUnit, "Invalid target unit specified.");
            }
            if (FromUnit == toUnit)
            {
                return Value;
            }
            return (FromUnit, toUnit) switch
            {
                (TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit) => CelsiusToFahrenheit(Value),
                (TemperatureUnit.Celsius, TemperatureUnit.Kelvin) => CelsiusToKelvin(Value),
                (TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius) => FahrenheitToCelsius(Value),
                (TemperatureUnit.Fahrenheit, TemperatureUnit.Kelvin) => FahrenheitToKelvin(Value),
                (TemperatureUnit.Kelvin, TemperatureUnit.Celsius) => KelvinToCelsius(Value),
                (TemperatureUnit.Kelvin, TemperatureUnit.Fahrenheit) => KelvinToFahrenheit(Value),
                _ => throw new ArgumentOutOfRangeException(nameof(toUnit), toUnit, "Invalid target unit specified.")
            };


        }

        #region Conversion helpers (each returns a value rounded to 2 decimals)
        private static double CelsiusToFahrenheit(double c) => Round2(c * 9 / 5 + 32);
        private static double CelsiusToKelvin(double c) => Round2(c + 273.15);

        private static double FahrenheitToCelsius(double f) => Round2((f - 32) * 5 / 9);
        private static double FahrenheitToKelvin(double f) => Round2((f - 32) * 5 / 9 + 273.15);

        private static double KelvinToCelsius(double k) => Round2(k - 273.15);
        private static double KelvinToFahrenheit(double k) => Round2((k - 273.15) * 9 / 5 + 32);

        /* Centralized rounding policy: 2 decimals, explicit rounding mode.
         * MidpointRounding.AwayFromZero ensures that .5 values are rounded to the next number away from zero,
         * i.e 2.5 -> 3, -2.5 -> -3.
         */
        private static double Round2(double x) => Math.Round(x, 2, MidpointRounding.AwayFromZero);
        #endregion 
    }
}

public enum TemperatureUnit
{
    Celsius,
    Fahrenheit,
    Kelvin
}