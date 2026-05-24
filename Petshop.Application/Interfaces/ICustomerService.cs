using Petshop.Application.Dtos.Customer;
using Petshop.Domain.Common;
using Petshop.Domain.Entities;

namespace Petshop.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Result<Customer>> GetCustomerById(int id);
        Task<Result<Customer>> CreateCustomer(CreateCustomerDto customer);
    }
}
