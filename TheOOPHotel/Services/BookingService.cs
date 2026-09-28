using TheOOPHotel.Helpers;
using TheOOPHotel.Models;

namespace TheOOPHotel.Services;

internal class BookingService()
{
    private readonly List<Booking> _bookings = [];
    private readonly List<Room> _rooms = 
    [
        new Room(1, RoomType.Single, 400),
        new Room(2, RoomType.Single, 400),
        new Room(3, RoomType.Single, 400),
        new Room(4, RoomType.Double, 800),
        new Room(5, RoomType.Double, 800),
        new Room(6, RoomType.Double, 800),
        new Room(7, RoomType.Suite, 3000),
        new Room(8, RoomType.Suite, 3000),
        new Room(9, RoomType.Suite, 3000),
    ];

    internal void AddBooking(BookingInput input)
    {
        var booking = new Booking
        (
            GetNextBookingId(),
            input.Guests,
            input.Room,
            input.StartDate,
            input.LengthOfStay
        );

        _bookings.Add(booking);
    }

    internal void EditBooking(int bookingId, BookingInput input)
    {
        var booking = GetBooking(bookingId);

        booking!.Guests = input.Guests;
        booking.Room = input.Room;
        booking.StartDate = input.StartDate;
        booking.EndDate = booking.StartDate.AddDays(input.LengthOfStay);
    }

    internal bool RemoveBooking(int bookingId)
    {
        var booking = GetBooking(bookingId);

        if (booking is null) return false;

        _bookings.Remove(booking);

        return true;
    }

    internal List<Room> GetAvailableRooms(DateTime startDate, int lengthOfStay, Booking? bookingToExclude = null)
    {
        var endDate = startDate.AddDays(lengthOfStay);

        return [.. _rooms
            .Where(room => !_bookings.Any(booking =>
            booking != bookingToExclude &&
            room.Number == booking.Room.Number &&
            startDate < booking.EndDate &&
            endDate > booking.StartDate))];
    }

    private int GetNextBookingId()
    {
        var id = 1;

        while (_bookings.Any(booking => booking.Id == id))
        {
            id++;
        }

        return id;
    }

    internal Booking? GetBooking(int bookingId)
    {
        return _bookings.FirstOrDefault
        (
            booking => booking.Id == bookingId
        );
    }
}
