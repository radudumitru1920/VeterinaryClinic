using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using VetClinicApp.Domain.Entities;


namespace VetClinicApp.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }
    
    [Authorize]
    [HttpPost("New Pet")]
    public async Task<IActionResult> AddPet([FromBody] AddPetDto dto)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        Pet createdPet = await _petService.AddPetAsync(dto, userId);

        return Ok(createdPet);
    }

    [Authorize]
    [HttpDelete("Delete Pet")]
    public async Task<IActionResult> DeletePet(Guid petId)
    {
       var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

       var petlist = await _petService.GetPetsByUserIdAsync(userId);
        if (petlist.Any(p => p.PetId == petId && p.UserId == userId))
    {
        await _petService.DeletePetAsync(petId);
        return NoContent();
    }

    return NotFound();
        }
       
}

  