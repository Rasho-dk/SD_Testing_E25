using MeasureConverterLib.Models;

namespace TestMeasureConverterLib.UnitTest
{
    [TestFixture]
    [Category("Temperature Tests")]
    public class TemperatureTest
    {
        private Temperature? _temp;

        [TestCase(0, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 32)]             // Melting point of water
        [TestCase(10, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 50)]
        [TestCase(100, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 212)]          // Boiling point of water
        [TestCase(-10, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 14)]
        [TestCase(-17.78, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 0)]
        [TestCase(-273.15, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -459.67)]  // Absolute zero
        [TestCase(-195.8, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -320.44)]   // Boiling point of liquid nitrogen
        [TestCase(-78, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -108.4)]       // Sublimation point of dry ice
        [TestCase(-40, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -40)]          // Celsius and Fahrenheit intersection
        [TestCase(20, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 68)]            // Room temperature
        [TestCase(37, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 98.6)]          // Average human body temperature
        [TestCase(1000, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 1832)]
        [TestCase(-1000, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -1768)]
        [TestCase(10000, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 18032)]
        [TestCase(-10000, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -17968)]
        [TestCase(100000, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 180032)]
        [TestCase(-100000, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, -179968)]
        public void CelsiusToFahrenheit_ValidInputs_ReturnsExpected(double value, TemperatureUnit fromUnit, TemperatureUnit toUnit, double expected)
        {
            _temp = new Temperature(value, fromUnit);
            var result = _temp.Convert(toUnit);
            Assert.That(result, Is.EqualTo(expected));
        }
        [TestCase(0, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -17.78)]
        [TestCase(32, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 0)]             // Melting point of water
        [TestCase(50, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 10)]
        [TestCase(212, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 100)]          // Boiling point of water
        [TestCase(14, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -10)]
        [TestCase(-459.67, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -273.15)]  // Absolute zero
        [TestCase(-320.44, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -195.8)]   // Boiling point of liquid nitrogen
        [TestCase(-108.4, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -78)]       // Sublimation point of dry ice
        [TestCase(-40, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -40)]          // Fahrenheit and Celsius intersection
        [TestCase(68, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 20)]            // Room temperature
        [TestCase(98.6, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 37)]          // Average human body temperature
        [TestCase(1832, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 1000)]
        [TestCase(-1768, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -1000)]
        [TestCase(18032, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 10000)]
        [TestCase(-17968, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -10000)]
        [TestCase(180032, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 100000)]
        [TestCase(-179968, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, -100000)]
        public void FahrenheitToCelsius_ValidInputs_ReturnsExpected(double value, TemperatureUnit fromUnit, TemperatureUnit toUnit, double expected)
        {
            _temp = new Temperature(value, fromUnit);
            var result = _temp.Convert(toUnit);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(0, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 273.15)] // Freezing point of water
        [TestCase(100, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 373.15)] // Boiling point of water
        [TestCase(-273.15, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 0)] // Absolute zero
        [TestCase(20, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 293.15)] // Room temperature
        [TestCase(37, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 310.15)] // Average human body temperature
        [TestCase(1000, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 1273.15)]
        [TestCase(-100, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 173.15)]
        [TestCase(10000, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 10273.15)]
        [TestCase(-10000, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, -9726.85)]
        [TestCase(100000, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 100273.15)]
        [TestCase(-100000, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, -99726.85)]
        public void CelsiusToKelvin_ValidInputs_ReturnsExpected(double value, TemperatureUnit fromUnit,
            TemperatureUnit toUnit, double expected)
        {
            _temp = new Temperature(value, fromUnit);
            var result = _temp.Convert(toUnit);
            Assert.That(result, Is.EqualTo(expected));

        }
        /*
         * We can repeat similar test for the other conversion methods
         */
        // test for Throws expectations
        [TestCase(double.NaN, TemperatureUnit.Celsius)]
        [TestCase(double.PositiveInfinity, TemperatureUnit.Celsius)]
        [TestCase(double.NegativeInfinity, TemperatureUnit.Celsius)]
        public void Temperature_InvalidValue_ThrowsArgumentOutOfRangeException(double inputValue, TemperatureUnit fromUnit)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _temp = new Temperature(inputValue, fromUnit));
            Assert.That(ex.Message, Does.Contain("Value must be a finite number."));
        }
        [TestCase(0, (TemperatureUnit)999)] // Invalid from unit
        public void Temperature_InvalidFromUnit_ThrowsArgumentException(double inputValue, TemperatureUnit fromUnit)
        {
            var ex = Assert.Throws<ArgumentException>(() => _temp = new Temperature(inputValue, fromUnit));
            Assert.That(ex.Message, Does.Contain("Invalid unit specified."));
        }
        [TestCase(0, TemperatureUnit.Celsius, (TemperatureUnit)999)] // Invalid target unit
        public void Convert_InvalidTargetUnit_ThrowsArgumentOutOfRangeException(double inputValue,
            TemperatureUnit fromUnit,
            TemperatureUnit toUnit)
        {
            _temp = new Temperature(inputValue, fromUnit);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _temp.Convert(toUnit));
            Assert.That(ex.Message, Does.Contain("Invalid target unit specified."));
        }
    }
}
