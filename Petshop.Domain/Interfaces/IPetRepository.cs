using Petshop.Domain.Entities;

namespace Petshop.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllAsync();   
        Task<Pet?> GetById(int id);
        Task<Pet> CreatePet(Pet newPet);
        Task<Pet> UpdatePet(Pet updatedPet);
        Task<Pet> DeletePet(Pet updatedPet);
    }
}
