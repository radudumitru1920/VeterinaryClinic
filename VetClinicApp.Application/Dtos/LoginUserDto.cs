

using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace VetClinicApp.Application.Dtos
{
    public class LoginUserDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}