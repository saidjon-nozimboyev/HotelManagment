namespace HotelManagment.Application.DTOs.RoomDTOs;

public class AddRoomDto
{
    public int HotelId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string RoomType { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;


    public static implicit operator Room(AddRoomDto room)
    {
        return new Room()
        {
            HotelId = room.HotelId,
            RoomNumber = room.RoomNumber,
            RoomType = room.RoomType,
            Capacity = room.Capacity,
            Price = room.Price,
            Description = room.Description
        };
    }
}
