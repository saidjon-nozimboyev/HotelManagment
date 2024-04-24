using HotelManagment.Application.DTOs.UserDTOs;
using HotelManagment.Application.Interfaces;
using HotelManagment.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService; 
    [HttpPost("registr")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromForm] AddUserDto dto)
    {
        var result = await _accountService.RegisterAsync(dto);
        return Ok(result);
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync(string email,string password)
    {
        var result = await _accountService.LoginAsync(email,password);
        return Ok($"Token : {result}");
    }
}
