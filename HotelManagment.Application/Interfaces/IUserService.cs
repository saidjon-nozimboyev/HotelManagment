using HotelManagment.Application.DTOs.UserDTOs;

namespace HotelManagment.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(int id);
}
