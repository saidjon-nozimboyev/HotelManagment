using HotelManagment.Application.DTOs.RoomDTOs;

namespace HotelManagment.Application.Interfaces;

public interface IRoomService
{
    Task CreateAsync(AddRoomDto dto);
    Task UpdateAsync(RoomDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<RoomDto>> GetAllAsync();
    Task<RoomDto> GetByIdAsync(int id);
    Task<List<RoomDto>> GetEmptyRoomsAsync();
}
