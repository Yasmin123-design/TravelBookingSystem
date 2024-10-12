using TravelBookingSystem.Models;

namespace TravelBookingSystem.Repository
{
    public interface IBookingRepository
    {
        List<Booking> MyBooking(string userid);
        void Book(int tripid, string userid);
        Booking GetBooking(int tripid, string userid);
        void Delete(int tripid, string userid);
    }
}
