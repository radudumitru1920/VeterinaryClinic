using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Domain.Entities;
public class User{

    required public Guid UserId { get; set; }

    public List<Pet> Pets { get; set; } = new List<Pet>();

    required public string Name { get; set; }

    required public string LastName { get; set; }

    required public string PhoneNumber { get; set; }

    required public string Email{ get; set; }

    public Role role { get; set; }= Role.Client;

    required public string PasswordHash { get; set; } 

}