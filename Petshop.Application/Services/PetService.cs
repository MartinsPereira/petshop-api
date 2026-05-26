using Petshop.Application.Dtos;
using Petshop.Application.Interfaces;
using Petshop.Domain.Common;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;

namespace Petshop.Application.Services
{
    public class PetService(IPetRepository petRepository, ICustomerService customerService) : IPetService
    {
        public async Task<Result<IEnumerable<PetReponseDto>>> GetAllPets()
        {
            var allPets = await petRepository.GetAllAsync();
            var listaPets = allPets.Select(MapToDto);

            return Result<IEnumerable<PetReponseDto>>.Success(listaPets, $"Lista de pets retornada com sucesso.");
        }

        public async Task<Result<PetReponseDto>> GetPetById(int id)
        {
            var pet = await petRepository.GetById(id);

            if (pet == null)
                return Result<PetReponseDto>.Failure($"Pet com id {id} não encontrado.");

            return Result<PetReponseDto>.Success(MapToDto(pet), $"Pet encontrado com sucesso.");
        }

        public async Task<Result<PetReponseDto>> CreatePet(CreatePetRequestDto newPet)
        {
            var customerResult = await customerService.GetCustomerById(newPet.CustomerId);

            if (customerResult.Entity == null)
                return Result<PetReponseDto>.Failure($"Cliente com id {newPet.CustomerId} não encontrado.");

            var petEntity = new Pet
            {
                Name = newPet.Name,
                Breed = newPet.Breed,
                Type = newPet.Type,
                BirthDate = newPet.BirthDate,
                Observations = newPet.Observations,
                Size = newPet.Size,
                CustomerId = newPet.CustomerId,
            };

            var created = await petRepository.CreatePet(petEntity);
            return Result<PetReponseDto>.Success(MapToDto(created), $"Pet criado com sucesso.");
        }

        public async Task<Result<PetReponseDto>> UpdatePet(int id, CreatePetRequestDto newPet)
        {
            var existingPet = await petRepository.GetById(id);

            if (existingPet == null)
                return Result<PetReponseDto>.Failure($"Pet com id {id} não encontrado.");

            existingPet.Name = newPet.Name;
            existingPet.Breed = newPet.Breed;
            existingPet.Type = newPet.Type;
            existingPet.BirthDate = newPet.BirthDate;
            existingPet.Observations = newPet.Observations;
            existingPet.Size = newPet.Size;
            existingPet.CustomerId = newPet.CustomerId;

            var updated = await petRepository.UpdatePet(existingPet);
            return Result<PetReponseDto>.Success(MapToDto(updated), $"Pet atualizado com sucesso.");
        }

        public async Task<Result<PetReponseDto>> DeletePet(int id)
        {
            var existingPet = await petRepository.GetById(id);

            if (existingPet == null)
                return Result<PetReponseDto>.Failure($"Pet com id {id} não encontrado.");

            var deleted = await petRepository.DeletePet(existingPet);
            return Result<PetReponseDto>.Success(MapToDto(deleted), $"Pet deletado com sucesso.");
        }

        private static PetReponseDto MapToDto(Pet pet) => new()
        {
            Id = pet.PetId,
            Name = pet.Name,
            Type = pet.Type,
            Breed = pet.Breed,
            Size = pet.Size,
            Tutor = pet.Customer?.Name ?? ""
        };
    }
}
