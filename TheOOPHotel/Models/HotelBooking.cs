namespace TheOOPHotel.Models;

internal class HotelBooking
{
    private const double _pricePerNight = 200;
    internal List<Guest> Guests {  get; set; }
    internal DateTime StartDate { get; set; }
    internal DateTime EndDate { get; set; }

    public HotelBooking(List<Guest> guests, DateTime startDate, int lengthOfStayInDays)
    {
        Guests = guests;
        StartDate = startDate;
        EndDate = startDate.AddDays(lengthOfStayInDays);
    }

    //internal void DisplayBookingInfo()
    //{
    //    Console.WriteLine($"Start Date: {StartDate.ToShortDateString()}"); // Hämtar ut start datumet 
    //    Console.WriteLine($"End Date: {EndDate.ToShortDateString()}"); // Hämtar ut slut datumet 
    //    foreach (var guest in Guests)
    //    {
    //        Console.WriteLine($"Guest Email: {guest.GuestEmail}");
    //        Console.WriteLine($"Guest Phonenumber: {guest.PhoneNumber}");
    //        Console.WriteLine($"Name: {guest.Name}"); // Slutligen hämtar ut informartion från guestname
    //    }
       

        


    //}

    //internal void UpdateBoking()
    //{
    //    Console.Write("Hur många extra dagar vill du stanna? ");
    //    int NewupDateBooking = int.Parse(Console.ReadLine());
        
    //    EndDate = StartDate.AddDays(NewupDateBooking); // hämtar och sätter ett värde


    //    Console.WriteLine($"UpdateBooking End Date: {EndDate.ToShortDateString()}");
    //}

    //internal void TotalPrice() 
    
    //{
    //    var span = EndDate.Subtract(StartDate);
    //    int days = span.Days;
    //    var totalPrice = days * PricePerNight;
    //    Console.WriteLine(totalPrice);

    
    //}
    



}
