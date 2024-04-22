using HotelManagment.Domain.Entities;

namespace HotelManagment.Application.DTOs.HotelDTOs;

public class HotelDto : AddHotelDto
{
    public int Id { get; set; } 

    public static implicit operator Hotel(HotelDto dto)
    {
        return new Hotel
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            ContactInformation = dto.ContactInformation,
            Geolocation = dto.Geolocation,
            StarRating = dto.StarRating,
        };
    }
}
