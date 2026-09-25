using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Domain.Entities;
public class User{

    required public Guid UserId { get; set; }

    required public string Name { get; set; }

    required public string LastName { get; set; }


    public List<Appointment> Appointments { get; set; }= [];

    required public string PhoneNumber { get; set; }

    required public string Email{ get; set; }

    public Role Role { get; set; }= Role.Client;

    required public string PasswordHash { get; set; } 

}