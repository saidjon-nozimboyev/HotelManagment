namespace HotelManagment.Application.Interfaces;

public interface IHotelService
{
    Task CreateAsync(AddHotelDto dto);
    Task UpdateAsync(HotelDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<HotelDto>> GetAllAsync();
    Task<HotelDto> GetByIdAsync(int id);
    Task<List<HotelDto>> GetByStartRatingAsync(double rating);
}