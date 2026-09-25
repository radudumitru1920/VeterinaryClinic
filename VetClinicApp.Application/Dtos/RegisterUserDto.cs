using System.ComponentModel.DataAnnotations;

namespace VetClinicApp.Application.Dtos;

public class RegisterUserDto
{
    public string Name { get; set; } = string.Empty;
    
    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

   [EmailAddress]
    public string? Email { get; set; }

    public string Password { get; set; }
}
