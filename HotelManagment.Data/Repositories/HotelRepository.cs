using HotelManagment.Data.DbContexts;
using HotelManagment.Data.Interfaces;
using HotelManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Data.Repositories;

public class HotelRepository(AppDbContext dbContext) 
    : GenericRepository<Hotel>(dbContext), IHotelInterface
{

    public async Task<IEnumerable<Hotel?>> GetByRatingAsync(double rating)
    {
         var results = await _dbContext.Hotels
                             .Where(h => Math.Abs(h.StarRating - rating) < 0.01)
                             .ToListAsync();
        return results;
    }

}
