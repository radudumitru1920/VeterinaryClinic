using Microsoft.EntityFrameworkCore; 
using VetClinicApp.Domain.Entities;
using VetClinicApp.Application.Dtos;

namespace VetClinicApp.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task <List<Appointment>> GetAllAppointmentsAsync(Guid userId);
        Task <Appointment> CreateAppointmentAsync(CreateAppointmentDto dto, Guid userId, string email, string phoneNumber, string name, string lastname);
       
        Task <Appointment> AcceptAppointmentAsync(Guid appointmentId);
        Task <Appointment> RejectAppointmentAsync(Guid appointmentId);

     

    }
    
}