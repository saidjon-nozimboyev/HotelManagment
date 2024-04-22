using HotelManagment.Domain.Entities;

namespace HotelManagment.Application.DTOs.HotelDTOs;

public class AddHotelDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double StarRating { get; set; }
    public string ContactInformation { get; set; } = string.Empty;
    public string Geolocation { get; set; } = string.Empty;

    public static implicit operator Hotel(AddHotelDto dto)
    {
        return new Hotel()
        {
            Name = dto.Name,
            Description = dto.Description,
            StarRating = dto.StarRating,
            ContactInformation = dto.ContactInformation,
            Geolocation = dto.Geolocation,
        };
    }
}
