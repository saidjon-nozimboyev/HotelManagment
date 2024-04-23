using System.Text.RegularExpressions;

namespace HotelManagment.Application.Common.Validators;

public class HotelValidator : AbstractValidator<Hotel>
{
    public HotelValidator()
    {
        RuleFor(h => h.Name)
            .NotEmpty()
            .WithMessage("Hotel name is required.")
            .MaximumLength(100)
            .WithMessage("Hotel name must not exceed 100 characters.")
            .Matches(@"^[a-zA-Z0-9\s]+$")
            .WithMessage("Hotel name must only contain alphanumeric characters and spaces.");

        RuleFor(h => h.Description)
            .NotEmpty()
            .WithMessage("Hotel description is required.")
            .MinimumLength(50)
            .WithMessage("Description must be at least 50 characters long.")
            .MaximumLength(1000)
            .WithMessage("Description must not exceed 1000 characters.");

        RuleFor(h => h.StarRating)
            .InclusiveBetween(1, 5)
            .WithMessage("Star rating must be between 1 and 5.");

        RuleFor(h => h.ContactInformation)
            .NotEmpty()
            .WithMessage("Contact information is required.")
            .Must(BeValidContact)
            .WithMessage("Contact information must be a valid email address or phone number.");

        RuleFor(h => h.Geolocation)
            .NotEmpty()
            .WithMessage("Geolocation is required.");
    }

    private bool BeValidContact(string contact)
    {
        return IsValidEmail(contact) || IsValidPhoneNumber(contact);
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[\w!#$%&'*+/=?`{|}~^-]+(?:\.[\w!#$%&'*+/=?`{|}~^-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?$");
    }
    private bool IsValidPhoneNumber(string phoneNumber)
    {
        // Implement phone number regex validation based on your region
        return Regex.IsMatch(phoneNumber, @"^\d{10}$"); 
    }

}