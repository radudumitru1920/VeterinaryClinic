using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Application.Dtos;

public class AddPetDto
{

    public string? PetName { get; set; }

    public AnimalType PetType { get; set; }

    public string? PetBreed { get; set; }

}