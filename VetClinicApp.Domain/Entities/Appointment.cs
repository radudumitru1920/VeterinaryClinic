namespace VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;

public class Appointment
{
    required public Guid AppointmentId { get; set; }

    required public Guid UserId { get; set; }
    

    public Guid? PetId { get; set; }

    public Guid? StaffId { get; set; }

    required public string Name { get; set; }

    required public string LastName { get; set; }

    required public string Email { get; set; }

    required public string PhoneNumber { get; set; }

    required public DateOnly Date { get; set; }

    required public TimeOnly Time { get; set; }

    required public string Reason { get; set; }

    public AppointmentStatus Status { get; set;  } = AppointmentStatus.Pending;
}