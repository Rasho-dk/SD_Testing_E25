using Moq;
using MoqCustomer;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        private MoqCustomerRepo? _testCustomer;
        private Mock<ICustomerRepository> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<ICustomerRepository>();

            _testCustomer = new MoqCustomerRepo
            {
                Id = 1,
                Name = "John Doe",
                Email = "",
                PhoneNumber = "123-456-7890",
            };

        }

        [Test]
        public void GetCustomer()
        {
            //arrange
            const int customerId = 1;

            _mock.Setup(repo => repo.GetCustomerById(customerId)).Returns(_testCustomer!);
            var service = new CustomerService(_mock.Object);
            //act
            var currentCustomer = service.GetCustomer(customerId);
            //assert
            Assert.That(currentCustomer, Is.EqualTo(_testCustomer));
        }
        [Test]
        public void GetCustomer_NotFound()
        {
            //arrange
            const int customerId = 1;
            const int customerNotFoundId = 2;

            _mock.Setup(repo => repo.GetCustomerById(customerId)).Returns(_testCustomer!);
            var service = new CustomerService(_mock.Object);

            //act & assert
            Assert.That(() => service.GetCustomer(customerNotFoundId),
                Throws.TypeOf<ArgumentNullException>()
                    .With.Message
                    .EqualTo($"Customer with given id = {customerNotFoundId} not found"));

        }
    }
}
