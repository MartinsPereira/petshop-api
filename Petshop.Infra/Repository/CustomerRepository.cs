using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;
using Petshop.Infra.Context;

namespace Petshop.Infra.Repository
{
    public class CustomerRepository(ApplicationDbContext context) : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await context.Customers.AsNoTracking().ToListAsync();
        }
        public async Task<Customer?> GetById(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(u => u.CustomerId == id);
        }

        public async Task<Customer?> GetByCpf(string cpf)
        {
            return await context.Customers.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }

        public async Task<Customer?> GetByEmail(string email)
        {
            return await context.Customers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var entity = context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
