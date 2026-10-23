using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;
using VetClinicApp.Dtos;


namespace VetClinicApp.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    } 

    [HttpPost("New Appointment")]
    [Authorize]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto dto)
    {
       var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
       var email = User.FindFirstValue(ClaimTypes.Email);
       var phoneNumber = User.FindFirstValue("PhoneNumber");
       var name = User.FindFirstValue("Name");
       var lastname = User.FindFirstValue("LastName");
       

            Appointment createdAppointment = await _appointmentService.CreateAppointmentAsync(dto, userId, email, phoneNumber, name, lastname);

        return Ok(createdAppointment);
    } 

    [HttpGet("My Appointments")]
    [Authorize]
    public async Task<IActionResult> GetAllAppointments()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        List<Appointment> appointments = await _appointmentService.GetAllAppointmentsAsync(userId);
        return Ok(appointments);
    }

    [HttpDelete("Reject Appointment")]
    [Authorize]
    public async Task<IActionResult> RejectAppointment(Guid appointmentId)
    {
        var userrole = User.FindFirstValue(ClaimTypes.Role);
        if (userrole is (string?)"Medic" or (string?)"Asistent")
        {
            await _appointmentService.RejectAppointmentAsync(appointmentId);
            return NoContent();
        }
        else
        {
            return Forbid();
        }
    }

    [HttpPatch("Accept Appointment")]
    [Authorize]
    public async Task<IActionResult> AcceptAppointment(Guid appointmentId)
    {
        var userrole = User.FindFirstValue(ClaimTypes.Role);
        if (userrole is (string?)"Medic" or (string?)"Asistent")
        {
            Appointment acceptedAppointment = await _appointmentService.AcceptAppointmentAsync(appointmentId);
            return Ok(acceptedAppointment);
        }
        else
        {
            return Forbid();
        }
    }
}
       
