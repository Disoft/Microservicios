using Customer.Api.Application.Interfaces;
using Customer.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Infrastructure.Persistence
{
    public class CustomerRepository(CustomerDbContext _context) : ICustomerRepository
    {
        public async Task CreateAsync(Domain.Customer customer)
        {
           _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Domain.Customer?> GetByIdAsync(Guid customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }
    }
}
