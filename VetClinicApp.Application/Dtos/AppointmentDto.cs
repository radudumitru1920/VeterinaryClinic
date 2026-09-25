using VetClinicApp.Domain.Enums;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Domain.Entities;

namespace VetClinicApp.Dtos;

public class AppointmentDto
{
    public Guid AppointmentId { get; set; }

   // required virtual public UserDto? UserDto { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public AppointmentStatus status { get; set; }

}