using System.ComponentModel.DataAnnotations;

namespace Petshop.Application.Dtos
{
    public class CreatePetRequestDto
    {
        [Required(ErrorMessage = "O nome do pet é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tipo do pet é obrigatório.")]
        public string Type { get; set; } = string.Empty; // Dog, Cat, etc.
        [Required(ErrorMessage = "A raça do pet é obrigatória.")]
        public string Breed { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tamanho do pet é obrigatório.")]
        public string Size { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tutor do pet é obrigatório.")]
        public int CustomerId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Observations { get; set; }
    }
}
