namespace HotelManagment.Application.Interfaces;

public interface IAuthManager
{
    string GenerateToken(User user);
}