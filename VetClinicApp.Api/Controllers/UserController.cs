using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using VetClinicApp.Application.Dtos;
using VetClinicApp.Application.Interfaces;
using Microsoft.IdentityModel.Tokens.Experimental;
using System.Text.Json;

namespace VetClinicApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _UserService;

    public UserController (IUserService UserService)
    {
        _UserService = UserService;
    }

    [HttpPost("register")]
   public async Task<IActionResult> RegisterUser ([FromBody] RegisterUserDto dto)
    {
        UserDto createdUser = await _UserService.RegisterUserAsync(dto);

        return Ok(createdUser);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser ([FromBody] LoginUserDto dto)
    {
        if( dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password) )
        return BadRequest(new{message = "Incorrect e-mail or password"});

        var token = await _UserService.LoginUserAsync(dto);

        if(token == null)
        return Unauthorized( new {message = "Incorrect e-mail or password"});

        return Ok( new { token = token });


    }
}