using System;
using System.Collections.Generic;
using System.Linq;

public class BookingService
{
    private readonly List<Booking> _bookings = new();

    public bool IsAvailable(DateTime start, DateTime end)
    {
        return !_bookings.Any(b => start < b.End && end > b.Start);
    }

    public void AddBooking(DateTime start, DateTime end)
    {
        if (IsAvailable(start, end))
        {
            _bookings.Add(new Booking { Start = start, End = end });
        }
    }
}