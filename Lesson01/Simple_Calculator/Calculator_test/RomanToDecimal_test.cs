using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple_Calculator_ex1;

namespace Calculator_test
{
    [TestClass]
    public class RomanToDecimal_test
    {
        private RomanToDecimal _romanToDecimal;
        [TestInitialize]
        public void Setup()
        {
            // Code that runs before each test
            _romanToDecimal = new RomanToDecimal();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("ABC")]
        public void Test_NullOrEmptyOrInvalidInput_ThrowsException(string romanNumeral)
        {
            // Arrange
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            // Exception is expected, so no need for an assert here
        }
        [TestMethod]
        public void Test_Sum_MDCCCLXVII_equal_1867()
        {
            // Arrange
            string romanNumeral = "MDCCCLXVII";
            int expected = 1867;
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_Sum_III_equal_3()
        {
            // Arrange
            string romanNumeral = "III";
            int expected = 3;
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("IIII")]
        [DataRow("XXXX")]
        [DataRow("CCCC")]
        [DataRow("MMMM")]
        public void Test_RepeatedMoreThan3Times_throwsException(string romanNumeral)
        {
            // Arrange
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            // Exception is expected, so no need for an assert here
        }
        [TestMethod]
        [DataRow("IV", 4)]
        [DataRow("XC", 90)]
        [DataRow("CD", 400)]
        public void Test_Allowed_Subtractive_Numerals_Valid(string romanNumeral, int expected)
        {
            // Arrange
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Subtraction_VL_Invalid_Throws_Exception()
        {
            // Arrange
            string romanNumeral = "VL";
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            // Exception is expected, so no need for an assert here
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("VV")]
        [DataRow("LL")]
        [DataRow("DD")]
        public void Test_CannotBeRepeated_V_L_D_throws_Exception(string romanNumeral)
        {
            // Arrange
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            // Exception is expected, so no need for an assert here
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("MMMCMXCIX")]
        public void Test_Exceeds_Maximum_Value_Throws_Exception(string romanNumeral)
        {
            // Arrange
            // Act
            int result = _romanToDecimal.RomanToInt(romanNumeral);
            // Assert
            // Exception is expected, so no need for an assert here
        }

    }
}
