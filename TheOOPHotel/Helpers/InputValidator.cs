namespace TheOOPHotel.Helpers;

public static class InputValidator
{
    public static bool IsValidName(string? name)
    {
        return !string.IsNullOrWhiteSpace(name)
                && name.All(char.IsLetter);

    }

    public static bool IsValidEmail(string? email)
    {
        return !string.IsNullOrWhiteSpace(email)
                && email.Contains('@')
                && email.Contains('.');
    }

    public static bool IsValidPhoneNumber(string? phoneNumber)
    {
        return !string.IsNullOrWhiteSpace(phoneNumber)
                && phoneNumber.Length == 10
                && phoneNumber.All(char.IsDigit);
    }

    public static bool IsValidDate(string? input, out DateTime date)
    {
        return DateTime.TryParse(input, out date);
    }

    public static bool IsValidStartDate(DateTime startDate)
    {
        return startDate >= DateTime.Today;
    }

    public static bool IsValidLengthOfStay(string? input, out int lengthOfStay)
    {
        return int.TryParse(input, out lengthOfStay)
               && lengthOfStay > 0;
    }
}
