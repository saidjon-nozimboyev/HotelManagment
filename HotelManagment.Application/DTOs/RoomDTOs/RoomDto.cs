namespace HotelManagment.Application.DTOs.RoomDTOs;

public class RoomDto : AddRoomDto
{
    public int Id { get; set; }

    public static implicit operator Room(RoomDto room)
    {
        return new Room()
        {
            Id = room.Id,
            Description = room.Description,
            Capacity = room.Capacity,
            HotelId = room.HotelId,
            Price = room.Price,
            RoomNumber = room.RoomNumber,
            RoomType = room.RoomType,
        };
    }
}
