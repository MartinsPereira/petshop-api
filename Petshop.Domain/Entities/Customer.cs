using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
