using HotelManagment.Application.DTOs.UserDTOs;

namespace HotelManagment.Application.Interfaces;

public interface IAccountService
{
    Task<bool> RegistrAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto login);
}
