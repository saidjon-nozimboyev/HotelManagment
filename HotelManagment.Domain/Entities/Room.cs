using HotelManagment.Domain.Entities;

public class Room : Base
{
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string RoomType { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsBooked { get; set; } = false;
}