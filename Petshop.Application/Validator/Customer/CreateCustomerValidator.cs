using FluentValidation;
using Petshop.Application.Dtos.Customer;
using Petshop.Domain.Interfaces;
using Petshop.Domain.Utils;

namespace Petshop.Application.Validator.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequestDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerValidator(ICustomerRepository customerRepository, bool hasUniqueValidation = true)
        {
            _customerRepository = customerRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(80).WithMessage("O nome não pode exceder 80 caracteres.");
            RuleFor(x => x.CellPhone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MaximumLength(15).WithMessage("O telefone não pode exceder 15 caracteres.")
                .Must(Validators.BeAValidCellPhone).WithMessage("Telefone inválido.");
           RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .MaximumLength(50).WithMessage("O e-mail não pode exceder 50 caracteres.")
                .EmailAddress().WithMessage("E-mail inválido.")
                .MustAsync(async (email, cancellation) => await BeUniqueEmail(email)).WithMessage("Esse e-mail já está cadastrado na base.").When((x) => hasUniqueValidation);
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O cpf é obrigatório.")
                .MaximumLength(12).WithMessage("O cpf não pode exceder 12 caracteres.")
                .Must(Validators.BeAValidCpf).WithMessage("CPF inválido.")
                .MustAsync(async (cpf, cancellation) => await BeUniqueCpf(cpf)).WithMessage("Esse cpf já está cadastrado na base.").When((x) => hasUniqueValidation);
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.");
        }

        public async Task<bool> BeUniqueCpf(string cpf)
        {
            var existingCpf = await _customerRepository.GetByCpf(cpf);

            if (existingCpf != null)
            {
                return false;
            }

            return true;

        }

        public async Task<bool> BeUniqueEmail(string email)
        {
            var existingEmail = await _customerRepository.GetByEmail(email);

            if (existingEmail != null)
            {
                return false;
            }

            return true;

        }
    }
}
