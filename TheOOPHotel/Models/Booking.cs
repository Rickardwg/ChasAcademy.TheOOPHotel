namespace TheOOPHotel.Models;

public class Booking
{
    public int Id { get; set; }
    public List<Guest> Guests {  get; set; }
    public Room Room { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; } 

    public Booking(int id, List<Guest> guests, Room room, DateTime startDate, int lengthOfStayInDays)
    {
        Id = id;
        Guests = guests;
        Room = room;
        StartDate = startDate;
        EndDate = startDate.AddDays(lengthOfStayInDays);
        TotalPrice = Room.PricePerNight * lengthOfStayInDays;
    }
}
