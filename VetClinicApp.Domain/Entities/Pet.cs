using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Domain.Entities;

public class Pet
{
    
    required public Guid PetId { get; set; }

    required public Guid UserId { get; set; }

    required public string PetName { get; set; }

    required public AnimalType PetType { get; set; }

    required public string PetBreed { get; set; }
}