using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<NSCustomer?> GetByIdAsync(Guid id);

        Task<IEnumerable<NSCustomer>> GetAllAsync();

        Task CreateAsync(NSCustomer customer);
    }
}
