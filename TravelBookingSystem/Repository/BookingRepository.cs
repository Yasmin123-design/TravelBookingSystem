using Microsoft.EntityFrameworkCore;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TravelSystemContext context;
        public BookingRepository(TravelSystemContext _context)
        {
            context = _context;
        }
        
        public void Book(int tripid , string  userid)
        {
            Booking booking = new Booking()
            {
                FlightId = tripid,
                ApplicationUserId = userid,
                BookingDate = DateTime.Now
            };
            context.Bookings.Add(booking);
            context.SaveChanges();
        }
        public Booking GetBooking(int tripid , string userid)
        {
            return context.Bookings.Where(x => x.FlightId == tripid && x.ApplicationUserId == userid).FirstOrDefault();
        }

        public List<Booking> MyBooking(string userid)
        {
            return context.Bookings.Where(x => x.ApplicationUserId == userid)
                .Include(x => x.ApplicationUser).Include(x => x.Flight).ToList();
        }
        public void Delete(int tripid,string userid)
        {
            Booking booking = GetBooking(tripid, userid);
            context.Bookings.Remove(booking);
            context.SaveChanges();
        }
    }
}
