using HotelManagment.Domain.Entities;

namespace HotelManagment.Application.DTOs.UserDTOs;

public class UserDto : AddUserDto
{
    public int Id { get; set; } 
    
    public static implicit operator User(UserDto dto)
    {
        return new User()
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
