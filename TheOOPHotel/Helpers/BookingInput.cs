using TheOOPHotel.Models;

namespace TheOOPHotel.Helpers;

public record BookingInput
(
    List<Guest> Guests,
    Room Room,
    DateTime StartDate,
    int LengthOfStay
);
