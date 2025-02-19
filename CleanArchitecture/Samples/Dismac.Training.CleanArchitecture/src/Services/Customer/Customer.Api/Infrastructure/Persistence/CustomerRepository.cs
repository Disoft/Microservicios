using Customer.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSCustomer = Customer.Api.Domain.Customer;

namespace Customer.Api.Infrastructure.Persistence
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<NSCustomer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<NSCustomer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task CreateAsync(NSCustomer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}
