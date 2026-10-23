using Microsoft.EntityFrameworkCore; 
using VetClinicApp.Domain.Entities;
using VetClinicApp.Application.Dtos;

namespace VetClinicApp.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task <List<Appointment>> GetAllAppointmentsAsync();
        Task <Appointment> CreateAppointmentAsync(CreateAppointmentDto dto, Guid userId, string name, string lastname, string email, string phoneNumber);
       

    }
    
}