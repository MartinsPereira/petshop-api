using Petshop.Application.Dtos.Customer;
using Petshop.Application.Interfaces;
using Petshop.Domain.Common;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;

namespace Petshop.Application.Services
{
    public class CustomerService(ICustomerRepository customerRepository): ICustomerService
    {
        public async Task<Result<Customer>> GetCustomerById(int id)
        {
            var customer = await customerRepository.GetById(id);

            if(customer == null)
            {
                return Result<Customer>.Failure("Nenhum cliente encontrado.");
            }

            return Result<Customer>.Success(customer, "Cliente encontrado com sucesso.");
        }

        public async Task<Result<Customer>> CreateCustomer(CreateCustomerDto customer)
        {
            var existingCpf = await customerRepository.GetByCpf(customer.Cpf);

            if(existingCpf != null)
            {
                return Result<Customer>.Failure("Já existe um cliente com esse cpf.");
            }

            var existingEmail = await customerRepository.GetByEmail(customer.Email);

            if (existingEmail != null)
            {
                return Result<Customer>.Failure("Já existe um cliente com esse email.");
            }

            var newCustomer = new Customer
            {
                Name = customer.Name,
                CellPhone = customer.CellPhone,
                Cpf = customer.Cpf,
                Email = customer.Email,
                BirthDate = customer.BirthDate,
            };

            var createdCustomer = await customerRepository.CreateCustomer(newCustomer);
            return Result<Customer>.Success(createdCustomer, "Cliente criado com sucesso.");
        }
    }
}
