using HotelManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Hotel> Hotels { get; set; }   
    public DbSet<Room> Rooms { get; set; }
}
