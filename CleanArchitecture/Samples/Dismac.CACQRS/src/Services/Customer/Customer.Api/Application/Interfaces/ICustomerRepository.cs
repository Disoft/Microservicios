using Customer.Api.Domain;
using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<NSCustomer?> GetByIdAsync(Guid id);

        Task<List<NSCustomer>> GetAllAsync();

        Task CreateAsync(NSCustomer customer);
    }
}
