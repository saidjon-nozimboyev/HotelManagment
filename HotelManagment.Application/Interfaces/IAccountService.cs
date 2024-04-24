namespace HotelManagment.Application.Interfaces;

public interface IAccountService
{
    Task<bool> RegisterAsync(AddUserDto dto);
    Task<string> LoginAsync(string email, string password);
    Task SendCodeAsync(string email);
    Task CheckCodeAsync(string email, string code);
    Task UpdatePasswordAsync(string email, string newPassword);
}
