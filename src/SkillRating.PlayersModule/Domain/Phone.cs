using System.ComponentModel.DataAnnotations;
using PhoneNumbers;

namespace SkillRating.PlayersModule.Domain;

public sealed record Phone
{
    public Phone(string value)
    {
        if (!IsValid(value))
        {
            throw new ValidationException("Phone is not valid");
        }

        Value = value;
    }


    public string Value { get; private set; }


    private static bool IsValid(string value)
    {
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        const string region = "en";

        try
        {
            var parsedPhone = phoneNumberUtil.Parse(value, region);
            var isValidNumber = phoneNumberUtil.IsValidNumber(parsedPhone);
            return isValidNumber;
        }
        catch
        {
            return false;
        }
    }
}
