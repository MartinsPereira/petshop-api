using Petshop.Application.Dtos;
using Petshop.Application.Dtos.Customer;
using Petshop.Domain.Common;
using Petshop.Domain.Entities;

namespace Petshop.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Result<IEnumerable<ListCustomerResponseDto>>> GetAllCustomers();
        Task<Result<CreateCustomerResponseDto>> GetCustomerById(int id);
        Task<Result<CreateCustomerResponseDto>> CreateCustomer(CreateCustomerRequestDto customer);
        Task<Result<CreateCustomerResponseDto>> UpdateCustomer(int id, CreateCustomerRequestDto customer);
        Task<Result<object?>> DeleteCustomer(int id);

    }
}
