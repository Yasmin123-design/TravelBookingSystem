using TravelBookingSystem.Models;

namespace TravelBookingSystem.Repository
{
    public interface IFlightRepository
    {
        List<Flight> GetAll();
        Flight Details(int id);
        List<Flight> Search(string from, string to);
    }
}
