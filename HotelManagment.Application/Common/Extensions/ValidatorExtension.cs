using FluentValidation.Results;
using System.Text;

namespace HotelManagment.Application.Common.Extensions;

public static class ValidatorExtension
{
    public static string GetErrorMessages(this ValidationResult result)
    {
        var messages = new StringBuilder();

        foreach (var message in result.Errors)
        {
            messages.Append(message.ErrorMessage);
        }

        return messages.ToString();
    }
}
