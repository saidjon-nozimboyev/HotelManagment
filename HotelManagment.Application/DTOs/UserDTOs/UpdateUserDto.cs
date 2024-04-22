using HotelManagment.Domain.Entities;
using HotelManagment.Domain.Enums;

namespace HotelManagment.Application.DTOs.UserDTOs;

public class UpdateUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PassportSeries { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    public static implicit operator User(UpdateUserDto user)
    {
        return new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Password = user.Password,
            Country = user.Country,
            PassportSeries = user.PassportSeries,
            Gender = user.Gender,
        };
    }
}
