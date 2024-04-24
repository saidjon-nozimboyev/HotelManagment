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

    public async Task<HotelDto> GetByIdAsync(int id)
    {
        var hotel = await _unitOfWork.Hotel.GetByIdAsync(id);
        if (hotel is null) 
            throw new StatusCodeException(HttpStatusCode.NotFound, "Hotel not found");
        return (HotelDto)hotel;
    }

    public async Task<List<HotelDto>> GetByStartRatingAsync(double rating)
    {
        if (rating < 0 || rating > 5)
            throw new StatusCodeException(HttpStatusCode.BadGateway, "The rating is incorrect");
        var hotels = await _unitOfWork.Hotel.GetByRatingAsync(rating);
        return hotels.Select(x => (HotelDto)x).ToList();
    }

    public async Task UpdateAsync(HotelDto dto)
    {
        var hotel = await _unitOfWork.Hotel.GetByIdAsync(dto.Id);
        if (hotel is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Hotel not found");

        var result = _validator.Validate(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        hotel.Name = dto.Name;
        hotel.Description = dto.Description;
        hotel.ContactInformation = dto.ContactInformation;
        hotel.StarRating = dto.StarRating;
        hotel.Geolocation = dto.Geolocation;

        await _unitOfWork.Hotel.UpdateAsync(hotel);
    }
}
