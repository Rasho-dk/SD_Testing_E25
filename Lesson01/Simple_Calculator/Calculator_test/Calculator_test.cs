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
    }
}
