using TheOOPHotel.Controllers;
using TheOOPHotel.Services;
using TheOOPHotel.Views;

var bookingService = new BookingService();
var bookingView = new BookingView();
var bookingController = new BookingController(bookingView, bookingService);

bookingController.Run();