
using Microsoft.EntityFrameworkCore;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;
using VetClinicApp.Infrastructure.Data;

namespace VetClinicApp.Infrastructure.Services
{

        public class StaffService : IStaffService
    {
        
        private readonly VetClinicAppDbContext _context;

        public StaffService(VetClinicAppDbContext context)
    {
        _context = context;
    }

        public async Task<List<MedicDto>> GetAllMedicsAsync (Role role)

        {
         return await _context.Users.Where(a => a.role == Role.Medic).Select(u => new MedicDto{userId = u.UserId, LastName = u.LastName, Name = u.Name} ).ToListAsync();
        
        }
        
    }
}