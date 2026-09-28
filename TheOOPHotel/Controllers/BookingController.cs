using TheOOPHotel.Helpers;
using TheOOPHotel.Services;
using TheOOPHotel.Views;

namespace TheOOPHotel.Controllers;

internal class BookingController(BookingView bookingView, BookingService bookingService)
{
    private readonly BookingView _bookingView = bookingView;
    private readonly BookingService _bookingService = bookingService;

    internal void Run()
    {
        while (true)
        {
            var choice = _bookingView.DisplayMenu();

            switch (choice)
            {
                case 1:
                    AddBooking();
                    break;

                case 2:
                    EditBooking();
                    break;

                case 3:
                    RemoveBooking();
                    break;

                case 4:
                    return;
            }
        }
    }

    private void AddBooking()
    {
        var startDate = _bookingView.GetStartDate();
        var lengthOfStay = _bookingView.GetLengthOfStay();

        var availableRooms = _bookingService.GetAvailableRooms(startDate, lengthOfStay);

        if (availableRooms.Count == 0)
        {
            _bookingView.DisplayMessage("Det finns inga lediga rum tillgängliga för perioden.");
            return;
        }

        var room = _bookingView.GetRoomChoice(availableRooms);
        var guests = _bookingView.GetGuests();

        var bookingInput = new BookingInput
        (
            guests,
            room,
            startDate,
            lengthOfStay
        );

        _bookingService.AddBooking(bookingInput);

        _bookingView.DisplayMessage("Bokningen har skapats.");
    }

    private void EditBooking()
    {
        var bookingId = _bookingView.GetBookingId();
        var booking = _bookingService.GetBooking(bookingId);

        if (booking == null)
        {
            _bookingView.DisplayMessage($"Ingen bokning med ID: {bookingId} existerar.");
            return;
        }

        var startDate = booking.StartDate;
        var lengthOfStay = (booking.EndDate - booking.StartDate).Days;
        var room = booking.Room;
        var guests = booking.Guests;

        var changeDates = _bookingView.GetConfirmation("Vill du ändra datum?");

        if (changeDates)
        {
            startDate = _bookingView.GetStartDate();
            lengthOfStay = _bookingView.GetLengthOfStay();
        }

        var changeRoom = _bookingView.GetConfirmation("Vill du byta rum?");

        if (changeDates || changeRoom)
        {
            var availableRooms = _bookingService.GetAvailableRooms(booking.StartDate, lengthOfStay, booking);

            if (availableRooms.Count == 0)
            {
                _bookingView.DisplayMessage("Det finns inga lediga rum tillgängliga för perioden.");
                return;
            }

            var isCurrentRoomAvailable = availableRooms.Contains(room);

            if (changeRoom || !isCurrentRoomAvailable)
            {
                room = _bookingView.GetRoomChoice(availableRooms);
            }
        }

        var changeGuests = _bookingView.GetConfirmation("Vill du ändra gäster?");

        if (changeGuests)
        {
            booking.Guests = _bookingView.GetGuests();
        }

        var bookingInput = new BookingInput(guests, room, startDate, lengthOfStay);

        _bookingService.EditBooking(bookingId, bookingInput);

        _bookingView.DisplayMessage("Bokningen har ändrats.");
    }

    private void RemoveBooking()
    {
        var bookingId = _bookingView.GetBookingId();

        if (_bookingService.RemoveBooking(bookingId))
        {
            _bookingView.DisplayMessage("Bokningen har avbokats.");
        }
        else
        {
            _bookingView.DisplayMessage($"Ingen bokning med ID: {bookingId} existerar.");
        }
    }
}
