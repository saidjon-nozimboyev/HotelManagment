using HotelManagment.Domain.Entities;

namespace HotelManagment.Data.Interfaces;

public interface IUserInterface : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
