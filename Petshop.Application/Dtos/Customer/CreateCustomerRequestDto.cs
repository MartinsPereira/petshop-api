
namespace Petshop.Application.Dtos.Customer
{
    public class CreateCustomerRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public string CellPhone { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}
