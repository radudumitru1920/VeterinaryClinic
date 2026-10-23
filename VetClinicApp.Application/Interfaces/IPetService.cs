using VetClinicApp.Application.Dtos;
using VetClinicApp.Domain.Entities;

namespace VetClinicApp.Application.Interfaces;

public interface IPetService
{
    Task<Pet> AddPetAsync(AddPetDto petDto, Guid userId);

    Task<Pet> DeletePetAsync(Guid petId);

    Task<List<Pet>> GetPetsByUserIdAsync(Guid UserId);

}