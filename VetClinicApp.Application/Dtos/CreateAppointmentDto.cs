
using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Application.Dtos;

public class CreateAppointmentDto
{ 
	public Guid PetId { get; set; }

	public Guid MedicId { get; set; }
	public DateOnly date  { get; set; } 

	public TimeOnly time { get; set; }

	public string reason { get; set; } = string.Empty;

	public  int Age { get; set; }

	public int Weight { get; set; }
}
