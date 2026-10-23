using Microsoft.EntityFrameworkCore;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Infrastructure.Data;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Application.Dtos;

namespace VetClinicApp.Infrastructure.Services
{

public class AppointmentService : IAppointmentService
    {
        private readonly VetClinicAppDbContext _context;
        public AppointmentService(VetClinicAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> CreateAppointmentAsync(CreateAppointmentDto dto, Guid userId, string name, string lastname, string email, string phoneNumber)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            // var appointment = Appointment.Create(
            //     UserId,
            //     petId: 0,
            //     staffId: 0,
            //     dto.date,
            //     dto.time,
            //     dto.reason); 

            var appointment = new Appointment
            {
                AppointmentId = Guid.NewGuid(),
                UserId = userId,
                Name = name,
                LastName = lastname,
                Email = email,
                PhoneNumber = phoneNumber,
               // PetId = Guid.NewGuid(),
                //StaffId = Guid.NewGuid(),
                Date = dto.date,
                Time = dto.time,
                Reason = dto.reason
            
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
       
    }
}