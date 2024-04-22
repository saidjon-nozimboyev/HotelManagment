using HotelManagment.Data.DbContexts;
using HotelManagment.Data.Interfaces;
using HotelManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Data.Repositories;

public class UserRepository<T>(AppDbContext dbContext) 
    : GenericRepository<User>(dbContext), IUserInterface
{
    public async Task<User?> GetByEmailAsync(string email)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
}
