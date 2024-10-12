using Microsoft.Identity.Client;

namespace TravelBookingSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime TravelDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }

    }
}
