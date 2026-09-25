using TheOOPHotel.Controllers;
using TheOOPHotel.Services;
using TheOOPHotel.Views;

var roomService = new RoomService();
var bookingService = new BookingService(roomService);
var bookingView = new BookingView();
var bookingController = new BookingController(bookingView, bookingService);

bookingController.Run();