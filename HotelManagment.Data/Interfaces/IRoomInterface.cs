namespace HotelManagment.Data.Interfaces;

public interface IRoomInterface : IGenericRepository<Room>
{
    Task<IEnumerable<Room?>> GetEmptyRooms();
}
