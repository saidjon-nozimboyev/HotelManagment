using HotelManagment.Domain.Entities;
using HotelManagment.Domain.Enums;

namespace HotelManagment.Data.Interfaces;

public interface IHotelInterface : IGenericRepository<Hotel>
{
    Task<IEnumerable<Hotel?>> GetByRatingAsync(double rating);
    Task<Hotel?> GetByNameAsync(string name);
}
