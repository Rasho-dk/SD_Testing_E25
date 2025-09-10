namespace MoqCustomer
{
    public class MoqCustomerRepo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public interface ICustomerRepository
    {
        MoqCustomerRepo GetCustomerById(int id);
    }

    public class CustomerService(ICustomerRepository customerRepository)
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public MoqCustomerRepo GetCustomer(int id)
        {
            return _customerRepository.GetCustomerById(id) ?? throw new ArgumentNullException(null, $"Customer with given id = {id} not found");
        }
    }
}
