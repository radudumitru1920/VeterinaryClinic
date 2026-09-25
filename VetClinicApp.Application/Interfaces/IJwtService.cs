

namespace VetClinicApp.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken (Guid userId, string email, string phonenumber, string name, string lastname, string Role);
    }
}