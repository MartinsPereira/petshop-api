using System.ComponentModel.DataAnnotations.Schema;

namespace Petshop.Domain.Entities
{
    public class Pet: BaseEntity
    {
        public int PetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // Dog, Cat, etc.
        public string Breed { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string? Observations { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }

    }
}
