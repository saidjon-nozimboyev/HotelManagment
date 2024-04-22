using HotelManagment.Data.DbContexts;
using HotelManagment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Data.Repositories;

public class RoomRepository<T>(AppDbContext dbContext) 
    : GenericRepository<Room>(dbContext), IRoomInterface
{
    public async Task<IEnumerable<Room?>> GetEmptyRooms()
    {
        return await _dbContext.Rooms
                    .Where(r => !r.IsBooked) 
                    .ToListAsync();
    }
}
