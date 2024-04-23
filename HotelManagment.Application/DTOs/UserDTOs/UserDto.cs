using HotelManagment.Domain.Entities;

namespace HotelManagment.Application.DTOs.UserDTOs;

public class UserDto : AddUserDto
{
    public int Id { get; set; } 
    
    public static implicit operator UserDto(User dto)
    {
        return new UserDto()
        {
            Id = dto.Id,
            Country = dto.Country,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Gender = dto.Gender,
            PassportSeries = dto.PassportSeries,
            Password = dto.Password,
            PhoneNumber = dto.PhoneNumber,
        };
    }
}
