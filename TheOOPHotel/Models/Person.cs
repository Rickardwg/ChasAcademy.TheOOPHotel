namespace TheOOPHotel.Models;

internal class Guest (string name, string email, string phoneNumber)
{
    internal string Name { get; set; } = name;
    internal string Email { get; set; } = email;
    internal string PhoneNumber { get; set; } = phoneNumber;
}
