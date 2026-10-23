using VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Application.Dtos;

public class PetDto
{
    public Guid PetId { get; set; }

    public Guid UserId { get; set; }

    public string? PetName { get; set; }

    public AnimalType PetType { get; set; }

    public string? PetBreed { get; set; }

}