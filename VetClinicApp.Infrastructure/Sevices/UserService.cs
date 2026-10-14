using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Infrastructure.Data;

namespace VetClinicApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly VetClinicAppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        public UserService (VetClinicAppDbContext context, IJwtService jwtService)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
            _jwtService = jwtService;
        }

        public async Task<bool> EmailExists(string Email)
            {
                return await _context.Users
                .AnyAsync(c => c.Email.ToLower() == Email.ToLower().Trim());
            }

        public async Task<UserDto> RegisterUserAsync(RegisterUserDto dto)
            {
                bool emailExist = await EmailExists(dto.Email);
                if(emailExist)
                {
                    throw new InvalidOperationException("E-mail already exists");   
                }
            
                var User = new User()
                {
                    UserId = Guid.NewGuid(),
                    LastName = dto.LastName,
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    PasswordHash = string.Empty
                };
                
                if(dto.Password.Length >= 8)
                {
                User.PasswordHash = _passwordHasher.HashPassword(User, dto.Password);

                _context.Users.Add(User);
                await _context.SaveChangesAsync();

                return new UserDto
                {
                    UserId = User.UserId,
                    LastName = User.LastName,
                    Name = User.Name,                
                    PhoneNumber = User.PhoneNumber,
                    Email = User.Email
                };
            }
                throw new InvalidOperationException ("Password too short");
            }
            
           public async Task<string?> LoginUserAsync(LoginUserDto dto)
        {
          
                var User = await _context.Users
                    .FirstOrDefaultAsync(c => c.Email.ToLower() == dto.Email.ToLower().Trim());

                    if(User == null)
            {
                throw new UnauthorizedAccessException("Incorrect e-mail or password");
            }

                var verifypassword = _passwordHasher.VerifyHashedPassword(User, User.PasswordHash, dto.Password);

                if (verifypassword == PasswordVerificationResult.Failed)
                {
                    throw new UnauthorizedAccessException("Incorrect e-mail or password");
                }

                var jwtToken = _jwtService.GenerateToken(User.UserId, User.Email, User.PhoneNumber, User.LastName, User.Name, User.Role.ToString());

                return jwtToken;
        }
    }
}