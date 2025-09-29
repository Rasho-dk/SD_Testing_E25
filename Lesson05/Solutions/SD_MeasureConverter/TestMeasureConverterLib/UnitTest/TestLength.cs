using MeasureConverterLib.Models;

namespace TestMeasureConverterLib.UnitTest
{
    public class TestLength
    {
        private Length? _length;


        [TestCase(0, SystemOfUnits.Imperial, 0)] // Lower valid boundary
        [TestCase(1, SystemOfUnits.Imperial, 2.54)]
        [TestCase(0.5, SystemOfUnits.Imperial, 1.27)]
        [TestCase(0.25, SystemOfUnits.Imperial, 0.64)]
        [TestCase(double.MaxValue / 2.54, SystemOfUnits.Imperial, double.MaxValue)] // Upper valid boundary


        [TestCase(0, SystemOfUnits.Metric, 0)] // Lower valid boundary
        [TestCase(0.635, SystemOfUnits.Metric, 0.25)]
        [TestCase(1.27, SystemOfUnits.Metric, 0.5)]
        [TestCase(2.54, SystemOfUnits.Metric, 1)]

        [TestCase(-1, SystemOfUnits.Imperial, 2.54)] // Negative case (absolute value)
        [TestCase(-2.54, SystemOfUnits.Metric, 1)] // Negative case (absolute value)
        public void Convert_ValidInput_ReturnsExpectedResult(double inputValue, SystemOfUnits targetUnit,
            double expectedValue)
        {
            //Console.WriteLine(double.MaxValue / 2.54);
            //Console.WriteLine(double.MaxValue);
            // Act
            _length = new Length(inputValue, targetUnit);
            var result = _length.Convert();
            // Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(double.NaN, SystemOfUnits.Imperial)]
        [TestCase(double.PositiveInfinity, SystemOfUnits.Imperial)]
        [TestCase(double.NegativeInfinity, SystemOfUnits.Imperial)]
        //[TestCase(-1,SystemOfUnits.Imperial, -2.54)]
        public void Convert_InvalidValue_ThrowsArgumentOutOfRangeException(double inputValue, SystemOfUnits targetUnit,
            double? expectedValue=null)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _length = new Length(inputValue, targetUnit));
            Assert.That(ex.Message , Does.Contain("Value must be a finite number."));

        }
    }
}

