using HotelManagment.Application.DTOs.RoomDTOs;
using HotelManagment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController(IRoomService roomService) : ControllerBase
{
    private readonly IRoomService _roomService = roomService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddRoomDto dto)
    {
        await _roomService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _roomService.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _roomService.GetAllAsync());
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(RoomDto dto) 
    {
        await _roomService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _roomService.DeleteAsync(id);
        return Ok();
    }
}
