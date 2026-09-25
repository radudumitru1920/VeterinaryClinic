using Microsoft.EntityFrameworkCore; 
using VetClinicApp.Domain.Entities;
using VetClinicApp.Application.Dtos;
using System.Security.Cryptography;

namespace VetClinicApp.Application.Interfaces;
public interface IUserService
{
   Task <UserDto> RegisterUserAsync (RegisterUserDto dto);
   
   Task <string?> LoginUserAsync (LoginUserDto dto);
}