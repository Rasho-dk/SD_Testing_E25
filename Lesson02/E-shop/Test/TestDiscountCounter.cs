using E_shop;

namespace Test
{
    public class Tests
    {
        private DiscountCounter _discountCounter;

        [SetUp]
        public void Setup()
        {
            _discountCounter = new DiscountCounter();
        }

        [Test]
        [TestCase(0.01, 0)] // Partition value 0.01 - 300.00 lower boundary
        [TestCase(0.02, 0)]
        [TestCase(200.05, 0)]
        [TestCase(299.99, 0)]
        [TestCase(300.00, 0)] // Partition value 0.01 - 300.00 upper boundary
        public void Test_CalculateDiscount_NoDiscount(decimal totalAmount, decimal expectedDiscount)
        {
            var discount = _discountCounter.CalculateDiscount(totalAmount);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [Test]
        [TestCase(300.01, 0.05)] // Partition value 300.01 - 800.00 lower boundary
        [TestCase(300.02, 0.05)]
        [TestCase(450.99, 0.05)]
        [TestCase(799.99, 0.05)]
        [TestCase(800.00, 0.05)] // Partition value 300.01 - 800.00 upper boundary
        public void Test_CalculateDiscount_ZeroPointFivePercentDiscount(decimal totalAmount, decimal expectedDiscount)
        {
            var discount = _discountCounter.CalculateDiscount(totalAmount);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [Test]
        [TestCase(800.01, 0.10)] // Partition value 800.01 and above lower boundary
        [TestCase(800.02, 0.10)]
        [TestCase(1000.99, 0.10)]
        public void Test_CalculateDiscount_TenPercentDiscount(decimal totalAmount, decimal expectedDiscount)
        {
            var discount = _discountCounter.CalculateDiscount(totalAmount);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [Test]
        // Invalid partition equal to 0
        [TestCase(0)]
        // Invalid partition values less than 0
        [TestCase(-0.01)]
        [TestCase(-0.02)]
        [TestCase(-20.45)]
        public void Test_CalculateDiscount_InvalidTotalAmount_ThrowsArgumentException(decimal totalAmount)
        {
            TestDelegate testDelegate = () => _discountCounter.CalculateDiscount(totalAmount);
            Assert.Throws<ArgumentException>(testDelegate);
        }


    }
}
