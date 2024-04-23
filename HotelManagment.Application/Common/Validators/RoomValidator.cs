namespace HotelManagment.Application.Common.Validators;

public class RoomValidator : AbstractValidator<Room>
{
    public RoomValidator()
    {
        RuleFor(r => r.HotelId)
            .GreaterThan(0)
            .WithMessage("Hotel ID must be a positive integer");

        RuleFor(r => r.RoomNumber)
            .NotEmpty()
            .WithMessage("Room number cannot be empty");

        RuleFor(r => r.RoomType)
            .NotEmpty()
            .WithMessage("Room type cannot be empty");

        RuleFor(r => r.Capacity)
            .GreaterThan(0)
            .WithMessage("Capacity must be a positive integer");

        RuleFor(r => r.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price cannot be negative");
    }
}
