using DCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<DCustomer?> GetByIdAsync(Guid customerId);

        Task<IEnumerable<DCustomer>> GetAllAsync();

        Task CreateAsync(DCustomer customer);
    }
}
