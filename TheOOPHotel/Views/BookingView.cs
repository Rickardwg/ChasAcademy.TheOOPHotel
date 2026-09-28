using TheOOPHotel.Helpers;
using TheOOPHotel.Models;

namespace TheOOPHotel.Views;

internal class BookingView
{

    internal int DisplayMenu()
    {
        Console.Clear();

        Console.WriteLine("THE OOP HOTEL");
        Console.WriteLine("[1] Boka");
        Console.WriteLine("[2] Ändra Bokning");
        Console.WriteLine("[3] Avboka");
        Console.WriteLine("[4] Avsluta");
        Console.Write("Välj ett alternativ: ");

        int.TryParse(Console.ReadLine(), out int choice);
        return choice;
    }

    internal List<Guest> GetGuests()
    {
        Console.Clear();

        Console.WriteLine("KONTAKTUPPGIFTER");

        var guests = new List<Guest>();

        do
        {
            guests.Add(GetGuest());
        } while (GetConfirmation("Vill du lägga till fler gäster?"));

        return guests;
    }

    private static Guest GetGuest()
    {
        var name = GetName();
        var email = GetEmail();
        var phoneNumber = GetPhoneNumber();

        return new Guest(name, email, phoneNumber);
    }

    private static string GetName()
    {
        while (true)
        {
            Console.Write("Namn: ");
            var name = Console.ReadLine();

            if (InputValidator.IsValidName(name)) return name!;

            Console.WriteLine("Ogiltigt namn. Försök igen.");
        }
    }

    private static string GetEmail()
    {
        while (true)
        {
            Console.Write("Epost: ");
            var email = Console.ReadLine();

            if (InputValidator.IsValidEmail(email)) return email!;

            Console.WriteLine("Ogiltig epost. Försök igen.");
        }
    }

    private static string GetPhoneNumber()
    {
        while (true)
        {
            Console.Write("Telefonnummer: ");
            var phoneNumber = Console.ReadLine();

            if (InputValidator.IsValidPhoneNumber(phoneNumber)) return phoneNumber!;

            Console.WriteLine("Ogiltigt telefonnummer. Skriv exakt 10 siffror.");
        }
    }

    internal DateTime GetStartDate()
    {
        while (true)
        {
            Console.Write("Startdatum: ");
            var input = Console.ReadLine();

            if (!InputValidator.IsValidDate(input, out DateTime startDate)) 
            {
                Console.WriteLine("Ogiltigt datum. Använd formatet ÅÅÅÅ-MM-DD.");
                continue;
            }

            if (!InputValidator.IsValidStartDate(startDate))
            {
                Console.WriteLine("Startdatum kan inte vara i det förflutna.");
                continue;
            }

            return startDate;
        }
    }

    internal int GetLengthOfStay()
    {
        while (true)
        {
            Console.Write("Antal dagar: ");
            var input = Console.ReadLine();

            if (InputValidator.IsValidLengthOfStay(input, out int lengthOfStay)) return lengthOfStay;

            Console.WriteLine("Ogiltig vistelselängd. Skriv ett positivt heltal.");
        }
    }

    internal int GetBookingId()
    {
        Console.Write("Bokningsnummer: ");
        int.TryParse(Console.ReadLine(), out int result);
        return result;
    }

    internal Room GetRoomChoice(List<Room> availableRooms)
    {
        for (int i = 0; i < availableRooms.Count; i++)
        {
            Console.WriteLine($"Rum {i+1}:");
            Console.WriteLine($"Typ: {availableRooms[i].Type}");
            Console.WriteLine($"Pris: {availableRooms[i].PricePerNight} kr per natt");
            Console.WriteLine();
        }

        while (true)
        {
            Console.Write("Välj ett alternativ: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int choice) 
                && choice >= 1 
                && choice <= availableRooms.Count)
            {
                return availableRooms[choice - 1];
            }

            Console.WriteLine("Ogiltigt alternativ. Försök igen.");
        }
    }

    internal void DisplayMessage(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }

    internal bool GetConfirmation(string message)
    {
        while (true)
        {
            Console.Write($"{message} (j/n): ");
            var input = Console.ReadLine()!;

            if (input.ToLowerInvariant() == "j") return true;

            if (input.ToLowerInvariant() == "n") return false;

            Console.WriteLine("Ogiltigt svar. Svara \"j\" eller \"n\"");
        }
    }
}
