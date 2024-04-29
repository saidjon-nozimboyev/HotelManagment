using HotelManagment.Application.DTOs.HotelDTOs;
using HotelManagment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(IHotelService hotelService) : ControllerBase
{
    private readonly IHotelService _hotelService = hotelService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddHotelDto dto)
    {
        await _hotelService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _hotelService.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _hotelService.GetAllAsync());
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(HotelDto dto) 
    {
        await _hotelService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _hotelService.DeleteAsync(id);
        return Ok();
    }
}
