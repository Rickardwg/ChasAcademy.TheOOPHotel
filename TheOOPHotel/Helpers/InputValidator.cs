namespace TheOOPHotel.Helpers;

public static class InputValidator
{
    private static int _phoneNumberLength = 10;

    // --- MAIN VALIDATION METHOD ---
    public static T GetValidInput<T>(Func<string?, (bool isValid, T value)> validateInput, string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            (var isValid, var value) = validateInput(input);

            if (isValid)
            {
                return value;
            }

            Console.WriteLine("Ogiltig inmatning, försök igen!");
            Console.WriteLine();
        }
    }

    // --- VALIDATION METHODS ---
    public static (bool isValid, string? value) ValidateName(string? input)
    {
        if (!string.IsNullOrWhiteSpace(input) && !input.All(char.IsLetter)) return (true, input.Trim());

        return (false, default);
    }

    public static (bool isValid, string? value) ValidateEmail(string? input)
    {
        if (!string.IsNullOrWhiteSpace(input) && input.Contains('@') && input.Contains('.')) return (true, input.Trim());

        return (false, default);
    }

    public static (bool isValid, string? value) ValidatePhoneNumber(string? input)
    {
        if (!string.IsNullOrWhiteSpace(input) && input.Length == _phoneNumberLength && input.All(char.IsDigit)) return (true, input);

        return (false, default);
    }

    public static (bool isValid, DateTime? value) ValidateStartDate(string? input)
    {
        if (DateTime.TryParse(input, out DateTime result) && result >= DateTime.Now.Date) return (true, result);

        return (false, default);
    }

    public static (bool isValid, int? value) ValidateLengthOfStay(string? input)
    {
        if (int.TryParse(input, out int result) && result > 0) return (true, result);

        return (false, default);
    }
}
