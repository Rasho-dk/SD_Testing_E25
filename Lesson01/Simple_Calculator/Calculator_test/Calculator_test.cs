using Simple_Calculator_ex1;

namespace Calculator_test
{
    [TestClass]
    public class Calculator_test
    {
        private Calculator _calculator;
        [TestInitialize]
        public void Setup()
        {
            // Code that runs before each test
            _calculator = new Calculator();

        }
        [TestMethod]
        public void Test_Sum()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 8;
            // Act
            int result = _calculator.Add(a, b);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_Subtract()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 2;
            // Act
            int result = _calculator.Subtract(a, b);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_Multiply()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 15;
            // Act
            int result = _calculator.Multiply(a, b);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_Divide()
        {
            // Arrange
            int a = 6;
            int b = 3;
            double expected = 2.0;
            // Act
            double result = _calculator.Divide(a, b);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Test_DivideByZero()
        {
            // Arrange
            int a = 6;
            int b = 0;
            // Act
            _calculator.Divide(a, b);
            // Assert is handled by ExpectedException

        }


    }
}
