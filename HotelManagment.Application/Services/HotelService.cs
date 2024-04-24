namespace HotelManagment.Application.Services;

public class HotelService(IUnitOfWork unitOfWork,
                          IValidator<Hotel> validator) 
    : IHotelService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Hotel> _validator = validator;

    public async Task CreateAsync(AddHotelDto dto)
    {
        var hotel = await _unitOfWork.Hotel.GetByNameAsync(dto.Name);
        if (hotel is not null)
            throw new StatusCodeException(HttpStatusCode.AlreadyReported,"Information about hotel already exists");
        var result = _validator.Validate(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Hotel.CreateAsync((Hotel)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var hotel = await _unitOfWork.Hotel.GetByIdAsync(id);
        if (hotel is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Hotel with this id not found");

        await _unitOfWork.Hotel.DeleteAsync(hotel);
    }

    public async Task<IEnumerable<HotelDto>> GetAllAsync()
    {
        var hotels = await _unitOfWork.Hotel.GetAllAsync();
        return hotels.Select(x => (HotelDto)x).ToList();
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
