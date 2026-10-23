using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;

namespace VetClinicApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        
        public StaffController (IStaffService staffService)
        {
            _staffService = staffService;
        }
        
        [HttpGet("Get Medics")]
        public async Task<IActionResult> GetAllMedics()
        {
            List<MedicDto> users = await _staffService.GetAllMedicsAsync(Role.Medic);

            return Ok(users);
        }
    }
}
