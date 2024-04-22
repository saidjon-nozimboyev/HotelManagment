using HotelManagment.Domain.Enums;

namespace HotelManagment.Domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; } = false;
    public string PassportSeries { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public Role Role { get; set; } = Role.User;
}
