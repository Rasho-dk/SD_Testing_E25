using Cartridges;

namespace Test
{
    [TestClass]
    public sealed class Cartridages_Test
    {
        private Calcualte_Cartridges cartridges;
        [TestInitialize]
        public void Setup()
        {
            cartridges = new Calcualte_Cartridges();
        }
        [TestMethod]
        [DataRow(5, 0.0)] // Partition value 5 - 99 lower boundary
        [DataRow(6, 0.0)]
        [DataRow(45, 0.0)]
        [DataRow(98, 0.0)]
        [DataRow(99, 0.0)] // Partition value 5 - 99 upper boundary
        public void Test_Calculate_Zero_Discount(int numberOfCartridges, double expectedDiscount)
        {
            // Act
            double discount = cartridges.Calculate_Discount(numberOfCartridges);
            // Assert
            Assert.AreEqual(expectedDiscount, discount);
        }
        [TestMethod]
        [DataRow(100, 0.2)] // Partition value 100 - Max_number lower boundary
        [DataRow(101, 0.2)]
        [DataRow(150, 0.2)]
        public void Test_Calculate_With_Discount(int numberOfCartridges, double expectedDiscount)
        {
            // Act
            double discount = cartridges.Calculate_Discount(numberOfCartridges);
            // Assert
            Assert.AreEqual(expectedDiscount, discount);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        // Invalid partition value less than minimum cartridges
        [DataRow(0)] 
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        // Negative values Edge case
        public void Test_Calculate_Throws_Exception_For_Less_Than_Minimum_Cartridges(int numberOfCartridges)
        {
            // Act
            cartridges.Calculate_Discount(numberOfCartridges);
            // Assert is handled by ExpectedException

        }
    }
}
