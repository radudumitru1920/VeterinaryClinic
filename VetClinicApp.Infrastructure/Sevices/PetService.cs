using VetClinicApp.Infrastructure.Data;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace VetClinicApp.Infrastructure.Services;

public class PetService : IPetService
{
    private readonly VetClinicAppDbContext _context;

    public PetService( VetClinicAppDbContext context )
    {
        _context = context;
    }

    public async Task<Pet> AddPetAsync(AddPetDto dto, Guid userId)
    {

        var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

        var pet = new Pet
        {

            PetId = Guid.NewGuid(),
            UserId = userId,
            PetName = dto.PetName,
            PetType = dto.PetType,
            PetBreed = dto.PetBreed

        };

        _context.Pets.Add(pet);

        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> DeletePetAsync(Guid petId)
    {
        var pet = await _context.Pets.FindAsync(petId);
        if (pet == null)
        {
            throw new Exception("Pet not found");
        }

        _context.Pets.Remove(pet);

        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<List<Pet>> GetPetsByUserIdAsync(Guid userId)
    {
        var pets = await _context.Pets.Where(p => p.UserId == userId).ToListAsync();
        return pets;
    }
}