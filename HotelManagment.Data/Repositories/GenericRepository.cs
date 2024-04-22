using HotelManagment.Data.DbContexts;
using HotelManagment.Data.Interfaces;
using HotelManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Data.Repositories;

public class GenericRepository<T>(AppDbContext dbContext)
    : IGenericRepository<T> where T : Base
{
    protected readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
