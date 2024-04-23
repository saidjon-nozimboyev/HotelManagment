namespace HotelManagment.Data.Interfaces;

public interface IUnitOfWork
{
    IHotelInterface Hotel { get; }
    IRoomInterface Room { get; }
    IUserInterface User { get; }
}
