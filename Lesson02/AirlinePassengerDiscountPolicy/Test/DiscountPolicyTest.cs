using AirlinePassengerDiscountPolicy;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        private AirlineDiscountPolicy _policy;
        [SetUp]
        public void Setup()
        {
            _policy = new AirlineDiscountPolicy();
        }

        [TestCase(19, Destination.India, DaysOfWeek.Wednesday, 1, 0.20)]
        [TestCase(20, Destination.India, DaysOfWeek.Friday, 6, 0.10)]
        [TestCase(50, Destination.India, DaysOfWeek.Wednesday, 7, 0.30)]
        [TestCase(119, Destination.India, DaysOfWeek.Monday, 1, 0)]
        public void TestDiscountPolicyForDestinationInIndiaAndPersonOver18(int age, Destination destination, DaysOfWeek dayOfWeek, int days, decimal expectedDiscount)
        {
            var discount = AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [TestCase(19, Destination.International, DaysOfWeek.Thursday, 5, 0.25)]
        [TestCase(20, Destination.International, DaysOfWeek.Wednesday, 6, 0.35)]
        [TestCase(50, Destination.International, DaysOfWeek.Monday, 7, 0.10)]
        [TestCase(119, Destination.International, DaysOfWeek.Friday, 1, 0)]
        public void TestDiscountPolicyForDestinationInternationalAndPersonOver18(int age, Destination destination, DaysOfWeek dayOfWeek, int days, decimal expectedDiscount)
        {
            var discount = AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [TestCase(3, Destination.India, DaysOfWeek.Wednesday, 1, 0.40)]
        [TestCase(4, Destination.International, DaysOfWeek.Thursday, 1, 0.40)]
        [TestCase(17, Destination.International, DaysOfWeek.Monday, 6, 0.50)]
        [TestCase(16, Destination.India, DaysOfWeek.Friday, 7, 0.50)]
        public void TestDiscountPolicyForPersonOlderThan2AndYoungerThan18(int age, Destination destination, DaysOfWeek dayOfWeek, int days, decimal expectedDiscount)
        {
            var discount = AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [TestCase(2, Destination.India, DaysOfWeek.Wednesday, 1, 1.00)]
        [TestCase(1, Destination.International, DaysOfWeek.Thursday, 1, 1.00)]
        [TestCase(0, Destination.International, DaysOfWeek.Monday, 6, 1.00)]
        public void TestDiscountPolicyForPerson2AndYounger(int age, Destination destination, DaysOfWeek dayOfWeek, int days, decimal expectedDiscount)
        {
            var discount = AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days);
            Assert.That(discount, Is.EqualTo(expectedDiscount));
        }
        [TestCase(-1, Destination.India, DaysOfWeek.Wednesday, 1)]
        [TestCase(121, Destination.International, DaysOfWeek.Thursday, 1)]
        public void TestDiscountPolicyForInvalidAge(int age, Destination destination, DaysOfWeek dayOfWeek, int days)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days));
            Assert.That(ex.Message, Does.Contain("Age must be between 0 and 120."));
        }
        [TestCase(25, Destination.India, DaysOfWeek.Wednesday, -1)]
        [TestCase(25, Destination.International, DaysOfWeek.Thursday, 0)]
        public void TestDiscountPolicyForNegativeDays(int age, Destination destination, DaysOfWeek dayOfWeek, int days)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days));
            Assert.That(ex.Message, Does.Contain("Days must be non-negative."));
        }
        [TestCase(25, (Destination)999, DaysOfWeek.Wednesday, 1)]
        public void TestDiscountPolicyForInvalidDestination(int age, Destination destination, DaysOfWeek dayOfWeek, int days)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days));
            Assert.That(ex.Message, Does.Contain("Invalid destination."));
        }
        [TestCase(25, Destination.India, (DaysOfWeek)999, 1)]
        public void TestDiscountPolicyForInvalidDayOfWeek(int age, Destination destination, DaysOfWeek dayOfWeek, int days)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => AirlineDiscountPolicy.CalculateDiscounted(age, destination, dayOfWeek, days));
            Assert.That(ex.Message, Does.Contain("Invalid day of the week."));
        }



    }
}
