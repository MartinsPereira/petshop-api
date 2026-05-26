using Petshop.Domain.Entities;

namespace Petshop.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer?> GetByCpf(string cpf);
        Task<Customer?> GetByEmail(string email);
        Task<Customer> UpdateCustomer(Customer updatedCustomer);
        Task<Customer> DeleteCustomer(Customer removedCustomer);
    }
}
