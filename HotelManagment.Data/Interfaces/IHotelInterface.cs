using HotelManagment.Domain.Entities;

namespace HotelManagment.Data.Interfaces;

public interface IHotelInterface : IGenericRepository<Hotel>
{
    Task<IEnumerable<Hotel?>> GetByRatingAsync(double rating);
}
