using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Entities;
using Petshop.Domain.Interfaces;
using Petshop.Infra.Context;

namespace Petshop.Infra.Repository
{
    public class PetRepository(ApplicationDbContext context) : IPetRepository
    {
        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await context.Pets.AsNoTracking().Include(p => p.Customer).ToListAsync();
        }

        public async Task<Pet?> GetById(int id)
        {
            return await context.Pets.Include(p => p.Customer).FirstOrDefaultAsync(u => u.PetId == id);
        }

        public async Task<Pet> CreatePet(Pet newPet)
        {
            var entry = context.Pets.Add(newPet);
            await context.SaveChangesAsync();
            return context.Pets.Include(p => p.Customer).FirstOrDefault(p => p.PetId == entry.Entity.PetId)!;
        }

        public async Task<Pet> UpdatePet(Pet updatedPet)
        {
            var entry = context.Pets.Update(updatedPet);
            await context.SaveChangesAsync();
            return context.Pets.Include(p => p.Customer).FirstOrDefault(p => p.PetId == entry.Entity.PetId)!;
        }

        public async Task<Pet> DeletePet(Pet updatedPet)
        {
            var entry = context.Pets.Remove(updatedPet);
            await context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
