using Petshop.Application.Dtos.Customer;
using Petshop.Application.Interfaces;
using Petshop.Application.Validator.Customer;
using Petshop.Domain.Common;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;

namespace Petshop.Application.Services
{
    public class CustomerService(ICustomerRepository customerRepository): ICustomerService
    {

        public async Task<Result<IEnumerable<ListCustomerResponseDto>>> GetAllCustomers()
        {
            var customers = await customerRepository.GetAll();

            var listCustomers = (IEnumerable<ListCustomerResponseDto>)customers.Select(pet => new ListCustomerResponseDto
            {
                CustomerId = pet.CustomerId,
                Name = pet.Name,
                CellPhone = pet.CellPhone,
                Cpf = pet.Cpf,
                Email = pet.Email,
                BirthDate = pet.BirthDate,
                QtdPets = pet.Pets?.Count() ?? 0
            });
          
            return Result<IEnumerable<ListCustomerResponseDto>>.Success(listCustomers, "Cliente encontrados com sucesso.");
        }
        public async Task<Result<CreateCustomerResponseDto>> GetCustomerById(int id)
        {
            var customer = await customerRepository.GetById(id);

            if(customer == null)
            {
                return Result<CreateCustomerResponseDto>.Failure("Nenhum cliente encontrado.");
            }

            var customerDto = new CreateCustomerResponseDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                CellPhone = customer.CellPhone,
                Cpf = customer.Cpf,
                Email = customer.Email,
                BirthDate = customer.BirthDate
            };

            return Result<CreateCustomerResponseDto>.Success(customerDto, "Cliente encontrado com sucesso.");
        }

        public async Task<Result<CreateCustomerResponseDto>> CreateCustomer(CreateCustomerRequestDto customer)
        {
            var validator = new CreateCustomerValidator(customerRepository, true);
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
            {
                return Result<CreateCustomerResponseDto>.Failure(validationResult.Errors.First().ErrorMessage);
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
            var createdCustomerDto = new CreateCustomerResponseDto
            {
                CustomerId = createdCustomer.CustomerId,
                Name = createdCustomer.Name,
                CellPhone = createdCustomer.CellPhone,
                Cpf = createdCustomer.Cpf,
                Email = createdCustomer.Email,
                BirthDate = createdCustomer.BirthDate
            };
            return Result<CreateCustomerResponseDto>.Success(createdCustomerDto, "Cliente criado com sucesso.");
        }

        public async Task<Result<CreateCustomerResponseDto>> UpdateCustomer(int id, CreateCustomerRequestDto customer)
        {
            var validator = new CreateCustomerValidator(customerRepository, false);
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
            {
                return Result<CreateCustomerResponseDto>.Failure(validationResult.Errors.First().ErrorMessage);
            }

            var existingCustomer = await customerRepository.GetById(id);
            if (existingCustomer == null)
                return Result<CreateCustomerResponseDto>.Failure("Cliente não encontrado.");


            existingCustomer.Name = customer.Name;
            existingCustomer.CellPhone = customer.CellPhone;
            existingCustomer.Cpf = customer.Cpf;
            existingCustomer.Email = customer.Email;
            existingCustomer.BirthDate = customer.BirthDate;

            var updatedCustomerReturn = await customerRepository.UpdateCustomer(existingCustomer);
            var updatedCustomerDto = new CreateCustomerResponseDto
            {
                CustomerId = updatedCustomerReturn.CustomerId,
                Name = updatedCustomerReturn.Name,
                CellPhone = updatedCustomerReturn.CellPhone,
                Cpf = updatedCustomerReturn.Cpf,
                Email = updatedCustomerReturn.Email,
                BirthDate = updatedCustomerReturn.BirthDate
            };
            return Result<CreateCustomerResponseDto>.Success(updatedCustomerDto, "Cliente atualizado com sucesso.");
        }

        public async Task<Result<object?>> DeleteCustomer(int id)
        {
            var existingCustomer = await customerRepository.GetById(id);
            if (existingCustomer == null)
                return Result<object?>.Failure("Cliente não encontrado.");

            await customerRepository.DeleteCustomer(existingCustomer);
            
            return Result<object?>.Success(null, "Cliente excluído com sucesso.");
        }
    }
}
