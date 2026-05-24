using Petshop.Application.Dtos;
using Petshop.Domain.Common;

namespace Petshop.Application.Interfaces
{
    public interface IPetService
    {
        Task<Result<IEnumerable<PetReponseDto>>> GetAllPets();
        Task<Result<PetReponseDto>> GetPetById(int id);
        Task<Result<PetReponseDto>> CreatePet(CreatePetRequestDto newPet);
        Task<Result<PetReponseDto>> UpdatePet(int id, CreatePetRequestDto newPet);
        Task<Result<PetReponseDto>> DeletePet(int id);
    }
}
