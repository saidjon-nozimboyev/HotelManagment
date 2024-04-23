using HotelManagment.Domain.Entities;

namespace HotelManagment.Application.Interfaces;

public interface IAuthManager
{
    string GeneratedToken(User user);
}
