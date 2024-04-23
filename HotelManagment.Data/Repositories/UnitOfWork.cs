using HotelManagment.Data.DbContexts;
using HotelManagment.Data.Interfaces;

namespace HotelManagment.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public IHotelInterface Hotel => new HotelRepository(_dbContext);

    public IRoomInterface Room => new RoomRepository(_dbContext);

    public IUserInterface User => new UserRepository(_dbContext);
}
