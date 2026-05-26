namespace Petshop.Application.Dtos.Customer
{
    public class ListCustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string CellPhone { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int QtdPets { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
