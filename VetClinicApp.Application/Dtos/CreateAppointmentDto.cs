
using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Application.Dtos;

public class CreateAppointmentDto
{ 
	public DateOnly date  { get; set; } 

	public TimeOnly time { get; set; }

	public string reason { get; set; } = string.Empty;

	public AnimalType? animalType { get; set; }

	public  int Age { get; set; }

	public int Weight { get; set; }
}
