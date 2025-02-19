using Customer.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Domain.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Domain.Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}