
namespace HotelManagment.Application.Services;

public class HotelService : IHotelService
{
    public Task CreateAsync(AddHotelDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<HotelDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<HotelDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<HotelDto>> GetByStartRatingAsync(double rating)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(HotelDto dto)
    {
        throw new NotImplementedException();
    }
}
