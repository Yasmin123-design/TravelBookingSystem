using TravelBookingSystem.Models;

namespace TravelBookingSystem.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly TravelSystemContext context;
        public FlightRepository(TravelSystemContext _context)
        {
            context = _context;
        }
        public Flight Details(int id)
        {
            return context.Flights.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Flight> GetAll()
        {
            return context.Flights.ToList();
        }

        public List<Flight> Search(string from, string to)
        {
            return context.Flights.Where( x => x.From == from && x.To == to ).ToList();
        }
    }
}
