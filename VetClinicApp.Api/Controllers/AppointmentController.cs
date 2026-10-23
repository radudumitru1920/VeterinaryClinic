using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Domain.Entities;
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

    [HttpPost]
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
}
       
