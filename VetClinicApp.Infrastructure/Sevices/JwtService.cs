
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VetClinicApp.Application.Interfaces;

namespace VetClinicApp.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Guid userId, string email, string phonenumber, string name, string lastname, string role)
        {
           
            var jwtSettings = _configuration.GetSection("JwtSettings");
            
            var secretKey = jwtSettings["Secret"] ;
            
           var key = Encoding.UTF8.GetBytes(secretKey);
            
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()), 
                new Claim(ClaimTypes.Email, email), 
                new Claim("PhoneNumber", phonenumber),         
                new Claim("Name", name),           
                new Claim("LastName", lastname),           
                new Claim(ClaimTypes.Role, role),                       
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

           
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(double.Parse(jwtSettings["ExpiryInHours"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = credentials
            };

          
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenObject = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(tokenObject);
        }
        
    }
}
