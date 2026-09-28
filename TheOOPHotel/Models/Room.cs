namespace TheOOPHotel.Models;

public class Room(int number, RoomType type, decimal pricePerNight)
{
    internal int Number { get; init; } = number;
    internal RoomType Type { get; set; } = type;
    internal decimal PricePerNight { get; set; } = pricePerNight;
}
