namespace TravelBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string  ApplicationUserId { get; set; }
        public int FlightId { get; set; }
        public DateTime BookingDate { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public Flight? Flight { get; set; }
    }
}
