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

        public async Task<List<Appointment>> GetAllAppointmentsAsync(Guid userId)
        {
            return await _context.Appointments.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Appointment> CreateAppointmentAsync(CreateAppointmentDto dto, Guid userId, string phoneNumber, string email, string name, string lastname)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.UserId == userId && p.PetId == dto.PetId);

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
                PhoneNumber = phoneNumber,
                PetId = dto.PetId,
                PetName = pet.PetName,
                PetType = pet.PetType.ToString(),
                PetBreed = pet.PetBreed,
                //StaffId = Guid.NewGuid(),
                Date = dto.date,
                Time = dto.time,
                Reason = dto.reason,
                Email = email,
                LastName = lastname,
                Name = name,
        
            };

            _context.Appointments.Add(appointment);

            await _context.SaveChangesAsync();
            return appointment;
        }
       
       public async Task<Appointment> RejectAppointmentAsync(Guid appointmentId)
        {
            _context .Appointments.Remove(await _context.Appointments.FindAsync(appointmentId));

            await _context.SaveChangesAsync();
            return null;
        }
        
         public async Task<Appointment> AcceptAppointmentAsync(Guid appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);

            if(appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            appointment.Status = Domain.Enums.AppointmentStatus.Accepted;

            await _context.SaveChangesAsync();
            return appointment;
        }

    
    }
    
     
}